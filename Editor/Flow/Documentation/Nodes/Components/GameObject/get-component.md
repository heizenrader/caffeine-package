---
sidebar_position: 2
---

# Get Component

Fetches a component of the configured type from a GameObject. Use it to grab a Rigidbody, Renderer, Audio Source, etc. so you can wire it into nodes that operate on that component.

**Category:** Variable
**Kind:** Property
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to query. |

## Outputs

The output port matching the configured `component` enum is the active one.

| Port | Type | Description |
|---|---|---|
| transform / rigidbody / collider / renderer / audioSource / light / camera / animator / particleSystem / rectTransform / TMPInputField / TMPText / inputField / image / videoPlayer / edXRInteractable | (matching component) | The component reference, or `null` if the GameObject doesn't have one. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| component | Enum&lt;UnityComponents&gt; | Which component to fetch. Same set as [Add Component](./add-component). |

:::tip Cached automatically
The result is cached per (gameObject, component) pair — repeated reads are cheap. The cache invalidates automatically when you swap the input GameObject or change the component type.
:::

:::tip Handles missing components gracefully
If the GameObject doesn't have the requested component, the output is `null`. Branch on that before using — wire through [Comparison](/docs/Flow/Nodes/Logic/comparison) for `null` checks.
:::

## See also

- [Add Component](./add-component) — add a component if missing
- [GameObject from Component](./game-object-from-component) — go the other direction
- [Set Component Property](/docs/Flow/Nodes/Components/General/overview)
