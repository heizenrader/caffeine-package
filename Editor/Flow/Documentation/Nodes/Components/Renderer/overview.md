---
sidebar_position: 0
sidebar_label: Overview
---

# Renderer Nodes

Renderer nodes wrap one method on `UnityEngine.Renderer` — query whether the renderer has a MaterialPropertyBlock attached.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Renderer.html)

:::tip For most Renderer edits
Use [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — for `enabled` (toggle visibility), `sortingOrder`, `sortingLayerName`, `shadowCastingMode`, etc. The codegen wrappers don't cover these.

For Material changes, see the dedicated [Material](/docs/Flow/Nodes/Components/Material/overview) nodes.
:::

:::note Implicit `renderer` input
The node takes a `Renderer` input. The table lists only the additional method parameters.
:::

## Operations

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Renderer HasPropertyBlock () | — | Bool | [↗](https://docs.unity3d.com/ScriptReference/Renderer.HasPropertyBlock.html) |

## See also

- [Material nodes](/docs/Flow/Nodes/Components/Material/overview) — read / write Materials and properties
- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property)
