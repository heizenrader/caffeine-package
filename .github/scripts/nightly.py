#!/usr/bin/env python3
"""Version and release-notes helper for .github/workflows/nightly.yml.

  plan    decide the nightly version from package.json and the two registry documents
  recent  count the commits made in the last N hours
  apply   write the nightly version into package.json and a section into CHANGELOG.md (workspace only, never committed)

The workflow runs this from the trusted workflow ref, never from the source line it builds.
"""
import argparse
import datetime
import json
import re
import subprocess
import sys

SEMVER = re.compile(r"^(\d+)\.(\d+)\.(\d+)(?:-[0-9A-Za-z.-]+)?(?:\+[0-9A-Za-z.-]+)?$")
NIGHTLY = re.compile(r"^\d+\.\d+\.\d+-nightly\.(\d{8})$")
SHA = re.compile(r"^[0-9a-f]{40}$")
MAX_SUBJECTS = 100


def base_of(version):
    """X.Y.Z of a package.json version (any prerelease or build part dropped)."""
    m = SEMVER.match(version or "")
    if not m:
        raise ValueError("package.json version %r is not semver" % (version,))
    return tuple(int(x) for x in m.groups())


def versions_of(doc, what):
    """The versions object of a registry document; an absent package is {}."""
    if doc is None:
        return {}
    if not isinstance(doc, dict) or not isinstance(doc.get("versions", {}), dict):
        raise ValueError("the %s document is not a package document" % what)
    return doc.get("versions", {})


def pick_base(base, stable_versions):
    """The base X.Y.Z, or the next patch (repeatedly) while that X.Y.Z is already a stable release."""
    major, minor, patch = base
    while "%d.%d.%d" % (major, minor, patch) in stable_versions:
        patch += 1
    return "%d.%d.%d" % (major, minor, patch)


def check_date(date):
    if not re.fullmatch(r"\d{8}", date or ""):
        raise ValueError("date %r is not YYYYMMDD" % (date,))
    datetime.datetime.strptime(date, "%Y%m%d")


def previous_nightly(nightly_versions):
    """(version, revision) of the newest nightly in the channel; revision is None when the document does not record one."""
    found = [(NIGHTLY.match(v).group(1), v) for v in nightly_versions if NIGHTLY.match(v)]
    if not found:
        return None, None
    version = max(found)[1]
    meta = nightly_versions[version]
    rev = meta.get("repository", {}).get("revision") if isinstance(meta, dict) and isinstance(meta.get("repository"), dict) else None
    return version, rev if isinstance(rev, str) and SHA.match(rev) else None


def plan(package_version, stable_doc, nightly_doc, date):
    check_date(date)
    base = pick_base(base_of(package_version), versions_of(stable_doc, "stable"))
    version = "%s-nightly.%s" % (base, date)
    nightly = versions_of(nightly_doc, "nightly")
    prev_version, prev_rev = previous_nightly(nightly)
    return {
        "BASE": base,
        "VERSION": version,
        "ALREADY_PUBLISHED": "true" if version in nightly else "false",
        "PREV_VERSION": prev_version or "",
        "PREV_REVISION": prev_rev or "",
    }


def git(repo, *args, check=True):
    return subprocess.run(["git", "-c", "safe.directory=*", "-C", repo, *args], capture_output=True, text=True, check=check)


def recent_count(repo, hours):
    out = git(repo, "log", "--since=%d hours ago" % hours, "--format=%H").stdout
    return len([l for l in out.splitlines() if l.strip()])


def subjects(repo, prev_revision):
    """(subjects, basis): the commit subjects since the previous nightly's commit, else the last 24 hours."""
    basis = "the last 24 hours"
    rng = None
    if prev_revision and SHA.match(prev_revision):
        have = git(repo, "cat-file", "-e", prev_revision + "^{commit}", check=False).returncode == 0
        if have and git(repo, "merge-base", "--is-ancestor", prev_revision, "HEAD", check=False).returncode == 0:
            rng = [prev_revision + "..HEAD"]
            basis = "the previous nightly (%s)" % prev_revision[:7]
    if rng is None:
        rng = ["--since=24 hours ago", "HEAD"]
    out = git(repo, "log", "--no-merges", "--format=%s", *rng).stdout
    subs = []
    for line in out.splitlines():
        line = "".join(c for c in line if c.isprintable()).strip()
        if line:
            subs.append(line[:200])
    return subs, basis


