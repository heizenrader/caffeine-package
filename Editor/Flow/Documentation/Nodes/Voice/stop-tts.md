---
sidebar_position: 2
---

# Stop TTS

Interrupt any in-progress speech on the connected VoiceBot. Useful when the user advances past a narrated step, opens a menu, or triggers a different prompt and you don't want the previous line to keep playing.

**Category:** Action
**Component / Source:** Caffeine `VoiceBot`

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| voiceBot | VoiceBot | Reference to the VoiceBot whose current speech should be stopped. |

## Notes & gotchas

:::warning Runtime only
Stop TTS does not work in Unity Editor Play mode — it logs a warning and skips. Test in a built player.
:::

:::note No `speakComplete` after a stop
Stopping speech does **not** trigger the [TTS](./tts) node's `speakComplete` output — that output only fires on natural completion of the phrase. If your downstream logic needs to run whether the phrase finished or was interrupted, wire that branch from a separate flow rather than from `speakComplete`.
:::

## See also

- [TTS](./tts)
