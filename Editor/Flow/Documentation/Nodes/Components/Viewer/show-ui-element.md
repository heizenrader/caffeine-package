---
sidebar_position: 2
---

# Show UI Element

Brings back a piece of the viewer's on-screen chrome that a [Hide UI Element](./hide-ui-element) node had hidden, on the platform(s) you choose. Use it to restore the interface after an immersive sequence — for example, hiding the labels and camera buttons for a guided walkthrough, then showing them again when the learner regains control.

**Category:** Action

## Settings

| Setting | Options | Description |
|---|---|---|
| Platform | `All`, `Mobile`, `Desktop` | Which presentation to affect. Mobile and Desktop are tracked independently, so showing on `Mobile` leaves the desktop presentation as it was. |
| Element | `Camera Controls`, `Labels`, `AR Button`, `AI Button`, `Back Button` | Which piece of chrome to show. **Camera Controls** covers the whole camera cluster — the rotate/pan toggle, reset model, and the zoom buttons where the platform has them. |

## Inputs

None beyond the flow entry.

## Outputs

None beyond the flow exit.

:::note Show can't force-reveal a button
This node lifts *your* hide only. It never overrides the viewer's own reasons for hiding something — AR not supported on the device, no AI entitlement on the account, navigation disabled for the course, or a button that only appears in multiplayer. Showing one of those is a harmless no-op.
:::

:::tip Tablets use the Desktop UI
`Mobile` means the phone interface. Tablets — and the web player — present the desktop interface, so target `Desktop` (or `All`) to affect an iPad.
:::

Everything starts visible, so you only need this node to undo an earlier hide. It has no effect in VR, which doesn't have this chrome.

## See also

- [Hide UI Element](./hide-ui-element) — hide the same elements
- [Side Menu](./side-menu) — open or close the viewer's side menu
