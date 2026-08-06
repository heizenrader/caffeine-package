---
sidebar_position: 6
---

# For Loop

Iterates from `first` to `last` by `step`, kicking the `body` output once per iteration. The standard `exit` fires once after the loop completes.

**Category:** Action
**Kind:** Control flow / Looping

## Inputs

| Port | Type | Description |
|---|---|---|
| first | Int | Starting value (inclusive). |
| last  | Int | Ending value (inclusive). |
| step  | Int | Increment per iteration. Positive `step` requires `last >= first`; negative `step` requires `last <= first`. A zero or wrong-direction `step` runs zero iterations. |

## Outputs

| Port | Type | Description |
|---|---|---|
| index | Int  | The current iteration's value. Read this from any node downstream of `body`. |
| body  | Flow | Kicks once per iteration. The full body subgraph runs to completion before the next iteration starts. |

:::note Standard Flow output vs `body`
For Loop fires `body` once per iteration — N total kicks for an N-iteration loop. The standard `exit` fires **once**, after the loop has finished iterating. Wire post-loop logic to `exit`, per-iteration logic to `body`.
:::

:::tip Body runs synchronously per iteration
The For Loop blocks until each iteration's body subgraph completes. If the body kicks an asynchronous node (e.g. [TTS](/docs/Flow/Nodes/Voice/tts), [Timed Kick](./timed-kick)), the loop does **not** wait for those to finish — it moves to the next iteration immediately. Use a synchronous chain in the body if you need per-iteration completion.
:::

## See also

- [Foreach Game Object](./foreach-game-object) — iterate over a list of GameObjects
- [Timed Kick](./timed-kick) — repeat at a time interval instead of a count
