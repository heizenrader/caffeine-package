---
sidebar_position: 3
---

# Is Collider Type

Tests whether a collider is a specific shape — Box, Sphere, Capsule, or Mesh — and outputs the result as a Bool. Use it to branch before reading or writing shape-specific properties.

**Category:** Variable
**Kind:** Predicate

## Inputs

| Port | Type | Description |
|---|---|---|
| inputCollider | Collider | The collider to test. Accepts any collider subtype. |

## Outputs

| Port | Type | Description |
|---|---|---|
| outputBool | Bool | `true` if the collider is the selected `Type`, otherwise `false`. The port is labelled to match the selection (e.g. "Is Capsule"). An unwired or destroyed collider reports `false`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type | Enum&lt;ColliderType&gt; | The shape to test for — Box, Sphere, Capsule, or Mesh. |

:::tip Guard shape-specific reads
[Get Collider Property](./get-collider-property) and [Set Collider Property](./set-collider-property) already no-op on a shape mismatch, but wiring Is Collider Type into a [Branch](/docs/Flow/Nodes/Logic/branch) lets you take a different path entirely — for instance, only resize colliders that are actually boxes.
:::

## See also

- [Get Collider Property](./get-collider-property)
- [Set Collider Property](./set-collider-property)
- [Branch](/docs/Flow/Nodes/Logic/branch) — act on the Bool result
