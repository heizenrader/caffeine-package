---
sidebar_position: 2
---

# Get SnapshotFile Item

Returns the SnapshotFile at a specific index in a `List<SnapshotFile>`. Pair with [Save System Get Snapshots](/docs/Flow/Nodes/SaveSystem/get-snapshots) and [Save System Load](/docs/Flow/Nodes/SaveSystem/load) to load a specific entry from the saved-snapshots list.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| list  | List&lt;SnapshotFile&gt; | The list to read from. |
| index | Int                       | Zero-based index. |

## Outputs

| Port | Type | Description |
|---|---|---|
| item | SnapshotFile | The snapshot at `index`, or `null` if out of range or list is unconnected. |

## See also

- [Save System Get Snapshots](/docs/Flow/Nodes/SaveSystem/get-snapshots)
- [Save System Load](/docs/Flow/Nodes/SaveSystem/load)
- [Count SnapshotFile Items](./count-snapshot-file-items)
