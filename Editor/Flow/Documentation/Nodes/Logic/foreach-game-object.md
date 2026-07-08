---
sidebar_position: 7
---

# Foreach Game Object

Iterates over a list of GameObjects, kicking `body` once per non-null item. Exposes the current `item`, `index`, and total `count` as data outputs while the body runs.

**Category:** Action
**Kind:** Control flow / Looping

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;GameObject&gt; | The list to iterate over. Connect from a [Game Object List](/docs/Flow/Nodes/Variables/overview) variable or any node that emits a list of GameObjects. |
| break | Bool                   | While truthy when checked at the end of an iteration, the loop exits early. Reset to `false` automatically at the start of each loop. |

## Outputs

| Port | Type | Description |
|---|---|---|
| item  | GameObject | The current item. Read this from nodes downstream of `body`. |
| index | Int        | The zero-based index of the current item. |
| count | Int        | Total number of items in `list`. Stable across iterations. |
| body  | Flow       | Kicks once per non-null item. Null items in the list are skipped silently. |

:::note Standard Flow output vs `body`
Foreach Game Object fires `body` once per non-null item. The standard `exit` fires **once**, after iteration completes (or after a `break`). Wire per-item logic to `body`, post-loop logic to `exit`.
:::

:::tip Breaking out
Connect a Bool source to `break` and set it to `true` from inside the body to abort the loop. The check happens at the end of each iteration, so the current iteration always finishes before the loop exits.
:::

## See also

- [For Loop](./for-loop) — counted integer iteration
- [Game Object List](/docs/Flow/Nodes/Variables/overview) — variable storing the list to iterate
