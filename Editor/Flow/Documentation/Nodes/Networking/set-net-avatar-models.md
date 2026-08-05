---
sidebar_position: 6
sidebar_label: Set Net Avatar Models
title: Set Net Avatar Models
---

# <span class="net-node">Set Net Avatar Models</span> <span class="net-badge">NET</span>

Replaces the head and hand model GameObjects of a networked avatar identified by player ID. Use it to swap avatar appearance at runtime — character customization, role-based skins, or per-step costume changes.

**Category:** Action (Net)

## Inputs

| Port | Type | Description |
|---|---|---|
| ID         | Int        | The player ID of the avatar to update. Pair with [Net Avatar](/docs/Flow/Nodes/Player/net-avatar)'s `AvatarID` output to find specific players. |
| Head       | GameObject | The new head model. |
| RightHand  | GameObject | The new right-hand model. |
| LeftHand   | GameObject | The new left-hand model. |

:::tip Cross-reference Net Avatar
Pair this with [Net Avatar](/docs/Flow/Nodes/Player/net-avatar) to read existing avatar IDs, then call this to update the chosen player's models.
:::

## See also

- [Net Avatar](/docs/Flow/Nodes/Player/net-avatar)
- [Net Instantiate](./net-instantiate)
