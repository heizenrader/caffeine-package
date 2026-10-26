# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.24-rc.7] - 10.26.2026

### New
- **Mesh Optimizer tools.** With Unity's Asset Transformer / Pixyz toolkit (`com.unity.industry.toolkit` 3.3.0 or newer) installed, Caffeine > Tools > Mesh Optimizer opens: optimize selected models (Fine, Medium or Hard), import a model already optimized, and the Course Readiness wizard, which takes an imported CAD model to course-ready one skippable step at a time. Caffeine turns the tools on when the toolkit is installed and off when it is removed (it adds or removes `CAFFEINE_ASSET_TRANSFORMER` in the active platform's Scripting Define Symbols, then scripts recompile once). Projects without the toolkit see no change.
- **Course links can ask where a course is.** `LaunchCheckGetRequest` asks the content service whether the signed-in user can open a course, and when they can, whether the app should first switch to the course's organization. The EducationXR apps use it for course links. A failed check only means the app keeps its own message.

### Improved
- **Publishing works on Intel Macs.** 1.1.24-rc.6 shipped only the Apple Silicon build of the publish supervisor, so on an Intel Mac every platform failed right away with "Publish supervisor exited before reporting all platforms". The package now includes an Intel build too, and Caffeine picks the one that runs on your Mac (Apple Silicon runs its own build even when Unity runs under Rosetta). If the right build is missing, Publish says which folder it needs instead of starting.
- **When the publish supervisor stops early, the console says why.** The error now includes the supervisor's exit code and the end of its own log (`supervisor.log` in the publish's folder under `Library/CaffeineSupervisor`). If there is no log, it says the supervisor never started.
- **Builders use Caffeine itself when the AI Harness or MCP package is installed.** Those packages' folders sort ahead of Caffeine's, so a new builder could be linked to one of them instead (it then had no builder code), and the Caffeine version in published courses, asset metadata, transfer logs and the update check could be read from the wrong package. Caffeine now finds `com.caffeine` by its exact name, and a builder linked to the wrong package is linked again.
- **Single sign-on lookup accepts a full email.** A sign-in connection limited to test addresses can only be found by the full email; the lookup now sends the email intact (including `@`, `+` and `.`).

## [1.1.24-rc.4] - 10.23.2026

