---
sidebar_position: 0
sidebar_label: Overview
---

# Utility Nodes

Utility nodes are engine-level helpers that don't bind to a specific Unity component — type conversion, value construction, string interpolation, axis access, and the generic property reader / writer family. Most are **pure-data** nodes (no Flow ports), wired straight into whatever consumes their output; the Set* variants are Actions that pair with a Get* counterpart.

:::note Mixed Action / Variable kinds
Like the [Components](/docs/Flow/Nodes/Components/overview) section, this folder holds both Action and Variable (pure-data) nodes. Each per-node page's `**Kind:**` field tells you which — Action nodes have implicit Flow ports per the [standard convention](/docs/Flow/Nodes/Components/overview#standard-flow-ports); Variable nodes have no Flow ports.
:::

## Type conversion & construction

| Node | Kind | Description |
|---|---|---|
| [Cast](./cast)                       | Variable (Operation)   | Convert a value from one type to another — Bool ↔ Int, Float ↔ String, Vector2 ↔ Vector3, etc. |
| [Create Vector2](./create-vector-2)  | Variable (Constructor) | Build a Vector2 from two Float inputs. |
| [Create Vector3](./create-vector-3)  | Variable (Constructor) | Build a Vector3 from three Float inputs. |
| [Get Axis](./get-axis)               | Variable (Property)    | Pull one component (X / Y / Z) of a Vector3 as a Float. |

## String formatting

| Node | Kind | Description |
|---|---|---|
| [Format String](./format-string) | Variable (Operation) | Interpolate values into a `String.Format`-style template with `{0}`, `{1}`, ... placeholders. |

## Property access — Get / Set

The Get / Set property family uses Unity reflection to read or write a property on a target by name. Pick a `Type` in the inspector, configure the target object + property path, and the matching typed port becomes active.

| Get node | Set counterpart | Target shape | Notes |
|---|---|---|---|
| [Get Property](./get-property)                       | [Set Property](./set-property)                       | Inspector-configured GameObject + property path | Most flexible — the picker walks the GameObject's components to find any property. |
| [Get GameObject Property](./get-gameobject-property) | [Set GameObject Property](./set-gameobject-property) | GameObject wired via input port                  | Use when the target GameObject varies at runtime. |
| [Get Component Property](./get-component-property)   | [Set Component Property](./set-component-property)   | Component wired via input port                   | Use when you've already obtained a component reference (e.g. via Get Component). |
| [Get Variable Property](./get-variable-property)     | —                                                    | Struct value (Vector / Quaternion / Color) wired via input port | Read a sub-property of a value struct (e.g. `.x` of a Vector3, `.magnitude` of a Vector2). |

:::tip Prefer the dedicated nodes when one exists
For Transform position/rotation/scale, AudioSource clip, Renderer material, and most common Unity properties, use the dedicated [Components](/docs/Flow/Nodes/Components/overview) nodes — they're easier to wire and less error-prone. Reach for the Get / Set Property family only when no dedicated wrapper exists for the property you need.
:::

## See also

- [Components](/docs/Flow/Nodes/Components/overview) — per-Unity-component nodes (the dedicated wrappers to prefer over generic property access)
- [Math](/docs/Flow/Nodes/Math/overview) — value-type math (Vector / Quaternion / Mathf / Color)
- [Variables](/docs/Flow/Nodes/Variables/overview) — typed storage scoped to nodes / graphs / project
