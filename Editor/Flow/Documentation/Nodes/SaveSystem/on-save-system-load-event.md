---
sidebar_position: 7
---

# Save System Load Event

Fires when a snapshot finishes loading via [Save System Load](./load). Use it to set up scene state from saved values — restore objective progress, position the user at the right step, swap in saved choices.

**Category:** Event

:::note Editor menu path
Appears in the Add Node menu under `Flow/Events/Save System Load Event`. Documented here under SaveSystem for cohesion with the rest of the Save System nodes.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks once after a snapshot has been loaded and the new save state is available to read. |

:::tip Read values in this event, not before
Wire [Save System Value](./save-system-value) reads downstream of this event — the values aren't valid until the load has completed and this event has fired.
:::

## See also

- [Save System Load](./load)
- [Save System Reset Event](./on-save-system-reset-event)
- [Save System Value](./save-system-value)
