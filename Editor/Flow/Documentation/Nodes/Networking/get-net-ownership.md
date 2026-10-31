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

:::caution Ownership isn't granted instantly
Don't move the object on the node wired straight after Get Net Ownership. Request ownership when the learner grabs, then gate the actual per-frame movement behind [Net Is Mine](./net-is-mine) so it starts once ownership has landed.
:::

## Request ownership from the local event, not the Net one

When several players each grab a different object, drive Get Net Ownership from the plain [Select Event](/docs/Flow/Nodes/Events/select-event) — it fires only on the client that clicked, so only that player asks for the object.

Wiring it to [Net Select Event](/docs/Flow/Nodes/Events/net-select-event) instead makes *every* client request ownership of the same object the moment anyone clicks it, and they fight over it.

The general rule: Net events are for things everyone should see happen; local events answer "what did **this** player just do".

## Shared grabbable pattern

The common setup for a rack of objects that different players can each pick up:

1. Give each object a Movable Joint with all three linear motions set to **Free** (see [what makes an object networked](./overview#what-makes-an-object-networked)).
2. On the local **Select Event**, kick Get Net Ownership and set a "held" variable.
3. On **Update**, gated by that variable, branch on **Net Is Mine** and move the object only on the branch where you own it.
4. If players should be able to drop the object, clear the "held" variable on select-up.

## See also

- [Net Is Mine](./net-is-mine)
- [Net Is Host](./net-is-host)
- [Net Destroy](./net-destroy)
