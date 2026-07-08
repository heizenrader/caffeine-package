---
sidebar_position: 16
---

# Add GameObject Item

Inserts a GameObject into a `List<GameObject>` at a specified index. Use it to manage runtime collections — adding picked-up items, building rosters, dynamic spawn lists.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;GameObject&gt; | The list to insert into. |
| Item  | GameObject              | The GameObject to add. |
| index | Int                     | Insertion index. Use 0 to insert at the start, list count to append. |

:::warning Index out-of-range silently no-ops
If `index` is greater than `list.Count`, the insertion is skipped without error. Verify the count first via [Count GameObject Items](./count-gameobject-items).
:::

## See also

- [Get GameObject Item](./get-gameobject-item)
- [Count GameObject Items](./count-gameobject-items)
- [Remove GameObject Item](./remove-gameobject-item)
- [GameObject List](/docs/Flow/Nodes/Variables/gameobject-list)
