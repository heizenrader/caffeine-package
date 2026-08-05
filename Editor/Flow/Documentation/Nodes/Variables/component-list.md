---
sidebar_position: 15
---

# Component List

A list of components you can populate in the inspector, mutate at runtime, and iterate over with [For Each Component](/docs/Flow/Nodes/Logic/for-each-component). The component counterpart of [GameObject List](./gameobject-list) — reach for it when a flow needs to act on several components in turn and you want a list you control, rather than the live snapshot that [Get Components](/docs/Flow/Nodes/Components/Component/get-components) returns.

**Category:** Variable
**Kind:** Variable accessor (collection)

## Inputs

| Port | Type | Description |
|---|---|---|
| inputList | List&lt;Component&gt; | When connected, the connected list replaces the current contents on each kick. When unconnected, the inspector list is used. |

## Outputs

| Port | Type | Description |
|---|---|---|
| list | List&lt;Component&gt; | The current list contents. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| List | List&lt;Component&gt; | The list contents. Edit directly in the inspector to add, remove, or reorder components. Runtime kicks may overwrite this list when `inputList` is connected. |

:::tip Iterate with For Each Component
Wire `list` into [For Each Component](/docs/Flow/Nodes/Logic/for-each-component)'s `list` input to run a body subgraph for each element, with the current element typed to the component you choose there.
:::

## See also

- [For Each Component](/docs/Flow/Nodes/Logic/for-each-component)
- [Get Components](/docs/Flow/Nodes/Components/Component/get-components) — fill a list from a GameObject
- [GameObject List](./gameobject-list) — the GameObject equivalent
