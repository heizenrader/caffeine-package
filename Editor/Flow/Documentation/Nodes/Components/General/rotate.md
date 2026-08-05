---
sidebar_position: 17
---

# Rotate

Rotates a Transform by Euler angles each time the node runs. Use it to apply incremental rotations — spin objects, nudge pose, accumulate rotation per frame.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| target | Transform | The Transform to rotate. |
| eulers | Vector3   | Euler angles to apply, in degrees. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| space | Enum&lt;Space&gt; | `Self` — rotate around the Transform's local axes. `World` — rotate around world axes. |

:::tip Multiply by Delta Time for per-frame spin
For continuous rotation driven by an [Update](/docs/Flow/Nodes/Events/update), multiply your degrees-per-second by [Delta Time](/docs/Flow/Nodes/Variables/delta-time) so spin speed is frame-rate-independent.
:::

## See also

- [Translate](./translate)
- [Transform Lerp](./transform-lerp)
- [Quaternion nodes](/docs/Flow/Nodes/Math/Quaternion/overview)
