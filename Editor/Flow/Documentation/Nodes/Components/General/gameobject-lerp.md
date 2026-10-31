---
sidebar_position: 19
---

# GameObject Lerp

Smoothly tweens a GameObject's position and rotation toward target values over a duration, using DOTween. Use it for "move to here over N seconds" animations — placing objects, transitioning between camera angles, returning props to a starting position.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| lerpTime      | Float      | Duration of the tween, in seconds. |
| gameObject    | GameObject | The GameObject to move. |
| inputPosition | Vector3    | Target world position. |
| inputRotation | Quaternion | Target rotation (defaults to `Quaternion.identity`). |

:::note Eases out — not a steady speed
The move starts fast and slows into the target: halfway through `lerpTime` it has covered about three quarters of the way, and it starts at twice its average speed. That suits placing objects and camera moves. For something that should keep one speed — a person walking, a vehicle, a conveyor — move it a little every frame instead: an [Update](/docs/Flow/Nodes/Events/update) event that sets its position to [Vector3 MoveTowards](/docs/Flow/Nodes/Math/Vector3/overview) (current position, target, speed × [Delta Time](/docs/Flow/Nodes/Variables/delta-time)).
:::

:::note Rotation turns over the same time
The object turns to `inputRotation` over the whole `lerpTime`, together with the move. To face the way first and then travel, run a short Lerp that keeps the position and changes only the rotation, then the move with that same rotation.
:::

:::tip Tween-based, not per-frame
The tween runs in the background once kicked — the standard `exit` fires immediately when the tween starts, not when it finishes. There's no "completed" callback on this node; if you need to chain on completion, use a [Delay](./delay) of the same duration.
:::

:::warning Cancels existing tweens on the target
Each kick calls `DOTween.Kill(gameObject.transform)` first, so any in-progress tween on the same transform is cancelled. Avoid running multiple Lerp nodes on the same target simultaneously.
:::

## See also

- [Transform Lerp](./transform-lerp) — variant that lerps to another Transform instead of a Vector3 / Quaternion
- [Delay](./delay) — chain on tween completion
- [Translate](./translate) — incremental movement (no tween)
