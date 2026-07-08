---
sidebar_position: 0
sidebar_label: Overview
---

# General Action Nodes

General action nodes perform engine-level effects that don't belong to any specific Unity component — logging, timing, cursor settings, raising UnityEvents, and incremental / tween-based motion on Transforms.

These are hand-coded (not generated) and live under `Nodes/Actions/` at the top level in the Caffeine source. They all follow the [standard Action Flow port convention](/docs/Flow/Nodes/Components/overview) — an implicit Flow input and an `exit` output.

## Nodes

| Node | Description |
|---|---|
| [Debug Log](./debug-log)             | Log a value to the Unity console. |
| [Delay](./delay)                     | Wait N seconds, then continue. Gates `exit` by the configured time. |
| [Cursor Settings](./cursor-settings) | Configure system cursor visibility and lock mode. |
| [Unity Event](./unity-event)         | Invoke a UnityEvent configured on the inspector. |
| [Rotate](./rotate)                   | Apply a one-shot Euler rotation to a Transform. |
| [Translate](./translate)             | Apply a one-shot direction translation to a Transform. |
| [GameObject Lerp](./gameobject-lerp) | Smoothly tween a GameObject's position and rotation over a duration. |
| [Transform Lerp](./transform-lerp)   | Smoothly tween one Transform to align with another. |

:::tip Pure-data utilities live under Utilities/
Type conversion (Cast), value construction (Create Vector 2/3), string interpolation (Format String), axis access (Get Axis), and the generic Get*/Set* property family are documented under [Utilities](/docs/Flow/Nodes/Utilities/overview) — they're pure-data nodes with no Flow ports, distinct from the actions above.
:::

## See also

- [Components overview](/docs/Flow/Nodes/Components/overview) — per-Unity-component action subfolders
- [Utilities](/docs/Flow/Nodes/Utilities/overview) — pure-data helpers (Cast, Format String, Get/Set Property family, etc.)
- [Logic nodes](/docs/Flow/Nodes/Logic/overview)
