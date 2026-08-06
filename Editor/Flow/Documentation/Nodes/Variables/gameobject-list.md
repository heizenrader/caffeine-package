---
sidebar_position: 13
---

# GameObject List

A list of GameObjects you can populate in the inspector, mutate at runtime, and iterate over with [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object). Use it whenever a flow needs to act on several GameObjects in turn — enable a row of buttons, pick a random spawn point, count the items the user has interacted with.

**Category:** Variable
**Kind:** Variable accessor (collection)

## Inputs

| Port | Type | Description |
|---|---|---|
| inputList | List&lt;GameObject&gt; | When connected, the connected list replaces the current contents on each kick. When unconnected, the inspector list is used. |

## Outputs

| Port | Type | Description |
|---|---|---|
| list | List&lt;GameObject&gt; | The current list contents. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| List | List&lt;GameObject&gt; | The list contents. Edit directly in the inspector to add, remove, or reorder GameObjects. Runtime kicks of this node may overwrite this list when `inputList` is connected. |

:::tip Iterate with Foreach Game Object
Wire `list` into [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object)'s `list` input to run a body subgraph for each item. The Foreach node exposes the current `item`, `index`, and `count` while the body runs.
:::

## See also

- [Foreach Game Object](/docs/Flow/Nodes/Logic/foreach-game-object)
- [GameObject](./gameobject) — single-reference variant
