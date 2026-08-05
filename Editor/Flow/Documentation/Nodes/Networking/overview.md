---
sidebar_position: 0
sidebar_label: Overview
---

# Networking Nodes

Networking nodes are net-specific actions and queries — replicate spawns and destroys across players, query ownership, check host status, configure avatar models. They don't have local counterparts; each one only makes sense in a multiplayer context.

Other Net variants live alongside their local counterparts in their respective categories — see [Net Variable](/docs/Flow/Nodes/Variables/net-variable), [Net Select Event](/docs/Flow/Nodes/Events/net-select-event), and so on.

:::note Editor menu path
Networking nodes appear in the Add Node menu under `Flow/Networking/...`. They're grouped here as a top-level category in the docs.
:::

## Nodes

**Spawn / destroy:**

| Node | Description |
|---|---|
| [Net Instantiate](./net-instantiate)            | Spawn a prefab on every client. |
| [Net Destroy](./net-destroy)                    | Destroy a GameObject on every client. |

**Ownership / identity:**

| Node | Description |
|---|---|
| [Get Net Ownership](./get-net-ownership)        | Take ownership of a networked GameObject on the local client. |
| [Net Is Host](./net-is-host)                    | True when the local client is the session host. |
| [Net Is Mine](./net-is-mine)                    | True when the local client owns a specific GameObject. |

**Player presence:**

| Node | Description |
|---|---|
| [Net Avatar](/docs/Flow/Nodes/Player/net-avatar) | Query a player's avatar (documented under Player). |
| [Set Net Avatar Models](./set-net-avatar-models) | Replace the head / hand models of an avatar by player ID. |

**Other:**

| Node | Description |
|---|---|
| [Net Kick](./net-kick) | Internal Net trampoline used by other Net flows. Rarely added directly. |

## See also

- [Networking in Flow](/docs/Flow/flow-networking)
- [Net Variable](/docs/Flow/Nodes/Variables/net-variable), [Net Select Event](/docs/Flow/Nodes/Events/net-select-event), [Net Trigger Event](/docs/Flow/Nodes/Events/net-trigger-event), [Net OnPlayerEnter](/docs/Flow/Nodes/Events/net-on-player-enter), [Net OnPlayerExit](/docs/Flow/Nodes/Events/net-on-player-exit)
