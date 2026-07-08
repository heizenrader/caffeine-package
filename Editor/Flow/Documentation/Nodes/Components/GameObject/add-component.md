---
sidebar_position: 1
---

# Add Component

Adds a new component of the configured type to a GameObject and returns a reference to it. Use it to attach a Rigidbody, Animator, Renderer, or any other supported Unity component at runtime.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/GameObject.AddComponent.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to add the component to. |

## Outputs

The output port matching the configured `component` enum is the active one — wire it to nodes that take that component type.

| Port | Type | Description |
|---|---|---|
| transform / rigidbody / collider / renderer / audioSource / light / camera / animator / particleSystem / rectTransform / TMPInputField / TMPText / inputField / image / videoPlayer / edXRInteractable | (matching component) | Reference to the newly-added component. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| component | Enum&lt;UnityComponents&gt; | Which component to add. Supported: `Transform`, `Rigidbody`, `Collider`, `Renderer`, `AudioSource`, `Light`, `Camera`, `Animator`, `ParticleSystem`, `RectTransform`, `TMP_InputField`, `TMP_Text`, `InputField`, `Image`, `VideoPlayer`, `EdXRInteractable`. |

:::tip Pair with Set Component Property
After adding a component, wire its output through a Set Component Property flow to configure it (set Rigidbody mass, AudioSource clip, Light intensity, etc.) before using it.
:::

## See also

- [Get Component](./get-component) — fetch an existing component instead of adding one
- [Destroy](./destroy)
