---
sidebar_position: 6
---

# Flow Event Variable Listener

Fires when the bound Flow Event Variable asset is raised by a [Raise Flow Event Variable](./raise-flow-event-variable) node. Outputs the typed value the raiser sent.

**Category:** Event

## Behavior

The event asset's `Type` selects which output port is active in the editor — wire the matching typed output to read the raised value.

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow                       | Flow  | Kicks each time the bound event is raised. |
| (type)VariableValue        | Typed | The value sent by the raiser. The active output (e.g. `floatVariableValue`, `vector3VariableValue`) matches the asset's `Type`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowVariableEvent | NodeEventVariableSO asset | The Flow Event asset this listener subscribes to. |

## See also

- [Raise Flow Event Variable](./raise-flow-event-variable)
- [Flow Event Listener](./flow-event-listener)
- [Flow Event GameObject Listener](./flow-event-game-object-listener)
