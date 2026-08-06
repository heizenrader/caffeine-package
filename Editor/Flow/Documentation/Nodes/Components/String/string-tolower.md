---
sidebar_position: 3
---

# String ToLower

Returns the input string converted to all lowercase. Use it for case-insensitive comparisons or normalized display text.

**Category:** Variable
**Kind:** Operation

## Inputs

| Port | Type | Description |
|---|---|---|
| inputString | String | The string to lowercase. |

## Outputs

| Port | Type | Description |
|---|---|---|
| lowerString | String | The lowercased string. Returns empty string for null or empty input. |

:::tip For case-insensitive comparison
Convert both sides of a comparison through String ToLower before feeding into [Comparison](/docs/Flow/Nodes/Logic/comparison) — the `==` operator on strings is case-sensitive.
:::

## See also

- [Comparison](/docs/Flow/Nodes/Logic/comparison)
- [String Contains](./string-contains)
