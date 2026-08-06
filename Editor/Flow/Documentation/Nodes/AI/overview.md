---
sidebar_position: 0
sidebar_label: Overview
---

# AI Nodes

AI nodes connect a Flow Graph to Caffeine's AI Bot conversation system — send the user's prompts, receive the model's answers, and reset state when a new dialogue should start fresh.

Both AI nodes operate against an **AIBot** reference set on the inspector. The same AIBot wired into Conversation and Reset nodes shares state, so a Reset elsewhere in the graph affects the same dialogue.

:::note Standard Flow ports
AI nodes are Action / Updatable nodes — they follow the [standard Flow port convention](/docs/Flow/Nodes/Components/overview). Standard `entry` / `exit` are implicit. The [AI Bot Conversation](./ai-bot-conversation) node has an additional `answerReady` Flow output that fires asynchronously when the answer arrives.
:::

## Nodes

| Node | Description |
|---|---|
| [AI Bot Conversation](./ai-bot-conversation)             | Send a prompt and receive the answer. |
| [Reset AI Bot Conversation](./reset-ai-bot-conversation) | Clear the AI Bot's conversation history. |

## See also

- [Voice nodes](/docs/Flow/Nodes/Voice/overview) — pair voice dictation as the user's prompt source and TTS as the answer's output channel
