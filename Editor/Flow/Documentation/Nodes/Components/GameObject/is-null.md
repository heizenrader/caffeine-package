---
sidebar_position: 4
---

# Is Null

Returns `true` when the input GameObject is null. Use it to gate flows on whether a GameObject reference exists — empty Self, a Foreach iteration that hit a null entry, or a Get Component result for a missing component.

**Category:** Variable
**Kind:** Predicate

## Inputs

| Port | Type | Description |
|---|---|---|
| GameObject | GameObject | The GameObject to test. |

## Outputs

| Port | Type | Description |
|---|---|---|
| isNull | Bool | `true` when the input is null, `false` otherwise. |

## See also

- [Equal GameObjects](/docs/Flow/Nodes/Logic/equal-game-objects) — compare two GameObjects for identity
- [Branch](/docs/Flow/Nodes/Logic/branch) — gate flow on the result
