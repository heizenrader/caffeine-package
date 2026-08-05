---
sidebar_position: 0
sidebar_label: Overview
---

# Event Nodes

Event nodes are the entry points for any **Flow Graph**. They "kick" the Flow forward when something happens in the scene — a click, a frame update, a collision, a course step, or a custom signal raised from another graph. Every behavior you build in Flow starts at an event node.

Local event nodes share a common shape: an `Enabled` boolean port on the left that gates whether the event fires, and one or more Flow output ports on the right that kick connected nodes when the event triggers. Many events also have a **Net** counterpart (shown in purple) that fires on every player in a multiplayer session — see [Networking in Flow](/docs/Flow/flow-networking) for when to prefer one over the other.

:::tip Enabled port (local events only)
The green `Enabled` boolean port on the left of every local event node lets you turn the event on or off at runtime by wiring a variable into it. This is cleaner than disabling the whole graph when you only want to mute one event. Net event nodes don't have this port — gate downstream logic with a Branch on a graph variable instead.
:::

## Lifecycle

Standard MonoBehaviour-style lifecycle events on the host GameObject.

| Node | Description |
|---|---|
| [Awake](./awake)                       | Once — when the host GameObject is first awakened, before [Start](./start). |
| [Start](./start)                       | Once — before the first Update, after [Awake](./awake). |
| [On Enable](./on-enable)               | Each time the host GameObject becomes active. |
| [On Disable](./on-disable)             | Each time the host GameObject becomes inactive. |
| [On Destroy](./on-destroy)             | Once — when the host GameObject is destroyed. |
| [Update](./update)         | Every frame. |
| [Late Update](./late-update)           | Every frame, after all Update handlers. |
| [FixedUpdate](./fixed-update)          | Every fixed-physics tick. |
| [On Animator IK](./on-animator-ik)     | Every IK pass on a connected Animator. |
| [On Application Focus](./on-application-focus)           | The application regains focus (desktop tab back in, mobile foregrounded). |
| [On Application Lost Focus](./on-application-lost-focus) | The application loses focus (desktop tab away, mobile backgrounded). |

## Interaction

Scene-driven interaction events.

| Node | Description | Net |
|---|---|---|
| [Select Event](./select-event)         | Fires when the GameObject's collider is selected. | [Net version](./net-select-event) |
| [Trigger Event](./trigger-event)       | Fires on collider trigger enter / stay / exit. | [Net version](./net-trigger-event) |
| [Collision Event](./collision-event)   | Fires on physical collisions. | — |

## Networking lifecycle

Multiplayer session events.

| Node | Description |
|---|---|
| [Net OnPlayerEnter](./net-on-player-enter) | Fires on every existing client when a new player joins. |
| [Net OnPlayerExit](./net-on-player-exit)   | Fires on every remaining client when a player leaves. |

## Course

Step-driven events. Most are created from the course-step inspector (drag-from-step), not the Add Node menu.

| Node | Description |
|---|---|
| [On Step Loaded](./on-step-loaded)                                | Fires when a course step finishes loading. |
| [A-to-B Interaction End](./a-to-b-interaction-end)                | Fires when a step's A-to-B interaction ends. |
| [Course Click Interaction](./course-click-interaction)            | Fires when a step's click interaction triggers. |
| [Course Hold Interaction](./course-hold-interaction)              | Fires on hold-start / hold / hold-end of a step's hold interaction. |
| [Course Trigger Interaction](./course-trigger-interaction)        | Fires on trigger enter / stay / exit of a step's trigger interaction. |

## Save System

Documented under SaveSystem since they're tightly coupled with that subsystem:

| Node | Description |
|---|---|
| [Save System Load Event](/docs/Flow/Nodes/SaveSystem/on-save-system-load-event)   | Fires after a snapshot finishes loading. |
| [Save System Reset Event](/docs/Flow/Nodes/SaveSystem/on-save-system-reset-event) | Fires after the save store has been reset. |

## See also

- [Signals (raise / listen)](/docs/Flow/Nodes/Signals/overview) — cross-graph signals using Flow Event assets
- [Networking in Flow](/docs/Flow/flow-networking)
