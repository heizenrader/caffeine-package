---
sidebar_position: 1
---

# Pause Experience

Pauses the experience. Sets `Time.timeScale` to `0` (freezing physics, animations, and anything driven by scaled time) and `AudioListener.pause` to `true` (muting every `AudioSource` that doesn't opt out of listener pause).

The values held before pausing are cached and restored by [Unpause Experience](./unpause-experience) — an experience already running at a non-default time scale resumes at that scale, not at `1`.

Kicking Pause Experience while the experience is already paused is a no-op (the cached values are not overwritten with the current zeroed-out ones).

**Category:** Action
**Kind:** System control

## Effects while paused

| Subsystem | What happens |
|---|---|
| Time | `Time.timeScale = 0`. Scaled `Time.deltaTime`-based logic (most Flow timing, including [Delay](/docs/Flow/Nodes/Components/General/delay)) halts. |
| Audio | `AudioListener.pause = true`. Every `AudioSource` pauses unless its mixer group has "Ignore Listener Pause" enabled — useful for UI sounds that should keep playing through a pause. |
| Per-frame Flow events | [Update](/docs/Flow/Nodes/Events/update), [Late Update](/docs/Flow/Nodes/Events/late-update), and [FixedUpdate](/docs/Flow/Nodes/Events/fixed-update) stop kicking. |
| Other events | Lifecycle, interaction, course, and signal events keep firing. Branch on [Is Experience Paused](/docs/Flow/Nodes/Logic/is-experience-paused) inside their handlers if you want them to skip work during pause. |

:::tip Auto-pause on focus loss
Wire [On Application Lost Focus](/docs/Flow/Nodes/Events/on-application-lost-focus) → Pause Experience to pause automatically when the player tabs away, and [On Application Focus](/docs/Flow/Nodes/Events/on-application-focus) → [Unpause Experience](./unpause-experience) to resume on return.
:::

:::note Course progression isn't paused
Pausing doesn't stop the course's own step timing or progression — only Unity-level time and audio. If your course step depends on `Time.timeScale`-driven progress, it'll halt; otherwise it keeps running. Branch on Is Experience Paused inside step logic if you need full course-level pause.
:::

## See also

- [Unpause Experience](./unpause-experience) — resume the experience
- [Is Experience Paused](/docs/Flow/Nodes/Logic/is-experience-paused) — read the current pause state
- [On Application Lost Focus](/docs/Flow/Nodes/Events/on-application-lost-focus) — typical driver for auto-pause
