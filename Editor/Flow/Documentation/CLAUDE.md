# CLAUDE.md — Flow Node Documentation

This folder is a **staging area** for Flow node documentation. Files written here are eventually copy-pasted into the `edxr-docs` Docusaurus repo at `docs/Flow/Nodes/`. The other agent that owns `edxr-docs` is responsible for site rendering and integration; this folder is the authoring side.

The rulebook for *what* to write and *how* the folder is laid out is `templates/flow-nodes-structure.md` — read it before authoring. This CLAUDE.md covers *how to extract correct information from the Flow source* and the conventions specific to this staging folder.

**Progress tracking:** [`PROGRESS.md`](PROGRESS.md) is the source of truth for what's documented vs pending. **Read it before starting a batch** to pick what to work on, and **update it after completing a batch** (mark items done, update the "Last scan" date if you re-grep the source). It does not ship to edxr-docs — only `Nodes/` gets copied across.

Paths in this file are relative to `Packages/caffeine/Editor/Flow/`.

## Source of truth

Node implementations live at `Nodes/`. Each documented node maps to a C# class there. Authors should always read the source class (and its `*NodeEditor.cs` if present) before writing a doc — the source is canonical, the doc is derived.

| Doc category | Primary source folders |
|---|---|
| **Events** | `Nodes/Events/` (lifecycle + interaction events), `Nodes/Events/Course Events/` (Course-triggered events), `Nodes/NetNodes/Events/` (Net counterparts) |
| **Components** (per-thing-touched) | `Nodes/CodeGenerated/<Component>/` (codegen variants), `Nodes/Actions/<Component>/` (hand-coded specializations). Most subfolders map to a Unity component; a few group Caffeine subsystems (XR, Analytics, Viewer) or non-component utilities (General, Lists, String). Holds both Action nodes (Flow ports) and pure-data queries (no Flow ports). |
| **Components / General** | `Nodes/Actions/EdXR_*Node.cs` files at the top level — **only the true Actions**: Debug Log, Delay, Cursor Settings, Unity Event, Rotate, Translate, GameObject Lerp, Transform Lerp. |
| **Utilities** | `Nodes/Actions/EdXR_*Node.cs` top-level files that are **pure-data utilities** (or paired Get/Set): Cast, Create Vector 2/3, Format String, Get Axis, Get/Set Property, Get/Set GameObject Property, Get/Set Component Property, Get Variable Property. Source still lives under `Nodes/Actions/` but docs live under `Utilities/`. |
| **Math** | `Nodes/CodeGenerated/{Mathf,Color,Quaternion,Vector2,Vector3,Vector4}/` |
| **Variables** | `Nodes/Variables/`, `Nodes/Variables/Collections/`, `Nodes/Variables/Random/`, `Nodes/NetNodes/Variables/` |
| **Logic** | `Nodes/Logic/`, `Nodes/Conditions/` |
| **Signals** (cross-graph raise/listen) | `Nodes/Events/EdXR_RaiseEvent*Node.cs` + `EdXR_EventListener*Node.cs` (source still uses "Flow Event"; docs group as Signals to disambiguate from scene-driven Events) |
| **Course** (actions) | `Nodes/Actions/Course/` (docs live under `Course/`) |
| **AI** | `Nodes/AI/` |
| **Input** | `Nodes/Input/` |
| **Interactables** | `Nodes/Interactables/` |
| **Voice** | `Nodes/Voice/` |
| **Save System** | `Nodes/SaveSystem/` |
| **System** | `Nodes/System/Time/`, `Nodes/System/Performance/` |
| **Paint** | `Nodes/Paint/` |
| **Pulse** (physiology) | `Nodes/Pulse/` |
| **Player** | `Nodes/Player/2D/`, `Nodes/Player/VR/` |

`Nodes/Notes/NoteNode.cs` is a graph-annotation widget, not a runtime node — **do not document**. Skip any class without `[CreateNodeMenu(...)]` and any class whose only role is a base/abstract type.

## Reading a node class

To produce one doc page, gather the following from the source:

### 1. Menu path & category

