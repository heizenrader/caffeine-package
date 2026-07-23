---
sidebar_position: 0
sidebar_label: Overview
---

# Course Nodes

Course nodes act on the Course / Step structure — exit the course, mark an objective complete, reset an A-to-B interaction, or trigger a step's animation or media attachment. They're distinct from **Course Events** (which fire when course interactions happen and live under [Events](/docs/Flow/Nodes/Events/overview)).

Most Course nodes target a specific step and a specific item on that step (objective, attachment, A-to-B interaction). Pick the target from the inspector dropdowns when you place the node — the binding is stored automatically.

## Nodes

| Node | Description |
|---|---|
| [Exit Course](./exit-course)                       | End the current course and return to the selection screen. |
| [Go To Step](./go-to-step)                         | Jump the course to a specific step. |
| [Objective Completion](./objective-completion)     | Mark a specific objective on a step as complete. |
| [Reset A to B](./a-to-b-reset)                     | Reset an A-to-B interaction back to its starting position. |
| [Animation Attachment](./animation-attachment)     | Trigger a step's animation attachment. |
| [Media Attachment](./media-attachment)             | Trigger a step's interactive media attachment. |

## See also

- [Course events](/docs/Flow/Nodes/Events/overview) — events fired when course interactions happen
- [Branch](/docs/Flow/Nodes/Logic/branch) / [Comparison](/docs/Flow/Nodes/Logic/comparison) — gate course actions on conditions
