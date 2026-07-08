# Flow Nodes Documentation — Structure & Handoff

> **Read this BEFORE writing any node docs.** Review the structure, validate the open questions at the bottom, and suggest changes here first. Don't silently deviate from the layout — it's referenced by `edxr-docs/CLAUDE.md` and by templates.

## Goal

Document every node available in **Caffeine's Flow** visual scripting language so that creators can:

- Find a node by name (Typesense search lands directly on its page).
- Browse by category when they don't know the exact name.
- Understand inputs, outputs, parameters, networking behavior, and common pitfalls for each node.

## Why one page per node (and not one long page per category)

At the scale we're targeting (hundreds of nodes), per-node pages beat per-category long pages on every axis that matters:

- **Stable canonical URL per node.** Typesense lands users on the exact node. Internal cross-references don't break when headings reorder. Future Caffeine editor "Help" buttons can deep-link straight to a node.
- **Edit isolation.** Agents and humans modify one small file at a time. No 5000-line files. Merge conflicts when multiple authors work in parallel are minimized.
- **Right-side TOC stays useful.** It shows the structure of one node, not 50.
- **Sets up future codegen.** If Caffeine ever emits a JSON manifest of its nodes, per-node files are the structure that makes generation possible. Long category pages are a dead end for that.

The known tradeoff (large sidebar) is mitigated by `"collapsed": true` on every category — the sidebar shows top-level categories first, creators expand only the one they care about.

## Folder layout

```
docs/Flow/Nodes/
  _category_.json                        ← top-level "Nodes" entry, generated-index
  Events/
    _category_.json
    overview.md                          ← prose intro + table of nodes here
    select-event.md
    net-select-event.md                  ← Net (multiplayer) variant — its own page
    update.md
    course-click-interaction.md          ← Course Events live as siblings here
    ...
  Components/
    _category_.json
    overview.md
    General/                             ← non-component utility actions (DebugLog, Delay, FormatString, Cast, AddComponent, GetComponent, etc.)
      _category_.json
      overview.md
      debug-log.md
      delay.md
      ...
    Animator/
      _category_.json
      overview.md
      play.md
      set-trigger.md
      ...
    AudioSource/
    Camera/
    Collider/
    Course/                              ← course-action nodes (ExitCourse, ObjectiveCompletion, AtoBReset, attachments)
    Light/
    ParticleSystem/
    Renderer/
    Rigidbody/
    Transform/
    VideoPlayer/
  Math/
    _category_.json
    overview.md
    Mathf/
    Color/
    Quaternion/
    Vector2/
    Vector3/
    Vector4/
  Variables/
  Logic/                                 ← Branch, ForLoop/Foreach, Switch, Comparison, Conditionals, Not, SplitFlow, TimedKick, EqualObjects/EqualGameObjects, IsPlatform
  Signals/                               ← cross-graph: Flow Event raise/listen
  Input/                                 ← keyboard, mouse, hand-tracking, player input axes, haptics
  Interactables/                         ← IsInteractable, StartInteraction, EndInteraction, BeFree, IsBeingHeld
  AI/                                    ← AI bot conversation, reset
  Voice/                                 ← TTS, dictation, language switch
  SaveSystem/                            ← save/load/snapshot + OnSaveSystemLoad/Reset events
  System/
    _category_.json
    overview.md
    Time/                                ← current date, time-of-day variants
    Performance/                         ← foveated rendering
  Paint/                                 ← ClearPaintable, PaintPercentage
  Pulse/                                 ← Pulse physiology engine integration
  Player/                                ← player GameObject references (2D, VR)
```

## Categories

