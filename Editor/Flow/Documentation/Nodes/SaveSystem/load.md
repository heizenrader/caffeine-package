---
sidebar_position: 2
---

# Save System Load

Restores save state from a snapshot file. Use it to resume the user where they left off, or to load a specific save slot the user has selected.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| snapshotFile | SnapshotFile | The snapshot to load, when `quickLoad` is `false`. Connect from a [Save System Get Snapshots](./get-snapshots) iteration or a UI selection. |

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| quickLoad | Bool | When `true`, loads the **most recent** snapshot automatically. When `false`, loads from the connected `snapshotFile` input. |

:::tip Quick-load for resume, explicit load for selection
Use `quickLoad = true` for "continue where I left off" entry points. Use `quickLoad = false` when the user has chosen a specific save from a list — pair with [Save System Get Snapshots](./get-snapshots) and a UI selection step.
:::

:::note Triggers the Load Event
A successful load fires the [Save System Load Event](./on-save-system-load-event) — wire any post-load setup off that event so it runs whether the load was quick or explicit.
:::

## See also

- [Save System Save](./save)
- [Save System Get Snapshots](./get-snapshots)
- [Save System Load Event](./on-save-system-load-event)
