---
sidebar_position: 2
---

# Set Collider Property

Writes a single property on a collider — resize a box, retune a capsule, flip a collider to a trigger, or enable/disable it. Pick the collider shape and the property in the inspector; the node shows one input port typed to match, editable inline or wired from another node.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| inputCollider | Collider | The collider to modify. Accepts any collider subtype. |
| (Vector3 / Float / Int / Bool) | matching the property | The value to write. The active port matches the selected `Property`. Edit it inline when nothing is connected, or wire a source to override the inline value. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type     | Enum&lt;ColliderType&gt; | The collider shape you're targeting — Box, Sphere, Capsule, or Mesh. Filters the `Property` dropdown. |
| Property | Dropdown                 | Which property to write (see the table below). |

### Writable properties by collider type

| Property | Value type | Available on |
|---|---|---|
| Size       | Vector3 | Box |
| Center     | Vector3 | Box, Sphere, Capsule |
| Radius     | Float   | Sphere, Capsule |
| Height     | Float   | Capsule |
| Direction  | Int     | Capsule — axis the height runs along (`0` = X, `1` = Y, `2` = Z). Clamped to that range. |
| Convex     | Bool    | Mesh |
| Enabled    | Bool    | Any collider |
| Is Trigger | Bool    | Any collider |

:::note Type is a shape filter, not a hard cast
`Type` decides which properties are offered and which port type appears, but the write runs against the collider's **actual** runtime type. If the wired collider isn't the selected shape, the write is a safe no-op — nothing changes and no error is raised. `Enabled` and `Is Trigger` apply to any collider.
:::

:::note Bounds can't be set
A collider's bounds are derived from its shape and transform, so they're read-only. They appear on [Get Collider Property](./get-collider-property) but not here.
:::

## See also

- [Get Collider Property](./get-collider-property) — read the same properties
- [Is Collider Type](./is-collider-type) — confirm the shape before writing
- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — generic property writes on any component
