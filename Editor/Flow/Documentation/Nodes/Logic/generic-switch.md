---
sidebar_position: 4
---

# Generic Switch

Like [Switch](./switch), but the `Condition` input accepts an Int, Float, or String — the node detects the runtime type and matches each case label as the corresponding parsed value.

**Category:** Action
**Kind:** Control flow

:::note Menu name
This node appears in the editor's Add Node menu as **"Switch (Int, String, Float)"** under `Flow/Logic/`. Title here uses the shorter "Generic Switch" for readability.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| Condition | Object (Int / Float / String) | The value compared against each case label. Type is detected at runtime. If `null` or an unsupported type, `Default` kicks. |

## Outputs

| Port | Type | Description |
|---|---|---|
| CasesList | Flow (dynamic list) | One Flow port per case label. Labels are stored as strings and parsed at match time — `"42"` parses as `42` for Int conditions, `"3.14"` parses as `3.14` for Float. |
| Default   | Flow                | Kicks when no case label matches `Condition`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| CasesList | List&lt;String&gt; | Add a case label per entry. Labels are always stored as strings; their interpretation depends on the runtime type of `Condition`. |

:::note Standard Flow output vs case ports
Generic Switch fires the standard `exit` **first**, then the matched case port (or `Default`). Both fire on the same kick.
:::

:::warning Float comparison is exact, not approximate
Float case matching uses exact equality (`floatValue == (float)condition`), not `Mathf.Approximately`. Floating-point drift can cause unexpected misses — prefer Int or String for Switch keys when possible.
:::

## See also

- [Switch](./switch) — string-only variant
- [Comparison](./comparison) — emit a Bool from value comparisons
