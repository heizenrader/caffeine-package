---
sidebar_position: 5
---

# Set Material Color

Shortcut for setting a Material's main `color` property. Same as [Set Material Property](./set-material-property) with `type = Color`, but with a tighter input shape.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| targetMat       | Material | The Material to update. |
| inputColorValue | Color    | The new color. |

:::tip For non-main colors, use Set Material Property
This node writes to `Material.color`, which maps to the shader's main color property (typically `_Color` on the Standard shader, `_BaseColor` on URP/HDRP Lit). For other colors (emission, specular tint, named extras), use [Set Material Property](./set-material-property) with the specific property name.
:::

## See also

- [Set Material Property](./set-material-property)
- [Color nodes](/docs/Flow/Nodes/Math/Color/overview)
