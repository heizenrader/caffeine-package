---
sidebar_position: 13
sidebar_label: Net Trigger Event
title: Net Trigger Event
---

# <span class="net-node">Net Trigger Event</span> <span class="net-badge">NET</span>

Fires on every player in the multiplayer session when a specified collider pair (A, B) interacts via trigger. Use it for trigger-based interactions that should be visible to all players — entering a shared zone, picking up a shared object.

**Category:** Event (Net, Interaction)
**Component / Source:** Built-in (requires Collider components configured on `gameObjectA` and `gameObjectB`)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObjectA  | GameObject | The GameObject hosting the trigger collider. |
| gameObjectB  | GameObject | The GameObject whose collider must enter `gameObjectA`'s trigger to drive this event. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks on every player when the configured `eventType` happens on the originating client. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| eventType | Enum&lt;TriggerEventType&gt; | `OnEnter` or `OnExit` (Net Trigger uses these only — no `OnStay`). |

:::tip Net Trigger requires both colliders configured
The Net version checks for collisions between two specific GameObjects (A and B), not against any random collider entering. This makes the event predictable across players.
:::

## See also

- [Trigger Event](./trigger-event) — local-only counterpart
- [Net Select Event](./net-select-event)
- [Networking in Flow](/docs/Flow/flow-networking)
