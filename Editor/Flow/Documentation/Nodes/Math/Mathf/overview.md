---
sidebar_position: 0
sidebar_label: Overview
---

# Mathf Nodes

Mathf nodes are Flow wrappers around the static methods on `UnityEngine.Mathf` — Unity's general-purpose math library. They're pure data nodes (no Flow input or output): each takes one or more numeric inputs and emits a result you wire into actions, conditions, or other math.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Mathf.html)

:::note Editor menu path
Mathf nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Mathf/...`. They're grouped under **Math** here in the docs because they're mathematical operations, not component actions.
:::

:::tip Behavior matches Unity exactly
These nodes don't add behavior on top of Unity's API — each just exposes `Mathf.X(...)` as a Flow node. The Unity ScriptReference page (linked per row below) is the authoritative reference for argument semantics, edge cases (NaN, infinity), and clamping behavior. The doc below covers wiring; Unity covers the math.
:::

## Common operations

Frequently-used absolute-value, extremes, clamp, and square-root utilities. Several have separate Float and Int variants — pick the one matching your input type.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Abs (f)        | f (Float)               | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Abs.html) |
| Mathf Abs (value)    | value (Int)             | Int                    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Abs.html) |
| Mathf Min            | a, b (Float)            | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Min.html) |
| Mathf Min (Int)      | a, b (Int)              | Int                    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Min.html) |
| Mathf Max            | a, b (Float)            | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Max.html) |
| Mathf Max (Int)      | a, b (Int)              | Int                    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Max.html) |
| Mathf Clamp          | value, min, max (Float) | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html) |
| Mathf Clamp (Int)    | value, min, max (Int)   | Int                    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html) |
| Mathf Clamp01        | value (Float)           | Float (clamped 0–1)    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Clamp01.html) |
| Mathf Sign           | f (Float)               | Float (-1 or 1)        | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Sign.html) |
| Mathf Sqrt           | f (Float)               | Float                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Sqrt.html) |
| Mathf Approximately  | a, b (Float)            | Bool                   | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Approximately.html) |

:::tip Use Approximately for float equality
Float arithmetic accumulates tiny errors — testing two computed floats with `==` will often miss equality you'd expect to hold. `Mathf Approximately` tolerates that drift. For ordering (`>`, `<`), the regular [Comparison](/docs/Flow/Nodes/Logic/comparison) node is fine.
:::

## Trigonometry

Inputs and outputs are in **radians**. The angular interpolation/movement nodes (LerpAngle, MoveTowardsAngle, DeltaAngle) work in **degrees** — see Interpolation & movement.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Sin    | f (Float, radians)        | Float                       | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Sin.html) |
| Mathf Cos    | f (Float, radians)        | Float                       | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Cos.html) |
| Mathf Tan    | f (Float, radians)        | Float                       | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Tan.html) |
| Mathf Asin   | f (Float, -1..1)          | Float (radians)             | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Asin.html) |
| Mathf Acos   | f (Float, -1..1)          | Float (radians)             | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Acos.html) |
| Mathf Atan   | f (Float)                 | Float (radians, -π/2..π/2)  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Atan.html) |
| Mathf Atan2  | y, x (Float)              | Float (radians, -π..π)      | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html) |

:::tip Atan vs Atan2
`Atan(f)` only knows the slope `f`, so it can't tell which quadrant you came from — output is restricted to ±π/2. `Atan2(y, x)` keeps the signs of both arguments and returns the full ±π range. Use Atan2 to compute "angle from origin to (x, y)" or for any directional math; reach for Atan only when you genuinely have a single ratio.
:::

## Interpolation & movement

Linear interpolation, ease curves, and incremental moves toward a target. The angle variants (LerpAngle, MoveTowardsAngle, DeltaAngle) wrap correctly across the 0/360 boundary in **degrees**.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Lerp              | a, b, t (Float, t clamped 0–1)              | Float                          | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html) |
| Mathf LerpUnclamped     | a, b, t (Float, t unclamped)                | Float                          | [↗](https://docs.unity3d.com/ScriptReference/Mathf.LerpUnclamped.html) |
| Mathf LerpAngle         | a, b (Float, degrees), t (Float, clamped)   | Float (degrees)                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.LerpAngle.html) |
| Mathf InverseLerp       | a, b, value (Float)                         | Float (0–1)                    | [↗](https://docs.unity3d.com/ScriptReference/Mathf.InverseLerp.html) |
| Mathf SmoothStep        | from, to, t (Float)                         | Float (smoothstep curve)       | [↗](https://docs.unity3d.com/ScriptReference/Mathf.SmoothStep.html) |
| Mathf MoveTowards       | current, target, maxDelta (Float)           | Float                          | [↗](https://docs.unity3d.com/ScriptReference/Mathf.MoveTowards.html) |
| Mathf MoveTowardsAngle  | current, target, maxDelta (Float, degrees)  | Float (degrees)                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.MoveTowardsAngle.html) |
| Mathf DeltaAngle        | current, target (Float, degrees)            | Float (degrees, -180..180)     | [↗](https://docs.unity3d.com/ScriptReference/Mathf.DeltaAngle.html) |

:::tip Lerp vs SmoothStep
`Lerp` is linear — moving with constant velocity. `SmoothStep` eases in and out — natural-looking motion for camera moves, fades, and UI transitions. Pick SmoothStep when "linear feels mechanical".
:::

:::tip Use the Angle variants for rotational values
`MoveTowardsAngle` and `LerpAngle` wrap correctly across the 0/360 boundary, so moving from 350° to 10° goes 20° forward instead of 340° backward. Use them for any value that's a rotation; use the non-Angle variants for unconstrained quantities (height, opacity, score).
:::

## Rounding

Round to the nearest integer, either as a Float or directly as an Int.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Ceil        | f (Float) | Float                                         | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Ceil.html) |
| Mathf Floor       | f (Float) | Float                                         | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Floor.html) |
| Mathf Round       | f (Float) | Float (banker's rounding — `0.5` to nearest even) | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Round.html) |
| Mathf CeilToInt   | f (Float) | Int                                           | [↗](https://docs.unity3d.com/ScriptReference/Mathf.CeilToInt.html) |
| Mathf FloorToInt  | f (Float) | Int                                           | [↗](https://docs.unity3d.com/ScriptReference/Mathf.FloorToInt.html) |
| Mathf RoundToInt  | f (Float) | Int (banker's rounding)                       | [↗](https://docs.unity3d.com/ScriptReference/Mathf.RoundToInt.html) |

:::warning Round uses banker's rounding
`Round` and `RoundToInt` round `0.5` to the nearest *even* integer (`0.5 → 0`, `1.5 → 2`, `2.5 → 2`). If you specifically need "always round half up", add `0.5` then `Floor`.
:::

## Powers & logarithms

Exponentiation, log functions, and power-of-two utilities.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Pow              | f, p (Float) — `f` raised to the `p`      | Float | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Pow.html) |
| Mathf Exp              | power (Float) — `e` raised to the `power` | Float | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Exp.html) |
| Mathf Log (f, p)       | f, p (Float) — log of `f` in base `p`     | Float | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Log.html) |
| Mathf Log (f)          | f (Float) — natural log (base `e`)        | Float | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Log.html) |
| Mathf Log10            | f (Float) — base-10 log                   | Float | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Log10.html) |
| Mathf IsPowerOfTwo     | value (Int)                                | Bool  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.IsPowerOfTwo.html) |
| Mathf NextPowerOfTwo   | value (Int) — smallest power of 2 ≥ value | Int   | [↗](https://docs.unity3d.com/ScriptReference/Mathf.NextPowerOfTwo.html) |
| Mathf ClosestPowerOfTwo | value (Int) — nearest power of 2          | Int   | [↗](https://docs.unity3d.com/ScriptReference/Mathf.ClosestPowerOfTwo.html) |

## Cyclic

Wrap a value around a fixed range — useful for tiling, looping animations, or oscillating motion.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Repeat   | t, length (Float)  | Float — `t` modulo `length`, always positive (0 to length)             | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Repeat.html) |
| Mathf PingPong | t, length (Float)  | Float — bounces between 0 and length as `t` increases                  | [↗](https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html) |

## Color & noise

Color-space conversions, color temperature, and Perlin noise.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Mathf Gamma                            | value, absmax, gamma (Float)    | Float                                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.Gamma.html) |
| Mathf GammaToLinearSpace               | value (Float, 0–1)              | Float                                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.GammaToLinearSpace.html) |
| Mathf LinearToGammaSpace               | value (Float, 0–1)              | Float                                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.LinearToGammaSpace.html) |
| Mathf CorrelatedColorTemperatureToRGB  | kelvin (Float, ~1000–40000)     | Color                                | [↗](https://docs.unity3d.com/ScriptReference/Mathf.CorrelatedColorTemperatureToRGB.html) |
| Mathf PerlinNoise                      | x, y (Float)                    | Float (0–1, deterministic from x/y) | [↗](https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html) |

:::tip Perlin noise is deterministic
`PerlinNoise(x, y)` returns the same result for the same `x, y` inputs every call. To get an animated noise field, drive `x` or `y` from a time-based variable (e.g. via the [Update](/docs/Flow/Nodes/Events/update) and a graph variable that accumulates `Delta Time`).
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Vector3 nodes](/docs/Flow/Nodes/Math/Vector3/overview)
- [Comparison](/docs/Flow/Nodes/Logic/comparison) — compare math results to drive conditions
