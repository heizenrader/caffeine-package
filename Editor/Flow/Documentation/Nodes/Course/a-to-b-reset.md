---
sidebar_position: 3
---

# Reset A to B

Resets a specific A-to-B interaction on a step — returns the moved object back to its starting position so the user can attempt the interaction again.

**Category:** Action

## Target

Pick the target step and A-to-B interaction from the inspector dropdowns — the binding is stored automatically on the node.

:::tip Use after a failed attempt
Pair with the [A-to-B Interaction End event](/docs/Flow/Nodes/Events/overview) — when the user's attempt didn't meet the success criteria, kick this node to put the object back so they can try again.
:::

## See also

- [Objective Completion](./objective-completion)
- [Course events](/docs/Flow/Nodes/Events/overview)
