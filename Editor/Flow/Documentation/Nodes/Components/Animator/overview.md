---
sidebar_position: 0
sidebar_label: Overview
---

# Animator Nodes

Animator nodes are Flow wrappers around the methods on `UnityEngine.Animator` — control animation playback, set parameters, drive inverse kinematics, query layer state. They're action nodes (each takes an `Animator` reference plus the method's parameters and runs the corresponding Unity API call).

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Animator.html)

:::tip Behavior matches Unity exactly
Each node calls the underlying `Animator.X(...)` method directly. Read the Unity ScriptReference page (linked per row) for argument semantics. The doc below covers wiring; Unity covers the method.
:::

:::note Implicit `animator` input
Every node in this category takes an `Animator` input (the target). Tables below list only the additional method parameters — the `animator` input is universal and not repeated.
:::

There's also one hand-coded helper that bundles two related calls — see [SetLookAtPosition Full](./set-look-at-position-full).

## Playback

Play, CrossFade, and PlayInFixedTime — start animations on the Animator. Multiple overloads correspond to whether you target a state by name or by hash, with optional layer / time-offset / transition-time parameters.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator Play (stateName)                                                   | stateName (String)                                                       | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator Play (stateName, layer)                                            | stateName (String), layer (Int)                                          | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator Play (stateName, layer, normalizedTime)                            | stateName (String), layer (Int), normalizedTime (Float)                  | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator Play (stateNameHash)                                               | stateNameHash (Int)                                                      | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator Play (stateNameHash, layer)                                        | stateNameHash (Int), layer (Int)                                         | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator Play (stateNameHash, layer, normalizedTime)                        | stateNameHash (Int), layer (Int), normalizedTime (Float)                 | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Play.html) |
| Animator PlayInFixedTime (stateName) / (…, layer) / (…, layer, fixedTime)   | stateName (String) + optional layer (Int), fixedTime (Float)             | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.PlayInFixedTime.html) |
| Animator PlayInFixedTime (stateNameHash) / (…, layer) / (…, layer, fixedTime) | stateNameHash (Int) + optional layer (Int), fixedTime (Float)          | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.PlayInFixedTime.html) |
| Animator CrossFade (stateName, normalizedTransitionDuration) + 1–3 optional params | stateName (String), normalizedTransitionDuration (Float), optional layer (Int), normalizedTimeOffset (Float), normalizedTransitionTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.CrossFade.html) |
| Animator CrossFade (stateHashName, normalizedTransitionDuration) + 1–3 optional params | stateHashName (Int), normalizedTransitionDuration (Float), optional layer (Int), normalizedTimeOffset (Float), normalizedTransitionTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.CrossFade.html) |
| Animator CrossFadeInFixedTime (stateName, fixedTransitionDuration) + 1–3 optional params | stateName (String), fixedTransitionDuration (Float), optional layer (Int), fixedTimeOffset (Float), normalizedTransitionTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.CrossFadeInFixedTime.html) |
| Animator CrossFadeInFixedTime (stateHashName, fixedTransitionDuration) + 1–3 optional params | stateHashName (Int), fixedTransitionDuration (Float), optional layer (Int), fixedTimeOffset (Float), normalizedTransitionTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.CrossFadeInFixedTime.html) |

:::tip Name vs hash variants
The hash variants (`stateNameHash`, `stateHashName`) are faster — avoid string lookups every kick. Compute the hash once at startup via `Animator.StringToHash` and cache it in a graph variable for hot paths. Use the name variants for one-shot or rare calls where readability matters more.
:::

## Parameters

