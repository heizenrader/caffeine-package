---
sidebar_position: 0
sidebar_label: Overview
---

# Logic Nodes

Logic nodes shape how the Flow moves through your graph — branching on conditions, looping over collections, comparing values, and routing to one of several paths. They don't act on the scene; they decide which downstream nodes get kicked.

Most Logic nodes are Action / Updatable — they have a Flow input and one or more Flow outputs. A handful are pure data (Comparison, Not, Equal Objects, Equal GameObjects, Is Platform): they emit a Bool you wire into a [Branch](./branch) or [Conditionals](./conditionals).

:::note Standard Flow ports + augment-vs-replace
Logic Action nodes follow the [standard Flow port convention](/docs/Flow/Nodes/Components/overview) — implicit `entry` / `exit` not listed per page. **Read the per-page admonition** before wiring: some Logic nodes (Branch, Conditionals) **replace** `exit` with their named ports, while others (Switch, For Loop, Foreach, Split Flow, Timed Kick) **augment** it. Wiring from `exit` on a "replace" node produces no kick.
:::

## Branching

Decide which downstream path runs based on a condition.

| Node | Description |
|---|---|
| [Branch](./branch)                     | Two-way if/else on a Bool. Replaces `exit`. |
| [Conditionals](./conditionals)         | Logical AND across an arbitrary list of Bools. Replaces `exit`. |
| [Switch](./switch)                     | Route to a named case based on a String. Augments `exit`. |
| [Generic Switch](./generic-switch)     | Same shape as Switch, accepts Int / Float / String. Augments `exit`. |
| [Split Flow](./split-flow)             | Kick several downstream paths from one input, in list order. Augments `exit`. |

## Looping

Iterate over a counter or a collection.

| Node | Description |
|---|---|
| [For Loop](./for-loop)                       | Counted integer iteration with `index` output. |
| [Foreach Game Object](./foreach-game-object) | Iterate a `List<GameObject>`. Can break early. |
| [For Each Component](./for-each-component)   | Iterate a `List<Component>`, exposing each element typed to a chosen component. |
| [Timed Kick](./timed-kick)                   | Repeated kicks at a configurable interval, either forever or N times. |

## Comparisons & predicates

Pure data — emit a Bool you wire into a Branch or Conditionals.

| Node | Description |
|---|---|
| [Comparison](./comparison)                 | Compare two typed values (Int, Float, Vector3, etc.) with an operator. |
| [Not](./not)                               | Invert a Bool. |
| [Equal Objects](./equal-objects)           | Identity check for two `UnityEngine.Object` references. |
| [Equal GameObjects](./equal-game-objects)  | Typed identity check for two GameObject references. |
| [Is Platform](./is-platform)               | Check the runtime platform (Desktop / Tablet / Phone / VR). |
| [Is Experience Paused](./is-experience-paused) | `true` while the experience is paused by Pause Experience. |

## See also

- [Variables](/docs/Flow/flow-variables) — sources of values to compare and conditions to branch on
- [Components overview](/docs/Flow/Nodes/Components/overview) — standard Flow port convention plus augment-vs-replace pattern for additional outputs
