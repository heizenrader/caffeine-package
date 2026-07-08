---
sidebar_position: 5
---

# Flow Event GameObject Listener

Fires when the bound Flow Event GameObject asset is raised by a [Raise Flow Event GameObject](./raise-flow-event-game-object) node. Outputs the GameObject the raiser sent.

**Category:** Event

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow       | Flow       | Kicks each time the bound event is raised. |
| gameObject | GameObject | The GameObject sent by the raiser. Read this from any node downstream of the kick. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowGameObjectEvent | NodeEventGameObjectSO asset | The Flow Event asset this listener subscribes to. |

## See also

- [Raise Flow Event GameObject](./raise-flow-event-game-object)
- [Flow Event Listener](./flow-event-listener)
- [Flow Event Variable Listener](./flow-event-variable-listener)
