---
sidebar_position: 0
sidebar_label: Overview
---

# Component Nodes

These nodes are the **Component analog of the [GameObject list nodes](/docs/Flow/Nodes/Components/GameObject)**. Where [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component) fetches one component off a GameObject, [Get Components](./get-components) fetches *all* of them of a given type as a `List<Component>` — then you add, remove, get, count, and iterate that list the same way you would a GameObject list.

## How the list stays typed

A component list is a single generic `List<Component>` — one list type that any of these nodes can pass around and connect to each other. The **specific** type (Rigidbody, Collider, Image, …) is reattached only where you read an element out:

- [Get Component Item](./get-component-item) and [For Each Component](/docs/Flow/Nodes/Logic/for-each-component) each have a component dropdown and emit the element typed to your choice.

That typed output is what lets the element plug into [Get Component Property](/docs/Flow/Nodes/Utilities/get-component-property) / [Set Component Property](/docs/Flow/Nodes/Utilities/set-component-property), which read the **declared** type of the port feeding them. A plain `Component` would only expose `Component`'s own members, so the typed extraction is what makes per-element work useful.

The component dropdown offers the same set as [Get Component](/docs/Flow/Nodes/Components/GameObject/get-component): Transform, Rigidbody, Collider, Renderer, AudioSource, Light, Camera, Animator, ParticleSystem, RectTransform, TMP&nbsp;InputField, TMP&nbsp;Text, InputField, Image, VideoPlayer, EdXRInteractable.

## Nodes

| Node | Kind | Description |
|---|---|---|
| [Get Components](./get-components)                       | Variable | Every component of the chosen type on a GameObject, as a `List<Component>`. |
| [Get Component Item](./get-component-item)               | Variable | The element at an index, typed to the chosen component. |
| [Count Component Items](./count-component-items)         | Variable | How many components are in the list. |
| [Add Component Item](./add-component-item)               | Action   | Insert a component into the list at an index. |
| [Remove Component Item](./remove-component-item)         | Action   | Remove a component from the list by reference. |
| [Remove Component Item (Index)](./remove-component-item-index) | Action | Remove the component at an index. |

## See also

- [For Each Component](/docs/Flow/Nodes/Logic/for-each-component) — iterate the list, one typed element at a time
- [Component List](/docs/Flow/Nodes/Variables/component-list) — a mutable component list you populate and reuse
- [GameObject nodes](/docs/Flow/Nodes/Components/GameObject) — the GameObject equivalents these mirror
