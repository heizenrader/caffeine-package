---
sidebar_position: 1
---

# Save System Save

Writes the current save state to a snapshot file and uploads it to the cloud. Use it to persist user progress at meaningful points — end of a step, mid-task checkpoints, or right before exiting the course.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| fileName | String | The file name to save under, when `quickSave` is `false`. Ignored when `quickSave` is `true`. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| quickSave | Bool | When `true`, the node saves to a default `auto_save` slot or overwrites the currently-loaded snapshot. When `false`, the node saves to the file specified in the `fileName` input. |

:::tip Auto-save vs explicit save
Quick-save is the simplest pattern — leave `quickSave = true` and the system handles the file name for you. Use the explicit form (with a connected `fileName`) when you want named save slots the user picks, or to checkpoint multiple distinct states of the same course.
:::

## See also

- [Save System Load](./load) — restore from a snapshot
- [Save System Reset](./reset) — clear save state
- [Save System Get Snapshots](./get-snapshots) — list available saves
- [Save System Value](./save-system-value) — read / write individual saved values
