# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.15] - 03.09.2026
### Fixed
- General Bug Fixes

## [1.1.14] - 03.05.2026
### Added
- Publish Notes. Add notes when publishing to describe what changed in each version.
- Version History & Rollback. Full publish history tracking with the ability to rollback courses to previous versions.
- Asset Caching. Course assets are now cached locally for faster loading and more reliable update detection.
- Platform "Select All" and "Deselect All" buttons in the publish UI.
### Changed
- Improved course validation to catch more issues before publishing.
- Creation forms auto-focus the name field and support Enter to submit.
- Unity window title now shows the current course version and editor info.
- Update banner is more compact and less intrusive.
- Course update and remote change dialogs have clearer, more consistent messaging.
- Significantly faster thumbnail loading with smarter caching and background updates.
### Fixed
- Fixed publish views not appearing on first publish in a new project.
- Fixed an edge case where publish settings could temporarily carry over when creating a course from a template.
- Resolved thumbnail images occasionally not refreshing after downloading a course update.
- Minor focus and display fixes in creation and publish windows.
- Improved socket connection stability.
- Resolved an issue with macOS archive extraction.

## [1.1.13] - 01.29.2026
### Fixed
- Fixed an issue that can sometimes cause failures in the builders while publishing.
- Fixed two assets that had import issues.
## [1.1.12] - 01.23.2026
### Fixed
- Fixed a rare issue when reordering graph variables can result in a broken graph.
## [1.1.11] - 01.15.2026
### Added
- URP Support. We introduced URP in beta form in 2025, with this release URP becomes an official supported workflow for creators. URP support comes with support for specific URP render features by allowing creators to overwrite the default URP asset and renderer.
- Save and Persistence System. We are for the first time introducing a cloud sync persistence and saving system for creators. It is fully configurable to support any of our Flow types in key value form, and creators can configure their desired functionality. From progress saves, to scoreboards, the uses are unlimited. These cloud saves are user owned and sync across devices automatically so you never have to worry where you access content from.
- Flow Event GameObject nodes.  Call events from any graph to any graph and carry a GameObject variable, extremely useful to create dynamic interaction systems.
- Flow Prefab support, lifecycle improvements.
- Nested Prefab support for Flow prefabs.
- UnityEvent Flow node.
- Graph Variable Sync On Start functionality. Graph variables now offer an option to sync on start so when users join a room they can “grab” the latest value for a graph variable from the host. This allows for synchronization of ongoing simulations in a seamless manner without the need to “program” it in Flow.
- Step Loaded Node now supports an option for “any step” which allows creators to start a flow at the beginning of any step.
- ForEach GameObject node. This allows to iterate through GameObject lists without having to worry about index looping in a more automated way.
- IsPlatform node. This node allows Flow creators to obtain a bool depending on the type of platform, whether that is mobile, VR or desktop, and utilize this to customize interaction systems and locomotion depending on the platform a user access from.
- Exit Course node. New node that allows to exit a course directly from within Flow graphs. This allows creators to control when a course is exited and the events that come with it such as analytics being sent to the backend.
- Equal objects and Gameobjects nodes. An equality node to compare Unity Objects or GameObjects.
- Mathf Clamp nodes.
- Flow Events can be raised from anywhere including UnityEvents, so you can connect UI events to Flow by using flow events.
- Split node. A node that allows you to visually split your flow in different branches. It does not provide parallel execution however as the branches will execute in order but it allows you to visually organize your graphs much better.
### Changed
- Updated EducationXR to Unity 6 LTS. With this release we mark full support for Unity 6 and all the features that come with it.
- Updated Pulse Physiology Engine to 4.3.1 version (implementing Editor Play mode support).
- Improved Dictation by providing a callback when timeouts occur, both with AI assistants as well as with Flow nodes.
- Updates to Lerp nodes for better rotation lerping.

## [1.1.10] - 01.15.2026
### Changed
- Migrating to a new package repository.

## [1.1.9] - 08.07.2025
### Fixed
- Fixed a minor bug that could occur with FLOW graphs during prefab unpacking.

## [1.1.8] - 08.07.2025
### Fixed
- Bug fixes.

## [1.1.7] - 07.10.2025
### Fixed
- Fixed a bug that could result in broken prefabs in certain situations.

## [1.1.6] - 07.09.2025
### Fixed
- FLOW Updates
-- Nested Prefab Support (Experimental) 
- Bug Fixes
- Performance and User Experience Optimizations
- URP Support (Experimental)

## [1.1.5] - 01.23.2025
### Fixed
- Bug Fixes

## [1.1.4] - 01.10.2025
### Added
- FLOW Features
- AI Assistant
### Fixed
- Bug Fixes
- Performance Improvements

## [1.1.3] - 07.12.2024
### Added
- VisionOS Build Support for Windows
- Added Option to Sign On from Another Device
- Added limited support for the use Unity Splines (More coming in a future version)
### Fixed
- Bug Fixes
- Performance Enhancements

## [1.1.2] - 06.06.2024
### Fixed
- Fixed an example shader error that affected Macs using Metal only.

## [1.1.1] - 06.06.2024
### Fixed
- Great news, we've updated to target Unity 2022.3.20f1. Updated todate to take advantage of all the new features.

## [1.1.0] - 05.18.2024
### Fixed
- Preparing for new major Unity release.

## [1.0.16] - 03.04.2024
### Fixed
- Fixed an issue that could break the builder process during auto-updates.

## [1.0.15] - 02.29.2024
### Fixed
- Fixed an issue that could sometimes prevent the automatic updates from working properly on Mac operating systems.

## [1.0.14] - 02.21.2024
### Fixed
- Fixed an issue that could sometimes cause issues with node connections while loading older versions of FLOW graphs.

## [1.0.13] - 02.20.2024
### Changed
- Cleaned up some pesky console messages.

## [1.0.12] - 02.20.2024
### Fixed
- Fixed a compatibility issue with versions of unity lower than the recommended version.

## [1.0.11] - 02.20.2024
### Added
- Automatic detection of package updates becoming available.

## [1.0.10] - 02.13.2024
### Fixed
- We corrected an issue that prevented some users from being able to create new courses.

## [1.0.9] - 01.02.2024
### Fixed
- Well, this is embarassing. Fixed another error with the builder system.

## [1.0.8] - 01.02.2024
### Fixed
- Fixed an error with the builder system.
### Added
- Meta file for changelog to silence unity warning.

## [1.0.7] - 01.02.2024
### Fixed
- Builder issues with dark scenes in VR should now be fixed.
### Added
- New settings options for adjusting advanced builder settings.
### Changed
- **[Breaking]** In the future Unity version 2021.3.32f1 will be required.
### Removed
- Redundant legacy step window.
