---
sidebar_position: 12
---

# Trigger Event

Fires when a collider enters, stays inside, or exits the configured trigger volume. Use it to detect proximity, trigger zones, or "when X enters the area" behaviors.

**Category:** Event (Interaction)
**Component / Source:** Built-in (requires a Collider configured as a trigger on the GameObject)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject whose trigger collider should drive this event. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow             | Flow       | Kicks when the configured `eventType` is detected on the trigger. |
| otherGameObject  | GameObject | The other GameObject — the one whose collider entered, stayed in, or exited the trigger volume. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| eventType | Enum&lt;TriggerEventType&gt; | Which trigger phase fires the event — typically `OnEnter`, `OnStay`, or `OnExit`. |

:::tip Use OnStay sparingly
`OnStay` fires every physics tick while the collider is inside the trigger — that's a lot of kicks. Prefer `OnEnter` to fire once when the collider arrives, and combine with state to track "still inside" without a per-tick event.
:::

## See also

- [Net Trigger Event](./net-trigger-event) — multiplayer counterpart
- [Collision Event](./collision-event) — for solid (non-trigger) collisions
- [Select Event](./select-event)
