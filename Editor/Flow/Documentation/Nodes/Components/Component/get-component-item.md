---
sidebar_position: 2
---

# Get Component Item

Returns the element at an index in a component list, **typed** to the component you pick. The typing is the point: a typed output can plug straight into [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) / [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property), which read the declared type of the port feeding them.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;Component&gt; | The component list to read from. |
| index | Int                   | Zero-based index to read. |

## Outputs

The active output port matches the `component` dropdown — the editor draws only that one.

| Port | Type | Description |
|---|---|---|
| (typed component) | matching the dropdown | The element at `index`, cast to the chosen type. `null` if the index is out of range, the list is unconnected, or the element isn't that type. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| component | Enum&lt;UnityComponents&gt; | Which type to cast the element to. Pick the same type the list holds. |

:::tip Pick the type the list holds
A [Get Components](./get-components) list is uniform — every element is the type you collected. Set this dropdown to that same type so the element comes out typed and ready to feed a property node. A mismatch yields `null`, not an error.
:::

## See also

- [Count Component Items](./count-component-items) — bounds-check before indexing
- [For Each Component](/docs/Flow/Nodes/Logic/for-each-component) — walk every element instead of one
- [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) — read a property off the returned component
