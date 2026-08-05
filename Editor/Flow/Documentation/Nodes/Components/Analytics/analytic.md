---
sidebar_position: 1
---

# Analytic

Emits an analytics event with a typed value. Use it to log user behavior — answer correctness, time spent on a step, exploration choices — to Caffeine's analytics pipeline.

**Category:** Action

## Inputs

The active typed input matches the configured `analytic`'s expected type:

| Port | Type | Description |
|---|---|---|
| intValue    | Int    | Used when the analytic expects an integer. |
| floatValue  | Float  | Used when the analytic expects a float. |
| boolValue   | Bool   | Used when the analytic expects a boolean. |
| stringValue | String | Used when the analytic expects a string. |

## Outputs

| Port | Type | Description |
|---|---|---|
| analyticName        | String | The configured analytic's name. |
| analyticDescription | String | The configured analytic's description. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| topic    | Topic    | The analytics topic this event belongs to. |
| analytic | Analytic | The specific analytic event to emit. Selects which input port is the active one (based on the analytic's configured value type). |

:::tip Author analytics from data, not code
Configure `topic` and `analytic` in the inspector — those resources define the metric names, descriptions, and value types. The Flow Graph's job is to fire the event at the right time with the right value.
:::

## See also

- [Get Analytic](./get-analytic) — read an analytic's name / description without firing
