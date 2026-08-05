---
sidebar_position: 4
---

# Awake

Fires once when the GameObject hosting the graph is initialized, before [Start](./start) and before any per-frame events. Use it for one-time setup that must run before anything else — caching references, initializing state, registering handlers.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once when the host GameObject is awakened. |

:::tip Awake vs Start
Awake fires *before* Start and even on inactive GameObjects (when the component initializes). Use Awake for setup that other Awake / Start logic depends on; use [Start](./start) for setup that should wait until the GameObject is active.
:::

## See also

- [Start](./start)
- [On Enable](./on-enable)
- [Update](./update)
