---
sidebar_position: 10
---

# Pulse Substance Compound Infusion

Starts a continuous infusion of a compound substance (blood, saline, packed RBCs) at a specified bag volume and rate. Use it for IV-fluid scenarios.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| bagVolume | Float | Total volume in the IV bag, in the units selected by `bagVolumeUnits`. |
| rate      | Float | Flow rate of the infusion, in the units selected by `rateUnits`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient         | EdXR_PulsePatient                 | The Pulse patient receiving the infusion. |
| CustomCompound  | Bool                              | When `true`, use the `Name` field. When `false`, pick from `substance`. |
| Name            | String                            | Custom compound name. |
| substance       | Enum&lt;CompoundSubstance&gt;     | One of the predefined compounds — `Blood`, `Saline`, `PackedRBC`. |
| bagVolumeUnits  | Enum&lt;EdXRVolumeUnits&gt;       | Units for `bagVolume` (L, mL, μL, dL, m³). |
| rateUnits       | Enum&lt;EdXRVolumePerTimeUnit&gt; | Units for `rate`. |

## See also

- [Pulse Substance Bolus](./pulse-substance-bolus)
- [Pulse Substance Infusion](./pulse-substance-infusion)
- [Pulse Hemorrage](./pulse-hemorrage)
