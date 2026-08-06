---
sidebar_position: 15
---

# Set Component Property

Writes a typed value to a property on a Unity Component instance at runtime. Counterpart of [Get Component Property](./get-component-property).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| inputComponentValue | Component | The Component instance to write the property on. |
| input(Type)Value    | Typed     | The value to write. Active port matches `Type`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                  | Enum&lt;SerializedType&gt; | The value type being written. |
| serializedObjProperty | Property selector           | Inspector picker for the property name on the component. |

## See also

- [Get Component Property](./get-component-property)
- [Set Property](./set-property)
- [Set GameObject Property](./set-gameobject-property)
