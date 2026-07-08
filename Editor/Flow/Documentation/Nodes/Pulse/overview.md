---
sidebar_position: 0
sidebar_label: Overview
---

# Pulse Nodes

Pulse nodes integrate Caffeine with the [Pulse Physiology Engine ↗](https://pulse.kitware.com) — query simulated patient state (heart rate, blood pressure, oxygen saturation, etc.) and apply medical actions (administer drugs, induce hemorrhage, change rhythm, advance time). Used in clinical training scenarios.

:::note Domain-specific
These nodes only function when a `EdXR_PulsePatient` is active in the scene. Most non-medical courses won't use this category.
:::

All Pulse action nodes follow the same shape: an `EdXR_PulsePatient` reference on the inspector, plus a set of typed inputs and inspector enums that configure the action. The Pulse engine documentation is the authoritative reference for medical semantics — this doc covers wiring.

## Nodes

**Reading state:**

| Node | Description |
|---|---|
| [Pulse Data](./pulse-data) | Read a single physiological data field from a patient (HR, BP, SpO2, etc.). |

**Time / state control:**

| Node | Description |
|---|---|
| [Pulse Reset Simulation](./pulse-reset-simulation) | Reset the patient to baseline. |
| [Pulse Advance Time](./pulse-advance-time)         | Advance the simulation by N seconds. |

**Cardiovascular:**

| Node | Description |
|---|---|
| [Pulse Arrythmia](./pulse-arrythmia)   | Apply a heart-rhythm change. |
| [Pulse Hemorrage](./pulse-hemorrage)   | Apply internal or external bleeding by rate or severity. |

**Respiratory:**

| Node | Description |
|---|---|
| [Pulse Start Airway Obstruction](./pulse-start-airway-obstruction) | Begin an airway obstruction at a given severity. |
| [Pulse Stop Airway Obstruction](./pulse-stop-airway-obstruction)   | Clear the airway. |

**Substance administration:**

| Node | Description |
|---|---|
| [Pulse Substance Bolus](./pulse-substance-bolus)                       | One-time bolus dose. |
| [Pulse Substance Infusion](./pulse-substance-infusion)                 | Continuous drug infusion. |
| [Pulse Substance Compound Infusion](./pulse-substance-compound-infusion) | IV fluid (blood, saline, packed RBC). |

## See also

- [Pulse engine documentation ↗](https://pulse.kitware.com) — medical semantics for each parameter and rhythm / substance
