---
sidebar_position: 0
sidebar_label: Overview
---

# Collider Nodes

Collider nodes operate on `UnityEngine.Collider` instances — query the closest point on a collider, read or write its shape properties (size, radius, center, trigger state…), and test which kind of collider you're holding. Useful for proximity-based gameplay, snapping, AI navigation, and reshaping colliders at runtime.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Collider.html)

## Properties & shape

These nodes pick a collider shape and property in the inspector and expose a single typed port to match. Neither throws on a shape mismatch — Get returns the type's default value, and Set does nothing.

| Node | Description |
|---|---|
| [Get Collider Property](./get-collider-property) | Read a property (size, radius, center, world-space bounds, enabled, is-trigger, …). |
| [Set Collider Property](./set-collider-property) | Write a property (size, radius, center, direction, convex, enabled, is-trigger). |
| [Is Collider Type](./is-collider-type)           | Test whether a collider is a Box, Sphere, Capsule, or Mesh collider. |

## Operations

Closest-point queries on a collider. Each takes an implicit `Collider` input; the table lists only the additional method parameters.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Collider ClosestPoint (position)            | position (Vector3, world space) | Vector3 (closest world-space point on the collider's surface) | [↗](https://docs.unity3d.com/ScriptReference/Collider.ClosestPoint.html) |
| Collider ClosestPointOnBounds (position)    | position (Vector3, world space) | Vector3 (closest point on the collider's axis-aligned bounding box) | [↗](https://docs.unity3d.com/ScriptReference/Collider.ClosestPointOnBounds.html) |

:::tip ClosestPoint vs ClosestPointOnBounds
`ClosestPoint` accounts for the actual collider geometry (sphere, capsule, mesh) and returns a point on the surface — more accurate but more expensive. `ClosestPointOnBounds` only uses the AABB — much cheaper, but only matches the collider's silhouette for box-shaped colliders.
:::
