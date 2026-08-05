---
sidebar_position: 6
---

# Pulse Start Airway Obstruction

Starts an airway obstruction on the Pulse patient at the specified severity (0 = clear, 1 = full obstruction). Use it to introduce respiratory-distress scenarios.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| severity | Float | Severity of the obstruction, 0–1. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient | EdXR_PulsePatient | The Pulse patient. |

:::tip Pair with Stop Airway Obstruction
For interventions where the user clears the airway during a step, kick [Pulse Stop Airway Obstruction](./pulse-stop-airway-obstruction) when the user successfully completes the intervention.
:::

## See also

- [Pulse Stop Airway Obstruction](./pulse-stop-airway-obstruction)
- [Pulse Hemorrage](./pulse-hemorrage)
