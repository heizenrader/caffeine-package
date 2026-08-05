---
sidebar_position: 15
sidebar_label: Net OnPlayerEnter
title: Net OnPlayerEnter
---

# <span class="net-node">Net OnPlayerEnter</span> <span class="net-badge">NET</span>

Fires on every existing client when a new player joins the multiplayer session. Use it to update rosters, spawn UI for the new player, or sync state to them.

**Category:** Event (Net, Lifecycle)
**Component / Source:** Built-in (multiplayer)

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks on every existing client when a new player joins. |

:::tip Pair with Net Avatar
After the event fires, query [Net Avatar](/docs/Flow/Nodes/Player/net-avatar) for the joining player to set up per-player UI or effects.
:::

## See also

- [Net OnPlayerExit](./net-on-player-exit)
- [Net Avatar](/docs/Flow/Nodes/Player/net-avatar)
- [Networking in Flow](/docs/Flow/flow-networking)
