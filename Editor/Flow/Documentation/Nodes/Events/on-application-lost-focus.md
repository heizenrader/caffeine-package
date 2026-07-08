---
sidebar_position: 11.6
---

# On Application Lost Focus

Fires every time the application **loses** focus — the player tabs away from the window on desktop, or sends the app to the background on mobile.

**Category:** Event (Lifecycle)
**Component / Source:** Built-in
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Application-focusChanged.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| Enabled | Bool | When `false`, the event will not fire. Defaults to `true`. |

## Outputs

| Port | Type | Description |
|---|---|---|
| Flow | Flow | Kicks each time the application loses focus. |

:::tip Auto-pause when the player tabs away
Wire this event's Flow output into [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience) to automatically pause when the player leaves the window, and [On Application Focus](./on-application-focus) into [Unpause Experience](/docs/Flow/Nodes/System/Experience/unpause-experience) to resume on return.
:::

:::note Mobile background / foreground
On mobile, backgrounding the app fires this event; bringing it back fires [On Application Focus](./on-application-focus). The single `Application.focusChanged` callback Unity surfaces covers both desktop and mobile.
:::

## See also

- [On Application Focus](./on-application-focus)
- [Pause Experience](/docs/Flow/Nodes/System/Experience/pause-experience) — typical handler for this event when auto-pausing on focus loss
