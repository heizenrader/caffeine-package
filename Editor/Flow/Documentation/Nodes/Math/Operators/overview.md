---
sidebar_position: 0
sidebar_label: Overview
---

# Math Operators

Hand-coded math nodes that complement the codegen Vector / Quaternion / Mathf wrappers. Mostly small convenience operations plus a flexible multi-type [Math Operator](./math-operator) and [Sample Curve](./sample-curve).

:::note Editor menu path
Operator nodes appear in the Flow editor's Add Node menu under `Flow/Math/...` (top-level Math, not under `Flow/Actions/`). They're grouped here in the docs as a sub-category of Math.
:::

All Math Operator nodes are pure data — no Flow ports. Each takes a small set of value inputs and emits a single result.

## Per-page

| Node | Description |
|---|---|
| [Math Operator](./math-operator) | Multi-type +/−/×/÷/% on Bool, Int, Float, String, Vector2/3/4, Quaternion, Color, Long. |
| [Sample Curve](./sample-curve)   | Evaluate an AnimationCurve at a given input value. |

## Convenience operators

Single-purpose operators wrapping a Unity API call:

| Node | Inputs | Output | Notes |
|---|---|---|---|
| Vector3 Operator    | a, b (Vector3)                  | Vector3                | Add or subtract two Vector3s. Subset of [Math Operator](./math-operator)'s Vector3 mode — the more flexible Math Operator covers `+`, `-`, `*`, `/`, `%`. |
| Vector Angle        | a, b (Vector3)                  | Float (degrees, 0–180) | `Vector3.Angle(a, b)`. Duplicates [Vector3 Angle](/docs/Flow/Nodes/Math/Vector3/overview) from codegen — same behavior. |
| Quaternion Angle    | a, b (Quaternion)               | Float (degrees, 0–180) | `Quaternion.Angle(a, b)`. Duplicates [Quaternion Angle](/docs/Flow/Nodes/Math/Quaternion/overview). |
| Cross Product       | a, b (Vector3)                  | Vector3                | `Vector3.Cross(a, b)`. Duplicates [Vector3 Cross](/docs/Flow/Nodes/Math/Vector3/overview). |
| Dot Product         | a, b (Vector3)                  | Float                  | `Vector3.Dot(a, b)`. Duplicates [Vector3 Dot](/docs/Flow/Nodes/Math/Vector3/overview). |
| Vector Multiple     | a (Vector3), b (Float)          | Vector3 (a × b)        | Scale a Vector3 by a scalar. Useful for "direction × speed" patterns where the codegen Vector3 wrappers don't cover scalar multiplication directly. |

:::tip Codegen vs hand-coded
For Cross / Dot / Angle, prefer the codegen [Vector3](/docs/Flow/Nodes/Math/Vector3/overview) and [Quaternion](/docs/Flow/Nodes/Math/Quaternion/overview) variants — they're identical in behavior and grouped with related operations. The hand-coded versions live alongside for backward compatibility with older graphs.
:::

## See also

- [Vector3](/docs/Flow/Nodes/Math/Vector3/overview), [Quaternion](/docs/Flow/Nodes/Math/Quaternion/overview), [Mathf](/docs/Flow/Nodes/Math/Mathf/overview) — codegen variants
- [Comparison](/docs/Flow/Nodes/Logic/comparison) — compare math results
