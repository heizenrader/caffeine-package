---
sidebar_position: 1
---

# Enable AR

Switches the viewer into augmented-reality mode, showing your scene in the user's real-world surroundings (the device camera feed on mobile, headset passthrough on MR devices like Meta Quest). Use it to drop the user into AR at a specific step (for example, when a lesson moves from a 3D model to placing it in the room).

**Category:** Action

:::note Only where AR is supported
Has no effect on builds and devices that don't support AR (such as VR builds), and does nothing if AR is already on. Safe to leave in a cross-platform graph — it simply no-ops where AR isn't available.
:::

## See also

- [Disable AR](./disable-ar) — switch back out of AR mode
- [Is AR On](./is-ar-on) — check whether AR is currently active
