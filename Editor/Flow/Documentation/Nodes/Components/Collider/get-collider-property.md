---
sidebar_position: 1
---

# Get Collider Property

Reads a single property off a collider — its size, radius, center, world-space bounds, trigger state, and more. Pick the collider shape and the property in the inspector; the node exposes one output port typed to match.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| inputCollider | Collider | The collider to read. Accepts any collider subtype (Box, Sphere, Capsule, Mesh). |

## Outputs

The active output port matches the selected `Property` — the editor draws only that one, labelled with the property name.

| Port | Type | Description |
|---|---|---|
| (Vector3 / Float / Int / Bool) | matching the property | The property value, or the type's default (zero / `false`) when the collider is unwired, destroyed, or isn't the shape the property belongs to. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type     | Enum&lt;ColliderType&gt; | Which collider shape you're targeting — Box, Sphere, Capsule, or Mesh. Filters the `Property` dropdown to the properties that shape supports. |
| Property | Dropdown                 | Which property to read. The choices depend on `Type` (see the table below). |

### Properties by collider type

| Property | Output type | Available on |
|---|---|---|
| Size                 | Vector3 | Box |
| Center               | Vector3 | Box, Sphere, Capsule |
| Radius               | Float   | Sphere, Capsule |
| Height               | Float   | Capsule |
| Direction            | Int     | Capsule — the axis the height runs along (`0` = X, `1` = Y, `2` = Z) |
| Convex               | Bool    | Mesh |
| Bounds → Center / Size / Extents / Min / Max | Vector3 | Any collider — the world-space axis-aligned bounding box (read-only) |
| Enabled              | Bool    | Any collider |
| Is Trigger           | Bool    | Any collider |

:::note Type is a shape filter, not a hard cast
`Type` decides which properties the dropdown offers and which port type appears. The read itself runs against the collider's **actual** runtime type. If the wired collider isn't the selected shape (for example `Type` is Box but a Sphere Collider is connected), a shape-specific read like Size just returns the default value — a safe no-op, never an error. `Bounds`, `Enabled`, and `Is Trigger` work on any collider regardless of `Type`.
:::

:::tip Bounds are world-space and read-only
The `Bounds` sub-properties report the collider's world-space bounding box — useful for proximity checks, framing a camera, or sizing a UI highlight. There's no Set counterpart for bounds because Unity derives them from the collider's shape and transform.
:::

## See also

- [Set Collider Property](./set-collider-property) — write the same properties
- [Is Collider Type](./is-collider-type) — test a collider's shape before reading
- [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component) — source a `Collider` reference to feed in
