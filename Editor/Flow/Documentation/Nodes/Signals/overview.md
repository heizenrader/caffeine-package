---
sidebar_position: 0
sidebar_label: Overview
---

# Signals (Cross-Graph Events)

Signal nodes connect Flow Graphs to each other rather than acting on the scene. They're how one graph announces something and any number of other graphs react — without direct port connections between them. If you've used Unity Signals, Godot signals, or UE event dispatchers, this is the same pattern.

The pattern is **raise / listen**:
- A **Flow Event** is a ScriptableObject asset (`Assets > Create > Caffeine > Flow > NodeEvent...`). It's the shared identifier — the thing both sides bind to.
- A **Raise Flow Event** node in any graph broadcasts the signal.
- Any number of **Flow Event Listener** nodes (in any graph) bound to the same asset fire when the signal is raised.

:::note Why these are called "Flow Events"
The asset type and node names use the term **Flow Event** — that's the source-of-truth name in the editor. In the docs we group them as **Signals** to make the cross-graph signalling intent obvious and to avoid confusion with the scene-driven events under [Events](/docs/Flow/Nodes/Events/overview). The two patterns are distinct:
- **Events** — fire when something happens *in the scene* (Update, Trigger, Click, Step Loaded).
- **Signals** — fire when *another graph raises them*. No scene involvement.
:::

## Three payload flavors

Pick the variant that matches what (if anything) you need to send along with the signal.

| Payload | Raise node | Listen node |
|---|---|---|
| **None** — just the signal | [Raise Flow Event](./raise-flow-event)                       | [Flow Event Listener](./flow-event-listener)                       |
| **GameObject**             | [Raise Flow Event GameObject](./raise-flow-event-game-object) | [Flow Event GameObject Listener](./flow-event-game-object-listener) |
| **Typed value**            | [Raise Flow Event Variable](./raise-flow-event-variable)      | [Flow Event Variable Listener](./flow-event-variable-listener)     |

Typed-value payloads support Bool / Int / Float / String / Vector2/3/4 / Quaternion / Color / Long — the same set as graph variables.

:::tip One asset, many listeners
Each Flow Event asset is one signal channel. Drop multiple [Flow Event Listener] nodes (in the same graph or across graphs) bound to the same asset, and they all fire when any raiser kicks. The raiser doesn't know or care who's listening — that's the whole point.
:::

:::tip Signals vs Variables
Reach for a signal when something **happened** (a one-shot announcement). Reach for a [Graph Variable](/docs/Flow/Nodes/Variables/graph-variable) / [Global Variable](/docs/Flow/Nodes/Variables/global-variable) when something **is** (shared state). They compose: raise a signal "score changed", and the listener reads the current score from a global variable.
:::

## See also

- [Events](/docs/Flow/Nodes/Events/overview) — scene-driven events (lifecycle, interactions, course)
- [Variables](/docs/Flow/Nodes/Variables/overview) — for shared state instead of one-shot signals
- [Networking in Flow](/docs/Flow/flow-networking) — for cross-client signalling, see Net events / Net variables
