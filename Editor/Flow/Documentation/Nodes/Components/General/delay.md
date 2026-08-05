---
sidebar_position: 2
---

# Delay

Waits for a configurable number of seconds, then continues the Flow. Use it to pace sequences — narration beats, timed reveals, "wait before retry" patterns.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| delay | Float | Seconds to wait before kicking the standard Flow output. |

:::note Standard Flow output fires after the wait
Unlike most Action nodes (where `exit` fires immediately), Delay only kicks `exit` once the wait completes. Wire downstream logic to `exit` and the Delay will gate it by the configured time.
:::

:::tip Frame-quantized, scaled time
The wait advances with scaled game time, so it halts while the experience is paused and resumes from where it left off. Timing is frame-quantized — heavy frames can shift the actual fire time. Don't use Delay for tight musical or animation timing.
:::

## See also

- [Timed Kick](/docs/Flow/Nodes/Logic/timed-kick) — for repeated kicks at an interval
- [Update](/docs/Flow/Nodes/Events/update)
