---
sidebar_position: 9
---

# FixedUpdate

Kicks every fixed-physics tick, at a constant rate independent of frame rate (Unity's `MonoBehaviour.FixedUpdate`). Use it for physics-driven flows that need consistent timing — applying forces, moving Rigidbodies, integrating physical state.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, skips this tick's kick. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once per fixed-physics tick. |

:::tip FixedUpdate vs Update
Use FixedUpdate for **physics** (Rigidbody forces, MovePosition, joints). Use [Update](./update) for **per-frame** logic (input polling, animation state, UI updates). Mixing them produces glitchy motion — physics moves at the fixed rate while visuals move at the frame rate.
:::

:::tip Read Fixed Delta Time, not Delta Time
Pair FixedUpdate with [Fixed Delta Time](/docs/Flow/Nodes/Variables/fixed-delta-time) for the per-tick interval — it's a constant value, unlike `Delta Time` which varies per frame.
:::

:::note Skipped while paused
FixedUpdate does not kick while the experience is paused by [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience).
:::

## See also

- [Update](./update)
- [Late Update](./late-update)
- [Fixed Delta Time](/docs/Flow/Nodes/Variables/fixed-delta-time)
