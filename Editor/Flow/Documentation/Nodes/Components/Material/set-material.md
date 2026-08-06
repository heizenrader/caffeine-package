---
sidebar_position: 2
---

# Set Material

Replaces the Material at a specific slot of a Renderer with a new Material. Use it to swap materials at runtime — change appearance based on state, switch between unlit and lit variants, etc.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| renderer | Renderer | The Renderer to update. |
| index    | Int      | The material slot index to replace. |
| material | Material | The new Material. |

:::warning Runtime only
Set Material no-ops in edit mode to avoid leaking instanced materials into the saved scene. Test in play mode.
:::

## See also

- [Get Material](./get-material)
- [Set Material Color](./set-material-color)
- [Set Material Property](./set-material-property)
