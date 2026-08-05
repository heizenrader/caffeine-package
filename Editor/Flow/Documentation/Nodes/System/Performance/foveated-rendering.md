---
sidebar_position: 1
---

# Foveated Rendering

Sets the foveated-rendering level of the active VR headset. Foveation reduces shading work in the user's peripheral vision to free up GPU budget — useful when frame rate dips during heavy scenes.

**Category:** Action
**Kind:** Performance setting

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| foveationLevel | Enum&lt;FoveatedRenderingLevel&gt; | Which level of foveation to apply. Higher levels free more GPU at the cost of peripheral image quality. Refer to your XR plug-in's documentation for the exact effect of each level. |

:::note VR builds only
This node has no effect on non-VR builds — kicking it on PC or mobile is a safe no-op. The level applies to whatever VR headset the player is using.
:::

:::tip Switch dynamically based on scene complexity
Foveated rendering can be raised when entering a heavy scene (lots of dynamic lighting, transparencies, post-FX) and lowered for menus or simpler areas. Wire this node to the [On Step Loaded](/docs/Flow/Nodes/Events/overview) event on each step's Flow Graph to set the level appropriate for that step.
:::
