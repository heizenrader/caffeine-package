---
sidebar_position: 1
---

# Current Time (Clock)

Returns the current local time in a configurable format, plus separate Int outputs for the individual hour / minute / second / millisecond components.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| format | String | A standard .NET `DateTime` format string. Default `h:mm:ss tt` produces output like `3:45:12 PM`. Invalid format strings fall back to the default rather than erroring. |

## Outputs

| Port | Type | Description |
|---|---|---|
| time         | String | Current time formatted using `format`. |
| hours        | Int    | Current hour in 12-hour form (1–12). |
| minutes      | Int    | Current minute (0–59). |
| seconds      | Int    | Current second (0–59). |
| milliseconds | Int    | Current millisecond (0–999). |

:::tip Each read samples a fresh value
Reading any output samples `DateTime.Now` at that moment, so wiring `seconds` into something that reads it twice in the same frame can return slightly different values. Cache via a [Local Variable](/docs/Flow/Nodes/Variables/local-variable) when you need a single consistent reading.
:::

## See also

- [Simple Current Time](./simple-current-time) — quick `h:mm[:ss] AM/PM` form, no format string
- [Simple Current Date](./simple-current-date)
