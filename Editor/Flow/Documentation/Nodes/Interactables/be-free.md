---
sidebar_position: 5
---

# Be Free

Releases an interactable from whoever is currently holding it. Use it as a generic "drop / release" action when you don't have (or don't need) a specific interactor reference.

**Category:** Action

:::note Editor menu path
Appears in the Add Node menu under `Flow/Actions/Interactables/Be Free`.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| interactable | EdXRInteractable | The interactable to release. The node no-ops if `null`. |

:::tip Be Free vs End Interaction
Be Free releases regardless of who's holding — simpler when you just want the object dropped. [End Interaction](./end-interaction) requires a specific interactor and only releases that one.
:::

## See also

- [End Interaction](./end-interaction)
- [Is Being Held](./is-being-held)
- [Start Interaction](./start-interaction)
