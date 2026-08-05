---
sidebar_position: 0
sidebar_label: Overview
---

# Light Nodes

Light nodes wrap a small set of methods on `UnityEngine.Light` — Reset and command-buffer management.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Light.html)

:::tip For per-property changes
Most Light edits creators want — set intensity, color, range, type — are best done via [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) with the Light as the component, since the codegen wrappers don't cover those getters/setters.
:::

:::note Implicit `light` input
Every node in this category takes a `Light` input. The table lists only the additional method parameters.
:::

## Operations

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Light Reset ()                       | —                                  | — | [↗](https://docs.unity3d.com/ScriptReference/Light.Reset.html) |
| Light RemoveAllCommandBuffers ()     | —                                  | — | [↗](https://docs.unity3d.com/ScriptReference/Light.RemoveAllCommandBuffers.html) |
| Light RemoveCommandBuffers (evt)     | evt (Enum&lt;LightEvent&gt;)       | — | [↗](https://docs.unity3d.com/ScriptReference/Light.RemoveCommandBuffers.html) |

## See also

- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property)
- [Color nodes](/docs/Flow/Nodes/Math/Color/overview)
