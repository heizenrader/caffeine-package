---
sidebar_position: 0
sidebar_label: Overview
---

# Material Nodes

Material nodes read and write Material assignments on Renderers and individual Material properties (colors, floats, textures, vectors, matrices, keywords). Use them to drive shader changes from a Flow Graph — swap materials, animate a glow value, toggle shader features.

## Nodes

| Node | Description |
|---|---|
| [Get Material](./get-material)              | Read a Material from a Renderer's material slot. |
| [Set Material](./set-material)              | Replace a Renderer's Material at a slot. |
| [Get Material Property](./get-material-property) | Read a typed Material property (Color / Float / Texture / Vector / Matrix). |
| [Set Material Property](./set-material-property) | Write a typed Material property. |
| [Set Material Color](./set-material-color)  | Shortcut for setting the main `color` property. |
| [Enable Material Keyword](./enable-material-keyword)  | Turn on a shader keyword for variant-style features. |
| [Disable Material Keyword](./disable-material-keyword) | Turn off a shader keyword. |

:::warning Material instancing
Reading or writing a Material via `Renderer.materials` instances the material at runtime — Unity creates a per-renderer copy. This is usually what you want (each instance can vary independently), but it consumes memory and can break batching. The Get/Set Material nodes do this in play mode only to avoid leaking instanced materials into your saved scene.
:::

## See also

- [Renderer actions](/docs/Flow/Nodes/Components/overview) — for shape-level enable/disable, etc.
- [Color nodes](/docs/Flow/Nodes/Math/Color/overview)
