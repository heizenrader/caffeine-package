---
sidebar_position: 3
sidebar_label: Get Net Ownership
title: Get Net Ownership
---

# <span class="net-node">Get Net Ownership</span> <span class="net-badge">NET</span>

Transfers ownership of a networked GameObject to the local client. Some networking actions (transform writes, destroy) require the caller to own the object — call this node first if you need to act on something another client currently owns.

**Category:** Action (Net)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The networked GameObject to take ownership of. |

:::tip Pair with Net Is Mine
Branch on [Net Is Mine](./net-is-mine) before doing ownership-required work. If you don't own the object, kick Get Net Ownership first.
:::

## See also

- [Net Is Mine](./net-is-mine)
- [Net Is Host](./net-is-host)
- [Net Destroy](./net-destroy)
