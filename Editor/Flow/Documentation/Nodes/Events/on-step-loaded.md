---
sidebar_position: 17
---

# On Step Loaded

Fires when a course step finishes loading. Use it to set up step-specific state — restore values from save, reset positions, kick off intro narration.

**Category:** Event (Course)
**Component / Source:** Course / Step

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks when the configured step (or any step, if `anyStep` is set) finishes loading. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| anyStep | Bool | When `true`, the event fires for *any* step load, not just the configured one. Useful for global "step changed" logic. |

Pick the target step from the inspector dropdown — the binding is stored automatically on the node. Ignored when `anyStep` is `true`.

:::tip Pair with Save System Load Event
A common bootstrap pattern: On Step Loaded → read [Save System Value](/docs/Flow/Nodes/SaveSystem/save-system-value) for any saved progress on this step → restore the scene to that state.
:::

## See also

- [Course actions](/docs/Flow/Nodes/Course/overview)
- [Course Click Interaction](./course-click-interaction)
- [Course Hold Interaction](./course-hold-interaction)
- [Course Trigger Interaction](./course-trigger-interaction)
- [A-to-B Interaction End](./a-to-b-interaction-end)
