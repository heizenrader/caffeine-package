---
sidebar_position: 1
---

# Raise Flow Event

Broadcasts a Flow Event to every [Flow Event Listener](./flow-event-listener) wired to the same Flow Event asset. Use it to drive cross-graph communication — when something happens in one graph, every other graph listening can react.

**Category:** Action / Raiser

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowEvent | NodeEventSO asset | The Flow Event asset to raise. Create one via `Assets > Create > Caffeine > Flow > NodeEvent`. |

:::tip Decouple graphs with Flow Events
Flow Events let two graphs communicate without direct port connections. Graph A raises an event, every Graph B that registered a listener for the same event runs its handler. Useful for global signals like "course started", "user submitted answer", "round over".
:::

## See also

- [Flow Event Listener](./flow-event-listener) — receives the event
- [Raise Flow Event GameObject](./raise-flow-event-game-object) — raise with a GameObject payload
- [Raise Flow Event Variable](./raise-flow-event-variable) — raise with a typed value payload