def section(version, date, subs, basis, head):
    iso = "%s-%s-%s" % (date[:4], date[4:6], date[6:])
    lines = ["## [%s] - %s" % (version, iso), "", "Nightly build of commit %s. Changes since %s:" % (head[:7], basis), ""]
    if subs:
        lines += ["- " + s for s in subs[:MAX_SUBJECTS]]
        if len(subs) > MAX_SUBJECTS:
            lines.append("- and %d more commits" % (len(subs) - MAX_SUBJECTS))
    else:
        lines.append("- No new commit subjects; rebuilt from the same source.")
    return "\n".join(lines) + "\n"


def insert_section(text, sec):
    """Put sec before the first released '## [x]' heading (after '## [Unreleased]'); at the end when there is none."""
    lines = text.replace("\r\n", "\n").split("\n")
    for i, line in enumerate(lines):
        if line.startswith("## [") and not line.startswith("## [Unreleased]"):
            return "\n".join(lines[:i] + sec.split("\n") + lines[i:])
    if not text.strip():
        return "# Changelog\n\n" + sec
    return text.rstrip("\n") + "\n\n" + sec


def apply(repo, version, date, prev_revision):
    check_date(date)
    pkg_path = repo + "/package.json"
    with open(pkg_path, encoding="utf-8") as f:
        pkg = json.load(f)
    head = git(repo, "rev-parse", "HEAD").stdout.strip()
    subs, basis = subjects(repo, prev_revision)
    sec = section(version, date, subs, basis, head)
    pkg["version"] = version
    # R6: _upm.changelog, when the package has one, must be headed with this version
    if isinstance(pkg.get("_upm"), dict) and "changelog" in pkg["_upm"]:
        pkg["_upm"]["changelog"] = sec.rstrip("\n")
    with open(pkg_path, "w", encoding="utf-8") as f:
        json.dump(pkg, f, indent=2, ensure_ascii=False)
        f.write("\n")
    try:
        with open(repo + "/CHANGELOG.md", encoding="utf-8") as f:
            old = f.read()
    except FileNotFoundError:
        old = ""
    with open(repo + "/CHANGELOG.md", "w", encoding="utf-8") as f:
        f.write(insert_section(old, sec))
    return sec


def load(path):
    """A registry document file; an empty file means the package is not in that channel."""
    with open(path, encoding="utf-8") as f:
        text = f.read()
    return json.loads(text) if text.strip() else None


def main(argv):
    ap = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    sub = ap.add_subparsers(dest="cmd", required=True)
    p = sub.add_parser("plan")
    p.add_argument("--package-json", required=True)
    p.add_argument("--stable", required=True, help="stable channel document file; empty when the package is not there")
    p.add_argument("--nightly", required=True, help="nightly channel document file; empty when the package is not there")
    p.add_argument("--date", required=True, help="UTC YYYYMMDD")
    r = sub.add_parser("recent")
    r.add_argument("--repo", default=".")
    r.add_argument("--hours", type=int, default=24)
    a = sub.add_parser("apply")
    a.add_argument("--repo", default=".")
    a.add_argument("--version", required=True)
    a.add_argument("--date", required=True)
    a.add_argument("--prev-revision", default="")
    args = ap.parse_args(argv)
    try:
        if args.cmd == "plan":
            with open(args.package_json, encoding="utf-8") as f:
                version = json.load(f).get("version")
            for k, v in plan(version, load(args.stable), load(args.nightly), args.date).items():
                print("%s=%s" % (k, v))
        elif args.cmd == "recent":
            print(recent_count(args.repo, args.hours))
        else:
            sys.stdout.write(apply(args.repo, args.version, args.date, args.prev_revision))
    except (ValueError, OSError, subprocess.CalledProcessError, json.JSONDecodeError) as e:
        print("error: %s" % e, file=sys.stderr)
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv[1:]))
