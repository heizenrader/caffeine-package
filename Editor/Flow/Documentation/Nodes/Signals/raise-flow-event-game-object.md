---
sidebar_position: 2
---

# Raise Flow Event GameObject

Broadcasts a Flow Event with a GameObject payload to every [Flow Event GameObject Listener](./flow-event-game-object-listener) wired to the same event asset. Use it when listeners need to know *which* GameObject the event is about.

**Category:** Action / Raiser

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to send with the event. Listeners receive this on their `gameObject` output. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| flowGameObjectEvent | NodeEventGameObjectSO asset | The Flow Event asset (with GameObject payload) to raise. Create via `Assets > Create > Caffeine > Flow > NodeEventGameObject`. |

## See also

- [Flow Event GameObject Listener](./flow-event-game-object-listener) — receives the event
- [Raise Flow Event](./raise-flow-event) — no payload
- [Raise Flow Event Variable](./raise-flow-event-variable) — typed-value payload
