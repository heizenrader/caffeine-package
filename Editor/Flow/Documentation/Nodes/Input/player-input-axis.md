---
sidebar_position: 3
---

# Player Input Axis

Returns a 2D axis value from the configured player input — VR controller thumbstick or PC keyboard / mobile virtual stick (Horizontal / Vertical axes). Use it for movement, look-around, scroll input, or any analog 2D control.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Vector2 | The current axis values. X is horizontal, Y is vertical. Each component is roughly in `[-1, 1]`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| playerType | Enum&lt;Player&gt;     | `XR` — read the thumbstick of a VR controller. `Screen` — read Unity's `Horizontal` / `Vertical` input axes (WASD on PC, virtual stick on mobile). |
| hand       | Enum&lt;Handedness&gt; | Which controller's thumbstick. Only used when `playerType` is `XR`. |

:::tip Multiply by Delta Time for movement
For continuous movement (rotate, translate) wired to this axis, multiply by [Delta Time](/docs/Flow/Nodes/Variables/delta-time) so motion stays frame-rate-independent.
:::

## See also

- [Player Input](./player-input) — discrete button presses
- [Mouse Delta](./mouse-delta) — frame-over-frame mouse movement (similar shape, mouse-specific)
- [Vector2 nodes](/docs/Flow/Nodes/Math/Vector2/overview) — math on the returned axis value
