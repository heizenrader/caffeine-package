---
sidebar_position: 6
---

# Destroy

Destroys a GameObject. Use it to permanently remove objects — picked-up items, finished projectiles, dismissed UI.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Object.Destroy.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to destroy. |

:::tip Destroy vs Set Active
For temporary hides where the object will come back, use [Set Active](./set-active) — destroying and re-instantiating is much more expensive. Reserve Destroy for genuinely permanent removals.
:::

:::warning Multiplayer destroys aren't replicated
Plain Destroy only removes the GameObject on the local client. To remove a networked object on every player, use [Net Destroy](/docs/Flow/Nodes/Networking/net-destroy) instead.
:::

## See also

- [Net Destroy](/docs/Flow/Nodes/Networking/net-destroy)
- [Instantiate](./instantiate)
- [Set Active](./set-active)
