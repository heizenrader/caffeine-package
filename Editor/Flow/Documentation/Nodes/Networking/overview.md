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

## What makes an object networked

Before any of these nodes are useful, the object has to be networked in the first place — that is, its position, rotation and scale replicate to every player in the session. Three things do that:

| How | When to use it |
|---|---|
| The object is a **step interactable** | Anything the learner already grabs, turns, or slides. |
| It was spawned by **[Net Instantiate](./net-instantiate)** | Objects that don't exist until runtime. |
| It carries a **Movable Joint** component | A plain scene object that isn't an interactable. |

The Movable Joint route is the one creators reach for when an object needs to be shared but isn't part of a step interaction. Add the component and set **Linear X / Y / Z Motion** to **Free**, leaving **Axis of Rotation** at zero — that gives you a fully unconstrained object whose transform is shared.

Keep the object under the **Models** root. That's the only part of the hierarchy scanned for Movable Joints when the session starts, so one placed elsewhere never gets networked.

:::caution Check the motion fields
A newly added Movable Joint has all three linear motions set to **Locked**, which holds the object at its starting position. If you're adding the joint to share an object rather than to constrain it, switch all three to **Free** — otherwise the object is networked but can never move.

The reverse is worth knowing too: if you add a Movable Joint purely to limit how far something can swing or slide, that object is now networked as well.
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
