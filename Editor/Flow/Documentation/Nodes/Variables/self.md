---
sidebar_position: 3
---

# Self

Returns the GameObject the current graph is running on. Use it whenever an action needs to act on its own host (toggle the GameObject's renderer, query its transform, reparent itself).

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject hosting this Flow Graph. |

:::tip Pair Self with component getters
For most "act on me" patterns, wire `Self` into a [Get Component](/docs/Flow/Nodes/Components/General/overview) node to grab the specific component (Rigidbody, Renderer, Animator) you want to act on.
:::

## See also

- [GameObject](./gameobject) — for storing a reference to a *different* GameObject
- [Global GameObject](./global-gameobject) — for sharing a GameObject reference across graphs
