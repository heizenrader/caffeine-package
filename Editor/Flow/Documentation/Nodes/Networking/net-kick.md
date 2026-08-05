---
sidebar_position: 7
sidebar_label: Net Kick
title: Net Kick
---

# <span class="net-node">Net Kick</span> <span class="net-badge">NET</span>

Internal Net trampoline used by other Net flows to continue execution on the network layer. Most graphs don't add this node directly — it's primarily a building block used by other Net actions.

**Category:** Action (Net)

:::note Advanced / rarely added by hand
This node is exposed in the Add Node menu but most use cases are covered by higher-level Net nodes ([Net Instantiate](./net-instantiate), [Net Destroy](./net-destroy), Net Variables, Net Events). Reach for Net Kick only when building custom Net interactions that don't fit the existing patterns.
:::

## See also

- [Net Instantiate](./net-instantiate)
- [Net Destroy](./net-destroy)
- [Networking in Flow](/docs/Flow/flow-networking)
