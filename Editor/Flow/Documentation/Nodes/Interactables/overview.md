---
sidebar_position: 0
sidebar_label: Overview
---

# Interactable Nodes

Interactable nodes operate on Caffeine's interaction system — query whether a GameObject can be interacted with, programmatically start or end interactions, force a release, and check whether something is currently being held.

:::note Editor menu path
Interactable nodes appear in the Add Node menu under `Flow/Actions/Interactables/...`. They're grouped at the top level here in the docs because they form a coherent set of player-interaction primitives.
:::

## Nodes

**Querying state** (pure data — no Flow ports):

| Node | Description |
|---|---|
| [Is Interactable](./is-interactable)  | Does the target GameObject have an interactable component? |
| [Is Being Held](./is-being-held)      | Is the interactable currently held by a user? |

**Driving state** (action — standard Flow ports):

| Node | Description |
|---|---|
| [Start Interaction](./start-interaction) | Force an interactor to grab a target. |
| [End Interaction](./end-interaction)     | Release a specific interactor's hold on a target. |
| [Be Free](./be-free)                     | Release an interactable from whoever is holding it. |

## See also

- [VR Player](/docs/Flow/Nodes/Player/vr-player) — source for hand / pointer GameObjects to feed `interactor`
- [Branch](/docs/Flow/Nodes/Logic/branch) — gate flow on the predicate outputs
