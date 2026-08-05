---
sidebar_position: 0
sidebar_label: Overview
---

# Vector3 Nodes

Vector3 nodes are Flow wrappers around the static methods on `UnityEngine.Vector3`. Each node takes the operand inputs you'd pass to the underlying Unity API and outputs the result as a data port — wire them into actions that need a computed position, direction, or magnitude.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Vector3.html)

:::note Editor menu path
Vector3 nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Vector3/...` (the codegen places them under Actions). They're grouped under **Math** here in the docs because the operations are mathematical, not component-specific.
:::

:::tip Behavior matches Unity exactly
These nodes don't wrap or modify Unity's behavior — they call the underlying static method and return the result. Read the Unity ScriptReference page (linked per row below) for argument semantics, edge cases (e.g. degenerate inputs returning zero vectors), and clamping behavior. The Flow doc only covers port wiring.
:::

## Properties

Property nodes read a derived value off a single Vector3 input. Each one wraps a Unity instance property — they don't compute anything new, they just expose a value Unity already maintains.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector3 Magnitude    | vector (Vector3) | Float                 | [↗](https://docs.unity3d.com/ScriptReference/Vector3-magnitude.html) |
| Vector3 Normalize    | value (Vector3)  | Vector3 (unit length) | [↗](https://docs.unity3d.com/ScriptReference/Vector3-normalized.html) |
| Vector3 SqrMagnitude | vector (Vector3) | Float                 | [↗](https://docs.unity3d.com/ScriptReference/Vector3-sqrMagnitude.html) |

:::tip Magnitude vs SqrMagnitude
`SqrMagnitude` skips the square-root that `Magnitude` performs and is meaningfully cheaper when you only need to compare lengths (`a.SqrMagnitude < threshold * threshold`). Don't use it where the actual length value matters.
:::

## Operations

Operation nodes compute a new Vector3 (or scalar) from two or more inputs by calling a Unity static method.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector3 Angle           | from, to (Vector3)                                                     | Float (degrees, 0–180) | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Angle.html) |
| Vector3 ClampMagnitude  | vector (Vector3), maxLength (Float)                                    | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.ClampMagnitude.html) |
| Vector3 Cross           | lhs, rhs (Vector3)                                                     | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Cross.html) |
| Vector3 Distance        | a, b (Vector3)                                                         | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Distance.html) |
| Vector3 Dot             | lhs, rhs (Vector3)                                                     | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Dot.html) |
| Vector3 Lerp            | a, b (Vector3), t (Float, clamped 0–1)                                 | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html) |
| Vector3 LerpUnclamped   | a, b (Vector3), t (Float, unclamped)                                   | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.LerpUnclamped.html) |
| Vector3 Max             | lhs, rhs (Vector3)                                                     | Vector3 (componentwise max) | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Max.html) |
| Vector3 Min             | lhs, rhs (Vector3)                                                     | Vector3 (componentwise min) | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Min.html) |
| Vector3 MoveTowards     | current, target (Vector3), maxDistanceDelta (Float)                    | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html) |
| Vector3 Project         | vector, onNormal (Vector3)                                             | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Project.html) |
| Vector3 ProjectOnPlane  | vector, planeNormal (Vector3)                                          | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.ProjectOnPlane.html) |
| Vector3 Reflect         | inDirection, inNormal (Vector3)                                        | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html) |
| Vector3 RotateTowards   | current, target (Vector3), maxRadiansDelta, maxMagnitudeDelta (Float)  | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html) |
| Vector3 Scale           | a, b (Vector3)                                                         | Vector3 (componentwise product) | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Scale.html) |
| Vector3 SignedAngle     | from, to, axis (Vector3)                                               | Float (degrees, ±180)  | [↗](https://docs.unity3d.com/ScriptReference/Vector3.SignedAngle.html) |
| Vector3 Slerp           | a, b (Vector3), t (Float, clamped 0–1)                                 | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html) |
| Vector3 SlerpUnclamped  | a, b (Vector3), t (Float, unclamped)                                   | Vector3                | [↗](https://docs.unity3d.com/ScriptReference/Vector3.SlerpUnclamped.html) |

:::tip Clamped vs unclamped Lerp/Slerp
The unclamped variants let `t` go below 0 or above 1, which extrapolates past the endpoints. Use them deliberately — for ordinary "blend between a and b" behavior you almost always want the clamped versions.
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Variables](/docs/Flow/flow-variables)
