---
sidebar_position: 0
sidebar_label: Overview
---

# Save System Nodes

Save System nodes read, write, and manage persistent save state for the current course or session. Use them to persist user progress, restore previous answers, list available saves, and react to load / reset transitions.

The Save System operates on a **store** of typed key-value entries. Each entry has a name, an ID, and a typed value (Bool, Int, Float, String, Vector2/3/4, Quaternion, Color, Long). Snapshots are full copies of the store written to disk and uploaded to the cloud.

:::note Editor menu paths
Save System action nodes appear under `Flow/Actions/SaveSystem/...`; the two events appear under `Flow/Events/...`. They're grouped under SaveSystem here in the docs because they form a cohesive feature.
:::

## Nodes

**Snapshot management:**

| Node | Description |
|---|---|
| [Save](./save)                                    | Write the current state to a snapshot file (auto or named). |
| [Load](./load)                                    | Restore state from a snapshot (most-recent or specified). |
| [Reset](./reset)                                  | Clear the save store back to defaults. |
| [Get Snapshots](./get-snapshots)                  | List all available snapshots. |
| [Get Loaded Snapshot](./get-loaded-snapshot)      | Get the snapshot the active session was loaded from (or `null` for a fresh session). |

**Per-value access:**

| Node | Description |
|---|---|
| [Save System Value](./save-system-value)          | Read or write a single typed value in the current store, picked by name from a dropdown. |

**Events:**

| Node | Description |
|---|---|
| [Save System Load Event](./on-save-system-load-event)   | Fires after a snapshot has finished loading. |
| [Save System Reset Event](./on-save-system-reset-event) | Fires after the store has been reset. |

## See also

- [Local Variable](/docs/Flow/Nodes/Variables/local-variable) — non-persistent in-graph alternative for short-lived values
- [Comparison](/docs/Flow/Nodes/Logic/comparison) — compare loaded values to drive flow decisions
