---
sidebar_position: 2
---

# Camera Rotation

Toggles the camera's input mode between rotation and pan. Use it to control whether the user's mouse / touch drag rotates the view or moves it laterally — useful for course steps that need a different camera-control feel.

**Category:** Action / Variable

## Inputs

| Port | Type | Description |
|---|---|---|
| value | Bool | `true` for rotation mode, `false` for pan mode. |

## Outputs

| Port | Type | Description |
|---|---|---|
| state | Bool | The current rotation-vs-pan state — read this to query the active mode. |

:::tip Per-step camera affordances
A guided tour might want pan mode for "look around the room" steps and rotation mode for "examine the object" steps. Wire Camera Rotation off [On Step Loaded](/docs/Flow/Nodes/Events/on-step-loaded) to set the appropriate mode per step.
:::

## See also

- [2D Camera Lerp](./2d-camera-lerp)
- [Side Menu](/docs/Flow/Nodes/Components/Viewer/side-menu)
