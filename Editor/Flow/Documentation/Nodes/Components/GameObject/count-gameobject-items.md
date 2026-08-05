---
sidebar_position: 18
---

# Count GameObject Items

Returns the number of GameObjects in a `List<GameObject>`.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| list | List&lt;GameObject&gt; | The list to count. |

## Outputs

| Port | Type | Description |
|---|---|---|
| count | Int | The number of elements. Returns 0 if the input is null or unconnected. |

## See also

- [Get GameObject Item](./get-gameobject-item)
- [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object) — iterate the list, which exposes `count` as one of its outputs
