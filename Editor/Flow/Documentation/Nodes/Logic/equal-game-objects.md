---
sidebar_position: 12
---

# Equal GameObjects

Compares two GameObject references for identity — outputs `true` when both inputs reference the same GameObject.

**Category:** Variable
**Kind:** Operation (predicate)

## Inputs

| Port | Type | Description |
|---|---|---|
| objectA | GameObject | The first reference. |
| objectB | GameObject | The second reference. |

## Outputs

| Port | Type | Description |
|---|---|---|
| equal | Bool | `true` when both inputs reference the same GameObject. `false` when they differ or when either is `null`. |

:::note Use this over Equal Objects for GameObject inputs
The typed GameObject variant rejects mismatched types at port-connection time, catching wiring errors earlier. Use [Equal Objects](./equal-objects) only when one of the inputs may be a non-GameObject reference (Material, Texture, Component).
:::

## See also

- [Equal Objects](./equal-objects) — generic Unity object identity check
- [Comparison](./comparison) — value-based comparison for primitives and structs
