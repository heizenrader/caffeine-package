---
sidebar_position: 0
sidebar_label: Overview
---

# Camera Nodes

Camera nodes wrap methods on `UnityEngine.Camera` — coordinate-space conversions (screen / viewport / world), render control, projection / view matrix resets, command buffer management. Each node takes a `Camera` reference and runs the corresponding Unity API call.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Camera.html)

:::note Implicit `camera` input
Every node in this category takes a `Camera` input. Tables list only the additional method parameters.
:::

There are also two hand-coded camera nodes — see [2D Camera Lerp](./2d-camera-lerp) (cinematic camera moves) and [Camera Rotation](./camera-rotation) (toggle rotation vs pan input mode).

## Coordinate-space conversions

Convert points between screen, viewport, and world spaces. Use these to project a 3D world point into screen UI space (or vice versa) for click-to-world or world-to-UI patterns.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Camera ScreenToWorldPoint (position)            | position (Vector3 — pixel x/y, distance from camera in z) | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html) |
| Camera ScreenToWorldPoint (position, eye)       | position (Vector3), eye (Enum&lt;Camera.MonoOrStereoscopicEye&gt;) | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html) |
| Camera ScreenToViewportPoint (nPosition)        | nPosition (Vector3)                       | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ScreenToViewportPoint.html) |
| Camera ViewportToScreenPoint (position)         | position (Vector3)                        | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ViewportToScreenPoint.html) |
| Camera ViewportToWorldPoint (position)          | position (Vector3)                        | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ViewportToWorldPoint.html) |
| Camera ViewportToWorldPoint (position, eye)     | position (Vector3), eye (Enum)            | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.ViewportToWorldPoint.html) |
| Camera WorldToScreenPoint (position)            | position (Vector3)                        | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html) |
| Camera WorldToScreenPoint (position, eye)       | position (Vector3), eye (Enum)            | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html) |
| Camera WorldToViewportPoint (nPosition)         | nPosition (Vector3)                       | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.WorldToViewportPoint.html) |
| Camera WorldToViewportPoint (nPosition, eye)    | nPosition (Vector3), eye (Enum)           | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Camera.WorldToViewportPoint.html) |

## Render control

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Camera Render ()                | —          | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.Render.html) |
| Camera RenderDontRestore ()     | —          | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.RenderDontRestore.html) |

## Reset operations

Reset various camera matrices and states back to defaults — typically used after temporary overrides for cinematics or special effects.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Camera Reset ()                                | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.Reset.html) |
| Camera ResetAspect ()                          | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetAspect.html) |
| Camera ResetCullingMatrix ()                   | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetCullingMatrix.html) |
| Camera ResetProjectionMatrix ()                | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetProjectionMatrix.html) |
| Camera ResetReplacementShader ()               | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetReplacementShader.html) |
| Camera ResetStereoProjectionMatrices ()        | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetStereoProjectionMatrices.html) |
| Camera ResetStereoViewMatrices ()              | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetStereoViewMatrices.html) |
| Camera ResetTransparencySortSettings ()        | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetTransparencySortSettings.html) |
| Camera ResetWorldToCameraMatrix ()             | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.ResetWorldToCameraMatrix.html) |

## Stereo / gate-fit (advanced)

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Camera CopyStereoDeviceProjectionMatrixToNonJittered (eye) | eye (Enum&lt;Camera.StereoscopicEye&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.CopyStereoDeviceProjectionMatrixToNonJittered.html) |
| Camera GetGateFittedFieldOfView ()             | — | Float | [↗](https://docs.unity3d.com/ScriptReference/Camera.GetGateFittedFieldOfView.html) |
| Camera GetGateFittedLensShift ()               | — | Vector2 | [↗](https://docs.unity3d.com/ScriptReference/Camera.GetGateFittedLensShift.html) |

## Command buffers

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Camera RemoveAllCommandBuffers ()              | — | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.RemoveAllCommandBuffers.html) |
| Camera RemoveCommandBuffers (evt)              | evt (Enum&lt;CameraEvent&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/Camera.RemoveCommandBuffers.html) |

## See also

- [2D Camera Lerp](./2d-camera-lerp) — cinematic tween between camera shots
- [Camera Rotation](./camera-rotation) — toggle camera-control input mode
- [Main Camera](/docs/Flow/Nodes/Player/main-camera)
