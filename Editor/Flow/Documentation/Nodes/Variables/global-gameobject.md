---
sidebar_position: 5
---

# Global GameObject

Reads or writes a **Global GameObject** asset (`Caffeine/Flow/Variables/Global GameObject`). The asset stores the GameObject reference outside the graph, so multiple graphs and nodes can share and mutate the same value.

**Category:** Variable
**Kind:** Variable accessor (global scope)

## Inputs

| Port | Type | Description |
|---|---|---|
| inputGameObject | GameObject | When connected, the connected value is written to the asset on each kick. When unconnected, the inspector default is written. |

## Outputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The current value of the wrapped asset. Reads the asset at delegate time, so it always reflects the latest writes. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| gameObjectVariable | Global GameObject asset | The external asset whose value this node reads / writes. Create the asset via `Assets > Create > Caffeine > Flow > Variables > Global GameObject`. |
| inputGameObject    | GameObject              | Default value used when the input port is unconnected. |

:::tip Creating the asset
Right-click in the Project window → `Create > Caffeine > Flow > Variables > Global GameObject`. Drop the same asset onto the `gameObjectVariable` field of every node that should share the reference.
:::

## See also

- [GameObject](./gameobject) — local-scope variant
- [Self](./self) — the GameObject hosting the graph
- [Global Variable](./global-variable) — typed (non-GameObject) global variable
