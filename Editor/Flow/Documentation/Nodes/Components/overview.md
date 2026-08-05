---
sidebar_position: 0
sidebar_label: Overview
---

# Component Nodes

Nodes here are grouped by what they touch. Most subfolders map to a Unity component (Rigidbody, AudioSource, Animator, Light, etc.) and hold the nodes that act on or query that component. A few subfolders group **Caffeine subsystems** (XR, Analytics, Viewer) or **non-component utilities** (General for engine-level Actions, Lists for typed-list operations) that fit the same pattern of "nodes that work on a specific thing" but aren't strictly Unity components.

## Two kinds of nodes inside each subfolder

Every per-node page has a `**Kind:**` field in its meta block — that's the source of truth. The two kinds you'll see:

- **Action** — performs an effect when the Flow reaches it. Has standard Flow ports (a Flow input on the top-left to kick the action, and a Flow output named `exit` on the top-right to continue the graph). Example: `Rigidbody AddForce`, `AudioSource Play`, `Add Component`.
- **Variable** (pure data) — reads or computes a value. **No Flow ports** — wire its data output into whatever needs the value. Example: `Get Component`, `Get Children`, `Is Null`.

Both kinds live side-by-side in the same component subfolder because creators looking for "what can I do with a GameObject" want the actions and the queries together. The Kind field on each page tells you whether you're looking at an action or a query.

## Standard Flow ports

*Applies to Action nodes only — pure-data Variable nodes have no Flow ports.*

Action nodes share a common shape: a Flow input port on the top-left, and a Flow output port (`exit`) on the top-right.

![action-node](/img/flow/action-node.png)

To avoid clutter, individual Action pages do **not** list the standard input/`exit` in their Inputs/Outputs tables. Assume:

- Every Action has a standard Flow input that kicks the action when reached.
- Every Action has a standard Flow output (`exit`) that kicks **immediately** after the action runs.

Per-node docs only list *additional* Flow outputs — extra exec ports beyond `exit`. Each affected page includes a `:::note Standard Flow output` admonition; read it before wiring. Additional Flow outputs come in two flavors:

**Augment** — `exit` still fires when the action runs, and the named outputs fire later or conditionally on top:
- [TTS](/docs/Flow/Nodes/Voice/tts) `speakComplete` — fires when the spoken phrase finishes (after `exit`).
- [Voice Dictation](/docs/Flow/Nodes/Voice/voice-dictation) `partialTranscription` / `fullTranscription` — fire as the recognizer reports interim and final transcripts.
- [For Loop](/docs/Flow/Nodes/Logic/for-loop) `body` — fires once per iteration; `exit` fires once after the loop completes.
- [Switch](/docs/Flow/Nodes/Logic/switch) case ports + `Default` — `exit` fires first, then the matched case (or `Default`).
- [Split Flow](/docs/Flow/Nodes/Logic/split-flow) — kicks every connected split port in list order, then fires `exit` last.

**Replace** — `exit` does **not** fire; one of the named ports fires instead:
- [Branch](/docs/Flow/Nodes/Logic/branch) `True` / `False` — exactly one fires based on the input bool.
- [Conditionals](/docs/Flow/Nodes/Logic/conditionals) `True` / `False` — `True` fires only if all connected conditions are true (logical AND).

Wiring `exit` on a "replace"-pattern node produces no kick — wire from one of the named ports.

Variable (pure-data) nodes have none of the above — no Flow input, no `exit`. Wire their typed data output directly into whatever consumes the value.

## Subcategories

**Unity components.** One subfolder per Unity component — the nodes inside act on or query an instance of that component.

| Subfolder | Typical contents |
|---|---|
| [Animator](./Animator/overview)             | Play, set trigger, set bool/int/float parameters, crossfade. |
| [AudioSource](./AudioSource/overview)       | Play, stop, pause, set clip, set volume. |
| [Camera](./Camera/overview)                 | Set field of view, target, culling. |
| [Collider](./Collider/overview)             | Closest-point queries; get/set shape properties (size, radius, center, trigger…); test collider type. |
| [GameObject](/docs/Flow/Nodes/Components/GameObject) | Add / get component, get children, set active, instantiate, destroy, parenting, tag queries, null check. Mix of Actions and Variable queries. |
| [Light](./Light/overview)                   | Set intensity, color, range, enable/disable. |
| [Material](./Material/overview)             | Get/set material, set color, set property, enable/disable shader keyword. |
| [ParticleSystem](./ParticleSystem/overview) | Play, stop, emit. |
| [Physics](./Physics/physics-raycast)        | Scene-physics queries (Raycast). Unity static API rather than a component, but lives here for proximity. |
| [Renderer](./Renderer/overview)             | Set material, set color, enable/disable. |
| [Rigidbody](./Rigidbody/overview)           | Add force, MovePosition, set velocity, sleep/wake. Plus point-velocity queries. |
| [Transform](./Transform/overview)           | Set position/rotation/scale, translate, rotate, look at. |
| [VideoPlayer](./VideoPlayer/overview)       | Play, pause, set clip, seek. |

**Caffeine subsystems.** Grouped here because they follow the same "operate on a specific thing" pattern even though they aren't Unity components.

| Subfolder | Typical contents |
|---|---|
| [Analytics](/docs/Flow/Nodes/Components/Analytics) | Emit analytic events from a Flow Graph. |
| [AR](./AR/overview)                                | Turn the viewer's augmented-reality mode on/off and check whether it's active. |
| [Viewer](/docs/Flow/Nodes/Components/Viewer)       | Side-menu and viewer-shell control. |
| [XR](/docs/Flow/Nodes/Components/XR)               | XR-rig and runtime hooks. |

**Non-component utilities.** Groupings of related nodes that don't bind to any single component or subsystem.

| Subfolder | Typical contents |
|---|---|
| [General](./General/overview)       | Engine-level Actions — Debug Log, Delay, Cursor Settings, Unity Event, Rotate, Translate, Lerp variants. |
| [Component](./Component/overview)   | Get all components of a type off a GameObject as a list, then add / remove / get / count items. The Component analog of the GameObject list nodes; pairs with For Each Component and Component List. |
| [Lists](./Lists/overview)           | Add, remove, count, get-by-index for typed lists (GameObject, String, SnapshotFile). |
| [String](./String/overview)         | Length, contains, substring, to-lower. Pure-data string utilities. |

:::note Net variants
Many actions have a Net counterpart that runs on every player in a multiplayer session. They live alongside their local counterparts in each component subcategory and are styled in purple. See [Networking in Flow](/docs/Flow/flow-networking).
:::

:::tip Looking for type conversion, vector construction, or generic property access?
Those are pure-data utilities — see [Utilities](/docs/Flow/Nodes/Utilities/overview) for Cast, Create Vector, Format String, Get Axis, and the generic Get/Set Property family.
:::

## See also

- [Utilities](/docs/Flow/Nodes/Utilities/overview) — pure-data helpers (type conversion, value construction, property access)
- [Math](/docs/Flow/Nodes/Math/overview) — value-type math (Vector / Quaternion / Mathf / Color)
- [Networking in Flow](/docs/Flow/flow-networking)
