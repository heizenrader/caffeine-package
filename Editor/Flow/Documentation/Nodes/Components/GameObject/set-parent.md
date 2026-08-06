---
sidebar_position: 9
---

# Set Parent

Reparents a Transform to a new parent. Use it to attach picked-up objects to a hand, stick UI to a moving target, or reorganize hierarchy at runtime.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Transform.SetParent.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| target    | Transform | The Transform to reparent. |
| newParent | Transform | The new parent. Pass `null` (unconnected with no inspector default) to move the target to the scene root. |

## See also

- [Get Parent](./get-parent)
- [Transform Lerp](/docs/Flow/Nodes/Components/General/transform-lerp) — smooth-animate a parenting move
