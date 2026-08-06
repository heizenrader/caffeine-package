---
sidebar_position: 1
---

# Exit Course

Ends the current course and returns the user to the course-selection screen. Use it as the final step of a completion flow, or to bail out of a course that the user has marked as done early.

**Category:** Action

:::tip Single-fire by design
Once kicked, Exit Course only fires once per session — subsequent kicks during the same play through are no-ops. You don't need to gate it manually.
:::

## See also

- [Objective Completion](./objective-completion) — mark a specific objective done before exiting
- [Course events](/docs/Flow/Nodes/Events/overview) — react to step changes inside the course
