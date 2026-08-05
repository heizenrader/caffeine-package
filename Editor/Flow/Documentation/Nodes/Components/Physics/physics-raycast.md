---
sidebar_position: 1
---

# Physics Raycast

Casts a ray from an origin in a direction, up to a maximum distance, and returns details about the first collider hit. Use it for line-of-sight checks, picking objects in 3D space, projectile collision tests.

**Category:** Action / Variable
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| origin      | Vector3 | World-space starting point of the ray. |
| direction   | Vector3 | Direction the ray travels. Doesn't need to be normalized. |
| maxDistance | Float   | Maximum distance the ray will travel. |

## Outputs

| Port | Type | Description |
|---|---|---|
| hit            | Bool       | `true` when the ray hit a collider. |
| collider       | Collider   | The collider that was hit, or `null`. |
| distance       | Float      | Distance from `origin` to the hit point. |
| normal         | Vector3    | Surface normal at the hit point. |
| point          | Vector3    | World-space hit point. |
| rigidBody      | Rigidbody  | The Rigidbody attached to the hit collider, or `null`. |
| hitTransform   | Transform  | The Transform of the hit GameObject. |
| textureCoord   | Vector2    | UV coordinate at the hit point on the first UV set. |
| textureCoord2  | Vector2    | UV on the second UV set. |
| hitGameObject  | GameObject | The GameObject of the hit collider. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| queryTriggerInteraction | Enum&lt;QueryTriggerInteraction&gt; | Whether triggers should be detected — `UseGlobal` (project default), `Collide`, or `Ignore`. |

:::tip Run in Update or trigger-event flows
Raycasts are typically run per-frame for "what's the player aiming at" patterns (drive from [Update](/docs/Flow/Nodes/Events/update)) or as a one-shot on a button press.
:::

## See also

- [Get Screen Position](/docs/Flow/Nodes/Components/GameObject/get-screen-position) — convert world to screen space
