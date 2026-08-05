---
sidebar_position: 3
---

# Pulse Advance Time

Advances the Pulse simulation forward by a specified number of seconds. Use it to fast-forward through periods where no user interaction happens, or to step the simulation ahead by a controlled amount.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| time | Float | Seconds of simulated time to advance. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient | EdXR_PulsePatient | The Pulse patient to advance. |

## See also

- [Pulse Reset Simulation](./pulse-reset-simulation)
- [Pulse Data](./pulse-data) — read state after advancing
