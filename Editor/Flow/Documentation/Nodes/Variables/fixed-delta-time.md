---
sidebar_position: 2
---

# Fixed Delta Time

Returns the duration of each fixed-update tick — Unity's `Time.fixedDeltaTime`. Use it inside physics-driven flows that run on the FixedUpdate cadence, where the per-tick interval is constant regardless of frame rate.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Time-fixedDeltaTime.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Float | Seconds per fixed-update tick. |

:::tip Pick the right time step for the loop you're in
Wire `Fixed Delta Time` into physics math driven by [FixedUpdate](/docs/Flow/Nodes/Events/fixed-update); wire [`Delta Time`](./delta-time) into per-frame math driven by [Update](/docs/Flow/Nodes/Events/update). Mixing them produces inconsistent motion.
:::

## See also

- [Delta Time](./delta-time)
- [Update](/docs/Flow/Nodes/Events/update)
