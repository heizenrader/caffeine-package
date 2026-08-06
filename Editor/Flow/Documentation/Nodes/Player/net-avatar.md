---
sidebar_position: 3
sidebar_label: Net Avatar
title: Net Avatar
---

# <span class="net-node">Net Avatar</span> <span class="net-badge">NET</span>

Returns the avatar of the local player or any other player in the multiplayer session. Outputs the avatar's name, color, ID, and the GameObjects for its head, hands, and floating name text — wire these into other nodes to attach UI, drive effects on a specific player, or display roster information.

**Category:** Variable (Net)
**Kind:** Property

:::note Editor menu path
Appears in the Add Node menu under `Flow/Networking/Net Avatar`. Documented here under Player since it's the canonical way to query player-avatar data.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| avatarID | Int | The numeric ID of a remote player whose avatar to look up. Only used when `local` is `false` — hidden in the inspector when `local` is `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| AvatarName     | String     | The avatar's display name. |
| AvatarColor    | Color      | The avatar's display color. |
| AvatarID       | Int        | The avatar's numeric ID. |
| AvatarHead     | GameObject | The avatar's head model. |
| AvatarRightHand| GameObject | The avatar's right-hand model. |
| AvatarLeftHand | GameObject | The avatar's left-hand model. |
| AvatarNameText | GameObject | The floating name-text GameObject above the avatar. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| local | Bool | When `true`, the node returns the **current player's** avatar and `avatarID` is ignored. When `false`, the node looks up the player whose avatar matches the `avatarID` input. |

:::tip Pick the right mode
For "show me where I am" or "attach UI to my own head", set `local = true`. For per-player rosters, "highlight the player who clicked", or any flow that iterates over remote avatars, leave `local = false` and feed `avatarID` from the player you care about.
:::

## See also

- [VR Player](./vr-player) — local-player VR rig elements (more granular than Net Avatar's hand models)
- [Main Camera](./main-camera)
- [Networking in Flow](/docs/Flow/flow-networking)
