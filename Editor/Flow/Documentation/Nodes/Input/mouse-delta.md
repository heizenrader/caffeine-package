---
sidebar_position: 5
---

# Mouse Delta

Returns the mouse movement since the last frame on each axis — Unity's `Input.GetAxis("Mouse X")` / `Mouse Y`. Use it for free-look camera control, drag-style interactions, or any input where what matters is *change* rather than absolute position.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| _delta | Vector2 | Frame-over-frame mouse movement. X is horizontal change, Y is vertical change. Already smoothed by Unity's input axis system. |

:::tip Sensitivity tuning lives in Project Settings
The numeric range of Mouse Delta is governed by Unity's Input axis sensitivity for `Mouse X` / `Mouse Y`. To adjust feel globally, edit those axes in `Edit > Project Settings > Input Manager`. To adjust per-flow, multiply by a Float variable in your graph.
:::

## See also

- [Mouse Position](./mouse-position) — absolute cursor position
- [Player Input Axis](./player-input-axis) — keyboard / thumbstick axis equivalent
