---
sidebar_position: 0
sidebar_label: Overview
---

# Math Nodes

Math nodes perform operations on value types — they don't act on components or GameObjects, they transform data. Use them to compute distances, blend colors, build rotations from angles, or do per-frame arithmetic between Flow variables.

All Math nodes are **pure data nodes** — no Flow input or output. They just take their value inputs and emit a result you wire into actions, conditions, or other math.

:::note Editor menu path
Math nodes appear in the Flow editor's Add Node menu under `Flow/Actions/<Type>/...`. They're grouped under **Math** here in the docs because they're value computations, not component actions.
:::

## Type subcategories

| Type | What lives here |
|---|---|
| [Mathf](./Mathf/overview)           | Trig, interpolation, rounding, powers, cyclic functions, color-space conversions, Perlin noise. |
| [Color](./Color/overview)           | HSV-to-RGB conversion (with HDR variant), color Lerp. |
| [Quaternion](./Quaternion/overview) | Build rotations (Euler, AngleAxis, LookRotation, FromToRotation), Slerp/Lerp, Inverse, RotateTowards, Angle measurements. |
| [Vector2](./Vector2/overview)       | 2D distance, dot, lerp, project/reflect, perpendicular. SqrMagnitude property. |
| [Vector3](./Vector3/overview)       | 3D distance, dot, cross, lerp, project/reflect, RotateTowards. Magnitude / Normalize / SqrMagnitude properties. |
| [Vector4](./Vector4/overview)       | 4D distance, dot, lerp, project. Magnitude / Normalize / SqrMagnitude properties. Mainly for shader uniforms. |

## Properties vs operations

The vector and quaternion subcategories split their tables into two sections:

- **Properties** — single-input nodes that read a derived value (`Magnitude`, `SqrMagnitude`, `Normalize`). Wrap Unity instance properties (`Type-name.html`).
- **Operations** — multi-input static methods (`Lerp`, `Cross`, `Distance`, `RotateTowards`, etc.) that compute a result. Wrap Unity static methods (`Type.Method.html`).

The split makes the URL convention explicit and surfaces the "free getter" subset for creators who just want a derived value. Mathf and Color are operations-only — single section.

## See also

- [Variables](/docs/Flow/flow-variables)
- [Logic nodes](/docs/Flow/Nodes/Logic/overview) — comparisons and predicates that consume math results
