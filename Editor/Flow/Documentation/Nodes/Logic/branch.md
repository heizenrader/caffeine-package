---
sidebar_position: 1
---

# Branch

Routes the Flow down one of two paths based on a Bool input — the classic if / else.

**Category:** Action
**Kind:** Control flow

## Inputs

| Port | Type | Description |
|---|---|---|
| condition | Bool | When `true`, `True` kicks. When `false`, `False` kicks. |

## Outputs

| Port | Type | Description |
|---|---|---|
| True  | Flow | Kicks when `condition` is `true`. |
| False | Flow | Kicks when `condition` is `false`. |

:::note Replaces standard Flow output
Branch does **not** fire its standard `exit` output. Exactly one of `True` / `False` kicks per run, replacing `exit`. Wire downstream logic from `True` or `False` — wiring `exit` on Branch produces no kick. See the [Action overview](/docs/Flow/Nodes/Components/overview#standard-flow-ports) for the augment-vs-replace convention.
:::

## See also

- [Conditionals](./conditionals) — branch on the AND of multiple bools
- [Switch](./switch) — branch on a string match against named cases
- [Comparison](./comparison) — produce the bool that feeds `condition`
- [Not](./not) — invert a bool before branching
