---
sidebar_position: 0
sidebar_label: Overview
---

# System Nodes

System nodes expose engine-level and runtime utilities — current date and time for timestamping, plus performance toggles like foveated rendering.

Subgrouped by purpose:

- **[Time](./Time)** — current date / time getters in several forms (custom-formatted full clock, simple display variants).
- **[Performance](./Performance)** — runtime performance settings (currently: foveated rendering for VR).
- **[Experience](./Experience)** — runtime controls for the experience itself (pause / resume).

## Nodes

### Time

| Node | Description |
|---|---|
| [Current Time (Clock)](./Time/current-time)        | Configurable .NET-format clock with separate hour / minute / second / millisecond outputs. |
| [Simple Current Time](./Time/simple-current-time)  | Pre-formatted `h:mm AM/PM` time string. |
| [Simple Current Date](./Time/simple-current-date)  | Long-form date string (`October 25, 2026`). |

### Performance

| Node | Description |
|---|---|
| [Foveated Rendering](./Performance/foveated-rendering) | Set the foveated-rendering level of the active VR headset. |

### Experience

| Node | Description |
|---|---|
| [Pause Experience](./Experience/pause-experience)     | Pause the experience (`Time.timeScale = 0` + `AudioListener.pause = true`). |
| [Unpause Experience](./Experience/unpause-experience) | Resume a paused experience, restoring the cached `Time.timeScale` and `AudioListener.pause`. |
