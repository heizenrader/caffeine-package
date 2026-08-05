---
sidebar_position: 8
---

# Timed Kick

Repeatedly kicks the `kick` output on a timer — either forever or a fixed number of times — separated by a configurable delay. Fire the standard `entry` to start the timer. Fire `stop` to halt it. The standard `exit` fires immediately when `entry` runs; the timer continues in the background.

**Category:** Action
**Kind:** Control flow / Timing

## Inputs

| Port | Type | Description |
|---|---|---|
| timeDelay | Float | Seconds between kicks. |
| times     | Int   | Number of kicks to fire. Only used when `repeat` is `Number`. |
| stop      | Flow  | Halts the running timer. Firing `entry` afterwards starts a fresh run. |

## Outputs

| Port | Type | Description |
|---|---|---|
| kick | Flow | Kicks every `timeDelay` seconds, starting one delay after the timer is started. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| repeat | Enum&lt;Repeat&gt; | `Always` to kick until stopped or the scene unloads, `Number` to kick exactly `times` times (or until stopped). |

:::note Standard Flow output vs `kick`
Timed Kick fires the standard `exit` **immediately** when the node runs, then starts firing `kick` on a delay loop in the background. Wire downstream logic to `exit` for "after I started the timer", to `kick` for "each time the timer fires".
:::

:::note Re-firing `entry` while the timer is running is ignored
While a Timed Kick is actively running, firing `entry` again does nothing — the in-progress timer keeps running undisturbed. To restart with new settings, fire `stop` first, then `entry`.
:::

:::warning Wait one frame between `stop` and the next `entry`
Stopping the timer takes effect on the next frame. Firing `entry` in the same frame as `stop` will be ignored — wait at least one frame before restarting. Wiring `stop` and `entry` to different events almost always gives you that automatically.
:::

:::tip Frame-quantized, scaled time
The delay advances with scaled game time, so the timer halts while the experience is paused and resumes from where it left off. Timing is frame-quantized — heavy frames can shift the actual fire time. Don't use Timed Kick for tight musical or animation timing.
:::

## See also

- [For Loop](./for-loop) — fixed-count synchronous iteration
- [Update](/docs/Flow/Nodes/Events/update) — fire every frame instead of on a delay
