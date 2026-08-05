---
sidebar_position: 2
---

# Sample Curve

Evaluates an AnimationCurve at a given input value. Use it to map a numeric input to a designer-controlled output curve — easing, custom interpolation, or any non-linear value mapping.

**Category:** Variable
**Kind:** Operation
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/AnimationCurve.Evaluate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| sampleValue | Float | The input to evaluate the curve at — typically the X axis value. |

## Outputs

| Port | Type | Description |
|---|---|---|
| output | Float | The curve's value at `sampleValue` — the Y axis value. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| curve | AnimationCurve | The curve to sample. Edit it directly in the inspector to shape the input-to-output mapping. |

:::tip Designer-friendly easing
Sample Curve is the cleanest way to give designers control over a value's shape. Wire `sampleValue` from a normalized input (e.g. `t` from a [Lerp](/docs/Flow/Nodes/Math/Mathf/overview), or a progress value 0–1) and let the designer tune the curve in the inspector for the visual result they want.
:::

:::tip Sample over time
Drive `sampleValue` from accumulated [Delta Time](/docs/Flow/Nodes/Variables/delta-time) inside an [Update](/docs/Flow/Nodes/Events/update) to get a time-based curve sample — useful for one-shot animations driven entirely by the curve shape.
:::

## See also

- [Mathf Lerp / SmoothStep](/docs/Flow/Nodes/Math/Mathf/overview) — built-in easing alternatives
- [Update](/docs/Flow/Nodes/Events/update)