| Category | Contents | Source folder(s) |
|---|---|---|
| **Events** | Lifecycle (OnEnable/Update/Awake/etc.), Select, Trigger/Collision, Course Events, Flow Event listeners, plus Net counterparts | `Nodes/Events/`, `Nodes/Events/Course Events/`, `Nodes/NetNodes/Events/`, `Nodes/NetNodes/MonoBehaviours/` |
| **Components** | Nodes grouped by what they touch. Most subfolders map to a Unity component (Rigidbody, AudioSource, Animator, etc.); some group Caffeine subsystems (XR, Analytics, Viewer) or non-component utilities (General for engine-level Actions, Lists for typed-list operations, String for string utilities). Each subfolder holds both Action nodes (Flow ports) and pure-data queries (no Flow ports) | `Nodes/Actions/`, `Nodes/CodeGenerated/<Component>/`, `Nodes/NetNodes/Actions/` |
| **Utilities** | Engine-level pure-data helpers + their Set-counterparts: Cast, Create Vector 2/3, Format String, Get Axis, Get/Set Property family. Source still under `Nodes/Actions/` but docs split out from `Components/` because these don't bind to a Unity component | `Nodes/Actions/EdXR_*Node.cs` (top-level pure-data + Set-counterparts) |
| **Course** | Course-action nodes (ExitCourse, ObjectiveCompletion, AtoBReset, course media/animation attachments). Distinct from Course **Events** under `Events/` | `Nodes/Actions/Course/` |
| **Math** | Operations on value types: Mathf, Color, Quaternion, Vector2/3/4 | `Nodes/CodeGenerated/{Mathf,Color,Quaternion,Vector2,Vector3,Vector4}/` |
| **Variables** | Graph variables, global variables, GameObject variables, collections (List/GameObjectList), Random, plus Net variables | `Nodes/Variables/`, `Nodes/Variables/Collections/`, `Nodes/Variables/Random/`, `Nodes/NetNodes/Variables/` |
| **Logic** | Control flow: Branch, ForLoop, Foreach, ForeachGameObject, Switch, GenericSwitch, Comparison, Conditionals, Not, SplitFlow, TimedKick, EqualObjects, EqualGameObjects, IsPlatform | `Nodes/Logic/`, `Nodes/Conditions/` |
| **Signals** | Cross-graph raise/listen of Flow Event assets (no-payload, GameObject payload, typed-value payload). Source nodes still use "Flow Event" naming; docs group them under Signals to disambiguate from scene-driven Events | `Nodes/Events/EdXR_RaiseEvent*Node.cs` + `EdXR_EventListener*Node.cs` |
| **Input** | Keyboard keys, mouse position/delta, player input axes, hand-tracking, haptics | `Nodes/Input/` |
| **Interactables** | IsInteractable, StartInteraction, EndInteraction, BeFree, IsBeingHeld | `Nodes/Interactables/` |
| **AI** | AI Bot Conversation, Reset AI Conversation | `Nodes/AI/` |
| **Voice** | TTS, Stop TTS, Dictation, Change Voice Language | `Nodes/Voice/` |
| **SaveSystem** | Save / Load / Reset, snapshot getters, value reader, plus OnSaveSystemLoad / OnSaveSystemReset events | `Nodes/SaveSystem/` |
| **System** | Time-of-day & current date (Time/), foveated rendering (Performance/) | `Nodes/System/Time/`, `Nodes/System/Performance/` |
| **Paint** | ClearPaintable, PaintPercentage | `Nodes/Paint/` |
| **Pulse** | Pulse physiology engine integration (state generator, data, actions) | `Nodes/Pulse/` |
| **Player** | Player GameObject references (2D camera, VR player) | `Nodes/Player/2D/`, `Nodes/Player/VR/` |

`Nodes/Notes/` (graph-annotation widget) is intentionally not represented in the docs — it's an authoring-time artifact, not a runtime node.

## Components covered under `Components/`

From the Caffeine source (`Nodes/CodeGenerated/`):

`Animator`, `AudioSource`, `Camera`, `Collider`, `Light`, `ParticleSystem`, `Renderer`, `Rigidbody`, `Transform`, `VideoPlayer`

Plus subfolders under `Components/`:

- **`Components/General/`** — non-component **Action** nodes (DebugLog, Delay, CursorSettings, UnityEvent, Rotate, Translate, GameObject Lerp, Transform Lerp). All have Flow ports. Hand-coded under `Nodes/Actions/` at the top level.
- **`Components/GameObject/`** — both Action and Variable nodes that touch a GameObject (AddComponent, GetComponent, GetChildren, IsNull, SetActive, Destroy, Instantiate, parenting, tag queries).
- **`Components/Component/`** — the Component analog of the GameObject list nodes (added 2026-06-25). Get Components (one typed list off a GameObject) + Add/Remove/Get/Count item nodes. Source: `Nodes/Actions/Component/`, menu `Flow/Actions/Component/`. The `List<Component>` is generic; typed extraction happens on Get Component Item / For Each Component (a `Logic/` node). The Component List variable lives under `Variables/`.
- **`Components/<other Unity components>/`** — per-component nodes for Animator, AudioSource, Rigidbody, etc. Source: codegen wrappers in `Nodes/CodeGenerated/<Component>/`, plus any hand-coded specializations in `Nodes/Actions/<Component>/`.

