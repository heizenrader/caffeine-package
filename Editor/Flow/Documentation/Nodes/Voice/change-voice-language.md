---
sidebar_position: 4
---

# Change Voice Language

Switch the active language on the connected VoiceBot. Affects both [TTS](./tts) (the voice and language used to speak) and [Voice Dictation](./voice-dictation) (the language the recognizer expects).

**Category:** Action
**Component / Source:** Caffeine `VoiceBot`

:::note Menu name
This node appears in the editor's Add Node menu as **"Change Language Voice"** under `Flow/Voice/`. The display title here uses the more natural English ordering.
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| language | Enum&lt;Languages&gt; | The language to switch to. Available values: `English`, `Spanish`, `Italian`, `Dutch`, `French`, `German`, `Polish`, `Portuguese`, `Swedish`, `Russian`. |
| voiceBot | VoiceBot | Reference to the VoiceBot whose language should change. |

## Notes & gotchas

:::warning Runtime only
Change Voice Language does not work in Unity Editor Play mode — it logs a warning and skips. Test in a built player.
:::

:::tip Switch before speaking
Wire this node *before* the [TTS](./tts) node that should speak in the new language — the change takes effect on the next TTS call, not on speech already in progress.
:::

## See also

- [TTS](./tts)
- [Voice Dictation](./voice-dictation)
