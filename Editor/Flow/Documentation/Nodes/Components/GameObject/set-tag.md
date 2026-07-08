---
sidebar_position: 11
---

# Set Tag

Sets a Caffeine `EdXR_Tag` value on a GameObject. If the GameObject already has an `EdXR_Tag` component, its tag is overwritten; otherwise a new component is added.

**Category:** Action

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to tag. |
| newTag     | String     | The tag to set. |

:::note One tag per Set Tag call, but multiple tags per GameObject
Each Set Tag call overwrites the first `EdXR_Tag` it finds. To add a second tag without losing the first, you'd need a custom flow — Caffeine's tag system itself supports multiple tags per GameObject (see [Compare Tag](./compare-tag) which checks all of them).
:::

## See also

- [Get Tag](./get-tag)
- [Compare Tag](./compare-tag)
- [Remove Tag](./remove-tag)
