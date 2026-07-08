---
sidebar_position: 12
---

# Get GameObject Property

Reads a property from a GameObject (or one of its components) at runtime — like [Get Property](./get-property) but the GameObject target is wired through an input port instead of fixed in the inspector.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| inputGameObjectValue | GameObject | The GameObject to read the property from. |

## Outputs

The `(type)Value` port matching `Type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                  | Enum&lt;SerializedType&gt; | Which output type the read returns. |
| serializedObjProperty | Property selector           | Inspector picker for the property name (relative to the input GameObject). |

:::tip Use this for runtime-targeted reads
Wire `inputGameObjectValue` from any node that returns a GameObject (Self, Net Avatar, Foreach Game Object's `item`) to read the same property from a varying target.
:::

:::note Returns default on type mismatch
If the property doesn't exist on the input GameObject, or its type doesn't match `Type`, the node returns the default for the output type (no error).
:::

## See also

- [Set GameObject Property](./set-gameobject-property)
- [Get Property](./get-property)
- [Get Component Property](./get-component-property)
