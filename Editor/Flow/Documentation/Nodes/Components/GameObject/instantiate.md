---
sidebar_position: 7
---

# Instantiate

Spawns a copy of a configured prefab at the given world position and Euler rotation. Use it to create projectiles, place props at runtime, or duplicate templates.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| worldPosition | Vector3 | World-space position for the new instance. |
| eulerAngles   | Vector3 | World-space Euler rotation (degrees) for the new instance. |

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The newly-spawned GameObject. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| prefab | GameObject | The prefab to spawn. |

:::tip Embedded Flow Graphs are auto-initialized
If the prefab contains GameObjects with `EdXR_SceneGraph` components, those graphs are copied at runtime (so they don't share state with the prefab) and initialized on the new instance. References to prefab-internal GameObjects are remapped to the corresponding instance children.
:::

:::warning Plain Instantiate isn't networked
For multiplayer spawns where every player should see the new object, use [Net Instantiate](/docs/Flow/Nodes/Networking/net-instantiate) instead.
:::

## See also

- [Net Instantiate](/docs/Flow/Nodes/Networking/net-instantiate)
- [Destroy](./destroy)
