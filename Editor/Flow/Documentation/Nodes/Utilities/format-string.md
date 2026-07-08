---
sidebar_position: 3
---

# Format String

Builds a string by interpolating values into a format template — `String.Format` style with `{0}`, `{1}`, etc. placeholders. Use it to build dynamic UI labels, log lines, or save names.

**Category:** Variable
**Kind:** Operation
**Unity reference:** [↗](https://docs.microsoft.com/en-us/dotnet/api/system.string.format)

## Inputs

| Port | Type | Description |
|---|---|---|
| format  | String                     | The format template, e.g. `"Hello {0}, your score is {1}"`. Multiline supported. |
| objects | List&lt;Object&gt; (dynamic) | One slot per `{N}` placeholder in `format`. Wire each typed value (Int, Float, String, etc.) — they're converted to string at format time. |

## Outputs

| Port | Type | Description |
|---|---|---|
| stringOutputValue | String | The interpolated result. Returns the unformatted `format` if the inputs don't match the placeholders. |

:::tip .NET format specifiers work
You can use standard .NET format specifiers — `{0:F2}` for two decimals, `{0:N0}` for thousand separators, `{0:P}` for percentages, etc. Refer to the Microsoft docs for the full set.
:::

## See also

- [Debug Log](/docs/Flow/Nodes/Components/General/debug-log) — log the formatted string
- [Mathf](/docs/Flow/Nodes/Math/Mathf/overview) — produce numeric values to interpolate
