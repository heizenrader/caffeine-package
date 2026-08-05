---
sidebar_position: 3
---

# Save System Reset

Clears the current save state, returning the user to a fresh start. Use it for "Reset Progress" buttons, end-of-course cleanup, or when restarting a course from scratch.

**Category:** Action

:::note Triggers the Reset Event
Resetting fires the [Save System Reset Event](./on-save-system-reset-event) — wire any "back to defaults" setup off that event so it runs every time the user resets.
:::

:::warning Destructive
Reset clears all keys in the current save store. There's no undo — confirm with the user (e.g. via a dialog step) before wiring this into any flow that runs without explicit user intent.
:::

## See also

- [Save System Save](./save)
- [Save System Load](./load)
- [Save System Reset Event](./on-save-system-reset-event)