Separate top-level folders for related-but-distinct kinds:

- **`Utilities/`** — engine-level pure-data helpers and their Set-counterparts (Cast, Create Vector 2/3, Format String, Get Axis, Get/Set Property family). Source: `Nodes/Actions/EdXR_*Node.cs` top-level (pure-data ones).
- **`Course/`** — course-action nodes (ExitCourse, ObjectiveCompletion, AtoBReset, course media/animation attachments). Source: `Nodes/Actions/Course/`. Distinct from Course **Events** which live under `Events/`.

## Math/data types covered under `Math/`

`Mathf`, `Color`, `Quaternion`, `Vector2`, `Vector3`, `Vector4`

(`Mathf` is a Unity utility class, not a component — included here because its nodes are math operations.)

## Naming conventions

| Thing | Convention | Example |
|---|---|---|
| File name | kebab-case | `add-force.md`, `set-active.md` |
| Net variant file | prefix with `net-` | `net-select-event.md` |
| Top-level category folder | PascalCase | `Events/`, `Components/` |
| Component/type subfolder | PascalCase, **match Caffeine source exactly** | `Rigidbody/` (not `RigidBody`), `Vector3/` |
| Internal link | absolute path | `/docs/Flow/Nodes/Events/select-event` |

## Standard Flow ports — implicit on Action nodes

Every Action / Updatable node has a standard Flow input (top-left, `entry`) and a standard Flow output (top-right, `exit`). Per-node docs **never** list these in their Inputs/Outputs tables. The convention is documented once in `Components/overview.md`; per-page docs only call out *additional* Flow ports beyond the standard pair.

Rules by node type:

| Node type | Flow input | Flow output | Per-page treatment |
|---|---|---|---|
| **Action / Updatable** (`EdXR_UpdatableNode`) | implicit `entry` | implicit `exit` | Don't list either. List only data inputs and ADDITIONAL Flow outputs. When listing additional Flow outputs, add a `:::note Standard Flow output` admonition explaining the timing relationship to `exit`. |
| **Event** (`EdXR_EventNode`) | no Flow input — events kick the flow, they don't consume one. The `Enabled` Bool input goes in the Inputs table. | one or more — the node's *purpose*. List all Flow outputs explicitly. | Use the display name "Flow" for the type column even when the underlying field is named `entry`. |
| **Pure data** (`EdXR_Node`) | none | none | No Flow ports to mention. Just data inputs and outputs. |

**Why "additional Flow outputs" need a note.** A creator wiring TTS's standard `exit` to "run after speech finishes" will be surprised — `exit` kicks immediately when the node runs, not when speech completes. The `speakComplete` port is what they want. The `:::note` admonition explicitly contrasts the two, preventing the footgun.

Pattern for the admonition:

```md
:::note Standard Flow output vs `<additional-port>`
Like every Action node, <Node Name> has a standard Flow output (`exit`) that kicks **immediately** when the node runs — not when <thing the additional port waits for>. To run logic after <event>, wire from `<additional-port>`, not from the standard output. See the [Action overview](/docs/Flow/Nodes/Components/overview) for the convention.
:::
```

## Net (multiplayer) variant treatment

**Source vs docs layout — they don't match, intentionally.** In source, Net nodes live under their own root: `Nodes/NetNodes/{Events,Actions,Variables,MonoBehaviours}/`. In docs, Net pages live **next to their non-Net counterpart** with a `net-` filename prefix — `Documentation/Nodes/Events/select-event.md` and `Documentation/Nodes/Events/net-select-event.md` sit in the same folder. Don't mirror `NetNodes/` as a top-level docs category; the flat layout is a deliberate creator-UX call.

- Each Net variant is its **own page** at the same level as the local node — not a subsection.
- File name prefixed with `net-`.
- Page title uses the `.net-node` purple class + `.net-badge` chip (defined in `src/css/custom.css` of the target Docusaurus repo):

  ```md
  ---
  sidebar_position: 2
  sidebar_label: Net Select Event
  title: Net Select Event
  ---

  # <span class="net-node">Net Select Event</span> <span class="net-badge">NET</span>
  ```

