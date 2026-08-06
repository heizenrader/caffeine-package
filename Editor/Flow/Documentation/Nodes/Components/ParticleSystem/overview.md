---
sidebar_position: 0
sidebar_label: Overview
---

# ParticleSystem Nodes

ParticleSystem nodes wrap methods on `UnityEngine.ParticleSystem` — start, stop, pause, emit specific counts, simulate forward, query liveness, and trigger sub-emitters.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.html)

:::note Implicit `particleSystem` input
Every node in this category takes a `ParticleSystem` input. Tables list only the additional method parameters.
:::

:::tip `withChildren` overloads
Several methods (Play, Stop, Pause, Clear, IsAlive) come in two variants — one acts on this particle system only, one cascades to all child particle systems too. Use the cascading variant for multi-emitter effects (sparks + smoke + flash) wired through a parent system.
:::

## Playback

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| ParticleSystem Play ()                                | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Play.html) |
| ParticleSystem Play (withChildren)                    | withChildren (Bool)            | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Play.html) |
| ParticleSystem Pause ()                               | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Pause.html) |
| ParticleSystem Pause (withChildren)                   | withChildren (Bool)            | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Pause.html) |
| ParticleSystem Stop ()                                | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Stop.html) |
| ParticleSystem Stop (withChildren)                    | withChildren (Bool)            | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Stop.html) |
| ParticleSystem Stop (withChildren, stopBehavior)      | withChildren (Bool), stopBehavior (Enum&lt;ParticleSystemStopBehavior&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Stop.html) |
| ParticleSystem Clear ()                               | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Clear.html) |
| ParticleSystem Clear (withChildren)                   | withChildren (Bool)            | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Clear.html) |

## Emission

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| ParticleSystem Emit (count)                           | count (Int)                    | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Emit.html) |
| ParticleSystem TriggerSubEmitter (subEmitterIndex)    | subEmitterIndex (Int)          | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.TriggerSubEmitter.html) |

## Simulate / state

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| ParticleSystem Simulate (t)                                              | t (Float)                                       | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Simulate.html) |
| ParticleSystem Simulate (t, withChildren)                                | t (Float), withChildren (Bool)                  | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Simulate.html) |
| ParticleSystem Simulate (t, withChildren, restart)                       | t (Float), withChildren (Bool), restart (Bool)  | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Simulate.html) |
| ParticleSystem Simulate (t, withChildren, restart, fixedTimeStep)        | t, withChildren, restart (Bool), fixedTimeStep (Bool) | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.Simulate.html) |
| ParticleSystem IsAlive ()                                                | —                                                | Bool | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.IsAlive.html) |
| ParticleSystem IsAlive (withChildren)                                    | withChildren (Bool)                              | Bool | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.IsAlive.html) |

## Custom-data attribute allocation (advanced)

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| ParticleSystem AllocateAxisOfRotationAttribute ()                     | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.AllocateAxisOfRotationAttribute.html) |
| ParticleSystem AllocateMeshIndexAttribute ()                          | —                              | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.AllocateMeshIndexAttribute.html) |
| ParticleSystem AllocateCustomDataAttribute (stream)                   | stream (Enum&lt;ParticleSystemCustomData&gt;) | — | [↗](https://docs.unity3d.com/ScriptReference/ParticleSystem.AllocateCustomDataAttribute.html) |

## See also

- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — set particle module values (emission rate, color over lifetime, etc.)
