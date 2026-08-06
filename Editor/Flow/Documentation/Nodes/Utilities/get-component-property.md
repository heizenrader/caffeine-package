---
sidebar_position: 14
---

# Get Component Property

Reads a property from a Unity Component instance at runtime. Like [Get GameObject Property](./get-gameobject-property) but the input is a typed Component reference (Rigidbody, AudioSource, custom MonoBehaviour, etc.) rather than a GameObject.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| inputComponentValue | Component | The Component instance to read from. Pair with [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component) to source it. |

## Outputs

The `(type)Value` port matching `Type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type                  | Enum&lt;SerializedType&gt; | Which output type the read returns. |
| serializedObjProperty | Property selector           | Inspector picker for the property name on the component. |

:::tip Component-typed reads
Use Get Component Property when the property lives on a specific component you've already obtained (via Get Component or Add Component). For GameObject-level properties (`name`, `activeSelf`), [Get GameObject Property](./get-gameobject-property) is more direct.
:::

## See also

- [Set Component Property](./set-component-property)
- [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component)
- [Get GameObject Property](./get-gameobject-property)
