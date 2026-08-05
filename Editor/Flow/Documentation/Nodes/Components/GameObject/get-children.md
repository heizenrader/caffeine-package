---
sidebar_position: 3
---

# Get Children

Returns the immediate children GameObjects of a parent. Use it to iterate over the children of a container — pair with [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object) to act on each.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| parent | GameObject | The parent GameObject whose children to enumerate. |

## Outputs

| Port | Type | Description |
|---|---|---|
| children | List&lt;GameObject&gt; | The immediate children of `parent`. Returns `null` when `parent` is null. |

:::note Direct children only
This returns only the immediate children, not the full hierarchy. To process descendants recursively, run a recursive Foreach pattern or use a custom traversal.
:::

## See also

- [Get Parent](./get-parent)
- [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object)