- The `sidebar_label` and `title` frontmatter fields are **required** on Net pages. Docusaurus would otherwise pick up the raw H1 text — including the `<span>` tags — for the sidebar entry, breadcrumb, and browser tab, leaking literal HTML into the UI.
- Local and Net pages cross-link in their "See also" sections.
- Default guidance to repeat in Net node descriptions: prefer the Net version unless you specifically want client-local behavior.

### CSS dependency

The `.net-node` and `.net-badge` classes used in Net headings are defined in `edxr-docs/src/css/custom.css` (the target Docusaurus site). They look like this:

```css
.net-node { color: #8b5cf6; }
[data-theme='dark'] .net-node { color: #a78bfa; }
.net-badge {
  display: inline-block;
  background: #8b5cf6;
  color: #fff;
  font-size: 0.6em;
  font-weight: 700;
  padding: 2px 8px;
  border-radius: 10px;
  vertical-align: middle;
  margin-left: 10px;
  letter-spacing: 0.08em;
}
```

If you preview the Nodes folder in isolation (outside the full Docusaurus site), these classes won't be available and the purple styling won't render — match the markup exactly anyway; the styling will apply once the folder is integrated.

## Templates

- **Per-node page:** [`flow-node-template.md`](./flow-node-template.md)
- **Category/subcategory overview page:** [`flow-node-overview-template.md`](./flow-node-overview-template.md)

Both templates contain `{/* ... */}` block comments with author instructions — strip them all from the final docs.

## Handoff checklist (before returning the Nodes folder)

This folder will be copy-pasted back into the target Docusaurus repo as a unit, replacing the existing `docs/Flow/Nodes/` directory. Before handing it back, verify ALL of the following — each one breaks the site or the navigation if missed:

- [ ] **Every new node has a row in its parent `overview.md` table.** The category index is hand-maintained — adding a node file alone won't make it discoverable.
- [ ] **Every new component subfolder has its own `_category_.json`.** Without it, Docusaurus won't show the subfolder in the sidebar. Use `"collapsed": true` and a `generated-index` link.
- [ ] **Every new component subfolder has an `overview.md`** (unless it has only 2–3 trivial nodes — then justify the omission in your handoff notes).
- [ ] **Net variant pages have `sidebar_label` and `title` in frontmatter.** Without them the raw HTML from the styled H1 leaks into the sidebar and breadcrumb.
- [ ] **Cross-links use absolute paths** (`/docs/Flow/Nodes/Events/select-event`) **or relative-to-doc paths** (`./net-select-event`) — never relative-to-disk (`../../...`).
- [ ] **Renamed or removed nodes:** delete the old file AND remove its row from the parent overview table AND grep the rest of the Nodes folder for stale links to it.
- [ ] **No references to files outside the Nodes folder** unless they're absolute Docusaurus paths (`/docs/...`). Markdown links to `../../templates/...` will warn at build time.
- [ ] **Folder structure matches what's described in this file.** If you needed to deviate, update the "Folder layout" section above and add a "Proposed change" entry under "Open questions".
- [ ] **No `{/* ... */}` author-instruction comments** left in any final node or overview page. Those belong only in the templates.

The user will integrate by replacing `edxr-docs/docs/Flow/Nodes/` wholesale, run `npm start`, and check the dev server for warnings. If any of the checklist items above fail, those warnings will be the first signal.

## Workflow

### Adding a new node

1. Identify its category and (for Components/Math) the component/type subfolder.
2. Create `<category>/<component>/<node-slug>.md` from `flow-node-template.md`.
3. Add a row to the `overview.md` of its parent folder so it's listed in the category index table.
4. If it has a Net counterpart, create `net-<slug>.md` from the same template; cross-link both.

### Adding a new category or component subfolder

1. Create the folder.
2. Add `_category_.json` (template below).
3. Add `overview.md` from `flow-node-overview-template.md`.
4. Update the **Folder layout** section of this file so it stays current.

### Reference: `_category_.json` template

```json
{
  "label": "Display Name",
  "position": 1,
  "collapsed": true,
  "link": {
    "type": "generated-index",
    "description": "One-line description shown on the category index page."
  }
}
```

## Compact pattern for repetitive node families

