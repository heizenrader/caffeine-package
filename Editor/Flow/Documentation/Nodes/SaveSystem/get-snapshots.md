---
sidebar_position: 5
---

# Save System Get Snapshots

Returns the list of saved snapshots available to the user. Wire it into a [Foreach](/docs/Flow/Nodes/Logic/foreach-game-object)-style iteration, a UI list, or pass an individual snapshot into [Save System Load](./load).

**Category:** Action / Variable

## Outputs

| Port | Type | Description |
|---|---|---|
| list | List&lt;SnapshotFile&gt; | All saved snapshots, ordered as the save system returns them. Each entry is a `SnapshotFile` with at least `path` and `name`. |

:::tip Sort by date for "most recent first"
The list comes back in the system's stored order. Wire it into a list-sort or filter flow if you want to display them in a specific order in the UI (e.g., newest first).
:::

## See also

- [Save System Load](./load) — load a specific snapshot from the list
- [Save System Get Loaded Snapshot](./get-loaded-snapshot) — get the one currently loaded, not the full list
- [Save System Save](./save)
