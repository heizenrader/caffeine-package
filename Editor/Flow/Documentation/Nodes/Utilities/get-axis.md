---
sidebar_position: 8
---

# Get Axis

Returns one component (X, Y, or Z) of a Vector3 as a Float. Use it to pull a single axis out of a position, direction, or accumulated motion.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| vector | Vector3 | The Vector3 to read from. |

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Float | The selected axis component. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| axis | Enum&lt;VectorAxis&gt; | Which component to return — `X`, `Y`, or `Z`. |

:::tip Use multiple Get Axis nodes for unpacking
To split one Vector3 into three Floats, use three Get Axis nodes — one per axis. Pair with [Create Vector3](./create-vector-3) to rebuild after modifying one component.
:::

## See also

- [Create Vector3](./create-vector-3)
- [Vector3 nodes](/docs/Flow/Nodes/Math/Vector3/overview)
