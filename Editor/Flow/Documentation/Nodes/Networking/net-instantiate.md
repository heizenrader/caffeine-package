---
sidebar_position: 1
sidebar_label: Net Instantiate
title: Net Instantiate
---

# <span class="net-node">Net Instantiate</span> <span class="net-badge">NET</span>

Spawns a prefab at a given position and rotation, replicating the spawn to every client in the multiplayer session. Use it for any GameObject that should appear for all players (placed object, projectile, spawned tool).

**Category:** Action (Net)

## Inputs

| Port | Type | Description |
|---|---|---|
| prefab        | GameObject | The prefab to spawn. |
| worldPosition | Vector3    | World-space position for the new instance. |
| eulerAngles   | Vector3    | World-space Euler rotation (degrees) for the new instance. |

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The spawned GameObject. Read this from any node downstream of `exit`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| syncTransform     | Bool                       | When `true`, the spawned object's transform is networked (other clients see its position / rotation update). When `false`, only the spawn itself is replicated. |
| interactable      | Bool                       | When `true`, configure the spawned object as a Caffeine interactable, using `interactableData` below. |
| interactableData  | InteractableInstantiateData | When `interactable = true`, configures the interactable's behavior: `type` (interaction type), `range`, `returnToOrigin`, `doubleHanded`, `allowScaling`, `requireTwoHands`. |

:::tip Falls back gracefully on non-net builds
If no networking layer is active (single-player or non-net build), this node falls back to a regular `Instantiate` plus graph-init for any embedded Flow Graphs. You can use the same node in both modes without branching.
:::

## See also

- [Net Destroy](./net-destroy)
- [Get Net Ownership](./get-net-ownership)
- [Net Is Mine](./net-is-mine)