### Improved
- **No "NormalMap settings" window when the Material Optimizer converts a glTF model.** A normal map inside a .glb or .gltf can't be marked as a normal map, so converting such a model's materials to Graphics Tools opened Unity's "NormalMap settings" window, and Fix now changed nothing. The converters now write the model's normal maps once to a Textures folder next to it, imported as normal maps (the same files Extract Textures from glTF writes, which it then reuses), and the converted materials use those files. Extract Textures from glTF also reuses an image it wrote earlier under a numbered name ("name 1.png") instead of writing another copy.
- **The Course Validator's prefab warnings are about your course's prefabs only.** "Prefab References" warnings (graphs with baked runtime state, graphs on prefab variants) used to list every such prefab in the project, so publishing one course asked you to accept warnings about prefabs only other courses use, and fixing them would have changed those courses. They now come up only for prefabs the course ships (from its scene, its Additional Assets, or the Resources folders when Include Resources is on). Each one says what in the course uses the prefab (an object in the scene, a Flow graph or the Publish Settings) and which other scenes in the project use it too, since a fix changes it for them as well.
- **No "Remote changes detected" after your own publish.** A publish started by an AI assistant uploads the cloud backup long before the builds finish, and the editor only noted it at the very end: clicking back into Unity meanwhile showed the dialog for your own new version. The backup is now noted as soon as it lands, and the check never asks about a course this editor is publishing.
- **The apps tell EducationXR about the error popups they show.** A sign-in that expired (error 1001), a request the server refused or an answer that could not be read used to reach us only when the server itself failed; now the app sends one short report to the content service (the error's code, title and text, the scene it was in and the id of the request that failed; no sign-in token and nothing you typed), so we hear about it and can fix the cause. The same error in the same place is sent once a minute, ten at most each launch, never when you are offline, and it never shows you anything or slows the app down. Hosts that do not want it set `ClientErrorReporter.Enabled = false`.

## [1.1.24-rc.2] - 10.21.2026

### New
- **AI assistants can create and publish courses.** With "Agents may create and publish courses" (Edit > Project Settings > EducationXR > AI Agents — on by default, saved for you only; untick it to turn assistants off), an AI assistant connected to the editor can create a course in your organization and publish it to production. It asks you which platforms first and waits for your yes, and it never signs in, switches organization or cancels a publish it did not start. While an assistant's publish prepares, entering play mode is refused without a dialog.
- **Graphics Tools materials from PBR texture sets.** AI assistants can turn a texture set from Poly Haven or ambientCG (base color, normal, metallic, roughness, ambient occlusion, emission) into a ready Graphics Tools material, with its channel map packed the same way the Material Optimizer packs it and each texture's import settings set for its role.
- **Send xAPI Statement node.** Report what learners do inside a course to your LMS's learning record store: pick a verb such as *answered* or *attempted*, name the activity, and optionally add a score, a success value and the learner's response. It sends only in launches from an LMS that has a learning record store, does nothing anywhere else, and never stops your flow. Find it under Flow > Actions > LMS. Learners need an EducationXR app version that includes the node; on an older app the course stops at it.
- **Course Validator caution for textures inside glTF models.** glTF and GLB models keep their embedded images uncompressed at full size in every platform's bundle (one course went from 232 MB to 56 MB once its textures were separate files). The validator now names each model whose embedded textures the course uses, with the estimated extra size, and its Fix extracts the textures to files next to the model and points the course's converted materials at them.

### Improved
- **Substring of an empty string gives an empty string.** The Substring node stopped the graph with a divide-by-zero error when its input was empty (for example a text not set yet), so everything after it in that chain didn't run. It now returns an empty string.
- **Flow Delay and timers keep running after a model fails to import.** When glTFast failed to import a model (for example a .glb whose rigged character has one mesh with several materials), it left the editor's async work stopped: in play mode every Delay and Timed Kick waited forever, publishing could stall, and nothing was logged until the editor restarted. The editor now puts it right after the import, with one console warning. A Delay that was already waiting at that moment stays stopped: enter play mode again.
- **The Material Optimizer no longer piles up questions while an AI assistant works.** With Material Optimization set to Ask, materials an assistant adds (during its tool calls and for 5 seconds after its last one; with the AI tools reached through the Unity CLI, the Unity AI Assistant or MCP for Unity, up to 2 minutes after their last call) are left as they are instead of opening a dialog nobody answers; one console line names them and says how to convert them. Materials you add yourself outside that time are asked about as before, GameObject > Optimize Materials... always asks, and Always / Never are unchanged.
- **Models exported as .gltf with separate files ship complete.** A .gltf keeps its geometry (.bin) and often its images in files beside it that Unity doesn't count as dependencies, so the scene package left them out and the course's models came out empty on devices. The package now carries every file a .gltf names. (A single .glb has none of this.)
- **Empty Material Optimizer windows close themselves.** A question window open during a script reload used to come back empty (no message, no buttons) and stay open; it now closes itself after the reload.
- **Coloured glows survive the Material Optimizer.** Converting glTF, Standard, URP Lit and URP Simple Lit materials to Graphics Tools now keeps an emission texture's colours (it goes on the Emissive Map, times the emission colour), so screens, flames and sky domes no longer glow in a single colour. Grey emission textures look the same as before. Materials converted earlier are unchanged: delete the converted copy and optimize again. Graphics Tools materials made from PBR texture sets do the same.
- **Extract Textures from glTF** imports each image for its role (normal maps as normal maps, metallic-roughness and occlusion maps linear), writes one file per image, reuses the files an earlier extraction wrote, leaves KTX2 / WebP images inside the model and no longer refreshes the whole project.
- **Objects on a layer this project doesn't name** (created, pasted or dragged in) still move to Default, but the scene is now only marked dirty, no longer saved together with your other unsaved edits. The move can be undone, prefab instances keep it, and one console warning lists the objects and their old layer.
- **Restore in "Course Assets Missing"** saves only the assets it restored and marks the scene dirty for you to save. It no longer saves every unsaved asset and the whole scene.
- **Publish settings made when a course scene opens** only mark the scene dirty. If you close without saving, the next open finds the same asset again instead of making a numbered copy.
- **One Quaternion Angle node.** The duplicate "Flow/Math/Quaternion Angle" no longer appears in the node menu. Use "Quaternion Angle (a, b)" under Flow > Actions > Quaternion, which also uses the values typed on the node. Graphs that already use the old node keep loading and running.
- **Extract Textures from glTF** (Assets menu) saves only the materials it rebinds, no longer every unsaved asset in the project.
- **NodeSettings create paths** (Instance, GetOrCreateSettings, the CachedScriptable menu item) save only their own asset.
- **Opening a course scene and every script reload no longer save the project's unsaved assets.** The pipeline step writes nothing when the project already matches the course, and on a real change saves only the graphics and quality settings; the publish page checks, the publish-settings creation and the settings singletons save only their own asset.
- **Graphics Tools materials can be updated in place from PBR maps** (`GraphicsToolsMaterialFactory.Apply`): same asset, so parts and step caches keep it; maps not given keep the material's own values.
- **The Material Optimizer** now also moves a swapped object's cached step materials and highlight copies onto the optimized material, so step loads no longer put the unoptimized material back; the swap is undoable.
- **Material converters save only what they write** (never every unsaved asset in the project).
- **Extracting embedded materials** (Course Validator fix, Material Optimizer) now also rebinds the open scenes' other renderers and every step's cached materials, so parts no longer turn magenta on a step load.
- **Course Validator issues name their object and their check**, so assistants can find and fix them. The Camera and EventSystem fixes remove the components that depend on them first, and the legacy step-panel caution can be ignored.
- **The shader variant caution only lists shaders the course uses**: shaders in the course scene (saved or not, materials made in the scene included), its Additional Assets and, with Include Resources, the Resources folders. Other content in the project no longer adds cautions to every course. A caution you ignored for a shader the course doesn't use now stays ignored while the shader is in the project, so it still holds if the course uses the shader again.
- **Publishing ships what you see.** A publish packs the course's files from disk; an asset you changed and had not saved yet (a material edited in the Inspector or by an assistant) used to ship as it was on disk. The files that go into the package are saved first, and only those.
- **Restore in "Course Assets Missing" holds.** When the course scene had no unsaved changes, the restore now saves it, so closing without saving no longer drops the restored links (a second Restore then replaced the first one's assets and their settings). A scene with unsaved changes is only marked for you to save, as before.
- **Publishing an "embedded" .gltf no longer stalls** while the package's file list is made (its embedded data was copied in full before being skipped).
- **The publish thumbnail keeps your unsaved step edits.** Making the step editor for it reloaded the first step without saving the open one; the open step is now saved first and opened again after.

## [1.1.23] - 09.10.2026
Package dependency update.

### New
- **com.unity.vectorgraphics -** Added support for SVGImage & SVG Sprite Editor

## [1.1.22] - 08.05.2026

Flow sub-graphs arrive, alongside big-graph navigation tools, faster editing on large courses, safer importing, and a major wave of reliability fixes.

### New
- **Flow sub-graphs.** Collapse any part of a graph into a single tile you can step inside: wrap a selection with Ctrl+Shift+G, double-click the tile to enter its own canvas with a breadcrumb trail to climb back out, and wire through its labeled pins, which you can rename or expose. Existing and published courses open exactly as before.
- **Cut, jump-to-connection, and long-distance wiring in Flow.** Cut and paste nodes without losing a single wire, jump straight to a wire's other end from any port, and connect distant ports without scrolling across the canvas. A new preference can display very long wires as small labeled stubs that expand on hover, so huge graphs stay readable.
- **Flow Search window.** Drag any variable, event, or scene object into the new Flow Search window (Caffeine > Windows) to see every place it is used across your graphs, grouped and clickable, including results inside prefabs and sub-graphs.
- **Go To Step node.** Jump learners to any step of the course straight from a graph, with navigation that keeps working even after you reorder your steps.
- **New Flow node families, Caffeine+ templates, and AI Bot conversation nodes.** Work with collider properties and types, manage lists of components, and stop a repeating Timed Kick right from the graph. Ready-to-edit templates jump-start custom Caffeine+ nodes, and AI Bot Conversation nodes are now available, applying your bot's prompt, model, and reference documents.
- **AR authoring tools.** Toggle AR Occlusion per step so real-world geometry can hide virtual content, control AR mode directly from Flow nodes, and preview AR in the scene view near-instantly.
- **Safer course importing and an expanded Course Validator.** Choose per file whether to keep your project's version or the incoming one when an import conflicts, with identical files skipped automatically and your project's core text assets protected. The Course Validator now catches nine more issues, from missing fonts and broken materials to Flow group problems, most with a one-click fix.
- **Material Optimizer support for URP and glTF.** Optimize URP Lit, URP Simple Lit, and glTF materials, not just Standard materials as before, and extract embedded textures from GLB and glTF models to control their compression and resolution yourself.

### Improved
- **Massively improved Flow graph performance.** Navigating big graphs is now smooth, with panning, zooming, and editing staying responsive even at hundreds of nodes.
- **Faster step editing on large courses.** Step changes that took over a second are now near-instant, and the up-to-ten-second hang on your first save each session is gone.
- **Publishing and course management polish.** Build failure messages stay specific instead of a generic notice, disabled platforms can no longer sneak into a publish, publish notes and settings save instantly with no typing lag, and uninstalling a course preserves shared assets and cleans up after itself.

### Fixed
- **Flow graph integrity when copying and spawning.** Duplicating, spawning, or copying an object that carries a Flow graph now keeps each copy's graph correctly isolated from the original, including nested groups and prefab overrides. A new Fix Polluted Prefab References tool and a matching Validator check repair any prefabs affected earlier, and previously published courses are unaffected.
- **Undo now works everywhere in the Flow editor.** Disconnecting or re-routing a wire, renaming a node, and deleting a sub-graph tile with its contents are all fully undoable, and a rare case where undo could permanently remove a node from the graph is fixed.
- **Pink materials and duplicate settings files.** Imported FBX and OBJ models in URP projects no longer render pink, and already-affected projects self-heal when you open the course scene. Multiple URP courses coexist in one project without conflicts, duplicate publish-settings files no longer pile up over time, and a missing course asset shows one clear recovery dialog instead of stacked prompts.
- **Flow node behavior corrections.** Physics Raycast reports the object actually hit, Translate honors a direction typed into the inspector, port connections on about two dozen nodes work again with inline values restored, and every wire on a port is reachable from its right-click menu, even when connections share a name.
- **Caffeine+ publishing and testing.** Custom scripts enabled through Include All Scripts now publish correctly with your course, and testing with Build and Run no longer crashes on startup. New Caffeine+ courses exclude extra assets and scripts from publishing by default, so enable them in the course's publish settings when you need them; existing courses keep their settings.

## [1.1.21] - 05.20.2026

A major Flow Editor refresh: color-code your groups, hide and rename them in one click, and navigate huge courses smoothly with new LOD rendering.

### New
- **Group colors in the Flow Editor.** You can now assign a color to any group, making it easy to organize and navigate complex courses at a glance.
- **Hide and rename groups with one click.** A new eye icon on each group collapses it instantly, and collapsed groups now show a pencil icon so you can rename them without expanding first.
- **LOD rendering for large graphs.** When you zoom out, nodes simplify to clean color blocks so panning and navigating big courses stays smooth. A new "LOD (Performance)" section in Preferences lets you tune the zoom threshold and toggle name labels.
- **Course Validator catches two more setup issues:** a missing starting point and objects with conflicting IDs, each with a one-click fix.

### Improved
- **Smoother interaction inside groups.** Drag-selecting now works from inside an open group, and clicking eye buttons or the Course Events panel no longer accidentally selects a group behind them. Open groups appear at lighter opacity so the nodes inside stand out.
- **Validator collider check is now a warning,** so a label whose target lacks a collider no longer blocks publishing.
- **Landscape and Joystick course settings** are now included in your published course's metadata.

### Fixed
- **Unpacking a prefab preserves all flow graph connections,** including in prefabs that contain text components.
- **Several Flow Editor behaviors work correctly:** resizing a collapsed group, the show/hide eye buttons at high zoom, and duplicating a collapsed group.

## [1.1.20] - 04.16.2026

Publishing and importing are noticeably more reliable on slow and unstable connections, with clearer progress feedback throughout.

### Improved
- **Uploads complete reliably on slow and cellular connections**, even under heavy congestion.

## [1.1.19] - 04.14.2026

A new Course Validator, smoother transfers, and a much better create-from-template experience.

### New
- **Course Validator.** Catch missing references, misconfigured scenes, and setup issues in your course before you publish. Click any issue to jump to it, or use Fix All to resolve common problems automatically.

### Improved
- **Faster, smoother uploads** with more accurate progress and timing.
- **Creating a course from a template** now shows live progress, closes cleanly when finished, and no longer shows a spurious "Remote changes detected" warning on first open.
- **Scrolling inside text fields** now behaves naturally instead of hijacking the surrounding graph or page.

### Fixed
- Environment lighting renders correctly on Graphic Tools materials in URP projects.
- Uploads now automatically recover from transient storage issues, and canceled or failed uploads clear themselves from the admin panel automatically.

## [1.1.18] - 04.10.2026

Faster downloads, a live import window, and a more reliable publishing experience.

### New
- **Import progress window.** Watch your course import in real time with live status updates and clear stage labels.
- **Dirty scene protection.** You are prompted to save, cancel, or continue if you have unsaved changes before publishing.
- **Network auto-pause and resume.** Downloads pause automatically if your connection drops and pick up where they left off when you reconnect.
- **Environment indicator.** The title bar now shows which environment you are connected to at a glance.
- **Resizable text areas.** Description fields in the publish view can now be resized to fit longer content.
- **Download integrity checks.** Every downloaded file is verified automatically so corrupted transfers are caught before import.

### Improved
- **Downloads are 2-3x faster,** reaching 70-80 MBps on supported connections.
- **Course re-imports take seconds instead of minutes** when most of your content has not changed.
- **Course thumbnails** load noticeably faster.
- **More reliable publish view.** Platform settings update immediately when changed, broken builders are detected with a repair option, and platform toggles stay the way you set them.

### Fixed
- Canceling an import no longer removes a course that was already installed.
- Downloads and imports now complete normally when the Unity editor is in the background or in Play mode.
- Lighting renders correctly in Built-In pipeline projects.

## [1.1.17] - 03.19.2026
### Added
- GLTFast support.

## [1.1.16] - 03.11.2026
### Fixed
- Fixed a bug that could result in a partially failed publish.

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
