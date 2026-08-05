---
sidebar_position: 10
---

# Get Tag

Returns the first Caffeine `EdXR_Tag` value on a GameObject, or empty string if none. Caffeine tags are managed via the `EdXR_Tag` component — distinct from Unity's built-in tag system, and a GameObject can carry multiple at once.

**Category:** Variable
**Kind:** Property

## Inputs

| Port | Type | Description |
|---|---|---|
| gameObject | GameObject | The GameObject to read the tag from. |

## Outputs

| Port | Type | Description |
|---|---|---|
| tag | String | The first tag found on the GameObject, or `""` if there's no `EdXR_Tag` component. |

:::tip Caffeine tags vs Unity tags
Caffeine's tag system uses `EdXR_Tag` components, allowing multiple tags per GameObject. Unity's built-in `gameObject.tag` is a single string. Get Tag here reads the Caffeine tag — for the Unity tag, use [Get Property](/docs/Flow/Nodes/Utilities/get-property) on the `tag` field.
:::

## See also

- [Set Tag](./set-tag)
- [Compare Tag](./compare-tag)
- [Remove Tag](./remove-tag)
