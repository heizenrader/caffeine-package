---
sidebar_position: 0
sidebar_label: Overview
---

# VideoPlayer Nodes

VideoPlayer nodes wrap playback methods on `UnityEngine.Video.VideoPlayer` — start, pause, stop, prepare, step forward.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.html)

:::tip Set the clip / target via Set Component Property
For changing `clip`, `targetTexture`, `playbackSpeed`, etc., use [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — the codegen wrappers cover playback control only.
:::

:::note Implicit `videoPlayer` input
Every node in this category takes a `VideoPlayer` input. The table lists only the additional method parameters.
:::

## Operations

| Node | Inputs | Output | Unity ref |
|---|---|---|---|
| VideoPlayer Play ()                | — | — | [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.Play.html) |
| VideoPlayer Pause ()               | — | — | [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.Pause.html) |
| VideoPlayer Stop ()                | — | — | [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.Stop.html) |
| VideoPlayer Prepare ()             | — | — | [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.Prepare.html) |
| VideoPlayer StepForward ()         | — | — | [↗](https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.StepForward.html) |

:::tip Prepare before play for smooth start
For videos that take noticeable time to load, kick `Prepare` ahead of when you actually need playback to start, then call `Play` when the prepared event fires (via [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) on `isPrepared`). This avoids the user seeing a hitch on `Play`.
:::

## See also

- [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property) — set clip, target texture, playback speed
- [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) — read `isPrepared`, `isPlaying`, `length`
