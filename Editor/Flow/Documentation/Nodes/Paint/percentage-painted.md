---
sidebar_position: 2
---

# Percentage Painted

Returns the fraction (0–1) of the connected Paintable surface that has been covered, optionally filtered by paint channel. Use it to drive completion logic for painting exercises — branch when coverage exceeds a threshold, fill a progress bar, or reward the user.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| percentage | Float | Coverage between 0 (untouched) and 1 (fully painted). Returns 0 when `paintable` is unset. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| paintable | Paintable                | The surface to measure. |
| channel   | Enum&lt;ChannelType&gt;  | Which paint channel to count toward the percentage. |

:::tip Drive completion checks via Comparison
Wire `percentage` into a [Comparison](/docs/Flow/Nodes/Logic/comparison) (`GreaterThan` / `Float`) with a threshold like `0.95`, then feed the bool into a [Branch](/docs/Flow/Nodes/Logic/branch) — that's the canonical "did the user paint enough" check.
:::

## See also

- [Clear Paint](./clear-paint)
