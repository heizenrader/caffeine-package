---
sidebar_position: 4
---

# GameObject

A node-local GameObject reference holder. Set the reference on the inspector or wire one in via the input port — when the node runs, it stores the value, and the output emits whatever it last stored.

Use it to cache a frequently-referenced GameObject in a clean spot, or to provide a fallback default that downstream nodes can override at runtime.

**Category:** Variable
**Kind:** Variable accessor (local scope)

## Inputs

| Port | Type | Description |
|---|---|---|
| inputGameObject | GameObject | When connected, the connected value is stored when the node runs. When unconnected, the inspector field's value is used. |

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The currently stored reference. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| inputGameObject | GameObject | Default reference used when nothing is connected to the input port. |

:::note Local scope
Each GameObject node stores its own reference — two GameObject nodes wired to the same source don't share state. For cross-graph or cross-node sharing, use [Global GameObject](./global-gameobject) instead.
:::

## See also

- [Global GameObject](./global-gameobject)
- [Self](./self)
- [Graph GameObject Variable](./graph-gameobject-variable) — for a graph-scoped variant managed via the Variables panel
