---
sidebar_position: 2
---

# Reset AI Bot Conversation

Clears the conversation history of the connected AI Bot. After a reset, the next [AI Bot Conversation](./ai-bot-conversation) call starts a fresh dialogue without any prior context.

**Category:** Action
**Component / Source:** Caffeine `AIBot`

:::note Editor menu name
Appears in the editor as **"AI Bot Conversation Reset"** under `Flow/AI/`. Doc title uses the more natural ordering "Reset AI Bot Conversation".
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| aiBot | AIBot | Reference to the AI Bot whose conversation should be reset. |

:::tip Reset between distinct dialogues
The AI Bot remembers earlier exchanges to provide contextual answers. When the user moves to a new step, lesson, or topic where prior context would confuse the bot, kick this node before the next [AI Bot Conversation](./ai-bot-conversation) call.
:::

## See also

- [AI Bot Conversation](./ai-bot-conversation)
