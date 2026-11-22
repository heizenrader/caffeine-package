"""Cases for nightly.py. Run: python3 -I -m unittest discover -s .github/scripts -p 'test_*.py' -v"""
import json
import os
import re
import subprocess
import tempfile
import unittest

import nightly

REV = "a" * 40


def doc(*versions, revisions=None):
    revisions = revisions or {}
    return {"versions": {v: ({"repository": {"revision": revisions[v]}} if v in revisions else {}) for v in versions}}


class PlanTests(unittest.TestCase):
    def plan(self, ver, stable=None, nightly_doc=None, date="20261121"):
        return nightly_plan(ver, stable, nightly_doc, date)

    def test_base_unreleased_is_kept(self):
        self.assertEqual(self.plan("3.2.7", doc("3.2.6"))["VERSION"], "3.2.7-nightly.20261121")

    def test_base_already_released_uses_next_patch(self):
        self.assertEqual(self.plan("3.2.7", doc("3.2.6", "3.2.7"))["VERSION"], "3.2.8-nightly.20261121")

    def test_next_patch_also_released_keeps_going(self):
        self.assertEqual(self.plan("1.1.5", doc("1.1.5", "1.1.6"))["BASE"], "1.1.7")

    def test_package_not_in_stable_channel(self):
        self.assertEqual(self.plan("1.1.5", None)["BASE"], "1.1.5")

    def test_prerelease_in_package_json_is_dropped(self):
        self.assertEqual(self.plan("2.0.0-rc.1", doc("1.9.0"))["VERSION"], "2.0.0-nightly.20261121")

    def test_nightly_never_sorts_below_a_shipped_release(self):
        # 1.1.5 shipped, so the nightly is 1.1.6-nightly, which sorts above 1.1.5
        self.assertEqual(self.plan("1.1.5", doc("1.1.5"))["VERSION"], "1.1.6-nightly.20261121")

    def test_already_published_same_day(self):
        r = self.plan("3.2.7", doc("3.2.6"), doc("3.2.7-nightly.20261121"))
        self.assertEqual(r["ALREADY_PUBLISHED"], "true")

    def test_not_published_when_other_day(self):
        r = self.plan("3.2.7", doc("3.2.6"), doc("3.2.7-nightly.20261120"))
        self.assertEqual(r["ALREADY_PUBLISHED"], "false")

    def test_previous_nightly_revision_is_the_newest(self):
        r = self.plan("3.2.7", doc("3.2.6"), doc("3.2.7-nightly.20261119", "3.2.7-nightly.20261120", revisions={"3.2.7-nightly.20261119": "b" * 40, "3.2.7-nightly.20261120": REV}))
        self.assertEqual((r["PREV_VERSION"], r["PREV_REVISION"]), ("3.2.7-nightly.20261120", REV))

    def test_previous_nightly_without_revision(self):
        r = self.plan("3.2.7", doc("3.2.6"), doc("3.2.7-nightly.20261120"))
        self.assertEqual(r["PREV_REVISION"], "")

    def test_no_previous_nightly(self):
        self.assertEqual(self.plan("3.2.7", doc("3.2.6"), None)["PREV_VERSION"], "")

    def test_garbage_inputs_fail(self):
        for args in [("v3", None, None, "20261121"), ("3.2.7", None, None, "2026-11-21"), ("3.2.7", None, None, "20261399"), ("3.2.7", [], None, "20261121"), ("3.2.7", None, {"versions": []}, "20261121")]:
            with self.assertRaises(ValueError, msg=str(args)):
                nightly_plan(*args)


def nightly_plan(ver, stable, nightly_doc, date):
    return nightly.plan(ver, stable, nightly_doc, date)


class InsertTests(unittest.TestCase):
    def test_after_unreleased(self):
        out = nightly.insert_section("# Changelog\n\n## [Unreleased]\n\n## [3.2.7] - x\n\nold\n", "## [3.2.8-nightly.20261121] - 2026-11-21\n\n- a\n")
        self.assertLess(out.index("[Unreleased]"), out.index("[3.2.8-nightly"))
        self.assertLess(out.index("[3.2.8-nightly"), out.index("[3.2.7]"))

    def test_no_released_section_appends(self):
        self.assertIn("## [1.0.0-nightly.20261121]", nightly.insert_section("# Changelog\n", "## [1.0.0-nightly.20261121] - d\n\n- a\n"))

    def test_empty_file(self):
        self.assertTrue(nightly.insert_section("", "## [1.0.0-nightly.20261121] - d\n").startswith("# Changelog"))


