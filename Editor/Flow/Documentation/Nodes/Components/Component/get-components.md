---
sidebar_position: 1
---

# Get Components

Fetches every component of the chosen type on a GameObject as a `List<Component>`. The multi-result counterpart of [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component) — use it when an object has several of the same component (multiple Colliders, Audio Sources, Renderers) and you want to act on all of them.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to scan. |

## Outputs

| Port | Type | Description |
|---|---|---|
| components | List&lt;Component&gt; | Every component of the selected type on the GameObject. Empty when the object has none. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| component | Enum&lt;UnityComponents&gt; | Which component type to collect. Same set as [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component). |

:::tip Read the list with typed nodes
The output is a generic `List<Component>`. To pull elements out typed (so they feed Get/Set Component Property), wire it into [Get Component Item](./get-component-item) or [For Each Component](/docs/Flow/Nodes/Logic/for-each-component) and pick the same component type there.
:::

:::note This is a live query, not a mutable container
The result is cached and refreshed when you change the GameObject or the component type (and while the result is still empty, so components added a bit later are still picked up). Once it has returned something, components added or removed at runtime aren't re-detected. If you need a list you build up and mutate yourself, use a [Component List](/docs/Flow/Nodes/Variables/component-list) instead.
:::

## See also

- [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component) — single-result version
- [For Each Component](/docs/Flow/Nodes/Logic/for-each-component) — iterate the result
- [Component List](/docs/Flow/Nodes/Variables/component-list) — a mutable component list
