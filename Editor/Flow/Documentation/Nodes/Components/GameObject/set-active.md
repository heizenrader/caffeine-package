---
sidebar_position: 5
---

# Set Active

Activates or deactivates a GameObject — toggles its `activeSelf` state. Use it to show / hide objects, enable / disable features, gate behaviors that should only run when the object is active.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| target | GameObject | The GameObject to set active state on. |
| active | Bool       | `true` to activate, `false` to deactivate. |

:::tip Set Active triggers OnEnable / OnDisable
A GameObject becoming active fires its [On Enable](/docs/Flow/Nodes/Events/on-enable) flow; deactivating fires [On Disable](/docs/Flow/Nodes/Events/on-disable). Use those events to react to activation transitions.
:::

## See also

- [Destroy](./destroy)
- [Instantiate](./instantiate)
- [On Enable](/docs/Flow/Nodes/Events/on-enable) / [On Disable](/docs/Flow/Nodes/Events/on-disable)
