---
sidebar_position: 11
---

# On Animator IK

Fires every IK pass on a connected Animator, with the current IK layer index available as a data output. Use it to drive Animator IK goal positions and rotations from a Flow Graph (e.g., point a hand at a target, look at the player).

**Category:** Event (Lifecycle)
**Component / Source:** Unity `Animator`
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnAnimatorIK.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| animator | Animator | The Animator whose IK pass should drive this event. Required. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow          | Flow | Kicks once per IK pass on the connected Animator. |
| layerAnimator | Int  | The layer index of the current IK pass. Use it to gate logic that should only run on a specific layer. |

:::tip Drive Animator IK from a flow
Inside the kicked flow, wire `Animator SetIKPositionWeight` / `Animator SetIKPosition` (and similar IK setters from the [Animator action nodes](/docs/Flow/Nodes/Components/Animator/overview)) to position IK goals. The IK pass itself happens in this event — setters from elsewhere may have stale effects.
:::

## See also

- [Animator action nodes](/docs/Flow/Nodes/Components/Animator/overview)
- [Update](./update)
