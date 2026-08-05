---
sidebar_position: 20
---

# Course Hold Interaction

Fires when a specific hold interaction on a course step transitions through one of its phases — start, end, or held. Use it to react to step-specific press-and-hold patterns.

**Category:** Event (Course)

:::note Not in the Add Node menu
Course Hold Interaction nodes are created from the inspector of a course step's hold interaction — not from the right-click Add Node menu.
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
| type | Enum&lt;HoldEventType&gt; | Which phase fires the event — `HoldStart`, `Hold` (sustained), or `HoldEnd`. |

:::tip Use phases distinctly
Use `HoldStart` to begin an effect (visual cue, timer), `Hold` to keep it running while the user holds, and `HoldEnd` to wrap up. `Hold` fires every frame the user keeps holding — gate downstream work behind state if it should run only once per hold cycle.
:::

## See also

- [On Step Loaded](./on-step-loaded)
- [Course Click Interaction](./course-click-interaction)
- [Course Trigger Interaction](./course-trigger-interaction)
