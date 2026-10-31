---
sidebar_position: 3
---

# Hide UI Element

Hides a piece of the viewer's on-screen chrome on the platform(s) you choose — the camera controls, the labels button, the AR button, the AI button, or the Back button. Use it to strip the interface down for a focused or cinematic moment, or to tailor the presentation per device: labels can be hidden on a phone where screen space is tight while staying available on desktop.

**Category:** Action

## Settings

| Setting | Options | Description |
|---|---|---|
| Platform | `All`, `Mobile`, `Desktop` | Which presentation to affect. Mobile and Desktop are tracked independently, so hiding on `Mobile` leaves the desktop presentation untouched. |
| Element | `Camera Controls`, `Labels`, `AR Button`, `AI Button`, `Back Button` | Which piece of chrome to hide. **Camera Controls** covers the whole camera cluster — the rotate/pan toggle, reset model, and the zoom buttons where the platform has them. |

## Inputs

None beyond the flow entry.

## Outputs

None beyond the flow exit.

:::tip Hiding everything hides the menu
On phones, the camera, labels and AR buttons live in a collapsible utility tray. Once nothing in that tray is left visible, the tray and its handle disappear too, rather than leaving an empty tab on screen. In a multiplayer course the tray keeps showing the Players button, which isn't author-controllable.
:::

:::note Hiding a button doesn't disable the feature
Hiding the AR button doesn't turn AR off — an [Enable AR](../AR/enable-ar) node still works. This node only controls what the learner can see and tap.
:::

:::tip Tablets use the Desktop UI
`Mobile` means the phone interface. Tablets — and the web player — present the desktop interface, so target `Desktop` (or `All`) to affect an iPad.
:::

The setting lasts for the rest of the course session, or until a [Show UI Element](./show-ui-element) node brings it back. It has no effect in VR, which doesn't have this chrome.

## See also

- [Show UI Element](./show-ui-element) — bring the same elements back
- [Side Menu](./side-menu) — open or close the viewer's side menu
