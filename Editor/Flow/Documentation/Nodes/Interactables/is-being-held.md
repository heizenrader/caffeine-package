---
sidebar_position: 2
---

# Is Being Held

Returns `true` while the connected interactable is currently being held by a user (in VR — actively grabbed by a controller; on 2D — actively dragged or selected).

**Category:** Variable
**Kind:** Predicate

:::note Editor menu name
Appears in the Add Node menu as **"Interactable IsBeingHeld"** under `Flow/Actions/Interactables/`. Doc title uses "Is Being Held" for readability.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| interactable | EdXRInteractable | The interactable to query. |

## Outputs

| Port | Type | Description |
|---|---|---|
| isBeingHeld | Bool | `true` while the interactable is actively held; `false` when released or when the input is null. |

:::tip Drive per-frame "while held" effects
Wire `isBeingHeld` into a [Branch](/docs/Flow/Nodes/Logic/branch) downstream of an [Update](/docs/Flow/Nodes/Events/update) to run logic only while the user is holding the object — apply a glow, count hold time, or play a sustained sound.
:::

## See also

- [Is Interactable](./is-interactable)
- [Start Interaction](./start-interaction)
- [End Interaction](./end-interaction)
- [Be Free](./be-free)
