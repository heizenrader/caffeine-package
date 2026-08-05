---
sidebar_position: 8
---

# Mobile Joystick

Reads the current axis value of one of the on-screen joysticks shown in the mobile / touch viewer. Use it to drive movement, look, or any 2D control from the virtual thumbsticks.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Vector2 | The selected joystick's axis, each component normalized between -1 and 1. `(0, 0)` when the stick is centered or untouched. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| joystick | Enum&lt;Joystick&gt; | Which on-screen stick to read — `Left` or `Right`. |

:::tip Read inside Update
Like the other input nodes, the value reflects the stick's state at the moment it's read. Drive the read from an [Update](/docs/Flow/Nodes/Events/update) flow to track it continuously.
:::

:::note Mobile / touch viewer only
The on-screen joysticks exist in the touch viewer. On platforms without them (VR, desktop without the touch overlay) the axis reads `(0, 0)`.
:::

## See also

- [Mobile Joystick Button](./mobile-joystick-button) — read the joystick's face buttons
- [Mobile Joystick Active](./mobile-joystick-active) — check whether the joysticks are shown
- [Player Input Axis](./player-input-axis) — VR thumbstick / keyboard axis
