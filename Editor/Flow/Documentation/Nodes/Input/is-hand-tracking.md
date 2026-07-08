---
sidebar_position: 7
---

# Is Hand Tracking

Returns `true` when the active VR player is currently using hand tracking instead of holding controllers. Use it to swap UI hints, gate controller-specific haptics, or switch interaction modes between hands and controllers.

:::note Editor menu name
Appears in the Add Node menu as **"IsHandTracking"** (one word) under `Flow/Input/`. Doc title uses "Is Hand Tracking" for readability.
:::

**Category:** Variable
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| isHandTracking | Bool | `true` when the player is using hand tracking; `false` on non-VR builds and when controllers are active. |

:::tip Branch on this before using haptics
Hand tracking has no controller, so [Player Input Haptics](./player-input-haptics) won't produce a vibration. Branch on Is Hand Tracking and skip haptic flows when it returns `true`, or fall back to a visual cue.
:::

## See also

- [Player Input](./player-input)
- [Player Input Haptics](./player-input-haptics)
- [Is Platform](/docs/Flow/Nodes/Logic/is-platform) — broader VR-vs-non-VR check
