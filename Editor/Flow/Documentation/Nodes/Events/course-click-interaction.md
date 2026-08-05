---
sidebar_position: 19
---

# Course Click Interaction

Fires when a specific click interaction on a course step is triggered — the user clicks (or VR-selects, or taps) the object configured for that interaction. Use it to react to step-specific clicks without manually wiring colliders.

**Category:** Event (Course)

:::note Not in the Add Node menu
Course Click Interaction nodes are created from the inspector of a course step's click interaction — not from the right-click Add Node menu. Multiple nodes per interaction are allowed.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks when the bound click interaction is triggered. |

:::tip Course events vs Select Event
Course Click Interaction binds to a step's pre-configured click target — the inspector picks which object the click counts on, and the event drives flow logic for that step. Use [Select Event](./select-event) when you want to react to clicks on any GameObject without going through the Course/Step layer.
:::

## See also

- [On Step Loaded](./on-step-loaded)
- [Course Hold Interaction](./course-hold-interaction)
- [Course Trigger Interaction](./course-trigger-interaction)
- [Select Event](./select-event)