Two treatments exist; pick per node, not per folder.

**Per-page treatment** — one `.md` file per node, with its own URL, sidebar entry, and the full template (Inputs / Outputs / Inspector / Notes / See also). Use for hand-coded nodes (`Branch`, `ForLoop`, `Delay`, `Select Event`) and for codegen variants that have a footgun, an enum parameter, or non-obvious semantics worth a paragraph.

**Compact pattern** — no individual file. The whole family is documented as a single table on the parent `overview.md`. Use for codegen variants where the only differences across siblings are operand types or trivial getter/setter shape:

```md
## Vector3 operations

| Node | Inputs | Output |
|---|---|---|
| Vector3 Angle           | a, b               | Float   |
| Vector3 ClampMagnitude  | vector, maxLength  | Vector3 |
| Vector3 Cross           | a, b               | Vector3 |
| Vector3 Distance        | a, b               | Float   |
| Vector3 Lerp            | a, b, t            | Vector3 |
```

(Compact tables for codegen families also get a `Unity ref` column — see "Unity API references" below.)

**Decision test.** Look at the proposed table row: *if I deleted the node name, would the remaining cells be enough to know what the node does?* If yes → compact. If a creator needs a paragraph on a parameter, gotcha, or behavior → per-page.

**Source-folder defaults:**
- `Nodes/CodeGenerated/<Type>/` (Mathf, Vector2/3/4, Quaternion, Color) → **default to compact**, since each variant just maps to a Unity API method.
- `Nodes/CodeGenerated/<Component>/` (Animator, Rigidbody, etc.) → **mixed**. Trivial setters compact, anything with a `ForceMode`, timing concern, or component-state caveat per-page.
- Hand-coded folders (`Nodes/Logic/`, `Nodes/Events/`, `Nodes/Variables/`, `Nodes/Actions/<Component>/` specializations — docs live under `Components/<Component>/`) → **default to per-page**.
- Net variants → **per-page when the Net variant has its own Add Node menu entry** (e.g., `Net Variable` at `Flow/Networking/Variable/Net Variable`). When the Net flavor is selected at drag-time via popup rather than as a separate menu choice (e.g., Global Variable, Graph Variable), document it as a `## Local vs Net flavor` section on the parent page — see [`../CLAUDE.md`](../CLAUDE.md) "Net variants → Exception" for details.

**Properties vs Operations split (value-type compact tables).** Vector3, Vector2, Vector4, Quaternion, and Color overviews mix two kinds of nodes — Unity *property* getters (single input, returns a derived value, URL `Type-name.html`) and *static method* operations (multiple inputs, computes a result, URL `Type.Method.html`). Split the overview into two sub-tables under `## Properties` and `## Operations` headings so the URL conventions stay clean and creators can spot the "free getters" subset quickly. See [`Math/Vector3/overview.md`](../Nodes/Math/Vector3/overview.md) for the canonical example. Mathf is all static methods → single-table is fine. The classification framework in [`Documentation/CLAUDE.md`](../CLAUDE.md) covers when to apply this split.

Mixing within one overview is fine: a `Rigidbody/overview.md` can have a "Trivial setters" compact table at the bottom and link to per-page docs (`add-force.md`, `set-velocity.md`) for the nuanced ones.

The per-node template's Appendix A has the table-shape examples.

## Unity API references

Codegen nodes are thin wrappers around Unity API methods. Don't re-document the underlying math or component behavior — link to the official Unity ScriptReference page instead and let the doc focus on Flow-specific concerns (port wiring, Net behavior, footguns).

**Link convention.** The visible link text is just an external-link arrow `↗`, with a bold label preceding it for context. Unversioned ScriptReference URLs only — Unity updates `/ScriptReference/` in place; pinning to `6000.0` breaks readers on other editor versions.

```md
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html)
```

URL patterns — Unity uses different separators for methods and properties:

| API kind | URL pattern | Example |
|---|---|---|
| Static or instance **method** | `<Type>.<MethodName>.html` (dot, PascalCase method name) | `Vector3.Lerp.html`, `Rigidbody.AddForce.html` |
| **Property** (instance or static) | `<Type>-<propertyName>.html` (dash, **lowercase** first letter) | `Vector3-magnitude.html`, `Vector3-sqrMagnitude.html`, `Transform-position.html`, `Vector3-zero.html` |
| Type page | `<Type>.html` | `Rigidbody.html` |