```csharp
[CreateNodeMenu("Flow/Logic/Branch")]
[Node.CreateNodeMenuAttribute("Flow/Logic/Branch")]   // older syntax, same effect
```

The string after the leading `Flow/` segment is the **canonical Add-Node menu path** creators see in the editor. Match the doc category (and the doc page title) to the last segment. Net nodes use `Flow/Networking/...` — strip `Networking/` and treat them as Net variants of their non-Net counterpart. If the class has no `CreateNodeMenu` attribute, it is internal — skip it.

### 2. Class hierarchy (tells you the node shape)

| Base class | Means |
|---|---|
| `EdXR_UpdatableNode` | Updatable: has implicit `entry`/`exit` `EventPort`s wired to the standard Flow input/output. Document any *additional* output EventPorts (e.g., Branch's `True`/`False`) but don't restate the standard Flow port — the Events/Components overview already covers it. |
| `EdXR_Node` | Pure data node: no Flow input/output, just data ports. |
| `EdXR_EventNode` | Event entry point: emits Flow but doesn't consume one. Has an `Enabled` input. |
| `EdXR_NetNode` / `EdXR_NetUpdatableNode` / `EdXR_NetActionNode` / `EdXR_NetEventNode` | Net variant — see the Net section below. |
| `EdXR_Variable` / `EdXR_NetVariable` | Variable (graph-scoped or net-replicated). |

### 3. Ports

```csharp
[Input(backingValue = ShowBackingValue.Unconnected, connectionType = ConnectionType.Override)]
public bool condition;                // → Inputs row: condition / Bool

[Output(typeConstraint = TypeConstraint.Strict, connectionType = ConnectionType.Override)]
public EventPort True, False;         // → Outputs rows: True / Flow, False / Flow
```

Mapping rules:
- **Field type → port type column.** Map C# types to the doc table vocabulary: `bool→Bool`, `int→Int`, `float→Float`, `string→String`, `GameObject→GameObject`, `Vector3→Vector3`, `Quaternion→Quaternion`, `Transform→Transform`, `EventPort→Flow`, `List<T>→List<T>`, generic `UnityEngine.Object→Object`, enums→`Enum<EnumName>`.
- **Field name → port name column.** Use the field name as written; don't lowercase it.
- **Don't restate** `entry`/`exit` `EventPort`s on `EdXR_UpdatableNode` subclasses — they're the standard Flow in/out, covered by the category overview. Do document additional EventPorts (Branch's True/False, ForLoop's iteration/done).
- **`ShowBackingValue.Unconnected`** means a default-value field is shown next to the port until something connects to it. Mention the default in the description if it's meaningful.
- **`ShowBackingValue.Never`** means port-only, no inline default field.
- **`TypeConstraint.Strict`** means the port only accepts an exact type match. **`TypeConstraint.None`** means upcast/downcast is allowed. This rarely matters to creators; skip it from docs unless a connection rule is surprising.

### Standard Flow ports are implicit on Action nodes

Every `EdXR_UpdatableNode` subclass inherits an `entry` Flow input and an `exit` Flow output. **Do not list them in per-page Inputs/Outputs tables** — the convention is documented once in `Components/overview.md`. Per-page docs only call out *additional* Flow ports.

Quick rules:

- **Action / Updatable**: skip standard `entry`/`exit`. List only data ports and ADDITIONAL Flow outputs (e.g. `speakComplete`, `True`/`False`, `partialTranscription`/`fullTranscription`). When listing additional Flow outputs, add a `:::note Standard Flow output` admonition explaining when `exit` fires vs. when the named port fires — this prevents the common "wired exit thinking it'd run after TTS finishes" footgun.
- **Event**: events have no Flow input (they kick the flow, they don't consume one). List the `Enabled` Bool input and any data inputs. Always list Flow output(s) — they're the node's purpose. Display the type as "Flow" even when the underlying field is named `entry`.
- **Pure data** (`EdXR_Node`): no Flow ports at all. Data inputs and outputs only.

Full pattern (with the admonition template) is in `templates/flow-nodes-structure.md` under "Standard Flow ports — implicit on Action nodes".

### Some creator-facing nodes lack `[CreateNodeMenu]`

The earlier guidance "skip classes without `[CreateNodeMenu]`" was too strict. Several real creator-facing nodes (e.g. `EdXR_TTSNode`, `EdXR_StopTTSNode`, `EdXR_VoiceDicationNode`) have no `[CreateNodeMenu]` attribute yet appear in the Add Node menu via xNode's namespace-based fallback. **Verify against the editor's Add Node menu, not just the attribute.** If unsure whether to document a class, search the codebase for usages or check whether the user can add it in the Flow editor.

## Classifying nodes

Before documenting a node, identify two things — its **port shape** (from the base class) and its **conceptual kind** (what creators perceive the node as doing). The combination determines doc placement, section structure, Unity URL form, and whether to apply the Properties/Operations split.

### Port shape (from base class)

| Base class | Has Flow input? | Has Flow output? | Doc treatment |
|---|---|---|---|
| `EdXR_UpdatableNode` | implicit `entry` | implicit `exit` (+ optional named extras) | Skip standard ports; list additional Flow outputs with a `:::note` admonition contrasting their timing with `exit` |
| `EdXR_EventNode` | none — events kick the flow, they don't consume one. List `Enabled` Bool input. | one or more — explicit, the node's purpose | List Flow output(s) explicitly. Display type as "Flow" even when the field is `entry`. |
| `EdXR_Node` | none | none | Pure data — list data ports normally, no Flow ports anywhere |
| `EdXR_NetXxx` | depends on which one of the above it extends | depends | Always per-page, even when the local counterpart is trivial. Source layout (`NetNodes/...`) ≠ docs layout (sibling with `net-` prefix). |
| `EdXR_Variable` / `EdXR_NetVariable` | none | none | Variable accessor — getter/setter pattern, document the value type and scope (graph / global / net) |

### Conceptual kind

| Kind | What it does | Examples | Typical port shape | Unity URL form (if applicable) |
|---|---|---|---|---|
| **Action** | Performs an effect | TTS, Stop TTS, Play, AddForce, DebugLog, Delay | Updatable | `Type.Method.html` |
| **Property** | Reads a derived value off a single input | Vector3 Magnitude, SqrMagnitude, Normalize; Transform position | Pure data | `Type-property.html` (dash, lowercase first letter) |
| **Operation** | Computes a value from two or more operands | Vector3 Lerp, Cross, Dot; Mathf Sin, Pow; Color Lerp | Pure data | `Type.Method.html` (dot, PascalCase) |
| **Constructor / factory** | Assembles a value from primitives | Create Vector3 (x,y,z), Create Vector2 | Pure data | usually a constructor — `Type-ctor.html` |
| **Predicate** | Returns a Bool from a query | IsPlatform, IsHandTracking, IsInteractable, IsBeingHeld | Pure data | varies |
| **Event** | Fires when something happens | Select Event, Update, OnStepLoaded, Course Click Interaction | Event | n/a |
| **Listener** | Receives a Flow Event raised elsewhere | Event Listener, Event GameObject Listener, Event Variable Listener | Event | n/a |
| **Raiser** | Emits a Flow Event for listeners | Raise Event, Raise Event GameObject, Raise Event Variable | Updatable | n/a |
| **Variable** | Reads/writes a stored value | Graph Variable, Global Variable, Graph GameObject Variable | Variable | n/a |

### Implications for bulk authoring

- **The codegen menu path `Flow/Actions/<Type>/` is misleading** for value-type wrappers (Vector3, Vector2, Vector4, Quaternion, Color, Mathf). Those nodes are **pure data**, not Action nodes — they have no Flow ports. Categorize them under `Math/`, never under `Components/`.
- **The same goes for engine-level pure-data utilities** (Cast, Create Vector, Format String, Get Axis, generic Get/Set Property family) — their source lives in `Nodes/Actions/` but docs go under `Utilities/`, not `Components/`. The `Components/` folder is for nodes that bind to a specific Unity component.
- **Compact tables for Vector/Color/Quaternion overviews split into Properties + Operations sub-tables.** Properties use `Type-property.html` URLs, Operations use `Type.Method.html` URLs. The split also surfaces the "free getters" subset for creators who just want a derived value. Mathf is all static methods — single-table is fine. Color/Quaternion will mix both like Vector3.
- **Predicates implemented as Updatable nodes** (rare in Caffeine — most are pure data) keep the Action treatment: implicit standard Flow ports, predicate result on a Bool output port.
- **For Net variants, port shape is determined by which `EdXR_NetXxx` base they extend** (`EdXR_NetNode`, `EdXR_NetUpdatableNode`, `EdXR_NetActionNode`, `EdXR_NetEventNode`). The conceptual kind is the same as the local variant's.

When documenting a node, write its kind in the doc's meta block (`**Category:** Action`, `**Kind:** Property`, etc.) so the classification is visible to readers. The current per-node template uses `**Category:**` for this — for value-type wrappers, prefer `**Kind:** Property` or `**Kind:** Operation` over the generic `Action` label.

### 4. Inspector parameters

Public fields **without** an `[Input]` or `[Output]` attribute are inspector-only — they appear on the node body, not as ports. Examples include enum selectors:

```csharp
[NodeEnum]                           // Odin attribute → enum dropdown on the node body
public SelectEventType eventType;    // → Inspector parameters row: eventType / Enum<SelectEventType>
```

These need their own row in the **Inspector parameters** table. Many docs miss them — verify by scanning all public fields, not just port-attributed ones.

**Don't document system-internal ID fields.** Fields that only exist for the runtime/networking layer to route or reconcile state are **not creator-editable** and must not appear in docs. Examples: `idString` on Net nodes, `graphVariableID` / `graphGameObjectVariableID` on graph variables, `stepIndex` / `*InteractionIndex` on Course event nodes that are bound to a specific interaction. These are auto-populated; surfacing them as parameter rows implies the creator can edit them, which is wrong. Omit the row entirely. If unsure, ask.

### 5. Custom editor logic

Each node usually has a sibling `*NodeEditor.cs` file. It almost never changes inputs/outputs/parameters, but it can add custom layout (extra labels, dropdowns wired to non-trivial logic) or hide fields. If the editor file is non-trivial, scan it for fields that the inspector renders that aren't on the node class itself.

## Net variants

Source layout puts Net variants under their own root: `Nodes/NetNodes/Events/`, `Nodes/NetNodes/Actions/`, `Nodes/NetNodes/Variables/`, `Nodes/NetNodes/MonoBehaviours/`. Documentation layout flattens this — Net pages live **next to their local counterpart** with a `net-` prefix:

```
Documentation/Nodes/Events/select-event.md
Documentation/Nodes/Events/net-select-event.md
```

When documenting a Net node:
- Find its non-Net counterpart in the matching `Nodes/<category>/` folder. The class names usually pair as `EdXR_<Name>Node` ↔ `EdXR_Net<Name>Node`.
- Apply the Net heading + frontmatter pattern from `templates/flow-nodes-structure.md` (purple `.net-node` span, `NET` badge, `sidebar_label`/`title` overrides).
- Cross-link both pages in their "See also" sections.
- If a node has only a Net version (no local counterpart), skip the prefix — name it normally — but flag it in chat so we can reconsider category placement.

### Exception — popup-driven Net flavors

Some Net variants aren't standalone node types creators pick from a separate menu — they're a flavor selected by a popup when the user drags a Local equivalent onto the canvas. Examples in Caffeine:

- **Global Variable** — drag the asset from the Project window → popup asks Local or Net.
- **Graph Variable** — drag from the Variables panel → popup asks Local or Net.

For these, **don't create a separate `net-<name>.md` page**. Document both flavors on the parent page (`global-variable.md`, `graph-variable.md`) with a `## Local vs Net flavor` section explaining the popup choice. The Net flavor's `idString` and similar network-routing internals are **not creator-facing** — do not list them as inspector parameter rows (see "Don't document system-internal ID fields" below).

Distinguishing rule: if the Net variant has its own `[CreateNodeMenu(...)]` entry that creators see in the Add Node menu (e.g., `Flow/Networking/Variable/Net Variable`), it gets its own page. If it's only created via drag-and-popup, fold it into the parent.

## Code-generated nodes — use the compact pattern

`Nodes/CodeGenerated/` contains hundreds of node files generated from templates in `NodeTemplates/`. Each file maps one Unity component method (or struct method) to a node. Examples:
- `CodeGenerated/Vector3/EdXR_Vector3LerpNode.cs` ← `Vector3.Lerp(...)`
- `CodeGenerated/Mathf/EdXR_MathfAbsNode.cs` ← `Mathf.Abs(...)`
- `CodeGenerated/Rigidbody/EdXR_RigidbodyAddForceNode.cs` ← `Rigidbody.AddForce(...)`

**Default rule:** do **not** create one doc page per variant. Document the family on the parent `overview.md` with a table (see `templates/flow-node-template.md` Appendix A and `templates/flow-nodes-structure.md` "Compact pattern"). Create individual pages only for variants with non-trivial behavior worth calling out.

Versioned variants (`EdXR_MathfAbsNode_v1.cs`) are migration artifacts — document the latest version only and ignore `_v*` suffixes unless a creator-visible difference exists.

## Workflow for adding one node

1. Find the source class in `Nodes/`.
2. Read its `[CreateNodeMenu]`, base class, port fields, and inspector fields. Skim its `*NodeEditor.cs`.
3. Pick the doc category folder under `Documentation/Nodes/<Category>/` (using the table at the top of this file).
4. Copy `templates/flow-node-template.md` to `<slug>.md` (kebab-case from the menu name).
5. Fill in the template; strip every `{/* ... */}` block.
6. Add a row to the parent `overview.md`'s "Nodes" table.
7. If a Net counterpart exists, repeat for `net-<slug>.md` and cross-link.
8. Run through the handoff checklist in `templates/flow-nodes-structure.md` before declaring it done.

## Workflow for adding many nodes / a whole category

When bulk-authoring, batch by source folder so you only context-switch once per component:

1. Pick a source folder (e.g., `Nodes/CodeGenerated/Rigidbody/`).
2. Read its parent doc folder (`Documentation/Nodes/Components/Rigidbody/`) — create `_category_.json` and `overview.md` if missing.
3. Decide compact vs. per-page for each variant (default to compact for codegen, per-page for hand-coded).
4. Author all pages, then update the overview table at the end.

## Conventions specific to this staging folder

- **Stay self-contained.** This folder gets copy-pasted into `edxr-docs`. Don't link out to anything in this Caffeine repo — paths like `../../Nodes/...` will break the moment the folder ships.
- **Internal cross-links** use absolute Docusaurus paths (`/docs/Flow/Nodes/Events/select-event`) or relative-to-doc paths (`./net-select-event`). Never relative-to-disk.
- **Keep `.meta` files in place.** Unity needs them to track the assets; they don't make it into Docusaurus (the integration step strips them).
- **No `{/* ... */}` author comments** in shipped pages — those live only in templates.
- **Don't paste source code into docs.** Describe the node, don't transcribe its implementation. The exception is illustrating a port type or an inspector enum where the C# enum members are part of the contract.
- **Voice and style** match the existing Flow docs (`flow-intro.md`, `flow-events.md`) — second person, short paragraphs. The templates have a style cheatsheet appendix.

## Reference

- [`templates/flow-nodes-structure.md`](templates/flow-nodes-structure.md) — folder layout, Net pattern, handoff checklist, open questions
- [`templates/flow-node-template.md`](templates/flow-node-template.md) — per-node page template
- [`templates/flow-node-overview-template.md`](templates/flow-node-overview-template.md) — category/subcategory overview template
- [`../CLAUDE.md`](../CLAUDE.md) — Flow architecture (xNode fork, port reconciliation, codegen, conventions)
- [`../../CLAUDE.md`](../../CLAUDE.md) — Caffeine package overview
