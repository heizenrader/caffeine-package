---
sidebar_position: 2
---

# Player Input

Returns whether a configured player input is currently active. Abstracts VR controller buttons and 2D screen taps under one node — pick which player type you're targeting and which button / phase to check.

**Category:** Variable
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Bool | The result of the configured input check. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| playerType       | Enum&lt;Player&gt;       | `XR` — read from a VR controller. `Screen` — read mouse / touch on PC and mobile. |
| input            | Enum&lt;InputType&gt;    | `Down` — true on the frame the input started. `Hold` — true while held. `Up` — true on the frame the input ended. |
| controllerButton | Enum&lt;VRButtons&gt;    | Which VR button to read (Grip, Trigger, face buttons, joystick click, etc.). Only used when `playerType` is `XR`. |
| hand             | Enum&lt;Handedness&gt;   | Which hand's controller to read. Only used when `playerType` is `XR`. |

:::tip XR vs Screen
Set `playerType = Screen` and the node reads the primary mouse button (PC) or first touch (mobile / tablet) — handy for "tap anywhere to advance" patterns. Set `playerType = XR` to target a specific VR controller button. The `Down` / `Hold` / `Up` semantics are the same in both modes.
:::

:::warning Polling, not events
Like [Input Key](./input-key), Player Input reports the state at the moment of read. Read it inside a per-frame flow (downstream of [Update](/docs/Flow/Nodes/Events/update)) to catch transitions reliably.
:::

## See also

- [Input Key](./input-key) — keyboard-specific
- [Player Input Axis](./player-input-axis) — joystick / WASD axis values
- [Player Input Haptics](./player-input-haptics) — fire haptics on a VR controller
- [Update](/docs/Flow/Nodes/Events/update)
