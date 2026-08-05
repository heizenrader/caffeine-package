---
sidebar_position: 6
---

# Enable Material Keyword

Enables a shader keyword on a Material — turns on a feature variant in the shader. Use it to toggle effects controlled by `#pragma multi_compile` keywords (emission on/off, normal map enable, etc.).

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Material.EnableKeyword.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| material | Material | The Material to update. |
| keyword  | String   | The shader keyword (e.g., `_EMISSION`, `_NORMALMAP`). |

:::tip Keyword vs property
Material keywords switch between compiled shader variants — they're like compile-time `#define`s. Use them for features that have a "performance cost only when enabled" pattern (emission, normal mapping). For continuously-variable values, use [Set Material Property](./set-material-property) instead.
:::

## See also

- [Disable Material Keyword](./disable-material-keyword)
- [Set Material Property](./set-material-property)
