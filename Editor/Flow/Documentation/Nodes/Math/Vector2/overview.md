---
sidebar_position: 0
sidebar_label: Overview
---

# Vector2 Nodes

Vector2 nodes are Flow wrappers around the static methods and properties of `UnityEngine.Vector2`. They're pure data nodes (no Flow input or output) — common uses are 2D positions, UI coordinates, screen-space directions, and texture UVs.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Vector2.html)

:::note Editor menu path
Vector2 nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Vector2/...`. They're grouped under **Math** here in the docs because the operations are mathematical, not component-specific.
:::

## Properties

Single-input nodes that read a derived value off a Vector2.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector2 SqrMagnitude | a (Vector2) | Float | [↗](https://docs.unity3d.com/ScriptReference/Vector2-sqrMagnitude.html) |

:::tip SqrMagnitude for length comparisons
`SqrMagnitude` skips the square-root that a true magnitude operation would perform — meaningfully cheaper when you only need to compare lengths (`a.SqrMagnitude < threshold * threshold`). Don't use it where the actual length value matters.
:::

## Operations

Compute a new Vector2 (or scalar) from two or more inputs.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector2 Angle           | from, to (Vector2)                                                   | Float (degrees, 0–180)         | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Angle.html) |
| Vector2 ClampMagnitude  | vector (Vector2), maxLength (Float)                                  | Vector2                        | [↗](https://docs.unity3d.com/ScriptReference/Vector2.ClampMagnitude.html) |
| Vector2 Distance        | a, b (Vector2)                                                       | Float                          | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Distance.html) |
| Vector2 Dot             | lhs, rhs (Vector2)                                                   | Float                          | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Dot.html) |
| Vector2 Lerp            | a, b (Vector2), t (Float, clamped 0–1)                               | Vector2                        | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Lerp.html) |
| Vector2 LerpUnclamped   | a, b (Vector2), t (Float, unclamped)                                 | Vector2                        | [↗](https://docs.unity3d.com/ScriptReference/Vector2.LerpUnclamped.html) |
| Vector2 Max             | lhs, rhs (Vector2)                                                   | Vector2 (componentwise max)    | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Max.html) |
| Vector2 Min             | lhs, rhs (Vector2)                                                   | Vector2 (componentwise min)    | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Min.html) |
| Vector2 MoveTowards     | current, target (Vector2), maxDistanceDelta (Float)                  | Vector2                        | [↗](https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html) |
| Vector2 Perpendicular   | inDirection (Vector2)                                                | Vector2 (rotated 90° CCW)      | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Perpendicular.html) |
| Vector2 Reflect         | inDirection, inNormal (Vector2)                                      | Vector2                        | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Reflect.html) |
| Vector2 Scale           | a, b (Vector2)                                                       | Vector2 (componentwise product) | [↗](https://docs.unity3d.com/ScriptReference/Vector2.Scale.html) |
| Vector2 SignedAngle     | from, to (Vector2)                                                   | Float (degrees, ±180)          | [↗](https://docs.unity3d.com/ScriptReference/Vector2.SignedAngle.html) |

:::tip Clamped vs unclamped Lerp
The unclamped variant lets `t` go below 0 or above 1, which extrapolates past the endpoints. Use it deliberately — for ordinary "blend between a and b" behavior you almost always want the clamped version.
:::

:::tip Perpendicular for 2D normals
`Perpendicular` returns the input rotated 90° counter-clockwise — handy for computing a 2D surface normal or a tangent direction for movement.
:::

:::tip Angle vs SignedAngle
`Angle` returns the absolute angle between two vectors (always 0–180°). `SignedAngle` keeps the sign — positive when `to` is counter-clockwise from `from`, negative when clockwise. Use SignedAngle when you need to know which side, Angle when you only need magnitude.
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Vector3 overview](/docs/Flow/Nodes/Math/Vector3/overview)
- [Mathf overview](/docs/Flow/Nodes/Math/Mathf/overview)
