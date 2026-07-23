# Flow Node Documentation Progress

Tracks every node in the Caffeine Flow source against its documentation status. **Update this file** after completing a batch of docs (mark items done) and after pulling new Caffeine source (re-run the scan in [Refreshing the baseline](#refreshing-the-baseline) and add new pending entries).

This file lives at `Documentation/PROGRESS.md` and **does not ship to edxr-docs** — it stays in the staging folder. Only `Documentation/Nodes/` gets copied across.

**Last scan:** 2026-06-25
**Total source nodes:** ~499 unique creator-facing menu paths (`[CreateNodeMenu("Flow/...")]` with non-empty path)
**Last bulk-author session:** 2026-05-08 — **completed all categories**. Final push added 10 component codegen overviews (Animator ~85, AudioSource 7, Camera 26, Collider 2, Light 3, ParticleSystem 20, Renderer 1, Rigidbody 32, Transform 31, VideoPlayer 5) + 3 misc Lists nodes. ~190 nodes covered in this final push, ~210+ docs total this session.

**Incremental — 2026-07-10:** documented **Go To Step** (`Course/go-to-step.md`, per-page) — new `EdXR_GoToStepNode` (`Flow/Actions/Go To Step`), jumps the course to a specific step via the step dropdown; multiplayer host-drives-steps note + Delay-composition tip. Course overview table updated.

**Incremental — 2026-06-25:** documented two new node families shipped the week of 2026-06-16 (commits `8f119ac5`, `f0b86362`, `2a3cf0b7`):
- **Collider property/type nodes** (3, per-page) → `Components/Collider/`: Get Collider Property, Set Collider Property, Is Collider Type. Collider overview intro broadened + linked.
- **Component-list family** (8) → new `Components/Component/` subfolder (`_category_.json` position 29 + overview + 6 pages: Get Components, Get Component Item, Count Component Items, Add Component Item, Remove Component Item, Remove Component Item (Index)) + `Variables/component-list.md` + `Logic/for-each-component.md`. Mirrors the GameObject list family; documents the generic-`List<Component>` + typed-extraction model.
- Parent overviews updated: Components (new Component subfolder row + Collider row), Variables, Logic.

**Audit — 2026-06-25:** diffed all source menu paths against the 2026-05-09 baseline (`0eae6504`) — 22 new paths. Already-documented since the bulk session: Pause / Unpause Experience (`System/Experience/`), Is Experience Paused (`Logic/`), On Application (Lost) Focus (`Events/`). **Two gaps found and filled:**
- **AR family** (3) → new `Components/AR/` subfolder (`_category_.json` position 30 + overview + Enable AR / Disable AR / Is AR On). Caffeine subsystem, sits next to XR.
- **Mobile Joystick family** (3) → `Input/` (Mobile Joystick, Mobile Joystick Active, Mobile Joystick Button). These were added late March 2026 but **missed by the original audit** (the "Input 7/7" list never included them) — not new this month.
- Net result: every creator-facing menu path in source now has a doc. Method to re-run: `git grep -hoE '"Flow/[^"]+"' <baseline> -- 'Editor/Flow/Nodes/**/*.cs'` vs the working tree, `comm -13`.

## Status legend

- `[x]` — Documented (per-page or compact-pattern row in an overview)
- `[ ]` — Pending — exists in source, no doc yet
- `[~]` — Internal / drag-drop only / not creator-facing → skip
- *(c)* suffix — covered in a compact-pattern overview, no individual page

## Category status

| Category | Done / Total | Pattern | Notes |
|---|---|---|---|
| **Voice** | 4 / 4 | per-page | ✅ Complete |
| **Logic** | 15 / 15 | per-page | ✅ Complete (incl. IsPlatform folded in from `Conditions/`, Is Experience Paused, For Each Component) |
| **Math / Mathf** | 48 / 48 | compact | ✅ Complete |
| **Math / Vector3** | 21 / 21 | compact (split) | ✅ Complete |
| **Math / Vector2** | 14 / 14 | compact (split) | ✅ Complete |
| **Math / Vector4** | 12 / 12 | compact (split) | ✅ Complete |
| **Math / Color** | 4 / 4 | compact | ✅ Complete |
| **Math / Quaternion** | 15 / 15 | compact (split) | ✅ Complete (1 property + 14 operations) |
| **Math (hand-coded operators)** | 8 / 8 | mixed | ✅ Complete (`Math/Operators/` — overview + per-page Math Operator + per-page Sample Curve, others as compact rows) |
| **Variables** | 15 / 15 | per-page | ✅ Complete — incl. Component List (2026-06-25). Net flavors of Global / Graph Variable are popup-selected at drag-time and live on the parent page, not as separate files |
| **Events** | 23 / 23 | per-page | ✅ Complete (lifecycle + interaction + Net + Course events). Save System events documented under SaveSystem. |
| **Flow (graph-to-graph)** | 6 / 6 | per-page | ✅ Complete (raise/listen pairs for no-payload, GameObject, typed-variable). |
| **Course actions** | 5 / 5 | per-page | ✅ Complete |
| **Components / General** | 20 / ~21 | per-page | ✅ Effectively complete — utilities (DebugLog, Delay, FormatString, Cast, Create Vector2/3, Cursor Settings, Get Axis, Unity Event) + Property accessors (Get/Set Property, Get/Set GameObject Property, Get/Set Component Property, Get Variable Property) + Lerp/Move (Rotate, Translate, GameObject Lerp, Transform Lerp). Skipped: Get Transform (empty `[CreateNodeMenu]`). |
| **Components / Material** | 7 / 7 | per-page | ✅ Complete |
| **Components / String** | 4 / 4 | per-page | ✅ Complete |
| **Components / Animator** | 87 / 87 | mixed | ✅ Complete — 86 codegen ops in compact overview (Playback, Parameters, IK, Layers, Recording, Match target, Misc) + hand-coded `SetLookAtPosition Full`. |
| **Components / AudioSource** | 7 / 7 | compact | ✅ Complete — Play / Pause / Stop / UnPause / PlayDelayed + 2 spatializer setters. |
| **Components / Camera** | 28 / 28 | mixed | ✅ Complete — 26 codegen ops in compact overview (coordinate conversions, render control, resets, stereo / gate-fit, command buffers) + 2 hand-coded (`2D Camera Lerp`, `Camera Rotation`). |
| **Components / Collider** | 5 / 5 | mixed | ✅ Complete — compact `ClosestPoint` / `ClosestPointOnBounds` + per-page Get / Set Collider Property + Is Collider Type (2026-06-25). |
| **Components / Light** | 3 / 3 | compact | ✅ Complete — `Reset`, `RemoveAllCommandBuffers`, `RemoveCommandBuffers`. |
| **Components / ParticleSystem** | 20 / 20 | compact | ✅ Complete — Play / Pause / Stop / Clear (with `withChildren` overloads) + Emit / Simulate / IsAlive / TriggerSubEmitter / 3 attribute allocations. |
| **Components / Renderer** | 1 / 1 | compact | ✅ Complete — `HasPropertyBlock`. (Most Renderer edits go through Set Component Property.) |
| **Components / Rigidbody** | 33 / 33 | mixed | ✅ Complete — 32 codegen ops in compact overview (Forces, Torque, Movement, Queries, State control) + hand-coded `Rigidbody SetInterpolation`. |
| **Components / Transform** | 31 / 31 | compact | ✅ Complete — LookAt / Rotate / Translate / RotateAround / SetPositionAndRotation / coordinate conversions / hierarchy. (Hand-coded Translate, Rotate, Transform Lerp also live in `Components/General/`.) |
| **Components / VideoPlayer** | 5 / 5 | compact | ✅ Complete — Play / Pause / Stop / Prepare / StepForward. |
| **Components / GameObject** | 19 / 19 | per-page | ✅ Complete — Add Component, Get Component, Get Children, Is Null, Set Active, Destroy, Instantiate, Get/Set Parent, Get/Set/Compare/Remove Tag, Get Screen Position, GameObject from Component, Add/Get/Count/Remove GameObject Item (and Index variant). Get String Item moved to `Components/Lists/`. |
| **Components / Component** | 6 / 6 | per-page | ✅ Complete (2026-06-25) — new subfolder. Get Components, Get Component Item, Count Component Items, Add / Remove Component Item, Remove Component Item (Index). Pairs with For Each Component (Logic) + Component List (Variables). |
| **Components / Lists** | 3 / 3 | per-page | ✅ Complete — Get String Item, Get SnapshotFile Item, Count SnapshotFile Items. (Source-menu paths are split across `Flow/Actions/GameObject/`, `Flow/Actions/List/`, `Flow/Actions/SnapshotFile/`; consolidated under docs `Components/Lists/`.) |
| **Components / Physics** | 1 / 1 | per-page | ✅ Complete |
| **Components / Viewer** | 1 / 1 | per-page | ✅ Complete (Side Menu; Camera nodes moved to `Components/Camera/`) |
| **Components / XR** | 1 / 1 | per-page | ✅ Complete |
| **Components / AR** | 3 / 3 | per-page | ✅ Complete (2026-06-25) — new subfolder. Enable AR, Disable AR, Is AR On (viewer camera-passthrough mode toggle/query). |
| **Components / Analytics** | 2 / 2 | per-page | ✅ Complete |
| **Components / Interactables (in menu)** | 5 / 5 | per-page | ✅ Complete (docs category: `Interactables/`) |
| **Networking / Net Actions** | 8 / 8 | per-page | ✅ Complete — top-level `Networking/` category for Net-only actions/queries (Net Avatar lives in Player). |
| **Input** | 10 / 10 | per-page | ✅ Complete — incl. Mobile Joystick / Mobile Joystick Active / Mobile Joystick Button (2026-06-25; predate the May audit but were missed by it). |
| **AI** | 2 / 2 | per-page | ✅ Complete |
| **SaveSystem** | 8 / 8 | per-page | ✅ Complete (incl. 2 Save System events) |
| **System** | 4 / 4 | per-page | ✅ Complete (Time + Performance subfolders) |
| **Paint** | 2 / 2 | per-page | ✅ Complete |
| **Pulse** | 10 / 10 | per-page | ✅ Complete |
| **Player** | 3 / 3 | per-page | ✅ Complete (incl. Net Avatar) |

**Documented to date:** ~500 nodes (every creator-facing menu path + panel-driven nodes + namespace-fallback nodes)
**Remaining:** 0 — **all categories documented.** Bulk-author session complete.

## Audit (2026-05-08, post-completion)

Cross-referenced every `[CreateNodeMenu("Flow/...")]` in source against documented files:

- **Source:** 499 unique menu paths (incl. 2 commented-out duplicates in `Nodes/AI/*.cs`).
- **Effective creator-facing nodes:** ~497 from explicit menus + 4 namespace-fallback (3 Voice + AI Bot Conversation/Reset, which use `[CreateNodeMenu("")]` and rely on xNode's namespace fallback) + 7 panel-driven (4 Course Events: A-to-B Interaction End, Course Click/Hold/Trigger Interaction; 3 Graph Variables: Graph Variable, Graph GameObject Variable, Net Graph Variable).
- **Docs:** every node accounted for. Per-category sub-folder counts reconciled against source — Actions sub-cats sum to 372, Actions root has 34, Actions total = 406. Other top-levels (Events 21, Networking 14, Logic 12, Pulse 10, Variables 9, Math 8, Input 7, System 4, Player 2, Paint 2, AI 2, Voice 1, Conditions 1) all covered.

No gaps detected.

---

## Per-category details

### ✅ Voice — complete (4 / 4)

Source: `Nodes/Voice/`

- [x] TTS — `tts.md`
- [x] Stop TTS — `stop-tts.md`
- [x] Voice Dictation — `voice-dictation.md` *(source class is `EdXR_VoiceDicationNode` — typo in source, doc uses correct spelling)*
- [x] Change Voice Language — `change-voice-language.md`

### ✅ Logic — complete (13 / 13)

Source: `Nodes/Logic/` + `Nodes/Conditions/EdXR_IsPlatformNode.cs` (folded in)

- [x] Branch — `branch.md`
- [x] Conditionals — `conditionals.md`
- [x] Switch — `switch.md`
- [x] Generic Switch (`Switch (Int, String, Float)`) — `generic-switch.md`
- [x] Split Flow — `split-flow.md`
- [x] For Loop — `for-loop.md`
- [x] Foreach Game Object — `foreach-game-object.md`
- [x] Timed Kick — `timed-kick.md`
- [x] Comparison — `comparison.md`
- [x] Not — `not.md`
- [x] Equal Objects — `equal-objects.md`
- [x] Equal GameObjects — `equal-game-objects.md`
- [x] Is Platform — `is-platform.md` *(source: `Nodes/Conditions/`)*
- [~] `EdXR_ForeachNode<T>` — abstract base, not creator-facing

### ✅ Math — Vector / Color / Quaternion / Mathf complete (compact)

| Subcategory | Done | Source | Doc |
|---|---|---|---|
| Mathf      | 47 | `Nodes/CodeGenerated/Mathf/`      | `Math/Mathf/overview.md`      |
| Vector3    | 21 | `Nodes/CodeGenerated/Vector3/`    | `Math/Vector3/overview.md`    |
| Vector2    | 14 | `Nodes/CodeGenerated/Vector2/`    | `Math/Vector2/overview.md`    |
| Vector4    | 12 | `Nodes/CodeGenerated/Vector4/`    | `Math/Vector4/overview.md`    |
| Color      | 4  | `Nodes/CodeGenerated/Color/`      | `Math/Color/overview.md`      |
| Quaternion | 14 | `Nodes/CodeGenerated/Quaternion/` | `Math/Quaternion/overview.md` |

### ⏳ Math — hand-coded operators (0 / 8) — pending

Source: scattered across `Nodes/Actions/` (legacy hand-coded math). These have menu paths under `Flow/Math/...`, distinct from the codegen wrappers.

- [ ] Cross Product (`Flow/Math/Cross Product`)
- [ ] Dot Product (`Flow/Math/Dot Product`)
- [ ] Math Operator (`Flow/Math/Math Operator`) — likely a multi-type +/-/×/÷ operator
- [ ] Quaternion Angle (`Flow/Math/Quaternion Angle`) *(may overlap with codegen Quaternion Angle — confirm)*
- [ ] Sample Curve (`Flow/Math/Sample Curve`)
- [ ] Vector Angle (`Flow/Math/Vector Angle`) *(may overlap with codegen Vector3/2 Angle)*
- [ ] Vector Multiple (`Flow/Math/Vector Multiple`)
- [ ] Vector3 Operator (`Flow/Math/Vector3 Operator`) — likely +/- on Vector3

**Docs target:** add a `Math/<each>` per-page or fold into the existing Vector/Quaternion overviews where the hand-coded entry duplicates a codegen one.

### ✅ Variables — complete (14 / 14)

Source: `Nodes/Variables/`, `Nodes/Variables/Random/`, `Nodes/Variables/Collections/`, `Nodes/NetNodes/Variables/`

- [x] Delta Time
- [x] Fixed Delta Time
- [x] Self
- [x] GameObject
- [x] Global GameObject
- [x] Local Variable
- [x] Net Variable *(separate Add Node menu entry)*
- [x] Global Variable *(drag from Project + popup chooses Local/Net flavor — both documented on `global-variable.md`)*
- [x] Graph Variable *(drag from Variables panel + popup chooses Local/Net flavor — both documented on `graph-variable.md`)*
- [x] Graph GameObject Variable *(no menu — panel)*
- [x] GameObject List
- [x] Random

### 🔨 Events — in progress (3 / 21)

Source: `Nodes/Events/`, `Nodes/Events/Course Events/`, `Nodes/NetNodes/Events/`, `Nodes/NetNodes/MonoBehaviours/`

**Lifecycle:**
- [ ] Awake (`Flow/Events/Awake`)
- [ ] Start (`Flow/Events/Start`)
- [ ] OnEnable (`Flow/Events/OnEnable`)
- [ ] OnDisable (`Flow/Events/OnDisable`)
- [ ] OnDestroy (`Flow/Events/OnDestroy`)
- [x] Update — `update.md`
- [ ] Late Update (`Flow/Events/Late Update`)
- [ ] FixedUpdate (`Flow/Events/FixedUpdate`)
- [ ] OnAnimatorIK (`Flow/Events/OnAnimatorIK`)

**Interaction:**
- [x] Select Event — `select-event.md`
- [x] Net Select Event — `net-select-event.md`
- [ ] Trigger Event (`Flow/Events/Trigger Event`)
- [ ] Net Trigger Event (`Flow/Networking/Events/Net Trigger Event`)
- [ ] Collision Event (`Flow/Events/Collision Event`)
- [ ] Net OnPlayerEnter (`Flow/Networking/Events/Net OnPlayerEnter`)
- [ ] Net OnPlayerExit (`Flow/Networking/Events/Net OnPlayerExit`)

**Course events:**
- [ ] OnStepLoaded (`Flow/Events/OnStepLoaded`)
- [ ] (Course click / hold / trigger interaction events, plus AtoB Interaction End — verify menu paths)

**Save System events** *(also listed under SaveSystem section):*
- [ ] Save System Load Event (`Flow/Events/Save System Load Event`)
- [ ] Save System Reset Event (`Flow/Events/Save System Reset Event`)

### ⏳ Flow (graph-to-graph) — pending (0 / 6)

Source: `Nodes/Events/EdXR_*EventListenerNode.cs` and `EdXR_Raise*Node.cs`. Lives in `Events/` source but documented under docs `Signals/`.

- [ ] Raise Flow Event (`Flow/Events/Raise Flow Event`)
- [ ] Raise Flow Event GameObject (`Flow/Events/Raise Flow Event GameObject`)
- [ ] Raise Flow Event Variable (`Flow/Events/Raise Flow Event Variable`)
- [ ] Flow Event Listener (`Flow/Events/Flow Event Listener`)
- [ ] Flow Event GameObject Listener (`Flow/Events/Flow Event GameObject Listener`)
- [ ] Flow Event Variable Listener (`Flow/Events/Flow Event Variable Listener`)

### ⏳ Course actions — pending (0 / 5)

Source: `Nodes/Actions/Course/`. Menu paths are mixed — some under `Flow/Actions/`, some under `Flow/Actions/Course/` (verify per-node).

- [ ] Exit Course (`Flow/Actions/Exit Course`)
- [ ] Objective Completion (`Flow/Actions/Objective Completion`)
- [ ] A-to-B Reset (`Flow/Actions/Reset A to B`)
- [ ] Course Animation Attachment (`Flow/Actions/Animation Attachment`)
- [ ] Course Media Attachment (`Flow/Actions/Media Attachment`)

### ⏳ Components / General — pending (~30)

Source: `Nodes/Actions/EdXR_*Node.cs` files at the top level, plus a few nested. These mostly map to `Flow/Actions/<Verb>` menu paths without a deeper subfolder.

Hand-coded utility nodes:
- [ ] Add Component (`Flow/Actions/GameObject/Add Component`)
- [ ] Cast (`Flow/Actions/Type Cast`)
- [ ] Create Vector2 (`Flow/Actions/Create Vector2`)
- [ ] Create Vector3 (`Flow/Actions/Create Vector3`)
- [ ] Cursor Settings (`Flow/Actions/Cursor Settings`)
- [ ] Debug Log (`Flow/Actions/Debug.Log`)
- [ ] Delay (`Flow/Actions/Delay`)
- [ ] Format String (`Flow/Actions/Format String`)
- [ ] GameObject Lerp (`Flow/Actions/GameObject Lerp`)
- [ ] Get Axis (`Flow/Actions/Get Axis`)
- [ ] Get Children (no menu listing found — verify)
- [ ] Get Component (no menu listing found — verify; may live elsewhere)
- [ ] Get Component Property (`Flow/Actions/Get Component Property`)
- [ ] Get GameObject Property (`Flow/Actions/Get GameObject Property`)
- [ ] Get Property (`Flow/Actions/Get Property`)
- [ ] Get Variable Property (`Flow/Actions/Get Variable Property`)
- [ ] Rotate (`Flow/Actions/Rotate`)
- [ ] Set Component Property (`Flow/Actions/Set Component Property`)
- [ ] Set GameObject Property (`Flow/Actions/Set GameObject Property`)
- [ ] Set Property (`Flow/Actions/Set Property`)
- [ ] String Contains (`Flow/Actions/String Contains`)
- [ ] String Length (`Flow/Actions/String Length`)
- [ ] String ToLower (`Flow/Actions/String ToLower`)
- [ ] Substring (`Flow/Actions/Substring`)
- [ ] Transform Lerp (`Flow/Actions/Transform Lerp`)
- [ ] Translate (`Flow/Actions/Translate`)
- [ ] Unity Event (`Flow/Actions/Unity Event`)

### ⏳ Components / Material — pending (0 / 7)

- [ ] Get Material (`Flow/Actions/Material/Get Material`)
- [ ] Set Material (`Flow/Actions/Material/Set Material`)
- [ ] Get Material Property (`Flow/Actions/Get Material Property`)
- [ ] Set Material Property (`Flow/Actions/Set Material Property`)
- [ ] Set Material Color (`Flow/Actions/Set Material Color`)
- [ ] Disable Material Keyword (`Flow/Actions/Disable Material Keyword`)
- [ ] Enable Material Keyword (`Flow/Actions/Enable Material Keyword`)

### ⏳ Components / Component-codegen — pending (compact target)

Each component subcategory contains many codegen variants. Target treatment is **compact** (single overview per subcategory) with selective **per-page** for variants with non-trivial behavior (e.g. `Rigidbody.AddForce` with `ForceMode`).

| Subcategory | Source | Approx count | Notes |
|---|---|---|---|
| Animator      | `Nodes/CodeGenerated/Animator/` + `Nodes/Actions/Animator/` | ~65 | Per-page candidates: Play, CrossFade variants (lots of overloads — group thematically) |
| AudioSource   | `Nodes/CodeGenerated/AudioSource/`                          | ~17 | Per-page candidates: Play, Stop |
| Camera        | `Nodes/CodeGenerated/Camera/`                               | ~12 | |
| Collider      | `Nodes/CodeGenerated/Collider/`                             | ?   | |
| Light         | `Nodes/CodeGenerated/Light/`                                | ?   | |
| ParticleSystem| `Nodes/CodeGenerated/ParticleSystem/`                       | ?   | |
| Renderer      | `Nodes/CodeGenerated/Renderer/`                             | ?   | |
| Rigidbody     | `Nodes/CodeGenerated/Rigidbody/`                            | ?   | Per-page candidates: AddForce (ForceMode), AddTorque, MovePosition |
| Transform     | `Nodes/CodeGenerated/Transform/` + hand-coded               | ?   | Hand-coded: Translate, Rotate, Transform Lerp |
| VideoPlayer   | `Nodes/CodeGenerated/VideoPlayer/`                          | ?   | |

When authoring each, verify exact count by listing the source folder and grepping `[CreateNodeMenu]`.

### ⏳ Components / Other subcategories — pending

- [ ] Physics Raycast (`Flow/Actions/Physics/Physics Raycast`) — single node
- [ ] Get SnapshotFile Item (`Flow/Actions/SnapshotFile/Get SnapshotFile Item`) — single node
- [ ] Side Menu (`Flow/Actions/Viewer/Side Menu`) — single node
- [ ] Set Laser Active (`Flow/Actions/XR/Set Laser Active`) — single node
- [ ] Analytic (`Flow/Actions/Analytics/Analytic`)
- [ ] Get Analytic (`Flow/Actions/Analytics/Get Analytic`)
- [ ] (Actions/Interactables menu — verify nodes; may overlap with the docs `Interactables/` category)
- [ ] (Actions/SaveSystem menu — verify; likely the Save / Load / Reset action nodes that should live in docs `SaveSystem/`)
- [ ] (Actions/List menu — verify; likely list-mutation nodes that should live in docs `Variables/` or its own collections subsection)
- [ ] (Actions/GameObject menu — verify; Add Component is here, possibly more)

### ⏳ Networking / Net Actions — pending (0 / 8)

Source: `Nodes/NetNodes/Actions/`

- [ ] Net Destroy (`Flow/Networking/Net Destroy`)
- [ ] Net Instantiate (`Flow/Networking/Net Instantiate`)
- [ ] Net Is Host (`Flow/Networking/Net Is Host`)
- [ ] Net Is Mine (`Flow/Networking/Net Is Mine`)
- [ ] Net Kick (`Flow/Networking/Net Kick`)
- [ ] Net Avatar (`Flow/Networking/Net Avatar`)
- [ ] Get Net Ownership (`Flow/Networking/Get Net Ownership`)
- [ ] Set Net Avatar Models (`Flow/Networking/Set Net Avatar Models`)

These should be documented as siblings of their non-Net counterparts where one exists (e.g. Net Destroy → next to a Destroy action), or grouped into a top-level Actions/Networking section.

### ⏳ Input — pending (0 / 7)

Source: `Nodes/Input/`. Docs folder already scaffolded at `Documentation/Nodes/Input/`.

- [ ] Input Key (`Flow/Input/Input Key`)
- [ ] Mouse Position (`Flow/Input/Mouse Position`)
- [ ] Mouse Delta (`Flow/Input/Mouse Delta`)
- [ ] Player Input (`Flow/Input/Player Input`)
- [ ] Player Input Axis (`Flow/Input/Player Input Axis`)
- [ ] Player Input Haptics (XR) (`Flow/Input/Player Input Haptics (XR)`)
- [ ] Is Hand Tracking (`Flow/Input/IsHandTracking`)

### ⏳ AI — pending (0 / 2)

Source: `Nodes/AI/`. Note: `EdXR_AIBotConversationNode` has its `[CreateNodeMenu]` commented out and uses the namespace fallback.

- [ ] AI Bot Conversation
- [ ] AI Bot Conversation Reset (`Flow/AI/AI Bot Conversation Reset`)

### ⏳ SaveSystem — pending (0 / 8)

Source: `Nodes/SaveSystem/`. Some entries also surface in Events.

- [ ] Save (`Nodes/SaveSystem/EdXR_SaveSystemSaveNode.cs`)
- [ ] Load (`Nodes/SaveSystem/EdXR_SaveSystemLoadNode.cs`)
- [ ] Reset (`Nodes/SaveSystem/EdXR_SaveSystemResetNode.cs`)
- [ ] Get Snapshots (`Nodes/SaveSystem/EdXR_SaveSystemGetSnapshotsNode.cs`)
- [ ] Get Loaded Snapshot (`Nodes/SaveSystem/EdXR_SaveSystemGetLoadedSnapshotNode.cs`)
- [ ] SaveSystem Value (`Nodes/SaveSystem/EdXR_SaveSystemValueNode.cs`)
- [ ] On Save System Load Event *(also in Events list)*
- [ ] On Save System Reset Event *(also in Events list)*

Verify exact menu paths during authoring.

### ⏳ System — pending (0 / 4)

Source: `Nodes/System/Time/` (3 nodes), `Nodes/System/Performance/` (1 node).

- [ ] Current Date Simple (`Nodes/System/Time/EdXR_CurrentDateSimpleNode.cs`)
- [ ] Current Time (`Nodes/System/Time/EdXR_CurrentTimeNode.cs`)
- [ ] Current Time Simple (`Nodes/System/Time/EdXR_CurrentTimeSimpleNode.cs`)
- [ ] Foveated Rendering (`Nodes/System/Performance/EdXR_FoveatedRenderingNode.cs`)

### ⏳ Paint — pending (0 / 2)

Source: `Nodes/Paint/`

- [ ] Clear Paintable
- [ ] Paint Percentage

### ⏳ Pulse — pending (0 / 10)

Source: `Nodes/Pulse/` + `Nodes/Pulse/Actions/`

- [ ] Pulse Data (`Flow/Pulse/Pulse Data`)
- [ ] Pulse Advance Time (`Flow/Pulse/Actions/Pulse Advance Time`)
- [ ] Pulse Reset Simulation (`Flow/Pulse/Actions/Pulse Reset Simulation`)
- [ ] Pulse Substance Bolus (`Flow/Pulse/Actions/Pulse Substance Bolus`)
- [ ] Pulse Substance Infusion (`Flow/Pulse/Actions/Pulse Substance Infusion`)
- [ ] Pulse Substance Compound Infusion (`Flow/Pulse/Actions/Pulse Substance Compound Infusion`)
- [ ] Pulse Hemorrage (`Flow/Pulse/Actions/Pulse Hemorrage`) *(sic — source spelling)*
- [ ] Pulse Arrythmia (`Flow/Pulse/Actions/Pulse Arrythmia`) *(sic)*
- [ ] Pulse Start Airway Obstruction (`Flow/Pulse/Actions/Pulse Start Airway Obstruction`)
- [ ] Pulse Stop Airway Obstruction (`Flow/Pulse/Actions/Pulse Stop Airway Obstruction`)

Plus possibly a Pulse State Generator node — confirm.

### ⏳ Player — pending (0 / 3)

Source: `Nodes/Player/2D/`, `Nodes/Player/VR/`, plus `EdXR_NetAvatarNode` at `Nodes/Player/`.

- [ ] 2D Camera GO (`Nodes/Player/2D/EdXR_2DCameraGO.cs`) — verify menu path
- [ ] VR Player GO (`Nodes/Player/VR/EdXR_VRPlayerGO.cs`) — verify menu path
- [ ] Net Avatar — already listed under Networking; possibly also surfaces here; verify

### ⏳ Interactables — pending (0 / 5)

Source: `Nodes/Interactables/`. Note: docs `Interactables/` is already scaffolded.

- [ ] Is Interactable
- [ ] Is Being Held
- [ ] Start Interaction
- [ ] End Interaction
- [ ] Interactable Be Free

Verify menu paths during authoring — these may live under `Flow/Actions/Interactables/...` rather than a top-level `Flow/Interactables/...`.

---

## Priority queue — suggested batches

Smallest meaningful next batches, ordered by likely-creator-impact:

1. **Events lifecycle + Flow events** — fills out the most-used category. ~15 nodes.
2. **Input** — small (7), high-leverage, frequently wired into Branches/Comparisons.
3. **SaveSystem + System + Course actions** — bundle the small domain categories into one batch. ~17 nodes.
4. **AI + Voice (already done) + Interactables + Paint + Player** — finish the small domain categories. ~10 nodes.
5. **Math hand-coded operators** — 8 nodes, completes the Math category.
6. **Components / General + Material + String** — utility action nodes. ~40 nodes.
7. **Networking / Net Actions** — 8 nodes.
8. **Actions component categories** — Animator first (~65 codegen), then the rest by frequency: Rigidbody, Transform, AudioSource, Camera, Renderer, Light, Collider, ParticleSystem, VideoPlayer. ~250 nodes total, mostly compact.
9. **Pulse** — niche. 10 nodes.

---

## Refreshing the baseline

When new Caffeine source lands or you just want to verify the count is current, re-run this from the repo root in a Bash-capable shell:

```bash
grep -rh 'CreateNodeMenu' "Packages/caffeine/Editor/Flow/Nodes" --include='*.cs' \
  | grep -o '"Flow/[^"]*"' \
  | sort -u > /tmp/current-menu-paths.txt
wc -l /tmp/current-menu-paths.txt
```

Compare the count against the **Total source nodes** at the top of this file and the per-category counts. For per-category breakdown:

```bash
grep -rh 'CreateNodeMenu' "Packages/caffeine/Editor/Flow/Nodes" --include='*.cs' \
  | grep -o '"Flow/[^"]*"' | sort -u \
  | sed 's|^"Flow/||' | sed 's|/.*||' | sort | uniq -c | sort -rn
```

Then update the **Last scan** date and add any new menu paths as `[ ]` pending entries in the right category.

---

## Notes

- Empty `CreateNodeMenu("")` entries are intentional — they're internal nodes (e.g. Graph Variable nodes instantiated via drag-drop). Document them only if creators interact with them in the UI.
- The source menu path `Flow/Actions/<Type>/` for value-type wrappers (Vector / Color / Quaternion / Mathf) is a labeling artifact; docs structure groups them under `Math/<Type>/`. See `CLAUDE.md` "Classifying nodes" for the framework.
- Some nodes appear in multiple source folders (e.g. SaveSystem events live in `Nodes/SaveSystem/` but use `Flow/Events/Save System Load Event` menu). Group by the **docs** structure when authoring, not source.
- Compact-pattern entries are tracked at the category level (one row per subcategory in the status table), not per individual node.
