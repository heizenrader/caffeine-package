---
sidebar_position: 4
---

# Save System Value

Reads or writes a single typed value in the current save store, identified by a key the inspector lets you pick from the available save fields. Same typed shape as [Local Variable](/docs/Flow/Nodes/Variables/local-variable) — the type of the chosen key determines which input / output pair is active.

**Category:** Action / Variable

## Behavior

The inspector lets you select an entry from the active save store by name. The matching typed input / output pair becomes active in the editor — for example, if the selected entry is `score : Int`, the `inputIntValue` input and `intValue` output are the ones the editor renders. When the node runs, the typed input is written to the store; the typed output reads the current stored value on demand.

## Inputs

The `inputXxxValue` port matching the selected entry's type.

## Outputs

The `xxxValue` port matching the selected entry's type.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| (selected entry) | (typed) | A dropdown lists all entries available in the current save store. Picking one binds the node to that entry; the binding is stored automatically. |

:::tip Read in events, write in flows
For displaying saved values (UI labels, conditional content), wire the typed output. For updating saved values (after a step completes, when the user picks an option), kick the node from the appropriate flow with the typed input connected.
:::

:::warning Requires a current store
The node logs a warning and does nothing when no save store is loaded. Make sure a [Save System Load](./load) (or fresh save) has run before any flow that reads / writes values.
:::

## See also

- [Save System Save](./save) — persist all current values
- [Save System Load](./load) — restore values from a snapshot
- [Local Variable](/docs/Flow/Nodes/Variables/local-variable) — same shape but stored on the node
