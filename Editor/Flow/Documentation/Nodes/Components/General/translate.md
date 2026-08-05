---
sidebar_position: 18
---

# Translate

Moves a Transform by a direction vector each time the node runs. Use it for incremental translation — character movement, sliding objects, accumulating offsets.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Transform.Translate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| target    | Transform | The Transform to move. |
| direction | Vector3   | Direction and magnitude to translate by. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| space | Enum&lt;Space&gt; | `Self` — interpret `direction` in local space. `World` — interpret in world space. |

:::tip Multiply by Delta Time for per-frame motion
For continuous movement driven by an [Update](/docs/Flow/Nodes/Events/update), multiply units-per-second by [Delta Time](/docs/Flow/Nodes/Variables/delta-time) so motion stays frame-rate-independent.
:::

## See also

- [Rotate](./rotate)
- [GameObject Lerp](./gameobject-lerp) — smooth interpolated movement instead of incremental
