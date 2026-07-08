---
sidebar_position: 2
---

# Get Analytic

Reads an analytic's name and description without emitting an event. Use it to display analytic metadata in UI — e.g., a debug overlay showing what's being tracked, or end-of-course summary text describing what was measured.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| analyticName        | String | The configured analytic's name. |
| analyticDescription | String | The configured analytic's description. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| topic    | Topic    | The analytics topic. |
| analytic | Analytic | The specific analytic to query. |

## See also

- [Analytic](./analytic) — emit an analytics event
