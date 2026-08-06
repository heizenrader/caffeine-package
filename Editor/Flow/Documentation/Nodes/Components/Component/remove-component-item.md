---
sidebar_position: 5
---

# Remove Component Item

Removes the first occurrence of a specific component from a `List<Component>`. The variant that removes by index is [Remove Component Item (Index)](./remove-component-item-index).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| list      | List&lt;Component&gt; | The list to remove from. |
| component | Component             | The component to remove. Accepts any component subtype, so a typed output wires in directly. If it isn't in the list, the call is a no-op. |

## See also

- [Remove Component Item (Index)](./remove-component-item-index) — remove by position instead of by reference
- [Add Component Item](./add-component-item)
- [Count Component Items](./count-component-items)
