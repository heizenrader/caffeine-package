---
sidebar_position: 0
sidebar_label: Overview
---

# Vector4 Nodes

Vector4 nodes are Flow wrappers around the static methods and properties of `UnityEngine.Vector4`. They're pure data nodes (no Flow input or output). Vector4s are most often used for shader uniforms, four-component data (e.g. RGBA-as-vector), and homogeneous coordinates — Vector3 covers most gameplay positioning.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Vector4.html)

:::note Editor menu path
Vector4 nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Vector4/...`. They're grouped under **Math** here in the docs because the operations are mathematical, not component-specific.
:::

## Properties

Single-input nodes that read a derived value off a Vector4.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector4 Magnitude    | a (Vector4) | Float                 | [↗](https://docs.unity3d.com/ScriptReference/Vector4-magnitude.html) |
| Vector4 Normalize    | a (Vector4) | Vector4 (unit length) | [↗](https://docs.unity3d.com/ScriptReference/Vector4-normalized.html) |
| Vector4 SqrMagnitude | a (Vector4) | Float                 | [↗](https://docs.unity3d.com/ScriptReference/Vector4-sqrMagnitude.html) |

:::tip Magnitude vs SqrMagnitude
`SqrMagnitude` skips the square-root that `Magnitude` performs — meaningfully cheaper when you only need to compare lengths. Don't use it where the actual length value matters.
:::

## Operations

Compute a new Vector4 (or scalar) from two or more inputs.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Vector4 Distance      | a, b (Vector4)                                       | Float                            | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Distance.html) |
| Vector4 Dot           | a, b (Vector4)                                       | Float                            | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Dot.html) |
| Vector4 Lerp          | a, b (Vector4), t (Float, clamped 0–1)               | Vector4                          | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Lerp.html) |
| Vector4 LerpUnclamped | a, b (Vector4), t (Float, unclamped)                 | Vector4                          | [↗](https://docs.unity3d.com/ScriptReference/Vector4.LerpUnclamped.html) |
| Vector4 Max           | lhs, rhs (Vector4)                                   | Vector4 (componentwise max)      | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Max.html) |
| Vector4 Min           | lhs, rhs (Vector4)                                   | Vector4 (componentwise min)      | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Min.html) |
| Vector4 MoveTowards   | current, target (Vector4), maxDistanceDelta (Float)  | Vector4                          | [↗](https://docs.unity3d.com/ScriptReference/Vector4.MoveTowards.html) |
| Vector4 Project       | a, b (Vector4)                                       | Vector4 (projection of `a` onto `b`) | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Project.html) |
| Vector4 Scale         | a, b (Vector4)                                       | Vector4 (componentwise product)  | [↗](https://docs.unity3d.com/ScriptReference/Vector4.Scale.html) |

:::tip Clamped vs unclamped Lerp
The unclamped variant lets `t` go below 0 or above 1, which extrapolates past the endpoints. Use it deliberately — for ordinary "blend between a and b" behavior you almost always want the clamped version.
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Vector3 overview](/docs/Flow/Nodes/Math/Vector3/overview)
- [Mathf overview](/docs/Flow/Nodes/Math/Mathf/overview)
