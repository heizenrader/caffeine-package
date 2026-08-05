---
sidebar_position: 9
---

# Unity Event

Invokes a UnityEvent configured on the node's inspector. Use it to bridge Flow into existing UnityEvent-driven UI (Button.onClick, Toggle.onValueChanged, etc.) or any code that subscribes to UnityEvents.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html)

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| unityEvent | UnityEvent | The event to invoke. Configure target objects, methods, and arguments in the inspector exactly as you would for a Button or any other UnityEvent-using component. |

:::tip Bridge between Flow and prefab callbacks
A common use: existing prefabs use UnityEvents to expose hookable callbacks. Wire those events to your Flow Graph by adding a Unity Event node in the graph, then in the prefab's UnityEvent inspector, target the graph's runtime entry point.
:::

## See also

- [Raise Flow Event](/docs/Flow/Nodes/Signals/raise-flow-event) — for cross-graph signaling within Flow
