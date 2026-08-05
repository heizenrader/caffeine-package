---
sidebar_position: 9
---

# Comparison

Compares two values of the same type and outputs a Bool result. The active type and operator are configured on the node's inspector — only the input pair matching the chosen type is shown.

**Category:** Variable
**Kind:** Operation (predicate)

## Inputs

| Port | Type | Description |
|---|---|---|
| A, B | Bool / Int / Long / Float / String / Vector2 / Vector3 / Vector4 / Quaternion / Color | The two values to compare. The visible input pair (e.g. `iA` / `iB` for Int, `fA` / `fB` for Float) is determined by the `type` inspector field. |

## Outputs

| Port | Type | Description |
|---|---|---|
| result | Bool | The comparison result. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| type     | Enum&lt;SerializedType&gt;     | Selects the input pair and the set of available operators. |
| Operator | Enum&lt;ComparisonOperator&gt; | The operation to perform. Available operators depend on `type` — see below. |

## Notes & gotchas

Available operators by type:

| Type            | Available operators |
|---|---|
| Bool            | And, Or, Equal |
| Int / Long      | GreaterThan, LessThan, Equal |
| Float           | GreaterThan, LessThan, Equal (uses `Mathf.Approximately` for Equal) |
| String          | Equal |
| Vector2 / 3 / 4 | Equal |
| Quaternion      | Equal |
| Color           | Equal |

:::warning Float Equal is approximate
For Float values, `Equal` calls `Mathf.Approximately(a, b)` to tolerate floating-point drift. Use `GreaterThan` / `LessThan` for strict ordering and avoid relying on `Equal` for derived float values that may have rounded.
:::

:::tip Wire `result` into Branch
The most common Comparison pattern is to wire `result` into a [Branch](./branch)'s `condition` input. For multi-condition AND, feed several Comparisons into a [Conditionals](./conditionals) node instead.
:::

## See also

- [Branch](./branch) — route flow on the Bool result
- [Conditionals](./conditionals) — AND multiple Bool results
- [Equal Objects](./equal-objects) / [Equal GameObjects](./equal-game-objects) — typed identity comparison for Unity references
- [Not](./not) — invert the result
