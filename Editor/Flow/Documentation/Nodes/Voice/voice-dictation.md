---
sidebar_position: 3
---

# Voice Dictation

Listen to the user's microphone via the connected VoiceBot and emit transcripts as the system recognizes speech. The node fires twice per utterance — once with each rolling partial transcription as the user is still speaking, and once with the final transcript when the phrase ends.

**Category:** Action
**Component / Source:** Caffeine `VoiceBot`

## Outputs

| Port | Type | Description |
|---|---|---|
| partialTranscription | Flow | Kicks every time the recognizer updates its in-progress guess. The current text is available on the `transcription` output. Useful for live-display "you said…" UI. |
| fullTranscription | Flow | Kicks once when the recognizer commits a final result for the utterance. Use this to drive logic that needs the user's completed answer. |
| transcription | String | The most recent transcript text. Read this from any node downstream of `partialTranscription` or `fullTranscription`. |

:::note Standard Flow output vs transcription outputs
Like every Action node, Voice Dictation has a standard Flow output (`exit`) that kicks **immediately** when listening starts — not when transcription is ready. The two named outputs above kick later, asynchronously, as the recognizer reports interim and final results. See the [Action overview](/docs/Flow/Nodes/Components/overview) for the convention.
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| voiceBot | VoiceBot | Reference to the VoiceBot that will listen and transcribe. |

## Notes & gotchas

:::warning Runtime only
Voice Dictation does not work in Unity Editor Play mode — it logs a warning, kicks the standard Flow output, and skips listening. Test in a built player with a working microphone.
:::

:::tip Wait for `fullTranscription` before scoring
`partialTranscription` fires repeatedly with rough guesses that can change as the user keeps talking. Don't grade or branch on partial text; gate scoring/comparison logic on `fullTranscription` and read `transcription` there.
:::

:::note One listen per kick
Each time the standard Flow input kicks the node, the VoiceBot starts a fresh listening session. Subsequent partial/full kicks come from that one listen — to listen again, kick the node again.
:::

## See also

- [TTS](./tts)
- [Change Voice Language](./change-voice-language)
