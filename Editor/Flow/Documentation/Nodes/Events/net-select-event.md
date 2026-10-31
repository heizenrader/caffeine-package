---
sidebar_position: 2
sidebar_label: Net Select Event
title: Net Select Event
---

# <span class="net-node">Net Select Event</span> <span class="net-badge">NET</span>

Fires on every player in the multiplayer session when the GameObject is selected by any client. Use it for effects every participant should see; keep course progress (Objective Completion) on the local [Select Event](./select-event) — see below.

**Category:** Event (Net)
**Component / Source:** Built-in (requires a collider on the GameObject)

## Inputs

| Port | Type | Description |
|---|---|---|
| collider | Collider | The collider whose selection should fire this event. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks on every player when the configured `eventType` is detected on the collider on any client. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| eventType | Enum&lt;SelectEventType&gt; | Which selection moment to fire on: `OnSelectDown` (initial press), `OnSelectUp` (release), or `OnSelectHold` (continuous while held). Defaults to `OnSelectDown`. |

## Notes & gotchas

:::info Once per device
With `OnSelectDown` or `OnSelectUp`, the event fires straight away on the player who clicked, and once on every other player when the message arrives: each device runs it once per click. `OnSelectHold` fires every frame on every device while the collider is held (see below).
:::

:::tip Net for what others see, local for progress
Visual changes other players need to see belong on the Net version. Complete objectives from the local [Select Event](./select-event): objectives sync on their own, and completing one from a Net event makes every device complete it, repeating its sound and show/hide actions. Never put the same actions on both a Select Event and a Net Select Event for one click — the player who clicked would run them twice.
:::

:::warning Hold + multiplayer
`OnSelectHold` fires every frame on every client while *any* client holds the collider. Combined with networking, this can multiply traffic — gate downstream work behind a state variable rather than firing actions every frame.
:::

## See also

- [Select Event](./select-event)
- [Networking in Flow](/docs/Flow/flow-networking)
