---
sidebar_position: 3
---

# Start Interaction

Programmatically starts an interaction between an interactor (a hand, controller, or pointer) and a target GameObject. Use it when a Flow needs to force an interaction without the user actively grabbing — for example, auto-attaching an object to a hand at the start of a step.

**Category:** Action

:::note Editor menu path
Appears in the Add Node menu under `Flow/Actions/Interactables/Start Interaction`.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| target     | GameObject       | The GameObject hosting an interactable. Either an `EdXRInteractable` or `EdXRTouchInteractable` component must be present — the node no-ops otherwise. |
| interactor | EdXRInteractor   | The interactor that should "grab" the target (typically a hand, controller, or pointer reference). |

:::tip Pair with VR Player or Net Avatar to source the interactor
Wire the [VR Player](/docs/Flow/Nodes/Player/vr-player) node (with a hand `device`) or query a player's hand from [Net Avatar](/docs/Flow/Nodes/Player/net-avatar) into `interactor` to drive the interaction with a specific hand.
:::

## See also

- [End Interaction](./end-interaction) — release a forced interaction
- [Be Free](./be-free) — release without specifying an interactor
- [Is Interactable](./is-interactable)
