---
sidebar_position: 1
---

# Set Laser Active

Enables or disables the laser pointer on one or both VR controllers. Use it to hide the laser during steps where pointing isn't needed (immersive narrative beats) or to show it when interaction is expected.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| active | Bool | `true` to enable the laser, `false` to disable it. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| hand | Enum&lt;Handedness&gt; | Which laser to toggle — `Right`, `Left`, or `Any` (both at once). |

:::note VR builds only
This node has no effect on non-VR builds. The active state survives until changed by another Set Laser Active call.
:::

## See also

- [VR Player](/docs/Flow/Nodes/Player/vr-player)
- [Player Input Haptics](/docs/Flow/Nodes/Input/player-input-haptics)
