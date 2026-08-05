---
sidebar_position: 8
---

# Pulse Substance Bolus

Administers a one-time bolus dose of a substance to the Pulse patient — used for drugs given as a single push (epinephrine, fentanyl, naloxone, etc.).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| concentration | Float | Concentration of the substance, in the units selected by `concentrationUnits`. |
| dose          | Float | Volume of the dose, in the units selected by `doseVolumeUnits`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient             | EdXR_PulsePatient                                 | The Pulse patient receiving the bolus. |
| CustomSubstance     | Bool                                              | When `true`, use the `Name` field below. When `false`, pick from the `substance` enum. |
| Name                | String                                            | Custom substance name, used when `CustomSubstance` is `true`. |
| substance           | Enum&lt;Substance&gt;                             | One of the predefined substances (Epinephrine, Fentanyl, Ketamine, Morphine, Naloxone, Propofol, etc.). |
| concentrationUnits  | Enum&lt;EdXRMassPerVolumeUnit&gt;                 | Units for `concentration` (g/dL, mg/mL, μg/L, etc.). |
| doseVolumeUnits     | Enum&lt;EdXRVolumeUnits&gt;                       | Units for `dose` (L, mL, μL, dL, m³). |
| route               | Enum&lt;eSubstanceAdministration_Route&gt;        | Administration route — IV push, IM, intraosseous, etc. |

## See also

- [Pulse Substance Infusion](./pulse-substance-infusion) — continuous over time instead of one bolus
- [Pulse Substance Compound Infusion](./pulse-substance-compound-infusion) — compound substances (blood, saline, packed RBC)
