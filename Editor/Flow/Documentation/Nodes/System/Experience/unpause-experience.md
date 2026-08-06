---
sidebar_position: 2
---

# Unpause Experience

Resumes a paused experience. Restores `Time.timeScale` and `AudioListener.pause` to the values they held at the moment [Pause Experience](./pause-experience) was last kicked.

Kicking Unpause Experience while the experience isn't paused is a no-op.

**Category:** Action
**Kind:** System control

:::tip Cached time scale is restored
If you set a non-default `Time.timeScale` (slow-motion sequence, fast-forward) before pausing, that exact value is restored on unpause — Unpause Experience doesn't reset you to `1`.
:::

:::tip Pair with On Application Focus
Wire [On Application Focus](/docs/Flow/Nodes/Events/on-application-focus) → Unpause Experience to automatically resume when the player returns to the window, paired with [Pause Experience](./pause-experience) on [On Application Lost Focus](/docs/Flow/Nodes/Events/on-application-lost-focus).
:::

## See also

- [Pause Experience](./pause-experience) — pause the experience
- [Is Experience Paused](/docs/Flow/Nodes/Logic/is-experience-paused) — read the current pause state
- [On Application Focus](/docs/Flow/Nodes/Events/on-application-focus) — typical driver for auto-resume
