---
sidebar_position: 0
sidebar_label: Overview
---

# AR Nodes

AR nodes control the viewer's **augmented-reality mode** — your scene shown in the user's real-world surroundings on supported hardware. Turn it on or off from a flow, and check whether it's currently active.

| Node | Kind | Description |
|---|---|---|
| [Enable AR](./enable-ar)   | Action   | Switch the viewer into AR mode. |
| [Disable AR](./disable-ar) | Action   | Switch the viewer back out of AR mode. |
| [Is AR On](./is-ar-on)     | Variable | `true` while the viewer is in AR mode. |

:::note How AR appears depends on the device
On mobile phones and tablets, AR mode shows your scene over the device's live **camera feed**. On standalone MR headsets such as Meta Quest, it uses the headset's **passthrough**. The flow nodes are identical on both — they just request the viewer's AR mode, and the platform decides how it's presented.
:::

:::note Only where AR is supported
These nodes affect the viewer only on builds and devices that support AR. On platforms without AR — such as VR builds — Enable / Disable AR have no effect and Is AR On always reports `false`. You can wire the same graph across platforms without guarding it; it simply no-ops where AR isn't available.
:::

## See also

- [XR](/docs/Flow/Nodes/Components/XR) — VR-specific controls (laser pointer, etc.)
- [Is Platform](/docs/Flow/Nodes/Logic/is-platform) — branch on the runtime platform
