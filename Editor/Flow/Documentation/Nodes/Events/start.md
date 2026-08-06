---
sidebar_position: 5
---

# Start

Fires once before the first frame update on an active GameObject, after [Awake](./awake). Use it for setup that should run when the GameObject becomes active — initial scene state, opening UI, kicking off intro sequences.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once before the first Update of the host GameObject. |

:::tip Start vs Awake
Start runs *after* Awake on every component, so Start logic can depend on values that Awake handlers set. Start does not fire on inactive GameObjects — only when the GameObject becomes active.
:::

## See also

- [Awake](./awake)
- [On Enable](./on-enable)
- [Update](./update)
