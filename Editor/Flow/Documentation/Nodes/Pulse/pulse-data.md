---
sidebar_position: 1
---

# Pulse Data

Reads the latest value of a specific physiological data field from the connected Pulse patient — heart rate, blood pressure, oxygen saturation, respiratory rate, etc. Each Pulse Data node targets one field; add multiple to read multiple values.

**Category:** Variable
**Kind:** Property

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Float | The most recent value of the configured data field, optionally scaled by `multiplier`. Returns 0 when the patient has no data yet. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient    | EdXR_PulsePatient | The Pulse patient component to read from. |
| multiplier | Float             | Scales the raw value before output. Defaults to 1. Useful for unit conversions. |

Pick the physiological field to read from the inspector dropdown — the binding is stored automatically on the node.

:::tip Drive UI from Pulse Data
Wire the `value` output into a TextMeshPro setter on a UI label, refreshed on a per-frame [Update](/docs/Flow/Nodes/Events/update), to display live patient vitals during a simulation.
:::

## See also

- [Pulse Advance Time](./pulse-advance-time)
- [Pulse Reset Simulation](./pulse-reset-simulation)
- [Pulse engine documentation ↗](https://pulse.kitware.com)
