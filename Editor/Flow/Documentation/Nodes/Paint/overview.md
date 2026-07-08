---
sidebar_position: 0
sidebar_label: Overview
---

# Paint Nodes

Paint nodes operate on Caffeine's paintable-surface system — query how much of a surface has been painted, or clear it back to its initial state. Use them to drive completion logic for painting exercises and to reset state between attempts.

## Nodes

| Node | Description |
|---|---|
| [Clear Paint](./clear-paint)                | Reset a paintable surface to its initial unpainted state. |
| [Percentage Painted](./percentage-painted)  | Query the fraction of a paintable surface that has been painted, optionally filtered by channel. |

## See also

- [Comparison](/docs/Flow/Nodes/Logic/comparison) — compare percentage against a threshold to drive completion checks
