---
sidebar_position: 3
---

# Update

Kicks every frame, analogous to Unity's `MonoBehaviour.Update()`. Use it for per-frame logic like polling input, smoothing values, or driving animations that aren't already handled by Caffeine's animation system.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, skips this frame's kick. Useful for gating expensive per-frame logic behind a state variable. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once per frame. |

## Notes & gotchas

:::warning Performance
Update fires every frame on every active graph. Avoid heavy work (allocations, network calls, lookups by name) inside an Update — gate it behind the `Enabled` port or move it to a less frequent event when possible.
:::

:::note Skipped while paused
Update does not kick while the experience is paused by [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience). [Late Update](./late-update) and [FixedUpdate](./fixed-update) are gated the same way. Lifecycle, interaction, course, and signal events still fire — branch on [Is Experience Paused](/docs/Flow/Nodes/Logic/is-experience-paused) inside those handlers if you want them to skip work during pause.
:::

## See also

- [Flow known issues](/docs/Flow/flow-known-issues)
