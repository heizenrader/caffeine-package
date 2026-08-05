---
sidebar_position: 5
sidebar_label: Net Is Mine
title: Net Is Mine
---

# <span class="net-node">Net Is Mine</span> <span class="net-badge">NET</span>

Returns `true` when the local client owns the given GameObject. Pair with [Get Net Ownership](./get-net-ownership) to gate ownership-required actions and avoid contention.

**Category:** Variable (Net)
**Kind:** Predicate

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to check ownership of. |

## Outputs

| Port | Type | Description |
|---|---|---|
| isMine | Bool | `true` when the local client owns the input GameObject. Returns `true` on non-net builds. |

:::tip Take ownership before writing
A typical "I want to move this" flow: Net Is Mine → if `false`, [Get Net Ownership](./get-net-ownership) → then perform the write. The owner check avoids needless ownership transfers when the local client already owns the object.
:::

## See also

- [Get Net Ownership](./get-net-ownership)
- [Net Is Host](./net-is-host)
