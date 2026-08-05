---
sidebar_position: 7
sidebar_label: Net Variable
title: Net Variable
---

# <span class="net-node">Net Variable</span> <span class="net-badge">NET</span>

The networked counterpart of [Local Variable](./local-variable). Writes are replicated to every player in the session — when any client kicks the node, the new value is broadcast and the standard Flow output (`exit`) fires on every client.

**Category:** Variable (Net)
**Kind:** Variable accessor (local scope, replicated)

:::note Editor menu path
Net Variable appears in the Add Node menu under `Flow/Networking/Variable/Net Variable`.
:::

## Behavior

Identical input / output shape to [Local Variable](./local-variable) — pick a `Type` in the inspector, and the matching input / output pair becomes active. The difference is the write path: when the node runs locally, the new value is sent to all other clients, and on each remote client the same value is applied to the local copy and `exit` fires.

## Inputs

Same as [Local Variable](./local-variable#inputs). The active input pair depends on the `Type` inspector field.

## Outputs

Same as [Local Variable](./local-variable#outputs).

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type     | Enum&lt;SerializedType&gt; | Selects which input / output pair is active. |
| value    | Typed                      | The currently stored value. |

:::tip Prefer Net variants for shared state
If two players should see the same value (a score, a selected answer, a current step), use Net Variable. Use [Local Variable](./local-variable) only for client-local state that other players don't need to see (per-client UI state, animation timers, view preferences).
:::

:::warning Every write is broadcast
Each kick of a Net Variable produces a network message. Don't put one inside a tight [Update](/docs/Flow/Nodes/Events/update) loop unless you genuinely need per-frame replication — gate writes behind a [Comparison](/docs/Flow/Nodes/Logic/comparison) so the network only sees changes worth sending.
:::

## See also

- [Local Variable](./local-variable) — non-networked counterpart
- [Global Variable](./global-variable) — has its own popup-based Local / Net flavors
- [Graph Variable](./graph-variable) — graph-scoped variable with popup-based Local / Net flavors
- [Networking in Flow](/docs/Flow/flow-networking)
