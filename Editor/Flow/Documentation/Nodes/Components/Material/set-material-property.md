---
sidebar_position: 4
---

# Set Material Property

Writes a typed property on a Material — Color, Float, Integer, Vector, Texture, Matrix, etc. Counterpart of [Get Material Property](./get-material-property).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| material | Material | The Material to update. |
| property | String   | The shader property name. |
| (typed input) | (matching `type`) | The value to write (e.g., `color`, `float`, `texture`). The active port matches the `type` enum. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| type | Enum&lt;MaterialPropertyType&gt; | Which input type to use. |

:::tip Silently skips missing properties
The node checks `material.HasProperty(property)` and the typed accessor before writing — if the shader doesn't expose the property by that name and type, the write is skipped without error. Verify the property name matches the shader's actual uniform.
:::

## See also

- [Get Material Property](./get-material-property)
- [Set Material Color](./set-material-color) — shortcut for the main color property
