---
sidebar_position: 0
sidebar_label: Overview
---

# Input Nodes

Input nodes expose live player input to the Flow Graph — keyboard keys, mouse position and movement, VR controller buttons and thumbsticks, hand-tracking state, and haptic feedback. Most are pure data readouts (no Flow ports) — wire them into Branches, Comparisons, or actions that react to input state.

:::tip Read inputs inside Update
Input state is polled at the moment a node's output is read, so reading it from a one-shot event catches only that one frame's state. To detect button presses, transitions, or held input reliably, drive the read from an [Update](/docs/Flow/Nodes/Events/update) flow.
:::

## Nodes

| Node | Description |
|---|---|
| [Input Key](./input-key)                          | Read a specific keyboard key — held, just-pressed, just-released. |
| [Player Input](./player-input)                    | Abstracted button check — works for VR controller buttons and 2D mouse / touch. |
| [Player Input Axis](./player-input-axis)          | 2D axis value — VR thumbstick or `Horizontal` / `Vertical` keyboard / virtual stick. |
| [Mouse Position](./mouse-position)                | Absolute mouse cursor position in screen pixels. |
| [Mouse Delta](./mouse-delta)                      | Frame-over-frame mouse movement on each axis. |
| [Player Input Haptics](./player-input-haptics)    | Fire a haptic vibration on a VR controller. |
| [Is Hand Tracking](./is-hand-tracking)            | True when the VR player is using hand tracking instead of controllers. |
| [Mobile Joystick](./mobile-joystick)              | Axis value of an on-screen joystick in the touch viewer. |
| [Mobile Joystick Active](./mobile-joystick-active)| True while the on-screen joysticks are shown. |
| [Mobile Joystick Button](./mobile-joystick-button)| Press / hold / release state of an on-screen joystick's face buttons. |

## See also

- [Update](/docs/Flow/Nodes/Events/update) — drive input reads from a per-frame source
- [Branch](/docs/Flow/Nodes/Logic/branch) / [Comparison](/docs/Flow/Nodes/Logic/comparison) — gate flow on input results
- [VR Player](/docs/Flow/Nodes/Player/vr-player) — VR rig GameObjects (camera, hands, pointers)
