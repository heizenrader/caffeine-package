---
sidebar_position: 11.5
---

# On Application Focus

Fires every time the application **regains** focus — the player tabs back into the window on desktop, or brings the app back to the foreground on mobile.

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
| Flow | Flow | Kicks each time the application regains focus. |

:::tip Pair with On Application Lost Focus
Use this pair to "wake back up" your experience — resume audio, reset UI hover state, kick a re-fetch — when the user comes back after tabbing away or backgrounding the app.
:::

:::note Mobile background / foreground
On mobile, backgrounding the app fires [On Application Lost Focus](./on-application-lost-focus), and bringing it back fires this event. You don't need a separate mobile-specific event to cover both cases.
:::

## See also

- [On Application Lost Focus](./on-application-lost-focus)
- [Unpause Experience](/docs/Flow/Nodes/System/Experience/unpause-experience) — typical handler for this event when auto-pausing on focus loss
