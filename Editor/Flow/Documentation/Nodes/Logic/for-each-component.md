---
sidebar_position: 15
---

# For Each Component

Walks a `List<Component>` and kicks `body` once per element, exposing the current element — **typed** to the component you pick — plus its `index`. The list analog of [For Loop](./for-loop), and the component counterpart of [Foreach Game Object](./foreach-game-object).

**Category:** Action
**Kind:** Control flow / Looping

## Inputs

| Port | Type | Description |
|---|---|---|
| list | List&lt;Component&gt; | The component list to iterate. Connect from [Get Components](/docs/Flow/Nodes/Components/Component/get-components), a [Component List](/docs/Flow/Nodes/Variables/component-list), or any node emitting a component list. |

## Outputs

The active typed item port matches the `component` dropdown — the editor draws only that one.

| Port | Type | Description |
|---|---|---|
| (typed component) | matching the dropdown | The current element, cast to the chosen type. Read it from nodes downstream of `body`. `null` if the element isn't that type. |
| index | Int  | Zero-based index of the current element. |
| body  | Flow | Kicks once per element in the list. |

:::note Standard Flow output vs `body`
For Each Component fires `body` once for **every** element in the list. The standard `exit` fires **once**, after the whole list has been walked. Wire per-element logic to `body`, post-loop logic to `exit`. See the [Action overview](/docs/Flow/Nodes/Components/overview) for the convention.
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| component | Enum&lt;UnityComponents&gt; | Which type to cast each element to as the loop runs. Set it to the type the list holds so the item comes out typed (ready to feed Get/Set Component Property). |

:::tip Typed elements feed property nodes
The typed `item` output is what makes per-element work useful — wire it into [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) or [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) to read or write a property on each component as you iterate.
:::

:::note No early-out
For Each Component has no `break` input — it always runs the full list. (This differs from [Foreach Game Object](./foreach-game-object), which can break early.)
:::

## See also

- [For Loop](./for-loop) — counted integer iteration
- [Foreach Game Object](./foreach-game-object) — the GameObject equivalent
- [Get Components](/docs/Flow/Nodes/Components/Component/get-components) — produce a list to iterate
- [Component List](/docs/Flow/Nodes/Variables/component-list) — a mutable list to iterate
