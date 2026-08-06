---
sidebar_position: 4
---

# Cast (Type Cast)

Converts a value from one type to another — Bool ↔ Int, Float ↔ String, Vector2 ↔ Vector3, etc. Use it when a node needs a typed input that doesn't match the source's type.

**Category:** Variable
**Kind:** Operation

:::note Editor menu name
Appears as **"Type Cast"** under `Flow/Actions/`.
:::

## Behavior

Pick an `InputType` and an `OutputType` in the inspector. The matching input pair becomes active in the editor; the output emits the converted value on demand.

## Inputs

The `inputXxxValue` port matching `InputType`.

## Outputs

The `xxxValue` port matching `OutputType`.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| InputType  | Enum&lt;SerializedType&gt; | Type of the source value. |
| OutputType | Enum&lt;SerializedType&gt; | Type of the converted result. |

## Notes & gotchas

Not every conversion makes sense. The table below summarizes what happens for each combination.

| Input → Output | Behavior |
|---|---|
| Numeric → Numeric (Int / Float / Long) | Standard numeric conversion (Int 5 → Float 5.0, Float 3.7 → Int 3 truncated). |
| Bool → Int / Long | `true → 1`, `false → 0`. |
| Bool → Float | Always 0 (no useful conversion). |
| String → Int / Float / Long | `TryParse` — falls back to 0 if the string isn't parseable. |
| Anything → String | Unity's default `ToString()` representation. |
| Vector2 ↔ Vector3 ↔ Vector4 | Components carry over; missing components default to 0. |
| Vector3 → Color | RGB from x, y, z; alpha = 1 (Unity's `Color(r,g,b)` default). |
| Vector4 → Color | RGBA componentwise. |
| Quaternion → other | No useful conversion (returns default). |

:::warning Many casts return defaults
Casts between unrelated types (Vector2 → Quaternion, Color → Int) return the default value of the output type, not an error. Verify your output makes sense before relying on it.
:::

## See also

- [Comparison](/docs/Flow/Nodes/Logic/comparison) — type-specific value comparisons
- [Format String](./format-string) — for converting values to formatted strings
