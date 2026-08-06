---
sidebar_position: 0
sidebar_label: Overview
---

# Transform Nodes

Transform nodes wrap methods on `UnityEngine.Transform` — orient toward a target, rotate / translate by amounts, manipulate sibling order, and convert between local and world coordinate spaces. Each node takes a `Transform` reference and runs the corresponding Unity API call.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Transform.html)

:::note Implicit `transform` input
Every node in this category takes a `Transform` input. Tables list only the additional method parameters.
:::

There are also hand-coded Translate and Rotate helpers in [Actions/General](/docs/Flow/Nodes/Components/General/translate) — they accept a `target` Transform and apply incremental motion the same way as the codegen variants here. Use whichever feels more natural in your flow.

## Look at

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform LookAt (worldPosition)                | worldPosition (Vector3)                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.LookAt.html) |
| Transform LookAt (worldPosition, worldUp)       | worldPosition, worldUp (Vector3)                 | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.LookAt.html) |

## Rotate

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform Rotate (eulers)                                                        | eulers (Vector3, degrees)                                                       | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform Rotate (eulers, relativeTo)                                            | eulers (Vector3), relativeTo (Enum&lt;Space&gt;)                                | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform Rotate (axis, angle)                                                   | axis (Vector3), angle (Float, degrees)                                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform Rotate (axis, angle, relativeTo)                                       | axis (Vector3), angle (Float), relativeTo (Enum)                                | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform Rotate (xAngle, yAngle, zAngle)                                        | xAngle, yAngle, zAngle (Float, degrees)                                         | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform Rotate (xAngle, yAngle, zAngle, relativeTo)                            | xAngle, yAngle, zAngle (Float), relativeTo (Enum)                               | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html) |
| Transform RotateAround (point, axis, angle)                                      | point (Vector3), axis (Vector3), angle (Float, degrees)                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html) |

## Translate

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform Translate (translation)                                                | translation (Vector3)                                                            | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Translate.html) |
| Transform Translate (translation, relativeTo)                                    | translation (Vector3), relativeTo (Enum&lt;Space&gt;)                           | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Translate.html) |
| Transform Translate (x, y, z)                                                    | x, y, z (Float)                                                                  | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Translate.html) |
| Transform Translate (x, y, z, relativeTo)                                        | x, y, z (Float), relativeTo (Enum)                                               | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.Translate.html) |

## Combined

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform SetPositionAndRotation (nPosition, rotation)                           | nPosition (Vector3), rotation (Quaternion)                                       | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.SetPositionAndRotation.html) |

## Coordinate-space conversion

`TransformPoint` / `TransformDirection` / `TransformVector` convert from local to world space; the `Inverse*` variants go from world to local. Direction ignores scale and translation; Point applies all three; Vector applies scale and rotation but not translation.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform TransformPoint (position)             | position (Vector3, local)                  | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformPoint.html) |
| Transform TransformPoint (x, y, z)              | x, y, z (Float, local)                     | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformPoint.html) |
| Transform TransformDirection (direction)        | direction (Vector3, local)                 | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformDirection.html) |
| Transform TransformDirection (x, y, z)          | x, y, z (Float, local)                     | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformDirection.html) |
| Transform TransformVector (vector)              | vector (Vector3, local)                    | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformVector.html) |
| Transform TransformVector (x, y, z)             | x, y, z (Float, local)                     | Vector3 (world) | [↗](https://docs.unity3d.com/ScriptReference/Transform.TransformVector.html) |
| Transform InverseTransformPoint (nPosition)     | nPosition (Vector3, world)                 | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformPoint.html) |
| Transform InverseTransformPoint (x, y, z)       | x, y, z (Float, world)                     | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformPoint.html) |
| Transform InverseTransformDirection (direction) | direction (Vector3, world)                 | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformDirection.html) |
| Transform InverseTransformDirection (x, y, z)   | x, y, z (Float, world)                     | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformDirection.html) |
| Transform InverseTransformVector (vector)       | vector (Vector3, world)                    | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformVector.html) |
| Transform InverseTransformVector (x, y, z)      | x, y, z (Float, world)                     | Vector3 (local) | [↗](https://docs.unity3d.com/ScriptReference/Transform.InverseTransformVector.html) |

## Hierarchy

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Transform DetachChildren ()                     | —                                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.DetachChildren.html) |
| Transform GetSiblingIndex ()                    | —                                          | Int | [↗](https://docs.unity3d.com/ScriptReference/Transform.GetSiblingIndex.html) |
| Transform SetSiblingIndex (index)               | index (Int)                                | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.SetSiblingIndex.html) |
| Transform SetAsFirstSibling ()                  | —                                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.SetAsFirstSibling.html) |
| Transform SetAsLastSibling ()                   | —                                          | — | [↗](https://docs.unity3d.com/ScriptReference/Transform.SetAsLastSibling.html) |

## See also

- [Translate](/docs/Flow/Nodes/Components/General/translate) / [Rotate](/docs/Flow/Nodes/Components/General/rotate) — hand-coded variants in Actions/General
- [Get Parent](/docs/Flow/Nodes/Components/GameObject/get-parent) / [Set Parent](/docs/Flow/Nodes/Components/GameObject/set-parent)
- [Vector3 nodes](/docs/Flow/Nodes/Math/Vector3/overview)
