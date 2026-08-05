---
sidebar_position: 5
---

# Split Flow

Kicks several downstream paths from one input — adds an entry per branch in the inspector and connects each entry's port to the next node in that branch. When Split Flow runs, it walks its branches in list order and kicks each connected port; the standard `exit` fires last.

**Category:** Action
**Kind:** Control flow

## Outputs

| Port | Type | Description |
|---|---|---|
| SplitFlowList | Flow (dynamic list) | One Flow port per label you add in the inspector. Each connected port is kicked when the node runs. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| SplitFlowList | List&lt;String&gt; | Add an entry per branch. The label is just a name to identify the port in the editor — duplicates are fine, the labels don't affect behavior. |

:::note Standard Flow output vs split ports
Split Flow kicks every connected split port **first** (in list order), then fires the standard `exit` output. `exit` behaves like one more branch — leave it unwired or wire it like any other split port.
:::

:::warning Not truly parallel — sequential dispatch
Each port is kicked one after another in the order listed in the inspector. For purely synchronous branches, each branch's full downstream chain runs to completion before the next port is kicked. Branches that contain async nodes (`Delay`, `TTS`, `Voice Dictation`, `Timed Kick`, AI calls) yield control as soon as they hit the await, so subsequent ports can start while the earlier branch is waiting — but that's the only way "concurrency" happens here. Don't write a flow that depends on truly simultaneous execution.
:::

:::tip Use `exit` like another branch
Since `exit` fires after every split port, you can use it for "after I've kicked all the branches" cleanup logic, or just treat it as a labelled-by-convention branch like the rest.
:::

## See also

- [For Loop](./for-loop) — sequential iteration over a count, with `index` per iteration
- [Branch](./branch) — pick exactly one of two paths instead of all
- [Conditionals](./conditionals) — pick one of two paths based on multiple bools
