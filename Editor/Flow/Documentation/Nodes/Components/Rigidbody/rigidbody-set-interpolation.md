---
sidebar_position: 1
---

# Rigidbody SetInterpolation

Sets a Rigidbody's interpolation mode — controls how the Rigidbody's visual position is smoothed between physics ticks.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Rigidbody-interpolation.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| rigidBody | Rigidbody | The Rigidbody to update. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| interpolation | Enum&lt;RigidbodyInterpolation&gt; | `None` — no smoothing (cheapest, can stutter). `Interpolate` — smooth based on previous frame's position. `Extrapolate` — predict next frame's position from velocity. |

:::tip Pick interpolation per object
Use `Interpolate` for player-controlled or visually-prominent Rigidbodies (smooth visual motion). Use `None` for non-visible or very-fast-moving objects where the cost isn't worth it. `Extrapolate` is rarely the right choice — it can overshoot at rest.
:::

## See also

- Other Rigidbody codegen nodes (AddForce, SetVelocity, MovePosition)
