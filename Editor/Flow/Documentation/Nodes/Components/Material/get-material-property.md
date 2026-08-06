---
sidebar_position: 3
---

# Get Material Property

Reads a typed property from a Material — Color, Float, Integer, Vector, Texture, Matrix, etc. Use it to inspect current shader values for animation, conditional logic, or copying values between materials.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Material.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| material | Material | The Material to read from. |
| property | String   | The shader property name (e.g., `_BaseColor`, `_Metallic`, `_MainTex`). |

## Outputs

The output port matching `type` is the active one.

| Port | Type | Description |
|---|---|---|
| color / colorArray / float / floatArray / integer / matrix / matrixArray / texture / textureOffset / textureScale / vector / vectorArray | (matching type) | The property's current value. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| type | Enum&lt;MaterialPropertyType&gt; | Which output type to use. Maps to `material.GetColor`, `material.GetFloat`, `material.GetTexture`, etc. |

:::tip Property names match shader uniforms
The property name is the shader's internal name (with leading underscore, e.g. `_BaseColor`), not the inspector label. Check the shader source or use Unity's Frame Debugger to find the right name.
:::

## See also

- [Set Material Property](./set-material-property)
- [Get Material](./get-material)
