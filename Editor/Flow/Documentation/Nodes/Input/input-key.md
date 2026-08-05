---
sidebar_position: 1
---

# Input Key

Reads the state of a specific keyboard key — whether it's currently held, was just pressed this frame, or was just released. Use it to gate flows on keyboard input on PC builds.

**Category:** Variable
**Kind:** Predicate
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Input.GetKey.html)

## Outputs

| Port | Type | Description |
|---|---|---|
| outputValue | Bool | The result of the configured key check. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| input | Enum&lt;GetInput&gt; | `Get` — true while the key is held. `GetDown` — true only on the frame the key was first pressed. `GetUp` — true only on the frame the key was released. |
| key   | Enum&lt;KeyCode&gt;  | Which keyboard key to check. Includes letters, numbers, function keys, modifiers, arrow keys, and so on. |

:::tip Choose the right `input` mode
Use `GetDown` for actions that should fire once per press (toggle a UI panel, advance a step). Use `Get` for "while-held" effects (continuous movement, sustained sound). Use `GetUp` to commit a value when the user releases — useful for hold-to-charge mechanics.
:::

:::warning Polling, not events
Input Key reports the state at the moment of read — the result is only meaningful when read inside a per-frame flow (downstream of [Update](/docs/Flow/Nodes/Events/update)). Reading it from a one-shot event will catch only that one frame's state.
:::

## See also

- [Player Input](./player-input) — abstracted input that works for both VR controllers and 2D screen taps
- [Branch](/docs/Flow/Nodes/Logic/branch) — gate the flow on the result
- [Update](/docs/Flow/Nodes/Events/update)
