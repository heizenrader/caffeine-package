---
sidebar_position: 9
---

# Mobile Joystick Active

Outputs whether the on-screen joysticks are currently active in the viewer. Use it to branch input handling — read the joysticks when they're showing, fall back to another control scheme when they aren't.

**Category:** Variable
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Bool | `true` while the on-screen joysticks are active, otherwise `false`. |

:::tip Gate joystick reads
Wire this into a [Branch](/docs/Flow/Nodes/Logic/branch) so a graph only reads [Mobile Joystick](./mobile-joystick) / [Mobile Joystick Button](./mobile-joystick-button) when the sticks are actually on screen.
:::

## See also

- [Mobile Joystick](./mobile-joystick) — read a stick's axis
- [Mobile Joystick Button](./mobile-joystick-button) — read a stick's face buttons
