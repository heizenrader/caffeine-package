---
sidebar_position: 1
---

# Debug Log

Logs a message to the Unity console (`Debug.Log`). Use it to print runtime values, mark when a flow runs, or annotate complex sequences during development.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Debug.Log.html)

:::note Editor menu name
Appears as **"Debug.Log"** under `Flow/Actions/`.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| message | Object | Value to log. Can be any type — converted to string via `ToString()`. When unconnected, the inspector `messageStr` field is used instead. |
| context | Object | Optional Unity Object that the log line links back to. Click the log entry in the console to ping the linked object. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| messageStr | String (multiline) | Default text to log when the `message` input is unconnected. |

:::tip Format strings for richer output
For dynamic logs that interpolate variables, pair this with [Format String](/docs/Flow/Nodes/Utilities/format-string) — wire `Format String`'s output into Debug Log's `message` to log a templated string with current values.
:::

## See also

- [Format String](/docs/Flow/Nodes/Utilities/format-string)
