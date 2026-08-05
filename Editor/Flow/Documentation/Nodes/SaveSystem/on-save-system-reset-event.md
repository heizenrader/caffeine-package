---
sidebar_position: 8
---

# Save System Reset Event

Fires when the save store is reset via [Save System Reset](./reset). Use it to return the scene to its default state — re-initialize objectives, reset positions, restore opening UI.

**Category:** Event

:::note Editor menu path
Appears in the Add Node menu under `Flow/Events/Save System Reset Event`. Documented here under SaveSystem for cohesion.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once after the save store has been reset. |

:::tip Pair with the Reset action
A typical "reset progress" flow is: button click → [Save System Reset](./reset) action → this event fires → wire downstream the cleanup that resets the scene to its initial state.
:::

## See also

- [Save System Reset](./reset)
- [Save System Load Event](./on-save-system-load-event)
