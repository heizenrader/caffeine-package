---
sidebar_position: 4
---

# Mouse Position

Returns the current mouse cursor position in screen-space pixels. The origin (0, 0) is the bottom-left corner; (Screen.width, Screen.height) is the top-right.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Input-mousePosition.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| _position | Vector2 | Mouse position in screen-space pixels. |

:::tip Convert to viewport or world space via Camera
Wire `_position` into a Get Component → `Camera.ScreenToWorldPoint` or `ScreenToViewportPoint` flow if you need normalized (0–1) or world coordinates.
:::

## See also

- [Mouse Delta](./mouse-delta) — frame-over-frame movement instead of absolute position
- [Player Input](./player-input) — mouse / touch button state
