---
sidebar_position: 1
---

# Math Operator

Performs a basic arithmetic operation (`+`, `-`, `×`, `÷`, `%`) on two values of a configurable type. Pick the type in the inspector and only the matching input pair is shown.

**Category:** Variable
**Kind:** Operation

## Behavior

Pick a **type** in the inspector. The matching input pair (e.g. `a` / `b` for Float, `vector3A` / `vector3B` for Vector3) becomes active in the editor. Pick an **operator** — `Add`, `Substract`, `Multiplication`, `Division`, `Modulo`. The output emits the result on demand.

## Inputs

The `<type>A` and `<type>B` ports matching the configured `type`. Same shape as [Comparison](/docs/Flow/Nodes/Logic/comparison) — only the relevant pair is rendered.

## Outputs

The `<type>Output` port matching the configured `type`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| type     | Enum&lt;SerializedType&gt; | Which input/output pair is active. Supported: `Bool`, `Int`, `Long`, `Float`, `String`, `Vector2`, `Vector3`, `Vector4`, `Quaternion`, `Color`. |
| Operator | Enum&lt;MathOperator&gt;   | Which operation to perform. |

## Operator support by type

Not every operator is meaningful for every type — the table shows which combinations produce useful results.

| Type        | Add (`+`)         | Substract (`-`)            | Multiplication (`*`)               | Division (`/`)                   | Modulo (`%`)               |
|---|---|---|---|---|---|
| Float       | a + b             | a − b                      | a × b                              | a / b                            | a % b                      |
| Int / Long  | a + b             | a − b                      | a × b                              | a / b (integer divide)           | a % b                      |
| Bool        | `a OR b`          | `a AND NOT b`              | `a AND b`                          | `false`                          | `false`                    |
| String      | concatenate       | replace `b` in `a` with "" | concatenate                        | `""`                             | `""`                       |
| Vector2/3/4 | a + b             | a − b                      | componentwise multiply              | componentwise divide              | componentwise modulo        |
| Quaternion  | (no-op)           | (no-op)                    | quaternion multiply (rotation compose) | componentwise divide          | componentwise modulo        |
| Color       | a + b             | a − b                      | a × b                              | componentwise divide              | componentwise modulo        |

:::tip Pick the right type
Setting `type` to a high-level type like Vector3 or Color gives you the right shape automatically — no need to pull components apart, perform the op, and rebuild. For string concatenation, use `String + Add`; for string-replace, use `String + Substract`.
:::

:::warning Bool operator semantics are non-standard
The Bool mappings (Add → OR, Subtract → A AND NOT B, Multiplication → AND) are convenience semantics, not strict logic. For straightforward boolean logic, prefer [Conditionals](/docs/Flow/Nodes/Logic/conditionals) (logical AND) or [Not](/docs/Flow/Nodes/Logic/not).
:::

## See also

- [Comparison](/docs/Flow/Nodes/Logic/comparison)
- [Mathf](/docs/Flow/Nodes/Math/Mathf/overview), [Vector3](/docs/Flow/Nodes/Math/Vector3/overview) — codegen wrappers for specific Unity API methods