Read and write Animator parameters (Bool, Float, Int, Trigger). Each comes in name-string and hash-id variants.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator GetBool (id) / (name)         | id (Int) or name (String)                | Bool   | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetBool.html) |
| Animator GetFloat (id) / (nName)       | id (Int) or nName (String)               | Float  | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetFloat.html) |
| Animator GetInteger (id) / (nName)     | id (Int) or nName (String)               | Int    | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetInteger.html) |
| Animator SetBool (id, value) / (nName, value) | id (Int) or nName (String), value (Bool) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetBool.html) |
| Animator SetFloat (id, value) / (nName, value) | id (Int) or nName (String), value (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetFloat.html) |
| Animator SetFloat (id, value, dampTime, deltaTime) / (name, value, dampTime, deltaTime) | id (Int) or name (String), value (Float), dampTime (Float), deltaTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetFloat.html) |
| Animator SetInteger (id, value) / (name, value) | id (Int) or name (String), value (Int) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetInteger.html) |
| Animator SetTrigger (id) / (nName)     | id (Int) or nName (String)               | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html) |
| Animator ResetTrigger (id) / (name)    | id (Int) or name (String)                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.ResetTrigger.html) |
| Animator IsParameterControlledByCurve (id) / (nName) | id (Int) or nName (String)         | Bool   | [↗](https://docs.unity3d.com/ScriptReference/Animator.IsParameterControlledByCurve.html) |

## Inverse Kinematics (IK)

Drive look-at, IK goal positions, and IK hint positions. Most of these only have an effect when called from inside an [On Animator IK](/docs/Flow/Nodes/Events/on-animator-ik) flow.

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator SetLookAtPosition (lookAtPosition)                | lookAtPosition (Vector3)                                 | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtPosition.html) |
| Animator SetLookAtWeight (weight)                          | weight (Float)                                            | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtWeight.html) |
| Animator SetLookAtWeight (weight, bodyWeight)              | weight (Float), bodyWeight (Float)                        | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtWeight.html) |
| Animator SetLookAtWeight (weight, bodyWeight, headWeight)  | weight, bodyWeight, headWeight (Float)                    | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtWeight.html) |
| Animator SetLookAtWeight (weight, bodyWeight, headWeight, eyesWeight) | weight, bodyWeight, headWeight, eyesWeight (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtWeight.html) |
| Animator SetLookAtWeight (weight, bodyWeight, headWeight, eyesWeight, clampWeight) | weight, bodyWeight, headWeight, eyesWeight, clampWeight (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLookAtWeight.html) |
| Animator SetIKPosition (goal, goalPosition)                | goal (Enum&lt;AvatarIKGoal&gt;), goalPosition (Vector3)   | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKPosition.html) |
| Animator GetIKPosition (goal)                              | goal (Enum&lt;AvatarIKGoal&gt;)                           | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKPosition.html) |
| Animator SetIKPositionWeight (goal, value)                 | goal (Enum&lt;AvatarIKGoal&gt;), value (Float)            | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKPositionWeight.html) |
| Animator GetIKPositionWeight (goal)                        | goal (Enum&lt;AvatarIKGoal&gt;)                           | Float | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKPositionWeight.html) |
| Animator SetIKRotation (goal, goalRotation)                | goal (Enum&lt;AvatarIKGoal&gt;), goalRotation (Quaternion)| — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKRotation.html) |
| Animator GetIKRotation (goal)                              | goal (Enum&lt;AvatarIKGoal&gt;)                           | Quaternion | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKRotation.html) |
| Animator SetIKRotationWeight (goal, value)                 | goal (Enum&lt;AvatarIKGoal&gt;), value (Float)            | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKRotationWeight.html) |
| Animator GetIKRotationWeight (goal)                        | goal (Enum&lt;AvatarIKGoal&gt;)                           | Float | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKRotationWeight.html) |
| Animator SetIKHintPosition (hint, hintPosition)            | hint (Enum&lt;AvatarIKHint&gt;), hintPosition (Vector3)   | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKHintPosition.html) |
| Animator GetIKHintPosition (hint)                          | hint (Enum&lt;AvatarIKHint&gt;)                           | Vector3 | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKHintPosition.html) |
| Animator SetIKHintPositionWeight (hint, value)             | hint (Enum&lt;AvatarIKHint&gt;), value (Float)            | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetIKHintPositionWeight.html) |
| Animator GetIKHintPositionWeight (hint)                    | hint (Enum&lt;AvatarIKHint&gt;)                           | Float | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetIKHintPositionWeight.html) |
| Animator SetBoneLocalRotation (humanBoneId, rotation)      | humanBoneId (Int), rotation (Quaternion)                   | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetBoneLocalRotation.html) |

See also: [SetLookAtPosition Full](./set-look-at-position-full) (hand-coded combo of SetLookAtPosition + SetLookAtWeight).

## Layers

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator GetLayerIndex (layerName)            | layerName (String)                       | Int    | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetLayerIndex.html) |
| Animator GetLayerName (layerIndex)            | layerIndex (Int)                         | String | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetLayerName.html) |
| Animator GetLayerWeight (layerIndex)          | layerIndex (Int)                         | Float  | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetLayerWeight.html) |
| Animator SetLayerWeight (layerIndex, weight)  | layerIndex (Int), weight (Float)         | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetLayerWeight.html) |
| Animator IsInTransition (layerIndex)          | layerIndex (Int)                         | Bool   | [↗](https://docs.unity3d.com/ScriptReference/Animator.IsInTransition.html) |
| Animator HasState (layerIndex, stateID)       | layerIndex (Int), stateID (Int)          | Bool   | [↗](https://docs.unity3d.com/ScriptReference/Animator.HasState.html) |
| Animator GetCurrentAnimatorClipInfoCount (layerIndex) | layerIndex (Int)                 | Int    | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetCurrentAnimatorClipInfoCount.html) |
| Animator GetNextAnimatorClipInfoCount (layerIndex) | layerIndex (Int)                    | Int    | [↗](https://docs.unity3d.com/ScriptReference/Animator.GetNextAnimatorClipInfoCount.html) |

## Recording / Playback

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator StartRecording (frameCount) | frameCount (Int) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.StartRecording.html) |
| Animator StopRecording ()            | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.StopRecording.html) |
| Animator StartPlayback ()            | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.StartPlayback.html) |
| Animator StopPlayback ()             | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.StopPlayback.html) |

## Match target

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator SetTarget (targetIndex, targetNormalizedTime) | targetIndex (Int), targetNormalizedTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.SetTarget.html) |
| Animator InterruptMatchTarget ()                       | —                                               | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.InterruptMatchTarget.html) |
| Animator InterruptMatchTarget (completeMatch)          | completeMatch (Bool)                            | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.InterruptMatchTarget.html) |

## Misc

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| Animator Rebind ()                       | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Rebind.html) |
| Animator WriteDefaultValues ()           | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.WriteDefaultValues.html) |
| Animator ApplyBuiltinRootMotion ()       | —                | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.ApplyBuiltinRootMotion.html) |
| Animator Update (deltaTime)              | deltaTime (Float) | — | [↗](https://docs.unity3d.com/ScriptReference/Animator.Update.html) |

## See also

- [On Animator IK](/docs/Flow/Nodes/Events/on-animator-ik) — fires the IK pass that several SetIK* / SetLookAt* nodes operate against
- [SetLookAtPosition Full](./set-look-at-position-full) — hand-coded combo helper
