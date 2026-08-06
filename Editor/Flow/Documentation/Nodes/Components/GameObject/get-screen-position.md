---
sidebar_position: 14
---

# Get Screen Position

Converts a GameObject's world position to screen-space pixel coordinates via the main camera. Use it to position UI overlays at world-space targets, or read where on screen a 3D object appears.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject whose world position to project. |

## Outputs

| Port | Type | Description |
|---|---|---|
| pos | Vector3 | Screen-space position. X and Y are in screen pixels (origin bottom-left); Z is the world distance from the camera. Returns default when the main camera or input is null. |

:::tip For UI placement
Wire `pos` (specifically X and Y) into a UI element's `transform.position` to make it follow a 3D target across the screen. The Z component is useful for "is the target in front of the camera" checks (positive = in front).
:::

## See also

- [Main Camera](/docs/Flow/Nodes/Player/main-camera)
- [Mouse Position](/docs/Flow/Nodes/Input/mouse-position)
