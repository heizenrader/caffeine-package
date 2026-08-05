---
sidebar_position: 1
---

# Select Event

Fires when the user selects the GameObject's collider through any input method — mouse click on PC, laser select in VR, tap on mobile/tablet, or VR controller trigger when "touching" with the controller spheres.

**Category:** Event
**Component / Source:** Built-in (requires a collider on the GameObject)

## Inputs

| Port | Type | Description |
|---|---|---|
| collider | Collider | The collider whose selection should fire this event. If left unconnected, defaults to the collider configured on the inspector field. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks when the selection of the configured `eventType` is detected on the collider. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| eventType | Enum&lt;SelectEventType&gt; | Which selection moment to fire on: `OnSelectDown` (initial press), `OnSelectUp` (release), or `OnSelectHold` (continuous while held). Defaults to `OnSelectDown`. |

## Notes & gotchas

:::tip Choosing an eventType
Use `OnSelectDown` for instant reactions (button presses, picking up an object). Use `OnSelectUp` for confirmation gestures or to detect a click only after the user commits. Use `OnSelectHold` when an action should run for as long as the user keeps holding — note this fires repeatedly, so guard expensive work behind a state check.
:::

## See also

- [Net Select Event](./net-select-event)
- [Networking in Flow](/docs/Flow/flow-networking)
