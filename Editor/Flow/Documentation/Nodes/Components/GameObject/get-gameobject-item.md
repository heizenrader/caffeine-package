---
sidebar_position: 17
---

# Get GameObject Item

Returns the GameObject at a specific index in a `List<GameObject>`.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;GameObject&gt; | The list to read from. |
| index | Int                     | Zero-based index to read. |

## Outputs

| Port | Type | Description |
|---|---|---|
| item | GameObject | The element at `index`, or `null` if `index` is out of range or the list is unconnected. |

## See also

- [Count GameObject Items](./count-gameobject-items)
- [Add GameObject Item](./add-gameobject-item)
- [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object)
