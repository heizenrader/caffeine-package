---
sidebar_position: 6
---

# Local Variable

A typed value stored directly on the node — `Bool`, `Int`, `Long`, `Float`, `String`, `Vector2`, `Vector3`, `Vector4`, `Quaternion`, or `Color`. The value lives on this node only; two Local Variable nodes don't share state.

**Category:** Variable
**Kind:** Variable accessor (local scope)

## Behavior

Pick a **Type** in the inspector. The matching input and output pair becomes active in the editor — for example, when `Type = Float`, the `inputFloatValue` input and `floatValue` output are the ones the editor renders. When the node runs (kicked from upstream Flow), the value at the active input is written to the stored value. The active output emits the stored value to downstream nodes.

## Inputs

The `inputXxxValue` port matching `Type` (e.g. `inputBoolValue` for Bool, `inputVector3Value` for Vector3). Wire a same-typed source — when connected, it's written on each kick; when unconnected, the inspector default is written instead.

## Outputs

The `xxxValue` port matching `Type` (e.g. `boolValue`, `vector3Value`). Reads the stored value on demand.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| Type  | Enum&lt;SerializedType&gt; | Selects which input / output pair is active and which storage slot is used. |
| value | Typed                      | The currently stored value. Edit it directly in the inspector to set a default; runtime kicks of this node will overwrite it. |

:::tip One Local Variable per logical value
Local Variables don't share state. If two parts of your graph need to read the same value, either store it once in a [Graph Variable](./graph-variable) (graph scope) and drag it where needed, or wire one Local Variable's output into both consumers.
:::

:::note Asset menu duplicate
The `EdXR_Variable` class also defines an asset-creation entry (`Caffeine/Flow/Variables/Global Variable`) that creates a global variable asset. That asset is consumed by [Global Variable](./global-variable), not by this node — Local Variable always stores its value in-place.
:::

## See also

- [Net Variable](./net-variable) — networked counterpart that replicates writes to all players
- [Global Variable](./global-variable) — same shape, but stored in an external asset
- [Graph Variable](./graph-variable) — same shape, scoped to the graph
