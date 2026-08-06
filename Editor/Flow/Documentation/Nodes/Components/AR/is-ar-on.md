---
sidebar_position: 3
---

# Is AR On

Outputs whether the viewer is currently in augmented-reality mode. Use it to branch on AR state — show different UI, swap a controls hint, or skip an AR-only step.

**Category:** Variable
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| isOn | Bool | `true` while the viewer is in AR mode. Always `false` on builds and devices that don't support AR (such as VR builds). |

:::tip Cheap to read
This reads a cached flag, not the AR session — it's fine to poll every frame from an [Update](/docs/Flow/Nodes/Events/update) flow.
:::

## See also

- [Enable AR](./enable-ar) / [Disable AR](./disable-ar) — change AR mode
- [Branch](/docs/Flow/Nodes/Logic/branch) — act on the Bool result
