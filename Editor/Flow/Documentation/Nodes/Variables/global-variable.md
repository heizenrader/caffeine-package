---
sidebar_position: 8
---

# Global Variable

Wraps a typed **Global Variable** ScriptableObject asset (`Caffeine/Flow/Variables/Global Variable`). The asset stores the value outside any graph, so multiple graphs across the project can share and mutate the same value.

When you drag a Global Variable asset onto the canvas, a popup asks whether you want a **local** or **net** flavor — see [Local vs Net flavor](#local-vs-net-flavor) below.

**Category:** Variable
**Kind:** Variable accessor (global scope)

## Creating a Global Variable

Right-click in the Project window → `Create > Caffeine > Flow > Variables > Global Variable`. Set the asset's `Type` and starting `value`. Drag the asset onto a Flow Graph canvas to spawn a read / write node bound to it.

## Behavior

Same typed input / output shape as [Local Variable](./local-variable) — the asset's `Type` determines which input and output pair is active. The difference is the storage location: writes go to the wrapped asset (and persist with it), reads come from the asset (so updates from any graph are visible immediately).

## Local vs Net flavor

Each time you drag a Global Variable asset onto the canvas, a popup asks which flavor to create:

- **Local** — writes stay on the current client. Use for client-local state.
- **Net** — writes replicate to every player in the session. When any client kicks the node, the new value is broadcast and `exit` fires on every client. Use for shared state across players.

Both flavors share the same Inputs, Outputs, and Inspector parameters described below.

:::warning Every Net write is broadcast
Each kick of the Net flavor produces a network message. Don't put one inside a tight Update loop — gate writes behind a [Comparison](/docs/Flow/Nodes/Logic/comparison) so only meaningful changes go over the network.
:::

## Inputs

The `input(Type)Value` port matching the asset's `Type`. Same shape as Local Variable — when connected, the connected value is written to the asset on each kick; when unconnected, the inspector default is written.

## Outputs

The `(type)Value` port matching the asset's `Type`. Reads the asset's current value on demand.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| globalVariable | Global Variable asset | The external asset this node reads / writes. The asset's `Type` field controls which input / output pair this node renders. |
| input(Type)Value | Typed | Default value written when the input port is unconnected. |

:::warning Asset values persist between play sessions
Changing a Global Variable's value at runtime mutates the asset on disk in the editor (since assets are reference types). When you stop play mode, the value stays at whatever the last write was. Reset defaults manually if you depend on a known starting value.
:::

## See also

- [Local Variable](./local-variable) — node-local variant
- [Net Variable](./net-variable) — node-local variant with its own Add Node menu entry
- [Graph Variable](./graph-variable) — graph-scoped variant (also has Local / Net flavors)
- [Global GameObject](./global-gameobject) — global-scoped GameObject reference
- [Networking in Flow](/docs/Flow/flow-networking)
