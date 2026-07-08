---
sidebar_position: 1
---

# Get String Item

Returns the string at a specific index in a `List<String>`.

**Category:** Variable
**Kind:** Property

:::note Editor menu path
Appears in the Add Node menu under `Flow/Actions/GameObject/Get String Item` (the menu path is a bit misleading — the node operates on a string list, not GameObjects).
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;String&gt; | The list to read from. |
| index | Int                | Zero-based index. |

## Outputs

| Port | Type | Description |
|---|---|---|
| item | String | The element at `index`, or empty string if `index` is out of range or the list is unconnected. |

## See also

- [String Contains](/docs/Flow/Nodes/Components/String/string-contains)
- [Get GameObject Item](/docs/Flow/Nodes/Components/GameObject/get-gameobject-item) — same shape for GameObject lists
