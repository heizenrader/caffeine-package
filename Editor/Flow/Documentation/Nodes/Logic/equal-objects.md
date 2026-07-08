---
sidebar_position: 11
---

# Equal Objects

Compares two Unity object references for identity — outputs `true` when both inputs reference the same object. Accepts any `UnityEngine.Object` (Material, Texture, Component, GameObject, etc.).

**Category:** Variable
**Kind:** Operation (predicate)

## Inputs

| Port | Type | Description |
|---|---|---|
| objectA | Object | The first reference. |
| objectB | Object | The second reference. |

## Outputs

| Port | Type | Description |
|---|---|---|
| equal | Bool | `true` when both inputs reference the same Unity object. `false` when they differ or when either is `null`. |

:::note Identity, not value-equality
This node compares object references — it returns `true` only when both inputs point to the *same* Unity object. Two separate Material assets with identical settings, for example, return `false`.
:::

## See also

- [Equal GameObjects](./equal-game-objects) — typed variant for GameObject references specifically
- [Comparison](./comparison) — value-based comparison for primitives and structs
