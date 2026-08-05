---
sidebar_position: 6
---

# Save System Get Loaded Snapshot

Returns the snapshot file currently loaded — the source of all values reads in the active session. Use it to display "Continuing: &lt;save name&gt;" or to confirm which save the user is currently progressing.

**Category:** Variable
**Kind:** Property

:::note Editor menu name
Appears in the Add Node menu as **"Save System Get Loaded Snapshot File"** under `Flow/Actions/SaveSystem/`. Doc title shortened for readability.
:::

## Outputs

| Port | Type | Description |
|---|---|---|
| snapshotFile | SnapshotFile | The currently-loaded snapshot, or `null` when the active store is the default (no snapshot loaded). |
| name         | String       | The snapshot's display name, or `null` when no snapshot is loaded. |
| path         | String       | The snapshot's file path, or `null` when no snapshot is loaded. |

:::tip Branch to handle "no save loaded"
On a fresh session before any [Save System Load](./load), the outputs return `null`. Branch on `name == null` (or check via [Comparison](/docs/Flow/Nodes/Logic/comparison)) to display a "Start new course" UI versus "Continue: &lt;name&gt;".
:::

## See also

- [Save System Get Snapshots](./get-snapshots) — list all snapshots, not just the current one
- [Save System Load](./load)
