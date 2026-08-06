---
sidebar_position: 1
---

# String Contains

Tests whether an input string contains any of a configurable list of substrings. Returns both a Bool result and the first matched substring (when any matched).

**Category:** Action / Variable

## Inputs

| Port | Type | Description |
|---|---|---|
| inputString | String | The string to search in. |

## Outputs

| Port | Type | Description |
|---|---|---|
| contains      | Bool   | `true` if `inputString` contains at least one of the cases. |
| matchedString | String | The first case that matched. Empty string if none matched. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| CasesList | List&lt;String&gt; | The substrings to search for. The first matching one wins. |

:::tip Single-case, simple use
For a one-off "does X contain Y" check, set CasesList to `[Y]` and read `contains`. For multi-case lookups (e.g. "did the user say any of these keywords"), include all candidates and check `matchedString` to know which.
:::

## See also

- [String Length](./string-length)
- [Substring](./substring)
- [Comparison](/docs/Flow/Nodes/Logic/comparison) — exact equality
