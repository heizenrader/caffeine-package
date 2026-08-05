---
sidebar_position: 1
---

# SetLookAtPosition Full

Sets both the Animator's IK look-at target position and the look-at weight in a single node — a convenience over calling `SetLookAtPosition` and `SetLookAtWeight` separately. Use it inside an [On Animator IK](/docs/Flow/Nodes/Events/on-animator-ik) flow to drive the character's head/eyes toward a target.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtPosition.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| animator | Animator | The Animator whose IK look-at to set. |
| target   | Vector3  | World-space position to look at. |
| weight   | Float    | Look-at weight (0 = no look-at, 1 = full). |

:::tip Run inside On Animator IK
The Animator only applies look-at IK during the IK pass. Wire this node downstream of [On Animator IK](/docs/Flow/Nodes/Events/on-animator-ik) so the values are set at the right time — calling it from Update or other flows may have no visible effect.
:::

## See also

- [On Animator IK](/docs/Flow/Nodes/Events/on-animator-ik)
- Other Animator codegen nodes (Play, CrossFade, SetTrigger, etc.)
