---
sidebar_position: 19
---

# Remove GameObject Item

Removes the first occurrence of a specific GameObject from a `List<GameObject>`. The variant that removes by index is [Remove GameObject Item (Index)](./remove-gameobject-item-index).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| list       | List&lt;GameObject&gt; | The list to remove from. |
| gameObject | GameObject              | The GameObject to remove. If not in the list, the call is a no-op. |

## See also

- [Remove GameObject Item (Index)](./remove-gameobject-item-index) — remove by position instead of by reference
- [Add GameObject Item](./add-gameobject-item)
- [Count GameObject Items](./count-gameobject-items)
