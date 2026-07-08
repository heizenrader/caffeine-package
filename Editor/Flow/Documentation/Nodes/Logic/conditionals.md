---
sidebar_position: 2
---

# Conditionals

Routes the Flow to `True` only when **every** connected Bool input is `true`. If any input is `false` or unconnected, routes to `False`. Behaves like a chained logical AND across an arbitrary number of conditions.

**Category:** Action
**Kind:** Control flow

## Inputs

| Port | Type | Description |
|---|---|---|
| conditionals | List&lt;Bool&gt; (dynamic) | Add one slot per condition you want to AND together. Connect each to a Bool source. An unconnected slot is treated as `false`, so don't leave gaps. |

## Outputs

| Port | Type | Description |
|---|---|---|
| True  | Flow | Kicks when **all** connected `conditionals` are `true`. |
| False | Flow | Kicks when any connected `conditional` is `false` (or any slot is unconnected). |

:::note Replaces standard Flow output
Conditionals does **not** fire its standard `exit` output. Exactly one of `True` / `False` kicks per run. Wire downstream logic from `True` or `False`. See the [Action overview](/docs/Flow/Nodes/Components/overview#standard-flow-ports).
:::

:::tip Only AND, not OR
Conditionals is hard-coded to logical AND. To OR multiple conditions, feed each into a [Comparison](./comparison) configured with the `Or` operator (Bool type), or chain a series of [Branches](./branch).
:::

## See also

- [Branch](./branch) — single-condition if/else
- [Comparison](./comparison) — produce a Bool from comparing two values
- [Not](./not) — invert any of the input bools
