---
sidebar_position: 0
sidebar_label: Overview
---

# Variable Nodes

Variable nodes hold and pass values around your Flow Graph — references to GameObjects, typed primitives (Bool / Int / Float / String / Vector2/3/4 / Quaternion / Color / Long), lists, and engine-provided readouts like `Time.deltaTime`.

Variables come in several **scopes**, each with the same conceptual shape but a different storage location and lifetime:

| Scope | Where the value lives | Lifetime | Net flavor |
|---|---|---|---|
| **Local Variable**   | On the node itself | Per node instance — distinct values for every copy of the node in the graph. | [Net Variable](./net-variable) — separate Add Node menu entry |
| **Global Variable**  | In a `Caffeine/Flow/Variables/Global Variable` ScriptableObject asset | Persists across graphs and play sessions (until you change the asset). Many graphs can read / write the same global. | Drag-time popup — covered on the [Global Variable](./global-variable) page |
| **Graph Variable**   | In the Variables panel of the current graph (scene-graph asset) | Persists for the lifetime of the graph. Created in the Variables panel, dragged into the canvas to create read / write nodes. | Drag-time popup — covered on the [Graph Variable](./graph-variable) page |

GameObject references have parallel scopes:

| Scope | Node |
|---|---|
| Local (inline reference) | [GameObject](./gameobject) |
| Global (external asset)  | [Global GameObject](./global-gameobject) |
| Graph (panel-driven)     | [Graph GameObject Variable](./graph-gameobject-variable) |
| The hosting GameObject   | [Self](./self) |

## How typed variables work

The Local / Global / Graph variants all share one shape: pick a **Type** in the inspector (Bool / Int / Float / String / Vector2 / Vector3 / Vector4 / Quaternion / Color / Long), and only the input and output ports matching that type become active in the editor.

- Reading the variable: wire the **typed output** (e.g. `floatValue` when Type is Float) into a downstream port.
- Writing the variable: connect a value into the **typed input** (e.g. `inputFloatValue`) and kick the node — the new value replaces the stored one.

Per-page docs describe the read / write shape conceptually rather than listing all ten input pairs; only the pair matching the configured Type appears in the editor.

## Net flavors

Net variables replicate writes to every player in a multiplayer session. When any client kicks the node, the new value is broadcast and `exit` fires on every client. Use Net flavors for any value that should be consistent across players (score, current step, selected option). Use the local versions for client-local state (input echo, animation timers, view preferences).

How Net flavors are created depends on the scope:
- [**Net Variable**](./net-variable) — its own Add Node menu entry under `Flow/Networking/Variable/`. Pick it directly.
- [**Global Variable**](./global-variable) and [**Graph Variable**](./graph-variable) — when you drag the asset (Global) or panel entry (Graph) onto the canvas, a popup asks whether to create a local or net flavor. Both flavors are documented on the parent page.

## Nodes

| Node | Description |
|---|---|
| [Delta Time](./delta-time)                              | `Time.deltaTime` — seconds since the last frame. |
| [Fixed Delta Time](./fixed-delta-time)                  | `Time.fixedDeltaTime` — seconds per fixed-update tick. |
| [Self](./self)                                          | The GameObject the graph is running on. |
| [GameObject](./gameobject)                              | A node-local GameObject reference holder. |
| [Global GameObject](./global-gameobject)                | Wraps an external GameObject asset for cross-graph sharing. |
| [Local Variable](./local-variable)                      | A typed value stored on the node. |
| [Net Variable](./net-variable)                          | Networked counterpart of Local Variable, with its own Add Node menu entry. |
| [Global Variable](./global-variable)                    | Wraps an external typed-variable asset. Has Local and Net flavors selected via drag-time popup. |
| [Graph Variable](./graph-variable)                      | Typed variable scoped to the current graph (drag from the Variables panel). Has Local and Net flavors selected via drag-time popup. |
| [Graph GameObject Variable](./graph-gameobject-variable)| GameObject variable scoped to the current graph. |
| [GameObject List](./gameobject-list)                    | A list of GameObjects, mutable at runtime. |
| [Component List](./component-list)                      | A list of components, mutable at runtime. |
| [Random](./random)                                      | Random Float between two bounds. |

## See also

- [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object) — iterate a GameObject List
- [Networking in Flow](/docs/Flow/flow-networking) — when to pick Net variants over local
- [Math overview](/docs/Flow/Nodes/Math/overview) — operations on the typed values you store in variables
