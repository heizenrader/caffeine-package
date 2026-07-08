---
sidebar_position: 8
---

# On Destroy

Fires once when the host GameObject is destroyed (or when the scene unloads). Use it as the final cleanup hook — release allocations, unregister from external systems, write final state to save.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDestroy.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once when the host GameObject is destroyed. |

:::warning Don't kick scene-modifying actions here
On Destroy fires during the destruction phase — don't try to instantiate new GameObjects or modify the scene from this flow. Use it for final reads, logs, or external API cleanup.
:::

## See also

- [On Disable](./on-disable)
- [Awake](./awake)
