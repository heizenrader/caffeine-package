---
sidebar_position: 1
---

# AI Bot Conversation

Sends a question to a configured AI Bot and emits the answer when it arrives. Use it to drive conversational tutoring, dynamic feedback, or any flow that needs the user's input answered by an LLM.

**Category:** Action
**Component / Source:** Caffeine `AIBot`

## Inputs

| Port | Type | Description |
|---|---|---|
| question | String | The user's question or prompt to send to the AI Bot. |

## Outputs

| Port | Type | Description |
|---|---|---|
| answerReady | Flow   | Kicks once when the AI Bot returns its response. |
| answer      | String | The most recent answer text. Read this from any node downstream of `answerReady`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| aiBot | AIBot | Reference to the AI Bot that handles the conversation. Must be set and initialized — the node logs an error and skips otherwise. |

:::note Standard Flow output vs `answerReady`
Like every Action node, AI Bot Conversation has a standard Flow output (`exit`) that kicks **immediately** when the request is sent — not when the answer arrives. Wire downstream from `answerReady` for "after the AI responds", from `exit` for "after the request was kicked off". See the [Action overview](/docs/Flow/Nodes/Components/overview) for the convention.
:::

:::tip Display partial state while waiting
The AI service can take a few seconds to respond. Wire `exit` to a node that updates UI to "Thinking…", and `answerReady` to a node that swaps in the actual `answer` text — that gives the user clear feedback that the request is in flight.
:::

## See also

- [Reset AI Bot Conversation](./reset-ai-bot-conversation) — clear the AI Bot's conversation history
- [Voice Dictation](/docs/Flow/Nodes/Voice/voice-dictation) — capture the user's spoken question to feed into `question`
- [TTS](/docs/Flow/Nodes/Voice/tts) — speak the `answer` aloud
