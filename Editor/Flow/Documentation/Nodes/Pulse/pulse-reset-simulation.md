---
sidebar_position: 2
---

# Pulse Reset Simulation

Resets the connected Pulse patient back to its initial state — clears any active actions (hemorrhage, infusions, airway obstruction, arrhythmia) and reverts physiological values to baseline.

**Category:** Action

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient | EdXR_PulsePatient | The Pulse patient to reset. |

:::tip Reset between exercises
Use Reset Simulation when the user retries a clinical scenario or moves to a different scenario in the same session — gives them a fresh patient without reloading the scene.
:::

## See also

- [Pulse Advance Time](./pulse-advance-time)
- [Pulse Arrythmia](./pulse-arrythmia)
- [Pulse Hemorrage](./pulse-hemorrage)
