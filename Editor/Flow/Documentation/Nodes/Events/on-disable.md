---
sidebar_position: 7
---

# On Disable

Fires every time the host GameObject is disabled — when `SetActive(false)` is called, when the GameObject is destroyed (just before [On Destroy](./on-destroy)), and when the scene unloads. Use it for "going away" logic that should run on every deactivation.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks each time the host GameObject becomes inactive. |

:::tip Cleanup pattern
Use On Disable to undo what [On Enable](./on-enable) set up — stop animations, hide UI, pause timers. The pair acts as the "show/hide" cycle for transient state.
:::

## See also

- [On Enable](./on-enable)
- [On Destroy](./on-destroy)
