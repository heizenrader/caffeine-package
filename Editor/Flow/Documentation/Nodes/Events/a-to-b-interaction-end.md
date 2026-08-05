---
sidebar_position: 18
---

# A-to-B Interaction End

Fires when a specific A-to-B interaction on a course step ends — i.e., when the user finishes (successfully or not) moving an object from its starting position (A) to its target (B). Use it to score, advance, or reset based on the result.

**Category:** Event (Course)

:::note Not in the Add Node menu
A-to-B Interaction End nodes are created from the inspector of a course step's A-to-B interaction — not from the right-click Add Node menu. Each node binds to a specific interaction; multiple nodes per interaction are allowed.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks when the bound A-to-B interaction ends. |

:::tip Pair with Reset A to B
A typical "didn't get it right, try again" flow: A-to-B Interaction End → check success criteria → on failure, kick [Reset A to B](/docs/Flow/Nodes/Course/a-to-b-reset) to put the object back.
:::

## See also

- [Reset A to B](/docs/Flow/Nodes/Course/a-to-b-reset)
- [On Step Loaded](./on-step-loaded)
- [Course Click Interaction](./course-click-interaction)
