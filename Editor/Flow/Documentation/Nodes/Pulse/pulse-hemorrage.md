---
sidebar_position: 5
---

# Pulse Hemorrage

Applies a hemorrhage to the Pulse patient — internal or external, at a specified body compartment, with rate or severity. Use it to introduce bleeding scenarios for clinical training.

**Category:** Action

:::note Editor menu name
Appears in the Add Node menu as **"Pulse Hemorrage"** (matching the source spelling) under `Flow/Pulse/Actions/`.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| rate     | Float | Bleeding rate, in the units selected by `rateUnits`. Used when `flowOrSeverity` is `Flow`. |
| severity | Float | Severity (0–1) of the hemorrhage. Used when `flowOrSeverity` is `Severity`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient             | EdXR_PulsePatient                       | The Pulse patient to apply the hemorrhage to. |
| type                | Enum&lt;eHemorrhage_Type&gt;            | `Internal` or `External` hemorrhage. |
| externalCompartment | Enum&lt;EdXRBodyExternalCompartment&gt; | Body region for external hemorrhage (RightArm, LeftArm, RightLeg, LeftLeg, Skin, Muscle, lungs, brain, kidneys, liver, etc.). Used when `type` is `External`. |
| internalCompartment | Enum&lt;EdXRBodyInternalCompartment&gt; | Body region for internal hemorrhage (kidneys, liver, spleen, splanchnic, intestines, aorta, vena cava). Used when `type` is `Internal`. |
| flowOrSeverity      | Enum&lt;EdXRFlowOrSeverity&gt;          | Whether to specify the bleed by flow rate or severity. |
| rateUnits           | Enum&lt;EdXRVolumePerTimeUnit&gt;       | Units for `rate` (L/s, mL/s, L/min, m³/s, mL/min, mL/day). |

## See also

- [Pulse Substance Bolus](./pulse-substance-bolus) — administer drugs
- [Pulse Substance Infusion](./pulse-substance-infusion)
- [Pulse Reset Simulation](./pulse-reset-simulation)
