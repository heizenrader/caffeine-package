---
sidebar_position: 0
sidebar_label: Overview
---

# Rigidbody Nodes

Rigidbody nodes wrap methods on `UnityEngine.Rigidbody` — apply forces and torques, move position / rotation directly, query velocity, manage sleep state. Each node takes a `Rigidbody` reference and runs the corresponding Unity API call.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.html)

:::note Implicit `rigidbody` input
Every node in this category takes a `Rigidbody` input. Tables list only the additional method parameters.
:::

There's also a hand-coded helper for setting interpolation — see [Rigidbody SetInterpolation](./rigidbody-set-interpolation).

:::warning Run physics writes from FixedUpdate
Forces, MovePosition, and MoveRotation should fire from a [FixedUpdate](/docs/Flow/Nodes/Events/fixed-update) flow, not [Update](/docs/Flow/Nodes/Events/update) — the physics step uses the fixed timestep, and writes from per-frame Update produce inconsistent motion.
:::

## Forces

`AddForce` adds a force to the Rigidbody's center of mass. The `mode` parameter (`Enum<ForceMode>`) controls how the force is interpreted: `Force` (continuous, mass-aware), `Acceleration` (continuous, ignore mass), `Impulse` (instant, mass-aware), `VelocityChange` (instant, ignore mass).

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Rigidbody AddForce (force)                                                       | force (Vector3)                              | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) |
| Rigidbody AddForce (force, mode)                                                 | force (Vector3), mode (Enum&lt;ForceMode&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) |
| Rigidbody AddForce (x, y, z)                                                     | x, y, z (Float)                              | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) |
| Rigidbody AddForce (x, y, z, mode)                                               | x, y, z (Float), mode (Enum)                 | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) |
| Rigidbody AddForceAtPosition (force, nPosition)                                  | force (Vector3), nPosition (Vector3)          | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForceAtPosition.html) |
| Rigidbody AddForceAtPosition (force, nPosition, mode)                            | force, nPosition (Vector3), mode (Enum)      | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForceAtPosition.html) |
| Rigidbody AddRelativeForce (force) / (force, mode) / (x, y, z) / (x, y, z, mode) | force (Vector3) or x/y/z (Float), optional mode (Enum) | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddRelativeForce.html) |
| Rigidbody AddExplosionForce (explosionForce, explosionPosition, explosionRadius) | explosionForce (Float), explosionPosition (Vector3), explosionRadius (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html) |
| Rigidbody AddExplosionForce (… , upwardsModifier)                                | + upwardsModifier (Float)                    | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html) |
| Rigidbody AddExplosionForce (… , upwardsModifier, mode)                          | + upwardsModifier (Float), mode (Enum)       | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html) |

## Torque

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Rigidbody AddTorque (torque) / (torque, mode) / (x, y, z) / (x, y, z, mode)              | torque (Vector3) or x/y/z (Float), optional mode (Enum&lt;ForceMode&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddTorque.html) |
| Rigidbody AddRelativeTorque (torque) / (torque, mode) / (x, y, z) / (x, y, z, mode)      | torque (Vector3) or x/y/z (Float), optional mode (Enum) | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.AddRelativeTorque.html) |

## Movement (kinematic-friendly)

`MovePosition` and `MoveRotation` move the Rigidbody respecting physics interpolation — preferred over directly writing transform position when the Rigidbody is kinematic.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Rigidbody MovePosition (position)         | position (Vector3)        | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html) |
| Rigidbody MoveRotation (rot)              | rot (Quaternion)          | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html) |

## Queries

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Rigidbody GetPointVelocity (worldPoint)              | worldPoint (Vector3)     | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.GetPointVelocity.html) |
| Rigidbody GetRelativePointVelocity (relativePoint)   | relativePoint (Vector3)  | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.GetRelativePointVelocity.html) |
| Rigidbody ClosestPointOnBounds (nPosition)           | nPosition (Vector3)      | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.ClosestPointOnBounds.html) |
| Rigidbody IsSleeping ()                              | —                        | Bool    | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.IsSleeping.html) |

## State control

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Rigidbody Sleep ()                       | —                        | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.Sleep.html) |
| Rigidbody WakeUp ()                      | —                        | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.WakeUp.html) |
| Rigidbody ResetCenterOfMass ()           | —                        | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.ResetCenterOfMass.html) |
| Rigidbody ResetInertiaTensor ()          | —                        | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.ResetInertiaTensor.html) |
| Rigidbody SetDensity (density)           | density (Float)          | — | [↗](https://docs.unity3d.com/ScriptReference/Rigidbody.SetDensity.html) |

## See also

- [Rigidbody SetInterpolation](./rigidbody-set-interpolation) — hand-coded helper for visual smoothing
- [FixedUpdate](/docs/Flow/Nodes/Events/fixed-update) — drive physics writes from this event