Many codegen wrappers call the static-method form even when an instance property with identical semantics also exists (e.g., `Vector3.Magnitude(v)` vs. `v.magnitude`, `Vector3.SqrMagnitude(v)` vs. `v.sqrMagnitude`). For these, **link to the property page** — that's the canonical and more searchable Unity reference. Verify against the Unity docs before assuming `<Type>.<MethodName>.html` exists.

**Where to apply:**

- **Per-page codegen nodes** — one line in the meta block, directly under `**Component / Source:**`.
- **Compact-pattern tables** — add a `Unity ref` column to the table, one `[↗](url)` per row. Drop the column entirely if any row lacks a Unity equivalent (don't leave em-dashes).
- **Component overviews** (`Components/Animator/overview.md`, `Components/Rigidbody/overview.md`, etc.) — link the component class page once at the top: `**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.html)`.
- **Net variants** — link the same Unity method as the local variant. The underlying API is identical; the Net wrapper only changes how it's invoked. Note in the description that the Unity docs cover the underlying behavior, not the Net invocation model.
- **Hand-coded nodes** — skip. No Unity equivalent. This includes Branch, Delay, Select Event, Course actions, AI / Voice / SaveSystem / Interactables / Paint / Pulse / Flow Event raise-listen.

**`_v1` / `_v2` overload suffixes.** Unity puts all overloads of a method on one page, so both versioned variants link to the same URL. If the difference between overloads matters to creators (different parameter sets, different defaults), call out which overload in the doc body.

---

## Resolved decisions

These were open questions in an earlier draft, resolved against the actual `Nodes/` source tree (2026-05-08).

1. **Component list (`Components/`).** Confirmed: `Animator, AudioSource, Camera, Collider, Light, ParticleSystem, Renderer, Rigidbody, Transform, VideoPlayer`. No additional Caffeine-specific components warrant their own subfolder today. Generic non-component utility actions (DebugLog, Delay, FormatString, Cast, AddComponent, GetComponent, etc.) live under `Components/General/`.
2. **Course actions vs events — both exist.** Action-shaped course nodes (ExitCourse, ObjectiveCompletion, AtoBReset, course media/animation attachments) live under `Course/`. Event-shaped course nodes (CourseClickInteraction, CourseHoldInteraction, CourseTriggerInteraction, AtoBInteractionEnd, OnStepLoaded) live as siblings under `Events/`. Keep both; don't merge.
3. **Logic node list.** Branch, ForLoop, Foreach, ForeachGameObject, Switch, GenericSwitch, Comparison, Conditionals, Not, SplitFlow, TimedKick, EqualObjects, EqualGameObjects. Plus IsPlatform (currently `Nodes/Conditions/` in source — fold into the docs `Logic/` category, no separate `Conditions/` folder needed).
4. **Other event sources.** Input is its own top-level category (`Input/`), not under Events. Save-system events live under `SaveSystem/` next to their related actions. No timer/scheduling event nodes exist today (TimedKick is a Logic node, not an event).
5. **Function / subgraph nodes.** None. Cross-graph communication uses Flow Event raise/listen exclusively (`EdXR_RaiseEvent*Node` + `EdXR_EventListener*Node`). The `Signals/` category covers them.
6. **Math structure.** Vector3 etc. mix getters (Magnitude), reductions (Dot, Distance, Angle), and constructors (CrossProduct, Lerp). Default to compact pattern with per-page exceptions for any node with a non-obvious gotcha (e.g., LerpUnclamped's t > 1 behavior).
7. **Casing.** `Rigidbody` (one word, matches Unity).
8. **Tiny overview pages.** For folders with 1–3 nodes (e.g., Paint, Conditions/IsPlatform absorbed into Logic, Player/2D, Player/VR), the auto-generated category index is fine. Skip a hand-written `overview.md` and justify the omission in the handoff notes.

### How to suggest a structural change

Edit this file directly. Add a section under **Open questions** like:

```md
### Proposed change: <short title>
- **What:** ...
- **Why:** concrete reason — what's broken or what would be measurably better
- **Impacts:** URLs, other docs, templates, the parent CLAUDE.md
```

The structure is referenced from `edxr-docs/CLAUDE.md` and by both templates — don't change it unilaterally without flagging it here so the references can be updated together.
