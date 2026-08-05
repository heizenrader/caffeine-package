---
sidebar_position: 11
---

# Set Property

Writes a typed value to a property or field on a target Unity object — the writer counterpart of [Get Property](./get-property).

**Category:** Action

## Behavior

Pick a `Type` in the inspector and configure the target via `serializedObjProperty`. The matching typed input (`inputBoolValue`, `inputFloatValue`, etc.) is the value to write; when the node runs, the property is set.

## Inputs

The `input(Type)Value` port matching `Type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                  | Enum&lt;SerializedType&gt; | The value type being written. Selects the active input port. |
| targetObj             | GameObject                  | GameObject hosting the property. |
| serializedObjProperty | Property selector           | Inspector picker for the target object + property name. |

:::warning Type mismatch silently writes default
The picker doesn't enforce that the target property's actual type matches `Type`. A mismatch results in default values being written — verify your selection by reading back via [Get Property](./get-property) once.
:::

## See also

- [Get Property](./get-property)
- [Set GameObject Property](./set-gameobject-property), [Set Component Property](./set-component-property)
