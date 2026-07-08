---
sidebar_position: 2
---

# VR Player

Returns a GameObject for a specific element of the active VR rig — the whole rig, the headset, the hands, hand models, or controller pointers. Use it to attach UI to the headset, parent objects to a hand, or spawn effects from a controller.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject for the selected `device`. Returns `null` outside a VR build or if the rig is not yet initialized. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| device | Enum&lt;VRPlayerElement&gt; | Which rig element to return — `VRRig`, `Headset`, `RightHand`, `LeftHand`, `RightHandModel`, `LeftHandModel`, `RightHandPointer`, `LeftHandPointer`. |

:::tip Hand vs HandModel
`RightHand` / `LeftHand` is the controller anchor (transform tracking the controller pose); `RightHandModel` / `LeftHandModel` is the visible mesh attached to it. Use the anchor for parenting and physics queries, the model for visibility toggles or material swaps.
:::

:::tip Pointer for laser-style aim
`RightHandPointer` / `LeftHandPointer` is the GameObject driving the controller's laser/raycast pointer. Read its forward direction or position to sync custom UI or feedback to where the user is aiming.
:::

## See also

- [Main Camera](./main-camera) — for non-VR or generic main-camera access
- [Net Avatar](./net-avatar) — for accessing other players' avatar elements in multiplayer
- [Is Hand Tracking](/docs/Flow/Nodes/Input/overview) — gate VR-controller logic when the user is using hand tracking instead
