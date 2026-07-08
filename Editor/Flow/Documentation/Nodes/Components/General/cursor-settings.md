---
sidebar_position: 7
---

# Cursor Settings

Configures the system cursor — visibility and lock mode. Use it to hide the cursor during gameplay, lock it to the center of the screen for camera control, or restore it for menus.

**Category:** Action
**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Cursor.html)

## Inputs

| Port | Type | Description |
|---|---|---|
| visible | Bool | Whether the cursor should be visible. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| lockMode | Enum&lt;CursorLockMode&gt; | `None` — cursor moves freely. `Confined` — cursor stays inside the game window. `Locked` — cursor locked to the center of the window (typical for free-look camera). |

:::tip Match cursor state to context
A typical pattern: lock + hide during gameplay, unlock + show for menus and dialogs. Wire Cursor Settings into the Flow that drives those state transitions.
:::

## See also

- [Mouse Position](/docs/Flow/Nodes/Input/mouse-position)
- [Mouse Delta](/docs/Flow/Nodes/Input/mouse-delta)
