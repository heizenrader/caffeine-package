---
sidebar_position: 20
---

# Transform Lerp

Smoothly tweens one Transform to align with another (matching local position and rotation) over a duration, using DOTween. Use it to snap an object to a target placement smoothly — moving a held object onto a stand, parenting via animation.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| lerpTime          | Float     | Duration of the tween, in seconds. |
| originalTransform | Transform | The Transform to move. |
| target            | Transform | The Transform to align with. The original ends up at the target's local position and rotation (relative to its parent). |

:::note Eases out — not a steady speed
The move starts fast and slows into the target: halfway through `lerpTime` it has covered about three quarters of the way, and it starts at twice its average speed. That suits placing objects and camera moves. For something that should keep one speed — a person walking, a vehicle, a conveyor — move it a little every frame instead: an [Update](/docs/Flow/Nodes/Events/update) event that sets its position to [Vector3 MoveTowards](/docs/Flow/Nodes/Math/Vector3/overview) (current position, target, speed × [Delta Time](/docs/Flow/Nodes/Variables/delta-time)).
:::

:::tip Use for "snap to slot" animations
A common pattern: when an A-to-B interaction completes, kick this node with `originalTransform = movedObject.transform` and `target = slot.transform` to smoothly snap the moved object into the target slot.
:::

:::warning Cancels existing tweens on the target
Each kick calls `DOTween.Kill(originalTransform)` first — avoid simultaneous Lerp nodes on the same Transform.
:::

## See also

- [GameObject Lerp](./gameobject-lerp) — variant that lerps to a Vector3 / Quaternion target
- [Delay](./delay) — chain on tween completion
