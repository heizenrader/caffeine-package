---
sidebar_position: 7
sidebar_label: Net Kick
title: Net Kick
---

# <span class="net-node">Net Kick</span> <span class="net-badge">NET</span>

Runs the rest of a chain on every player's device. Use it when one player's action should play out for everyone: a door opens, a sound plays, a counter goes up.

**Category:** Action (Net)

## How it behaves

- **On the device that runs it**, the nodes after Net Kick run straight away, once.
- **On every other player's device**, the nodes after Net Kick run once when the message arrives. The nodes before it don't run there.
- **Anyone can send one**, not only the host.
- **Playing alone, and in editor play mode**, it passes straight through: the rest of the chain runs once on this device.
- **It carries no data.** The nodes after it read each device's own values, so a variable the sender set just before the kick still has its old value on the other devices. To share a value, write a [Net Variable](/docs/Flow/Nodes/Variables/net-variable): the write reaches every device and runs its exit there.
- **While the course is still starting** (Awake, Start), a kick reaches only this device.

## Typical use

Start from the local event of the person who acted, then kick:

**Select Event** (On Select Down) → **Net Kick** → **Set Active** (door, false) → **Play Sound**

Everyone sees the door open, and the click is handled once per device.

:::caution Things that already sync
Objective completion syncs on its own. Put **Objective Completion** before the kick, not after it: after it, every device completes the objective and its sound and show/hide actions repeat. **Go To Step** only works on the host, and on other devices it is ignored. A Go To Step after a kick therefore moves everyone, because the host runs it too.
:::

## See also

- [Net Variable](/docs/Flow/Nodes/Variables/net-variable)
- [Net Select Event](/docs/Flow/Nodes/Events/net-select-event)
- [Net Is Host](./net-is-host)
- [Networking in Flow](/docs/Flow/flow-networking)
