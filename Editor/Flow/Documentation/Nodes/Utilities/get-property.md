---
sidebar_position: 10
---

# Get Property

Reads a property or field from a target Unity object — any public C# member that's reflected onto the configured target. Use it for ad-hoc reads where there's no dedicated wrapper (e.g. read a custom-script field, or a Unity property not exposed by other nodes).

**Category:** Variable
**Kind:** Property

## Behavior

Pick a `Type` in the inspector and configure the target object + property path via the inspector's `serializedObjProperty` field. The matching typed output (`boolValue`, `floatValue`, etc.) emits the property's current value on demand.

## Outputs

The `(type)Value` port matching `Type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                 | Enum&lt;SerializedType&gt; | Which output type the read returns. Selects the active output port. |
| targetObj            | GameObject                  | The GameObject whose property to read. Used to resolve which component instance owns the property. |
| serializedObjProperty | Property selector          | Inspector picker for the target object + property name. Configure once via the inspector's dropdown — the picker walks the GameObject's components to find the matching property. |

:::tip Use the dedicated nodes when one exists
For Transform position/rotation/scale, AudioSource clip, Renderer material, and most common Unity properties, use the dedicated codegen nodes ([Transform](/docs/Flow/Nodes/Components/overview), [AudioSource](/docs/Flow/Nodes/Components/overview), etc.) — they're easier to wire and less error-prone. Reach for Get Property only when a property has no dedicated wrapper.
:::

## See also

- [Set Property](./set-property)
- [Get GameObject Property](./get-gameobject-property), [Get Component Property](./get-component-property), [Get Variable Property](./get-variable-property) — variants for different target shapes
