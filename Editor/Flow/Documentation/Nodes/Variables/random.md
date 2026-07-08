---
sidebar_position: 14
---

# Random

Returns a random Float between two bounds — Unity's `Random.Range(min, max)`. Use it to vary spawn positions, pick a random delay, jitter a value, or shuffle which branch of a flow runs.

**Category:** Variable
**Kind:** Operation
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Random.Range.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| inputLowerRange  | Float | The minimum value (inclusive). |
| inputHigherRange | Float | The maximum value (inclusive). |

## Outputs

| Port | Type | Description |
|---|---|---|
| floatRandomValue | Float | A new random value between the two bounds, sampled each time the output is read. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| inputLowerRange  | Float | Default lower bound when the input port is unconnected. |
| inputHigherRange | Float | Default upper bound when the input port is unconnected. |

:::tip Each read samples a new value
Reading `floatRandomValue` triggers a new sample — a node that reads it twice gets two different numbers. To freeze the value within a single graph kick, store it in a [Local Variable](./local-variable) on the way in.
:::

:::tip For Int picks, round the output
There's no separate Int Random node — wire `floatRandomValue` into [Mathf RoundToInt](/docs/Flow/Nodes/Math/Mathf/overview) (or `FloorToInt` for an inclusive-exclusive lower-bound result). Note that rounding a Float in `[0, 3]` gives values in `{0, 1, 2, 3}` (4 outcomes); flooring gives `{0, 1, 2, 3}` only with `[0, 4)` framing. Pick the form that matches your intent.
:::

## See also

- [Mathf](/docs/Flow/Nodes/Math/Mathf/overview) — round, clamp, or otherwise shape the random output
- [Comparison](/docs/Flow/Nodes/Logic/comparison) — compare a random value to drive a Branch
