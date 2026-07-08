---
sidebar_position: 4
sidebar_label: Net Is Host
title: Net Is Host
---

# <span class="net-node">Net Is Host</span> <span class="net-badge">NET</span>

Returns `true` when the local client is the session host. Use it to gate logic that only the host should run — spawning shared objects, advancing global state, awarding round-level results.

**Category:** Variable (Net)
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| isHost | Bool | `true` when the local client is the host. Returns `true` on non-net builds (treats single-player as "you're the host"). |

:::tip Single-player friendly
On a non-net build, this returns `true` so host-gated flows still execute. You don't need to branch on "is multiplayer" separately.
:::

## See also

- [Net Is Mine](./net-is-mine)
- [Get Net Ownership](./get-net-ownership)
