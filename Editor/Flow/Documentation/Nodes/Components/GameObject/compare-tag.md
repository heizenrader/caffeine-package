---
sidebar_position: 12
---

# Compare Tag

Returns `true` when a GameObject carries the specified Caffeine tag (matches against any `EdXR_Tag` component on the GameObject — multiple tags supported).

**Category:** Variable
**Kind:** Predicate

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to test. |
| Tag        | String     | The tag value to compare against. |

## Outputs

| Port | Type | Description |
|---|---|---|
| equal | Bool | `true` when any of the GameObject's `EdXR_Tag` components has a matching tag value. |

:::tip Use for typed object filtering
Compare Tag is the cleanest way to ask "is this the kind of thing I want?" — wire it from a Foreach iteration or Trigger Event's `otherGameObject` to filter only objects of interest.
:::

## See also

- [Get Tag](./get-tag)
- [Set Tag](./set-tag)
- [Remove Tag](./remove-tag)
- [Branch](/docs/Flow/Nodes/Logic/branch)
