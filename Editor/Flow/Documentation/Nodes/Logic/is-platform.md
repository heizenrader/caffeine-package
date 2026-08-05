---
sidebar_position: 13
---

# Is Platform

Returns `true` when the runtime matches the platform you query for. Use it to gate platform-specific logic — show touch UI only on phones, route a flow through hand-tracking only on VR, fall back to desktop input otherwise.

**Category:** Variable
**Kind:** Predicate

:::note Editor menu path
This node appears in the editor's Add Node menu under `Flow/Conditions/Is Platform`. It's grouped with other Logic nodes here in the docs.
:::

## Outputs

| Port | Type | Description |
|---|---|---|
| value | Bool | `true` when the current runtime matches `query`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| query | Enum&lt;PlatformQuery&gt; | Which platform to test for. One of `Desktop`, `Tablet`, `Phone`, `VR`. |

## How each query is decided

The four queries are mutually exclusive — exactly one of them is `true` for any given runtime.

| Query | When it returns `true` |
|---|---|
| **VR**      | The build is a VR build. This is a **build-time** decision — the runtime doesn't probe for a connected headset. |
| **Phone**   | Not VR, not desktop, and:<br/>• iOS — device model is **not** an iPad (i.e. iPhone / iPod / other iOS-class)<br/>• Android — the OS reports a small screen size (uses Google's standard phone/tablet boundary — the same one Android apps use for `layout-sw600dp/` resource qualifiers) |
| **Tablet**  | Not VR, not desktop, and:<br/>• iOS — device model contains `iPad`<br/>• Android — the OS reports a tablet-class screen size (same threshold as Phone, in the other direction) |
| **Desktop** | Not VR, and one of:<br/>• Running in the Unity Editor (always considered Desktop, even when a device-simulator window is faking the platform)<br/>• Windows / macOS / Linux standalone player<br/>• Anything else that isn't a Phone or Tablet (e.g. console, smart TV) |

:::note VR overrides everything
On a VR build, `Phone` / `Tablet` / `Desktop` all return `false` regardless of underlying OS. Use `VR` as your first branch when writing platform-conditional flows.
:::

:::note Android: OS-reported size, not DPI math
The Android phone/tablet split uses the size Android itself reports for the device — the same one Android apps use to pick layouts. It's more reliable than computing diagonal inches from screen DPI, because manufacturers often misreport DPI. If the lookup fails for any reason, Android defaults to Phone (the common case).
:::

:::tip Editor is always Desktop
Even with the device simulator window open faking an iPhone, `IsPlatform(Desktop)` still returns `true` in play mode. Content authors expect "editor == desktop" for flow authoring; test phone/tablet branches on real builds or in builds run on a phone/tablet device.
:::

:::tip Cached after first query
The result is cached per `query` value, so reading `value` repeatedly in a hot path is cheap. Changing `query` in the inspector invalidates the cache.
:::

## See also

- [Branch](./branch) — gate a flow on the result
- [Conditionals](./conditionals) — AND `IsPlatform(VR)` with another condition
- [Is Hand Tracking](/docs/Flow/Nodes/Input/is-hand-tracking) — VR-specific: is the player using hand tracking vs controllers
