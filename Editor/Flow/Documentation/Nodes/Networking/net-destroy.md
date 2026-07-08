---
sidebar_position: 2
sidebar_label: Net Destroy
title: Net Destroy
---

# <span class="net-node">Net Destroy</span> <span class="net-badge">NET</span>

Destroys a GameObject on every client in the multiplayer session — the mirror of [Net Instantiate](./net-instantiate). Use it to remove networked objects so that all players see the removal.

**Category:** Action (Net)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to destroy across the network. |

:::tip Falls back to regular Destroy
If no networking layer is active, this node falls back to a regular Unity `Destroy(gameObject)` — safe to use in both single- and multiplayer modes.
:::

## See also

- [Net Instantiate](./net-instantiate)
- [Net Is Mine](./net-is-mine) — only the owner can typically destroy networked objects
