---
sidebar_position: 0
sidebar_label: Overview
---

# Voice Nodes

Voice nodes connect a Flow Graph to Caffeine's voice system — speak text aloud, capture spoken input via dictation, and switch the active language at runtime. Every Voice node operates through a **VoiceBot** reference set on the node's inspector — the same VoiceBot wired into all related voice nodes lets them share state (current language, TTS engine, listening session).

:::warning Editor Play mode
Voice nodes are **runtime-only**. Inside Unity Editor Play mode they log a warning and skip — TTS won't speak, Dictation won't transcribe, Change Voice Language won't switch. Test voice flows in a built player (PC build, VR build, or device) rather than in the editor.
:::

:::note Standard Flow ports
Voice nodes are Action / Updatable nodes — they follow the [standard Flow port convention](/docs/Flow/Nodes/Components/overview). The standard Flow input and output (`exit`) are implicit on every node and aren't listed in per-page tables. Pages list only *additional* Flow outputs ([TTS](./tts)'s `speakComplete`, [Voice Dictation](./voice-dictation)'s `partialTranscription` and `fullTranscription`), each with a `:::note` explaining timing relative to `exit`.
:::

## Nodes

| Node | Description |
|---|---|
| [TTS](./tts) | Speak the connected text aloud. Fires a `speakComplete` event when the spoken phrase finishes. |
| [Stop TTS](./stop-tts) | Interrupt any in-progress speech on the connected VoiceBot. |
| [Voice Dictation](./voice-dictation) | Listen to the user's microphone and emit partial / final transcripts as the system recognizes speech. |
| [Change Voice Language](./change-voice-language) | Switch the active language on the connected VoiceBot for both TTS and Dictation. |

## See also

- [AI nodes](/docs/Flow/Nodes/AI/overview)
