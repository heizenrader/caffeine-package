---
sidebar_position: 15
sidebar_label: Net OnPlayerEnter
title: Net OnPlayerEnter
---

# <span class="net-node">Net OnPlayerEnter</span> <span class="net-badge">NET</span>

Fires on the host only, once a new player has joined the multiplayer session and loaded the course.

**Category:** Event (Net, Lifecycle)
**Component / Source:** Built-in (multiplayer)

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks on the host only, once the new player has loaded the course. |

:::note Host only
What this event runs happens on the host's device only, and it has no output for the joining player: UI or effects set up here appear on the host's screen only.
:::

## See also

- [Net OnPlayerExit](./net-on-player-exit)
- [Net Avatar](/docs/Flow/Nodes/Player/net-avatar)
- [Networking in Flow](/docs/Flow/flow-networking)
