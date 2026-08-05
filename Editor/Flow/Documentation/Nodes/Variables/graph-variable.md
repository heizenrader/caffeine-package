---
sidebar_position: 10
---

# Graph Variable

A typed variable scoped to the current graph. Created in the Variables panel of the Flow editor and dragged into the canvas to read or write its value. Same typed shape as [Local Variable](./local-variable), but the value persists for the lifetime of the graph rather than living on a single node.

When you drag a Graph Variable onto the canvas, a popup asks whether you want a **local** or **net** flavor — see [Local vs Net flavor](#local-vs-net-flavor) below.

**Category:** Variable
**Kind:** Variable accessor (graph scope)

:::note Not in the Add Node menu
Graph Variables are created via the **Variables panel** in the Flow editor, not via right-click → Add Node. Drag the variable from the panel onto the canvas to spawn a read / write node bound to it; multiple drag instances all reference the same underlying value.
:::

## Behavior

The Variables panel lets you declare a typed variable (Bool / Int / Float / String / Vector2/3/4 / Quaternion / Color / Long) with a name and starting value. Each drag of the variable creates a node that reads from / writes to the same storage. When the node runs, the connected typed input (or inspector default) is written; the typed output reads the current value on demand.

## Local vs Net flavor

Each time you drag a Graph Variable onto the canvas, a popup asks which flavor to create:

- **Local** — writes stay on the current client. Use for client-local state (per-client animation phase, view-toggle state, in-progress UI selections that don't need to replicate).
- **Net** — writes replicate to every player in the session. When any client kicks the node, the new value is broadcast and `exit` fires on every client. Use for shared state (course progress, accumulated scores, multi-step puzzle state).

Both flavors share the same Inputs, Outputs, and Inspector parameters described below.

:::warning Every Net write is broadcast
Each kick of the Net flavor produces a network message. Don't put one inside a tight Update loop — gate writes behind a [Comparison](/docs/Flow/Nodes/Logic/comparison) so only meaningful changes go over the network.
:::

## Inputs

The `inputGraphVariable(Type)Value` port matching the variable's declared `Type`. When connected, the connected value is written on each kick; when unconnected, the inspector default is written.

## Outputs

The `(type)GraphVariableValue` port matching the variable's `Type`. Reads the current stored value.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| inputGraphVariable(Type)Value | Typed | Default value written when the input port is unconnected. |

:::tip Prefer Graph Variables over Locals for shared state inside one graph
When two parts of the same graph need the same value (e.g. a counter you increment in one branch and read in another), Graph Variable is the right scope — declare once in the panel, drop the variable in both places. Reach for [Local Variable](./local-variable) only when the value is genuinely per-node.
:::

:::note Deleting a graph variable cleans up its nodes
Removing a variable from the Variables panel automatically removes any nodes on the canvas that referenced it — no manual cleanup needed.
:::

## See also

- [Graph GameObject Variable](./graph-gameobject-variable) — graph-scoped GameObject reference
- [Local Variable](./local-variable) — node-scoped variant
- [Net Variable](./net-variable) — node-scoped variant with its own Add Node menu entry
- [Global Variable](./global-variable) — project-scoped variant (also has Local / Net flavors)
- [Networking in Flow](/docs/Flow/flow-networking) — when to pick Net flavors over local
