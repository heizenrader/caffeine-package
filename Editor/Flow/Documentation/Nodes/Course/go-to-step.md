---
sidebar_position: 3
---

# Go To Step

Jumps the course to a specific step. Use it whenever a Flow Graph decides it's time to move on — after a correct answer, when a timed sequence finishes, or from a custom navigation button.

**Category:** Action

## Target

Pick the target step from the inspector dropdown — the binding is stored automatically on the node and survives step reordering.

:::note Multiplayer
In a multiplayer session, step changes follow the same rule as objective-driven jumps: the host drives the step for the room. If the node fires on a non-host client, that client's jump is ignored and everyone stays on the host's step.
:::

:::tip Delay before jumping
Need a pause before the jump (to let narration or an animation finish)? Wire a [Delay](/docs/Flow/Nodes/Components/General/delay) in front: `Delay` → Go To Step.
:::

:::warning Don't jump from an unconditional On Step Loaded flow
Jumping re-fires [On Step Loaded](/docs/Flow/Nodes/Events/on-step-loaded) on the destination step. An On Step Loaded flow that *unconditionally* calls Go To Step therefore loops forever — always gate it with a [Branch](/docs/Flow/Nodes/Logic/branch) or a one-shot variable.
:::

## See also

- [On Step Loaded](/docs/Flow/Nodes/Events/on-step-loaded) — react on the destination step after the jump
- [Objective Completion](./objective-completion) — objectives can also change steps when configured to
