---
sidebar_position: 14
---

# Collision Event

Fires when a Rigidbody / Collider collides with the configured GameObject — physical contact (not trigger volumes). Use it to react to impacts, bumps, and physics-driven contact.

**Category:** Event (Interaction)
**Component / Source:** Built-in (requires a non-trigger Collider on the GameObject)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject whose collider should drive this event. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow            | Flow       | Kicks when the configured `eventType` happens on the collider. |
| otherGameObject | GameObject | The other GameObject involved in the collision. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| eventType | Enum&lt;CollisionEventType&gt; | Which collision phase fires the event — typically `OnEnter`, `OnStay`, or `OnExit`. |

:::tip Trigger vs Collision
`Collision Event` fires for solid contacts where physics resolves the impact (objects bounce off, momentum transfers). [Trigger Event](./trigger-event) fires for *trigger* colliders — volumes that don't physically obstruct anything but detect when colliders overlap.
:::

## See also

- [Trigger Event](./trigger-event)
- [Rigidbody actions](/docs/Flow/Nodes/Components/Rigidbody/overview)
