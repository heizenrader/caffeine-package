---
sidebar_position: 4
---

# Substring

Extracts a portion of a string by start index and length.

**Category:** Variable
**Kind:** Operation
**Unity reference:** [↗](https://docs.microsoft.com/en-us/dotnet/api/system.string.substring)

## Inputs

| Port | Type | Description |
|---|---|---|
| input      | String | The source string. |
| startIndex | Int    | Starting position (0-based). Negative values wrap from the end of the string. |
| length     | Int    | Number of characters to extract. Use 0 or less to return an empty string. |

## Outputs

| Port | Type | Description |
|---|---|---|
| output | String | The extracted substring. If `length` would extend past the string's end, the rest of the string from `startIndex` is returned. On any other error, the unchanged input is returned. |

:::tip Negative startIndex wraps from the end
A negative `startIndex` is treated as offset-from-end (e.g. `-3` starts 3 characters before the end), useful for "last N characters" patterns.
:::

## See also

- [String Length](./string-length)
- [String Contains](./string-contains)
