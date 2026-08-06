---
sidebar_position: 14
---

# Is Experience Paused

Returns `true` when the experience is currently paused by [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience). Use it to branch on pause state — show a pause overlay, gate user input, or skip non-essential work while paused.

**Category:** Variable
**Kind:** Predicate

:::note Editor menu path
This node appears in the editor's Add Node menu under `Flow/Conditions/Is Experience Paused`. It's grouped with other Logic nodes here in the docs.
:::

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Bool | `true` while the experience is paused, `false` otherwise. |

## See also

- [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience) / [Unpause Experience](/docs/Flow/Nodes/System/Experience/unpause-experience) — drive the paused state from a Flow
- [Branch](./branch) — gate a Flow on the result
