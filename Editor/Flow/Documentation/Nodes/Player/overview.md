---
sidebar_position: 0
sidebar_label: Overview
---

# Player Nodes

Player nodes return GameObject references to elements of the active player — the main camera, the VR rig and its parts, or another player's avatar in a multiplayer session. Wire them into nodes that need to attach UI to the headset, parent objects to a hand, drive per-player effects, or query player position.

All Player nodes are pure data — no Flow ports.

## Nodes

| Node | Description |
|---|---|
| [Main Camera](./main-camera)  | Active main camera GameObject (`Camera.main`). |
| [VR Player](./vr-player)      | A specific element of the local VR rig — rig root, headset, hands, hand models, pointers. |
| [Net Avatar](./net-avatar)    | The local player's or a remote player's avatar — name, color, ID, head, hands, name text. |

## See also

- [Self](/docs/Flow/Nodes/Variables/self) — the GameObject hosting the current graph
- [Networking in Flow](/docs/Flow/flow-networking)
