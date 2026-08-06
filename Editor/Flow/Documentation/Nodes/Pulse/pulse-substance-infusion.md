---
sidebar_position: 9
---

# Pulse Substance Infusion

Starts a continuous infusion of a substance into the Pulse patient at a specified rate and concentration. Used for drugs delivered over time (norepinephrine drip, propofol infusion, etc.).

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| concentration | Float | Concentration of the infused substance. |
| rate          | Float | Flow rate of the infusion, in the units selected by `rateUnits`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient            | EdXR_PulsePatient                 | The Pulse patient receiving the infusion. |
| CustomSubstance    | Bool                              | When `true`, use the `Name` field. When `false`, pick from `substance`. |
| Name               | String                            | Custom substance name. |
| substance          | Enum&lt;Substance&gt;             | One of the predefined substances. |
| concentrationUnits | Enum&lt;EdXRMassPerVolumeUnit&gt; | Units for `concentration`. |
| rateUnits          | Enum&lt;EdXRVolumePerTimeUnit&gt; | Units for `rate` (L/s, mL/s, L/min, m³/s, mL/min, mL/day). |

:::tip Stop an infusion by re-running with rate=0
Setting `rate` to 0 effectively stops the infusion. Wire a Comparison or Branch to a second instance of this node with `rate=0` connected if you need to programmatically halt a running infusion.
:::

## See also

- [Pulse Substance Bolus](./pulse-substance-bolus) — one-time push
- [Pulse Substance Compound Infusion](./pulse-substance-compound-infusion) — for blood, saline, packed RBC
