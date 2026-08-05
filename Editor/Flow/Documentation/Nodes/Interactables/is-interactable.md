---
sidebar_position: 1
---

# Is Interactable

Returns `true` when the target GameObject has an interactable component attached (so the user can pick it up, click it, or otherwise interact with it through Caffeine's interaction system).

**Category:** Variable
**Kind:** Predicate

:::note Editor menu path
Appears in the Add Node menu under `Flow/Actions/Interactables/Is Interactable`. Documented here under the top-level Interactables category for discoverability.
:::

## Inputs

| Port | Type | Description |
|---|---|---|
| target | GameObject | The GameObject to check. |

## Outputs

| Port | Type | Description |
|---|---|---|
| isInteractable | Bool | `true` if the target has an interactable component, `false` otherwise (including when `target` is null). |

:::tip Cached per target
The result is cached per target GameObject — checking the same object repeatedly is cheap. Switching to a different target invalidates the cache automatically.
:::

## See also

- [Is Being Held](./is-being-held) — query whether an interactable is currently held
- [Start Interaction](./start-interaction)
- [End Interaction](./end-interaction)
- [Branch](/docs/Flow/Nodes/Logic/branch) — gate flow on the result
