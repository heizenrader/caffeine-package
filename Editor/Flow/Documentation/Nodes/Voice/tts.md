---
sidebar_position: 1
---

# TTS

Speak the connected text aloud through the configured VoiceBot. Use this node when you want the experience to read content to the user — narration, prompts, feedback after an answer.

**Category:** Action
**Component / Source:** Caffeine `VoiceBot`

## Inputs

| Port | Type | Description |
|---|---|---|
| textToSpeak | String | The text the VoiceBot will read aloud. |

## Outputs

| Port | Type | Description |
|---|---|---|
| speakComplete | Flow | Kicks once when the VoiceBot finishes speaking the phrase. Use this to chain follow-up actions (next narration line, enable a button, advance a step) instead of guessing how long the speech will take. |

:::note Standard Flow output vs `speakComplete`
Like every Action node, TTS has a standard Flow output (`exit`) that kicks **immediately** when the node runs — not when the speech finishes. To run logic after the spoken phrase completes, wire from `speakComplete`, not from the standard output. See the [Action overview](/docs/Flow/Nodes/Components/overview) for the convention.
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| voiceBot | VoiceBot | Reference to the VoiceBot that will speak. Must be set — the node no-ops if missing or uninitialized. |

## Notes & gotchas

:::warning Runtime only
TTS does not work in Unity Editor Play mode — it logs a warning and skips. Test in a built player.
:::

:::tip Chain on `speakComplete`
Don't put a fixed `Delay` after a TTS node hoping it lines up with the speech length. Wire downstream actions to the `speakComplete` output instead — the VoiceBot will kick it the moment the phrase finishes, regardless of length, language, or playback speed.
:::

## See also

- [Stop TTS](./stop-tts)
- [Change Voice Language](./change-voice-language)
- [Voice Dictation](./voice-dictation)
