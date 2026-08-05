---
sidebar_position: 4
---

# Add Component Item

Inserts a component into a `List<Component>` at a specified index. Use it to build up a component list at runtime.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;Component&gt; | The list to insert into. The list is only modified when this port is connected. |
| Item  | Component             | The component to add. Accepts any component subtype, so a typed output (Rigidbody, Collider, …) wires in directly. |
| index | Int                   | Insertion index. Use 0 to insert at the start, or the list count to append. |

:::warning Index out of range silently no-ops
The insertion runs only when `index` is between 0 and the list's count (inclusive). Anything outside that range is skipped without error. Check first with [Count Component Items](./count-component-items).
:::

## See also

- [Remove Component Item](./remove-component-item) — remove by reference
- [Remove Component Item (Index)](./remove-component-item-index) — remove by position
- [Count Component Items](./count-component-items)
- [Component List](/docs/Flow/Nodes/Variables/component-list) — a mutable list to add into
