---
sidebar_position: 12
---

# Graph GameObject Variable

A GameObject reference scoped to the current graph. Like [Graph Variable](./graph-variable), but specialized to hold a GameObject — declared in the Variables panel, dragged into the canvas to spawn read / write nodes that share the same storage.

**Category:** Variable
**Kind:** Variable accessor (graph scope)

:::note Not in the Add Node menu
Created via the Variables panel and dragged onto the canvas. Multiple drag instances all reference the same GameObject storage on the graph.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| inputGameObjectVariable | GameObject | When connected, the connected reference is written on each kick. When unconnected, the inspector default is written. |

## Outputs

| Port | Type | Description |
|---|---|---|
| outputGameObjectVariable | GameObject | The currently stored reference. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| inputGameObjectVariable | GameObject | Default reference written when the input port is unconnected. |

## See also

- [GameObject](./gameobject) — node-local variant
- [Global GameObject](./global-gameobject) — project-scoped variant
- [Self](./self) — the GameObject hosting the graph
- [Graph Variable](./graph-variable) — typed (non-GameObject) graph-scoped variable
