---
sidebar_position: 3
---

# Raise Flow Event Variable

Broadcasts a Flow Event with a typed value payload (Bool, Int, Float, String, Vector2/3/4, Quaternion, Color, or Long) to every [Flow Event Variable Listener](./flow-event-variable-listener) wired to the same event asset.

**Category:** Action / Raiser

## Behavior

The event asset's `Type` selects which input port is active in the editor. Wire the matching typed input — the value flows to every listener of the same event.

## Inputs

The `inputVariable(Type)Value` port matching the asset's `Type`. Same shape as [Local Variable](/docs/Flow/Nodes/Variables/local-variable).

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowVariableEvent | NodeEventVariableSO asset | The Flow Event asset (with typed payload) to raise. The asset's `Type` controls which input port this node renders. Create via `Assets > Create > Caffeine > Flow > NodeEventVariable`. |

## See also

- [Flow Event Variable Listener](./flow-event-variable-listener) — receives the event with the typed value
- [Raise Flow Event](./raise-flow-event)
- [Raise Flow Event GameObject](./raise-flow-event-game-object)
