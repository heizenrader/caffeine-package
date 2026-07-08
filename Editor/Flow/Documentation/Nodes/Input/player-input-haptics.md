---
sidebar_position: 6
---

# Player Input Haptics (XR)

Fires a haptic vibration on one of the active player's VR controllers. Use it for tactile feedback — confirming a button press, signalling a near miss, or pulsing during a sustained interaction.

**Category:** Action

:::note VR builds only
This node has no effect on PC or mobile builds — kicking it on non-VR is a safe no-op. The haptic is delivered by whatever VR runtime the player is using.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| frequency | Float | Vibration frequency. Higher values = a sharper buzz. |
| duration  | Float | Length of the haptic pulse, in seconds. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| hand | Enum&lt;Handedness&gt; | Which hand's controller should vibrate. |

:::tip Short pulses for confirmation
A short sub-100ms pulse at high frequency reads as a "click" or confirmation. Longer durations (300ms+) read as alerts or "something happened" cues. Tune with quick playtests on your target headset — perceived intensity differs by device.
:::

## See also

- [Player Input](./player-input) — read VR controller button state
- [VR Player](/docs/Flow/Nodes/Player/vr-player) — controller / hand GameObject reference
