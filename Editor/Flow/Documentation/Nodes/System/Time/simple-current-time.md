---
sidebar_position: 2
---

# Simple Current Time

Returns the current local time as a pre-formatted string in `h:mm AM/PM` (or `h:mm:ss AM/PM`) form. Use it as a quick way to display the wall-clock time without configuring a format string.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| time | String | Current time formatted as `h:mm AM/PM` or `h:mm:ss AM/PM` depending on the `IncludeSeconds` inspector flag. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| IncludeSeconds | Bool | When `true`, includes seconds in the output (`3:45:12 PM`). When `false`, hours and minutes only (`3:45 PM`). |

:::tip Need a different format?
Use [Current Time (Clock)](./current-time) if you want a custom format string or numeric hour / minute / second outputs.
:::

## See also

- [Current Time (Clock)](./current-time)
- [Simple Current Date](./simple-current-date)
