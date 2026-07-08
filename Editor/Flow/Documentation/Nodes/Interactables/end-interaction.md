---
sidebar_position: 4
---

# End Interaction

Programmatically ends the interaction between an interactor and a target GameObject. The mirror of [Start Interaction](./start-interaction).

**Category:** Action

:::note Editor menu path
Appears in the Add Node menu under `Flow/Actions/Interactables/End Interaction`.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| target     | GameObject     | The GameObject hosting the interactable. The node no-ops if the target lacks an interactable component. |
| interactor | EdXRInteractor | The interactor that should release the target. |

:::tip End vs Be Free
End Interaction targets a *specific* interactor — use it when you know which hand or pointer is currently holding the object. [Be Free](./be-free) releases the interactable from *any* interactor without needing the reference.
:::

## See also

- [Start Interaction](./start-interaction)
- [Be Free](./be-free)
- [Is Being Held](./is-being-held)
