---
sidebar_position: 10
---

# Late Update

Kicks every frame *after* all [Update](./update) handlers have run (Unity's `MonoBehaviour.LateUpdate`). Use it for logic that needs to read state already advanced this frame — camera follow, UI position adjustments after the player moves, post-animation tweaks.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, skips this frame's kick. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once per frame, after all Update handlers. |

:::tip Late Update for "follow" behaviors
A camera that follows the player should run in Late Update — by then the player has moved (in Update or via input) and the camera can read the final position cleanly. Doing the same in Update produces a one-frame lag.
:::

:::note Skipped while paused
Late Update does not kick while the experience is paused by [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience).
:::

## See also

- [Update](./update)
- [FixedUpdate](./fixed-update)
