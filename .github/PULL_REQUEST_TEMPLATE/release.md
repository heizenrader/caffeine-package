# 📦 Package Release Checklist

> **This template is required for all releases to the `main`/`release` branch.**
> Every checkbox below must be checked before this PR can be approved and merged.
> The `validate-release-checklist` CI check will **block merging** until all items are ticked.

---

## 🔖 Release Summary

**Package name:** <!-- e.g. com.educationxr.core -->
**Version being released:** <!-- e.g. 1.4.2 -->
**Previous version:** <!-- e.g. 1.4.1 -->
**Release type:** <!-- patch | minor | major -->
**Target Unity version (minimum):** <!-- e.g. 2021.3 -->

---

## 1 · package.json — Version & Identity

- [ ] `version` field matches the intended release version exactly (semver: `MAJOR.MINOR.PATCH`)
- [ ] `version` has been **bumped from the previous release** (no duplicate version numbers)
- [ ] `name` uses reverse-domain notation with at least three segments (e.g. `com.company.package-name`) and has **not changed** unintentionally
- [ ] `displayName` is human-readable and up to date
- [ ] `description` accurately reflects what the package does in this release

---

## 2 · package.json — Unity Version Compatibility

- [ ] `unity` field specifies the **minimum supported Unity version** in `MAJOR.MINOR` format (e.g. `"2021.3"`) and is correct for this release
- [ ] `unityRelease` field (if present) is set to the correct patch/release suffix (e.g. `"0f1"`) — **delete the field entirely** if no specific patch is required
- [ ] Compatibility with the declared `unity` version has been **manually tested or confirmed** in CI
- [ ] Any APIs used that were **introduced after** the declared minimum Unity version have been noted in the changelog and/or guarded with `#if UNITY_XXXX` directives

---

## 3 · package.json — Dependencies

- [ ] All UPM package dependencies in `"dependencies": {}` are listed using their **exact reverse-domain package name** (e.g. `"com.unity.mathematics": "1.2.6"`)
- [ ] Dependency versions are **pinned to the minimum compatible version**, not a version that happens to be installed locally
- [ ] Any **new dependencies** added in this release are intentional and documented in the changelog
- [ ] Any **removed dependencies** are intentional and will not break existing consumers
- [ ] No npm-ecosystem-only fields that Unity ignores have accidentally replaced UPM dependency entries (e.g. `devDependencies`, `peerDependencies` are ignored by UPM — verify they are not being relied upon)
- [ ] `"unity.modules"` entries (e.g. `com.unity.modules.physics`) are listed if the package relies on built-in Unity modules

---

## 4 · package.json — Other Required Fields

- [ ] `"author"` block is present with `name` (and optionally `email`, `url`)
- [ ] `"license"` is set to the correct SPDX identifier (e.g. `"MIT"`) — **do not leave blank**
- [ ] `"repository"` block points to the correct Git URL
- [ ] `"keywords"` array is appropriate and not stale

---

## 5 · Changelog

- [ ] `CHANGELOG.md` has been updated for this release
- [ ] The new version header in `CHANGELOG.md` matches the `version` in `package.json` **exactly**
- [ ] The changelog entry is under the correct date
- [ ] The changelog entry includes entries under the correct sub-headings (`Added`, `Changed`, `Deprecated`, `Removed`, `Fixed`, `Security`) — following [Keep a Changelog](https://keepachangelog.com) format
- [ ] The changelog entry accurately describes **all** user-facing changes in this release (nothing important omitted)
- [ ] The `## [Unreleased]` section has been cleared / moved to the new version block
- [ ] No changelog notes from a **different** version have been accidentally included under this version's header

---

## 6 · Git Tag & GitHub Release

- [ ] The Git tag that will be created matches `package.json` `version` exactly (e.g. `v1.4.2` or `1.4.2` — be consistent with your convention)
- [ ] No existing published tag with this version number already exists on the registry (`npm view <package-name> versions` checked)
- [ ] The GitHub Release title and description match the changelog entry for this version

---

## 7 · .meta Files (Unity-Specific)

- [ ] Every **new file or folder** added in this PR has a corresponding `.meta` file committed alongside it
- [ ] No `.meta` files have been **accidentally deleted** for files that still exist
- [ ] The `package.json` itself has a `package.json.meta` file (required to avoid import errors in Unity)
- [ ] No `.meta` files reference GUIDs that were previously used by a different asset (GUID collisions)

---

## 8 · Assembly Definitions (.asmdef)

- [ ] New `.asmdef` files (if any) have a unique `name` that matches the file name
- [ ] `rootNamespace` in any `.asmdef` matches the actual namespace used in the scripts
- [ ] Editor-only code lives in an `Editor/` folder with an `.asmdef` that includes `"Editor"` in `includePlatforms` — it is **not** mixed into Runtime assemblies
- [ ] Test assemblies (`EditMode`/`PlayMode`) are **not** included in the package's release build (confirm `testables` is not leaking into the package manifest)
- [ ] Any `.asmdef` `references` to other packages use the correct assembly name, not the package name

---

## 9 · Package Folder Structure

- [ ] All runtime scripts are under `Runtime/`
- [ ] All editor scripts are under `Editor/`
- [ ] All tests are under `Tests/` (with `EditMode/` and `PlayMode/` sub-folders as appropriate)
- [ ] `Samples~/` (tilde suffix) is used for samples so they are **not auto-imported** by Unity (correct UPM convention)
- [ ] `Documentation~/` (tilde suffix) is used for docs if present
- [ ] No unwanted files are included: no `node_modules/`, no `.DS_Store`, no Unity `Temp/` or `Library/` folders, no test project `Assets/` or `ProjectSettings/`

---

## 10 · API & Breaking Changes

- [ ] If this is a **patch** release: no public API has been removed or changed in a breaking way
- [ ] If this is a **minor** release: only additive public API changes; no removals
- [ ] If this is a **major** release: breaking changes are fully documented in the changelog and a migration guide is provided (or linked)
- [ ] `[Obsolete]` attributes have been added (with a message) for any deprecated APIs before hard removal
- [ ] Namespace changes (if any) are called out explicitly in the changelog

---

## 11 · CI & Tests

- [ ] All automated CI checks are passing on this PR (unit tests, compile checks)
- [ ] The package has been **imported into a clean Unity project** at the declared minimum `unity` version and confirmed to compile without errors or warnings
- [ ] Any new public APIs have tests covering the main use-cases
- [ ] No test-only code or test fixtures have been included in the published package files

---

## 12 · Reviewer Sign-off

**Please tag at least one engineer who did not author this PR.**

- [ ] A second engineer has reviewed the `package.json` diff line-by-line
- [ ] A second engineer has reviewed the `CHANGELOG.md` diff
- [ ] The release has been communicated to any downstream teams / consumers if it contains breaking or significant changes

---

## Notes / Context for Reviewers

<!-- Anything else reviewers should know about this release goes here. -->
