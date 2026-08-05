---
sidebar_position: 15
---

# GameObject from Component

Returns the GameObject hosting a Component — the inverse of [Get Component](./get-component).

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| inputComponentValue | Component | The Component instance to look up the host of. |

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject hosting the Component, or `null` if the input is unconnected. |

:::tip For Component → GameObject hops
Useful when a flow operates on Component references but a downstream node needs the GameObject — e.g., Foreach over Rigidbodies → GameObject from Component → Set Active.
:::

## See also

- [Get Component](./get-component)
