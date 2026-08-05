---
sidebar_position: 4
---

# Pulse Arrythmia

Applies a heart-rhythm change to the Pulse patient — sinus, ventricular fibrillation, asystole, etc. The exact set of available rhythms is defined by the Pulse engine.

**Category:** Action

:::note Editor menu name
Appears in the Add Node menu as **"Pulse Arrythmia"** (matching the source spelling) under `Flow/Pulse/Actions/`.
:::

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| patient | EdXR_PulsePatient        | The Pulse patient to apply the rhythm to. |
| rythm   | Enum&lt;eHeartRhythm&gt; | The heart rhythm to set. See the Pulse engine documentation for what each value represents. |

## See also

- [Pulse Hemorrage](./pulse-hemorrage)
- [Pulse engine documentation ↗](https://pulse.kitware.com)
