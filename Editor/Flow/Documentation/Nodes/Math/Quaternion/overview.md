---
sidebar_position: 0
sidebar_label: Overview
---

# Quaternion Nodes

Quaternion nodes are Flow wrappers around the static methods and properties of `UnityEngine.Quaternion` — Unity's representation for rotations. They're pure data nodes (no Flow input or output): wire them into [Transform](/docs/Flow/Nodes/Components/Transform/overview) actions or any node that takes a Quaternion.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Quaternion.html)

:::note Editor menu path
Quaternion nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Quaternion/...`. They're grouped under **Math** here in the docs because rotation math is mathematical, not component-specific.
:::

:::tip Behavior matches Unity exactly
These nodes don't add behavior on top of Unity's API. The Unity ScriptReference page (linked per row) is the authoritative reference for argument semantics and edge cases (zero-magnitude inputs, antipodal rotations, etc.). The doc below covers wiring; Unity covers the math.
:::

## Properties

Single-input nodes that read a derived value off a Quaternion. Each wraps a Unity instance property.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Quaternion Normalize | q (Quaternion) | Quaternion (unit length) | [↗](https://docs.unity3d.com/ScriptReference/Quaternion-normalized.html) |

## Operations

Construct, transform, and interpolate rotations. Multiple-input static methods.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Quaternion AngleAxis        | angle (Float, degrees), axis (Vector3)               | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.AngleAxis.html) |
| Quaternion Angle            | a, b (Quaternion)                                    | Float (degrees, 0–180)                | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Angle.html) |
| Quaternion Dot              | a, b (Quaternion)                                    | Float                                 | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Dot.html) |
| Quaternion Euler (x, y, z)  | x, y, z (Float, degrees)                             | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html) |
| Quaternion Euler (euler)    | euler (Vector3, degrees)                             | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html) |
| Quaternion FromToRotation   | fromDirection, toDirection (Vector3)                 | Quaternion (rotation that maps `from` onto `to`) | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.FromToRotation.html) |
| Quaternion Inverse          | rotation (Quaternion)                                | Quaternion (the inverse rotation)     | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Inverse.html) |
| Quaternion Lerp             | a, b (Quaternion), t (Float, clamped 0–1)            | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Lerp.html) |
| Quaternion LerpUnclamped    | a, b (Quaternion), t (Float, unclamped)              | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.LerpUnclamped.html) |
| Quaternion LookRotation (forward, upwards) | forward, upwards (Vector3)              | Quaternion (rotation looking down `forward` with `upwards` as up) | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html) |
| Quaternion LookRotation (forward) | forward (Vector3) — upwards defaults to world up | Quaternion                       | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html) |
| Quaternion RotateTowards    | from, to (Quaternion), maxDegreesDelta (Float)       | Quaternion (rotated toward `to` by at most `maxDegreesDelta`) | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.RotateTowards.html) |
| Quaternion Slerp            | a, b (Quaternion), t (Float, clamped 0–1)            | Quaternion (along the great-circle arc) | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.Slerp.html) |
| Quaternion SlerpUnclamped   | a, b (Quaternion), t (Float, unclamped)              | Quaternion                            | [↗](https://docs.unity3d.com/ScriptReference/Quaternion.SlerpUnclamped.html) |

:::tip Slerp vs Lerp for rotations
For smoothly rotating between two orientations over a noticeable arc, **use Slerp** — it follows the great-circle path so angular velocity stays constant. `Lerp` blends component-wise and is faster but produces visible "wobble" for rotations more than ~30°. Reach for `Lerp` only on tight rotations where the wobble is invisible and CPU matters.
:::

:::tip Picking a rotation constructor
Three ways to build a Quaternion: pick the one that matches your input.
- **Euler** — you have pitch / yaw / roll degrees (e.g., from a designer-set rotation).
- **AngleAxis** — you want to rotate by `N` degrees around a known axis (e.g., spin around world up).
- **LookRotation** — you have a direction vector and want an object's forward to point that way (e.g., look at a target).
- **FromToRotation** — you have two vectors and want the rotation that aligns one with the other.
:::

:::tip RotateTowards for capped per-frame rotation
`RotateTowards` is the rotation analogue of `Vector3.MoveTowards` — it moves `from` toward `to` by *at most* `maxDegreesDelta` degrees. Drive `maxDegreesDelta` from a per-second rate × `Delta Time` (from the [Update](/docs/Flow/Nodes/Events/update)) to get a frame-rate-independent rotation speed.
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Vector3 overview](/docs/Flow/Nodes/Math/Vector3/overview) — vectors used as axes and directions in Quaternion operations
- [Transform actions](/docs/Flow/Nodes/Components/Transform/overview) — apply rotations to GameObjects
