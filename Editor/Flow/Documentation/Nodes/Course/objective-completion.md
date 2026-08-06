---
sidebar_position: 2
---

# Objective Completion

Marks a specific objective on a specific step as complete. Use it whenever a Flow Graph determines that the user has met an objective's criteria — answered correctly, finished a task, painted enough, etc.

**Category:** Action

## Target

Pick the target step and objective from the inspector dropdowns — the binding is stored automatically on the node.

:::tip Wire after the success branch
A typical pattern is `Comparison` → `Branch` → Objective Completion on the True path — completing the objective only when the user's input meets the criteria.
:::

## See also

- [Exit Course](./exit-course) — end the course (often after the final objective completes)
- [Comparison](/docs/Flow/Nodes/Logic/comparison)
- [Branch](/docs/Flow/Nodes/Logic/branch)
