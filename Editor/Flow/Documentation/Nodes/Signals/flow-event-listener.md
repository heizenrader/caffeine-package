---
sidebar_position: 4
---

# Flow Event Listener

Fires when the bound Flow Event asset is raised by any [Raise Flow Event](./raise-flow-event) node anywhere in the project. Use it to react to cross-graph signals.

**Category:** Event

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks each time the bound event is raised. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowEvent | NodeEventSO asset | The Flow Event asset this listener subscribes to. Multiple listeners on the same asset all fire when any raiser triggers. |

## See also

- [Raise Flow Event](./raise-flow-event) — broadcasts the event
- [Flow Event GameObject Listener](./flow-event-game-object-listener) — listens for events with GameObject payload
- [Flow Event Variable Listener](./flow-event-variable-listener) — listens with typed-value payload
