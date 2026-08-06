---
sidebar_position: 0
sidebar_label: Overview
---

# AudioSource Nodes

AudioSource nodes are Flow wrappers around the methods on `UnityEngine.AudioSource` — start, pause, resume, and stop audio playback, with optional delay. Each node takes an `AudioSource` reference and runs the corresponding Unity API call.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/AudioSource.html)

:::note Implicit `audioSource` input
Every node in this category takes an `AudioSource` input (the target). Tables list only the additional method parameters.
:::

:::tip Setting the clip / volume / pitch
The codegen wrappers cover playback control. To change the clip, volume, or pitch, use [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — wire the AudioSource as the component, name the property (`clip`, `volume`, `pitch`), and the typed input.
:::

## Operations

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| AudioSource Play ()                                       | —                                | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.Play.html) |
| AudioSource PlayDelayed (delay)                           | delay (Float, seconds)           | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.PlayDelayed.html) |
| AudioSource Pause ()                                      | —                                | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.Pause.html) |
| AudioSource UnPause ()                                    | —                                | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.UnPause.html) |
| AudioSource Stop ()                                       | —                                | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.Stop.html) |
| AudioSource SetSpatializerFloat (index, value)            | index (Int), value (Float)       | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.SetSpatializerFloat.html) |
| AudioSource SetAmbisonicDecoderFloat (index, value)       | index (Int), value (Float)       | — | [↗](https://docs.unity3d.com/ScriptReference/AudioSource.SetAmbisonicDecoderFloat.html) |

## See also

- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — set `clip`, `volume`, `pitch`, etc.
- [Voice nodes](/docs/Flow/Nodes/Voice/overview) — Caffeine's higher-level TTS / dictation system
