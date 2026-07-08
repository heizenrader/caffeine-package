---
sidebar_position: 16
---

# Get Variable Property

Reads a typed sub-property from a struct value (Vector2/3/4, Quaternion, Color) — e.g., the `x` of a Vector3, the `r` of a Color, the `magnitude` of a Vector2.

**Category:** Variable
**Kind:** Property

## Behavior

Pick `InputType` (the type of the source struct) and `Type` (the type of the property being read). The matching typed input port for the source becomes active; the matching typed output emits the result.

## Inputs

The `input(InputType)Value` port matching `InputType` — `inputVector3Value`, `inputVector2Value`, `inputVector4Value`, `inputQuaternionValue`, or `inputColorValue`.

## Outputs

The `(type)Value` port matching `Type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| InputType             | Enum&lt;SerializedType&gt; | The source struct type. |
| Type                  | Enum&lt;SerializedType&gt; | The output type of the property being read. |
| serializedObjProperty | Property selector           | Inspector picker for which property of the source struct to read. |

:::tip Often replaced by dedicated nodes
For common reads ([Vector3 Magnitude](/docs/Flow/Nodes/Math/Vector3/overview), [Get Axis](./get-axis) for x/y/z components), the dedicated nodes are easier and less error-prone. Reach for Get Variable Property only for less-common struct properties.
:::

## See also

- [Get Axis](./get-axis) — pull x/y/z out of a Vector3
- [Vector3 / Vector2 / Color overviews](/docs/Flow/Nodes/Math/overview)
