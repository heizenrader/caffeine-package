---
sidebar_position: 1
---

# Main Camera

Returns the GameObject of the active main camera (`Camera.main`). On 2D platforms (PC, mobile, tablet) this is the player's view camera; on VR it's typically the headset's eye camera.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Camera-main.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| camera | GameObject | The GameObject of the camera tagged `MainCamera`. Returns `null` if no camera is currently tagged. |

:::tip Pair with Get Component for Camera-typed access
This node returns the GameObject. To read or set Camera-component fields (FOV, culling mask, target texture), wire it through a Get Component node typed to `Camera`.
:::

## See also

- [VR Player](./vr-player) — for VR-specific rig elements (rig root, hands, pointers)
- [Self](/docs/Flow/Nodes/Variables/self) — the GameObject hosting the graph
