---
sidebar_position: 10
---

# Mobile Joystick Button

Returns whether one of the on-screen joystick's face buttons is pressed, held, or released. Each stick has four buttons — A / B / C / D on the right stick, X / Y / Z / W on the left.

**Category:** Variable
**Kind:** Predicate

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Bool | The result of the configured button check. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| joystick | Enum&lt;Joystick&gt; | Which stick's buttons to read — `Left` or `Right`. |
| rightButton / leftButton | Enum | Which face button to check. The editor shows `rightButton` (`A` / `B` / `C` / `D`) when `joystick` is `Right`, and `leftButton` (`X` / `Y` / `Z` / `W`) when it's `Left`. |
| input | Enum&lt;InputType&gt; | `Down` — true on the frame the button is pressed. `Hold` — true while held. `Up` — true on the frame it's released. |

:::warning Polling, not events
Like the other input nodes, this reports the button state at the moment of read. Read it inside a per-frame flow (downstream of [Update](/docs/Flow/Nodes/Events/update)) so `Down` / `Up` transitions aren't missed.
:::

## See also

- [Mobile Joystick](./mobile-joystick) — read a stick's axis
- [Mobile Joystick Active](./mobile-joystick-active) — check whether the joysticks are shown
- [Player Input](./player-input) — VR controller / screen button check with the same `Down` / `Hold` / `Up` phases
