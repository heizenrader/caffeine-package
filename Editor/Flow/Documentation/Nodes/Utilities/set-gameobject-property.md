---
sidebar_position: 13
---

# Set GameObject Property

Writes a typed value to a property on a GameObject (or one of its components) at runtime. Counterpart of [Get GameObject Property](./get-gameobject-property).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| inputGameObjectValue | GameObject | The GameObject to write the property on. |
| input(Type)Value     | Typed      | The value to write. Active port matches `Type`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                  | Enum&lt;SerializedType&gt; | The value type being written. |
| serializedObjProperty | Property selector           | Inspector picker for the property name. |

## See also

- [Get GameObject Property](./get-gameobject-property)
- [Set Property](./set-property)
- [Set Component Property](./set-component-property)
