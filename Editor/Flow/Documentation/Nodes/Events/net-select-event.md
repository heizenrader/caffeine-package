---
sidebar_position: 2
sidebar_label: Net Select Event
title: Net Select Event
---

# <span class="net-node">Net Select Event</span> <span class="net-badge">NET</span>

Fires on every player in the multiplayer session when the GameObject is selected by any client. Prefer this over the local [Select Event](./select-event) for any logic that should be visible or consistent across all participants.

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

:::tip Prefer Net for shared logic
Any logic that other players need to see (visual changes, course progress, scoring) belongs on the Net version. Use the local [Select Event](./select-event) only for client-side feedback that doesn't need to replicate.
:::

:::warning Hold + multiplayer
`OnSelectHold` fires every frame on every client while *any* client holds the collider. Combined with networking, this can multiply traffic — gate downstream work behind a state variable rather than firing actions every frame.
:::

## See also

- [Select Event](./select-event)
- [Networking in Flow](/docs/Flow/flow-networking)
