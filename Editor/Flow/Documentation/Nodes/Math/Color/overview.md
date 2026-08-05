---
sidebar_position: 0
sidebar_label: Overview
---

# Color Nodes

Color nodes are Flow wrappers around the static methods on `UnityEngine.Color`. They're pure data nodes (no Flow input or output) — wire them into a [Renderer](/docs/Flow/Nodes/Components/Renderer/overview), [Light](/docs/Flow/Nodes/Components/Light/overview), or any node that takes a Color value.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Color.html)

:::note Editor menu path
Color nodes appear in the Flow editor's Add Node menu under `Flow/Actions/Color/...`. They're grouped under **Math** here in the docs because they're pure value computations, not component actions.
:::

:::tip Most colors come from the inspector
The codegen exposes only HSV conversion and Lerp because those are the operations that come up at runtime. To use a fixed color, set it directly on the inspector field of whatever node consumes a Color (Renderer, Light, etc.) instead of building it through a Color node.
:::

## Operations

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Color HSVToRGB (H, S, V)        | H, S, V (Float, 0–1)               | Color (RGB)                                     | [↗](https://docs.unity3d.com/ScriptReference/Color.HSVToRGB.html) |
| Color HSVToRGB (H, S, V, hdr)   | H, S, V (Float, 0–1), hdr (Bool)    | Color — when `hdr` is `true`, allows component values &gt; 1 for HDR emission | [↗](https://docs.unity3d.com/ScriptReference/Color.HSVToRGB.html) |
| Color Lerp                      | a, b (Color), t (Float, clamped 0–1) | Color (component-wise blend)                    | [↗](https://docs.unity3d.com/ScriptReference/Color.Lerp.html) |
| Color LerpUnclamped             | a, b (Color), t (Float, unclamped)  | Color                                           | [↗](https://docs.unity3d.com/ScriptReference/Color.LerpUnclamped.html) |

:::tip HSV for animated hue / saturation
HSV is the right colorspace for animating hue (cycle through colors), saturation (fade to grayscale), or value (brightness) — RGB blends through muddy intermediate colors. Drive `H`, `S`, or `V` from a [Mathf Lerp](/docs/Flow/Nodes/Math/Mathf/overview) or directly from a graph variable, then feed into HSVToRGB to get the displayable Color.
:::

:::tip HDR for emissive intensity
Use the 4-arg `HSVToRGB` with `hdr = true` when feeding into a Light's color or a material's emission slot — values above 1 produce bloom and over-bright effects that the regular 3-arg form clamps off.
:::

## See also

- [Math overview](/docs/Flow/Nodes/Math/overview)
- [Vector3 overview](/docs/Flow/Nodes/Math/Vector3/overview) — Vector-typed math