class GitTests(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.dir = self.tmp.name
        self.env = dict(os.environ, GIT_AUTHOR_NAME="t", GIT_AUTHOR_EMAIL="t@t", GIT_COMMITTER_NAME="t", GIT_COMMITTER_EMAIL="t@t")
        self.g("init", "-q")
        with open(self.dir + "/package.json", "w") as f:
            json.dump({"name": "com.x", "version": "3.2.7", "_upm": {"changelog": "## [3.2.7] - old\n\n- old"}}, f)
        with open(self.dir + "/CHANGELOG.md", "w") as f:
            f.write("# Changelog\n\n## [Unreleased]\n\n## [3.2.7] - 2026-11-15\n\n- old\n")

    def read(self, p):
        with open(self.dir + p) as f:
            return f.read()

    def pkg(self):
        return json.loads(self.read("/package.json"))

    def tearDown(self):
        self.tmp.cleanup()

    def g(self, *a, date=None):
        env = dict(self.env)
        if date:
            env["GIT_COMMITTER_DATE"] = env["GIT_AUTHOR_DATE"] = date
        return subprocess.run(["git", "-C", self.dir, *a], env=env, capture_output=True, text=True, check=True).stdout.strip()

    def commit(self, msg, date=None):
        self.g("commit", "-q", "--allow-empty", "-m", msg, date=date)
        return self.g("rev-parse", "HEAD")

    def test_recent_skips_when_nothing_in_24h(self):
        self.g("add", "."); self.commit("old work", date="2020-01-01T00:00:00Z")
        self.assertEqual(nightly.recent_count(self.dir, 24), 0)

    def test_recent_counts_new_commits(self):
        self.g("add", "."); self.commit("old work", date="2020-01-01T00:00:00Z")
        self.commit("new one"); self.commit("new two")
        self.assertEqual(nightly.recent_count(self.dir, 24), 2)

    def test_notes_since_previous_nightly_commit(self):
        self.g("add", "."); self.commit("before"); prev = self.commit("the previous nightly's commit")
        self.commit("fix a"); self.commit("feat b")
        sec = nightly.apply(self.dir, "3.2.8-nightly.20261121", "20261121", prev)
        self.assertIn("- fix a", sec); self.assertIn("- feat b", sec)
        self.assertNotIn("before", sec); self.assertNotIn("previous nightly's", sec)

    def test_notes_fall_back_to_24h_when_revision_unknown(self):
        self.g("add", "."); self.commit("ancient", date="2020-01-01T00:00:00Z"); self.commit("today")
        sec = nightly.apply(self.dir, "3.2.8-nightly.20261121", "20261121", "f" * 40)
        self.assertIn("- today", sec); self.assertNotIn("ancient", sec)

    def test_notes_fall_back_to_24h_without_revision(self):
        self.g("add", "."); self.commit("ancient", date="2020-01-01T00:00:00Z"); self.commit("today")
        self.assertNotIn("ancient", nightly.apply(self.dir, "3.2.8-nightly.20261121", "20261121", ""))

    def test_applied_files_satisfy_r5_r6(self):
        v = "3.2.8-nightly.20261121"
        self.g("add", "."); self.commit("x"); self.commit("y")
        nightly.apply(self.dir, v, "20261121", "")
        pkg = self.pkg()
        self.assertEqual(pkg["version"], v)
        # R6: _upm.changelog's first heading names this version
        self.assertEqual(re.match(r"^## \[([^\]]*)\]", pkg["_upm"]["changelog"]).group(1), v)
        # R5: CHANGELOG.md has "## [v]" (optionally " - date") with text under it
        text = self.read("/CHANGELOG.md")
        m = re.search(r"^## \[%s\]( - [^\n]*)?\n(.*?)(?=^## |\Z)" % re.escape(v), text, re.M | re.S)
        self.assertTrue(m and m.group(2).strip())

    def test_package_without_upm_is_left_without_one(self):
        with open(self.dir + "/package.json", "w") as f:
            json.dump({"name": "com.x", "version": "3.2.7"}, f)
        self.g("add", "."); self.commit("x")
        nightly.apply(self.dir, "3.2.8-nightly.20261121", "20261121", "")
        self.assertNotIn("_upm", self.pkg())

    def test_subjects_are_sanitised_and_capped(self):
        self.g("add", "."); self.commit("a\x1b[31mred" + "z" * 300)
        subs, _ = nightly.subjects(self.dir, "")
        self.assertEqual(len(subs), 1); self.assertLessEqual(len(subs[0]), 200); self.assertNotIn("\x1b", subs[0])


if __name__ == "__main__":
    unittest.main()
