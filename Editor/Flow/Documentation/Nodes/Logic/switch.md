---
sidebar_position: 3
---

# Switch

Routes the Flow to one of N named case ports based on a string `Condition`. If no case matches the string, routes to `Default`.

**Category:** Action
**Kind:** Control flow

## Inputs

| Port | Type | Description |
|---|---|---|
| Condition | String | The value compared against each case. If empty or `null`, `Default` kicks. |

## Outputs

| Port | Type | Description |
|---|---|---|
| CasesList | Flow (dynamic list) | One Flow port per case label you add in the inspector. The matching case kicks when `Condition` equals its label. |
| Default   | Flow                | Kicks when no case label matches `Condition`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| CasesList | List&lt;String&gt; | Add an entry per case. Each label becomes a Flow output port — wire from the port that matches the value you're switching on. Duplicate labels are tolerated; the first match wins. |

:::note Standard Flow output vs case ports
Switch fires the standard `exit` **first**, then the matched case port (or `Default`). Both fire on the same kick. Wire from `exit` for "regardless of case", from a specific case port for "only when this case matches", or from `Default` for the fallback.
:::

## See also

- [Generic Switch](./generic-switch) — same pattern but accepts Int / Float / String conditions
- [Branch](./branch) — two-way bool branch
- [Conditionals](./conditionals) — AND multiple conditions before branching
