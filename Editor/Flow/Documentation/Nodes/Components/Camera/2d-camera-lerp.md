---
sidebar_position: 1
---

# 2D Camera Lerp

Smoothly tweens the main camera (in 2D / non-VR builds) to a configured position, rotation, and field of view over a duration. Use it for cinematic camera moves between course steps.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| lerpTime | Float | Duration of the camera move, in seconds. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| cameraSettings | CameraStepSettings | Configures the destination position, rotation, FOV, orthographic mode, and orthographic size. The inspector usually exposes "Record Camera" / "Go To Camera" buttons that capture or preview the current scene-view camera. |

:::note 2D / non-VR only
This node has no effect on VR builds — VR cameras are controlled by the headset and shouldn't be tweened by graph logic. Use VR-specific player movement patterns for VR camera changes.
:::

:::tip Record cinematic shots from the scene view
The inspector typically lets you frame the scene view, click "Record Camera" to capture the position / rotation / FOV, and then click "Go To Camera" to preview it. Once recorded, kick this node from a flow to play the move at runtime.
:::

## See also

- [Camera Rotation](./camera-rotation) — toggle camera rotation vs pan mode
- [Main Camera](/docs/Flow/Nodes/Player/main-camera)
