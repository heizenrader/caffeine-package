---
sidebar_position: 6
---

# On Enable

Fires every time the host GameObject is enabled (or re-enabled) — once on initial activation, and again every time `SetActive(true)` is called after an `SetActive(false)`. Use it for "wake back up" logic that should rerun on every activation.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks each time the host GameObject becomes active. |

:::tip On Enable vs Start
Start fires only once per GameObject lifetime; On Enable fires on every activation. Use On Enable for state that should reset on each show/hide cycle (UI animations, timer resets, "appearing" cues).
:::

## See also

- [On Disable](./on-disable)
- [Awake](./awake)
- [Start](./start)
