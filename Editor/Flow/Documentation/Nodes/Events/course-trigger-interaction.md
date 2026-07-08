---
sidebar_position: 21
---

# Course Trigger Interaction

Fires when a specific trigger interaction on a course step transitions through one of its phases — enter, stay, or exit. Use it to react to step-specific zone entries without manually wiring trigger colliders.

**Category:** Event (Course)

:::note Not in the Add Node menu
Course Trigger Interaction nodes are created from the inspector of a course step's trigger interaction — not from the right-click Add Node menu.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks when the configured `type` phase happens on the bound interaction. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| type | Enum&lt;TriggerEventType&gt; | Which phase fires the event — typically `OnEnter`, `OnStay`, or `OnExit`. |

## See also

- [On Step Loaded](./on-step-loaded)
- [Course Click Interaction](./course-click-interaction)
- [Course Hold Interaction](./course-hold-interaction)
- [Trigger Event](./trigger-event) — generic (non-course) trigger event
