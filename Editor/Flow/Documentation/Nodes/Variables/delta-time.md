---
sidebar_position: 1
---

# Delta Time

Returns the seconds elapsed since the last frame — Unity's `Time.deltaTime`. Use it to make per-frame motion frame-rate-independent: multiply per-frame quantities (velocity, rotation rate) by Delta Time so behavior matches across different hardware and frame rates.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Float | Seconds since the previous frame. |

:::tip Pair with Update for frame-rate-independent motion
Read `Delta Time` inside a flow driven by the [Update](/docs/Flow/Nodes/Events/update) event and multiply per-frame quantities by it (velocity, rotation rate) so motion stays consistent across different frame rates.
:::

## See also

- [Fixed Delta Time](./fixed-delta-time)
- [Update](/docs/Flow/Nodes/Events/update)
