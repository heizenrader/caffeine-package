---
sidebar_position: 1
---

# Get Material

Returns the Material at a specific slot of a Renderer. Use it to grab a Renderer's current material so you can wire it into [Set Material Property](./set-material-property), [Set Material Color](./set-material-color), or another renderer's [Set Material](./set-material).

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| renderer | Renderer | The Renderer to read from. |
| index    | Int      | The material slot index (0 for the first / only material). |

## Outputs

| Port | Type | Description |
|---|---|---|
| material | Material | The material at the slot, or `null` if the renderer is null or the index is out of range. |

:::warning Returns null in editor (not in play mode)
To prevent leaking instanced materials into the saved scene, this node only resolves materials at runtime. In edit mode the output is `null`.
:::

## See also

- [Set Material](./set-material)
- [Get Material Property](./get-material-property)
