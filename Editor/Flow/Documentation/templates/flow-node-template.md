{/*
================================================================================
TEMPLATE: Single Flow Node Page
================================================================================

Purpose
-------
Document one Flow node per page. For Net (multiplayer) variants, create a
SEPARATE page using this same template — Net entries are first-class.

Output location
---------------
Per the structure doc (templates/flow-nodes-structure.md):
  - Events:    docs/Flow/Nodes/Events/<node-slug>.md
  - Actions:   docs/Flow/Nodes/Components/<Component>/<node-slug>.md
  - Math:      docs/Flow/Nodes/Math/<Type>/<node-slug>.md
  - Variables: docs/Flow/Nodes/Variables/<node-slug>.md
  - Logic:     docs/Flow/Nodes/Logic/<node-slug>.md
  - Signals:   docs/Flow/Nodes/Signals/<node-slug>.md
  - Course:    docs/Flow/Nodes/Course/<node-slug>.md

Net variants
------------
- File name: prefix with `net-` (e.g. `net-select-event.md`).
- Title: wrap the heading text in <span class="net-node">…</span> and append
  <span class="net-badge">NET</span> for the purple accent + chip.
- IMPORTANT: also add `sidebar_label:` and `title:` in the frontmatter with
  the plain text node name. Docusaurus uses the H1 text verbatim for the
  sidebar entry, breadcrumb, and browser tab — without these overrides the
  raw `<span class="...">...</span>` HTML leaks into the sidebar and crumb.
- Cross-link the local and Net pages from each other's "See also".

CSS dependency
--------------
The `.net-node` (purple text) and `.net-badge` (purple chip) classes are
defined in `src/css/custom.css` of the Docusaurus site. They MUST exist in
the target repo for the visual accent to render. If you're working in a
detached scratch space, be aware these classes won't render in your local
preview — match the markup exactly and trust the styling will apply once
the folder is integrated.

How to use this file
--------------------
1. Copy this file to its target path (see above).
2. Strip ALL `{/* ... */}` block comments — they're author instructions, not
   content.
3. Fill in the frontmatter and every section, omitting any subsection that
   doesn't apply (don't leave empty headings).

Conventions
-----------
- NO per-node screenshots. With hundreds of nodes, images don't scale —
  rely on the description, port tables, and parameter tables. Category
  overview pages may include a single shared screenshot at the top.
- Port types: Flow, Bool, Int, Float, String, GameObject, Vector3,
  Quaternion, Transform, Object (generic), List<T>, Enum<...>.
- Voice: second person, short paragraphs. Match flow-events.md tone.
- Internal links: absolute (/docs/Flow/...), never relative-to-disk.
*/}

---
sidebar_position: {/* integer ordering this node within its folder */}
{/* For NET variants, ALSO add these two lines to keep the sidebar/breadcrumb
    clean (the raw <span> HTML in the H1 would otherwise leak into them):
sidebar_label: {/* plain text node name, e.g. "Net Select Event" */}
title: {/* plain text node name, e.g. "Net Select Event" */}
*/}
---

# {/* Node Display Name */}

{/* For NET variants only:
# <span class="net-node">Net Node Display Name</span> <span class="net-badge">NET</span>
*/}

{/* 1–2 sentences: what the node does and when a creator would reach for it.
    Lead with the verb / outcome. Don't restate the category. */}

**Category:** {/* Event | Action | Variable | Logic | Math | Flow | Course | Input | Interactables | AI | Voice | SaveSystem | System | Paint | Pulse | Player */}{/* append " (Net)" for Net variants, e.g. "Event (Net)" */}
**Component / Source:** {/* "Built-in" | a Unity component (e.g. "Rigidbody") | "EDXR_SceneGraph" | "Course step" | "Flow Event asset" */}
{/* Optional — codegen nodes only. Link out to the Unity ScriptReference page
    for the wrapped method/property. Use the arrow `↗` as the link text and
    the unversioned ScriptReference URL. Skip this line for hand-coded nodes
    (no Unity equivalent). For Net variants, link the same Unity method as
    the local variant — the underlying API is identical.

**Unity reference:** [↗](https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html)
*/}

## Inputs

| Port | Type | Description |
|---|---|---|
| {/* port name */} | {/* type */} | {/* what it does, default if any, accepted values */} |

{/* Standard Flow port convention:
    - Action / Updatable nodes: the standard Flow input (top-left) is
      IMPLICIT — never list it here. Covered once in Components/overview.md.
      List only data inputs and any additional named ports.
    - Event nodes: list the `Enabled` input here (it gates whether the
      event fires). Other event-specific data inputs (e.g. a `collider`
      reference on Select Event) also belong here.
    - Pure data nodes: no Flow ports at all. List data inputs here.
    Omit this section entirely if the node has no inputs beyond the
    implicit standard Flow input. */}

## Outputs

| Port | Type | Description |
|---|---|---|
| {/* port name */} | {/* type */} | {/* what it emits and when */} |

{/* Standard Flow port convention:
    - Action / Updatable nodes: the standard Flow output (`exit`) is
      IMPLICIT — never list it here. List only ADDITIONAL Flow outputs
      (e.g. TTS's `speakComplete`, Branch's `True`/`False`) and data
      outputs. When you list an additional Flow output, ALSO add a
      `:::note Standard Flow output` admonition right after the table
      explaining when `exit` fires vs. when the named one fires.
    - Event nodes: ALWAYS list the Flow output(s) — they're the node's
      purpose, not boilerplate. Use a meaningful name (e.g. "Flow") even
      if the underlying field is named `entry`.
    - Pure data nodes: no Flow ports. List data outputs here.
    Omit this section entirely if the node has no outputs beyond the
    implicit standard Flow output. */}

{/* Example admonition for a node with an additional Flow output:

:::note Standard Flow output vs `speakComplete`
Like every Action node, TTS has a standard Flow output (`exit`) that kicks
**immediately** when the node runs — not when the speech finishes. To run
logic after the spoken phrase completes, wire from `speakComplete`, not
from the standard output. See the [Action overview](/docs/Flow/Nodes/Components/overview)
for the convention.
:::

*/}

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| {/* field name */} | {/* type */} | {/* what it configures, default value */} |

{/* Inspector parameters = fields shown on the node body itself, not
    connected via ports. Omit this section if none. */}

## Notes & gotchas

{/* Optional. Use admonitions for anything that could trip a creator up:
    networking pitfalls, performance considerations, version-specific
    quirks, interactions with other nodes. Skip the section entirely if
    there's nothing surprising. */}

:::warning
{/* e.g., "Do not place this node inside an Update loop — it allocates
   per-frame and will tank performance on mobile." */}
:::

## See also

- [{/* Net counterpart, if any */}](./net-{/* slug */})
- [{/* Local counterpart — only on Net pages */}]({/* ./local-slug */})
- [{/* Related node */}]({/* ./other-slug */})
- [{/* Cross-page concept */}](/docs/Flow/flow-networking)

{/*
================================================================================
APPENDIX A — Compact pattern for repetitive node families
================================================================================

Some categories (Math especially) have many near-identical variants:
  Add Int, Add Float, Add Vector3, ...
  Lerp Float, Lerp Vector3, Lerp Color, ...

For these, document the pattern ONCE on the parent overview.md (e.g.,
docs/Flow/Nodes/Math/overview.md or docs/Flow/Nodes/Math/Mathf/overview.md)
with a table:

  | Node | Operand type | Output |
  |---|---|---|
  | Add Int     | Int     | Int     |
  | Add Float   | Float   | Float   |
  | Add Vector3 | Vector3 | Vector3 |

Only create individual node pages for variants that have unique inputs,
parameters, or behavior worth documenting on their own.

================================================================================
APPENDIX B — Voice & style cheatsheet
================================================================================

- Match existing Flow docs (flow-intro.md, flow-events.md, flow-actions.md):
  conversational second person, short paragraphs.
- Bold key terms on first mention: **Flow Graph**, **Node**, **EDXR_SceneGraph**.
- Admonitions: `:::tip` (helpful nudge), `:::warning` (footgun), `:::note`
  (neutral aside). Always close with `:::`.
- Internal links: /docs/Flow/flow-networking — absolute, never relative-to-disk.
- Anchors: Docusaurus strips <span> tags when slugifying headings, so
  # <span class="net-node">Net Select Event</span> <span class="net-badge">NET</span>
  has slug #net-select-event-net. To pin a clean anchor, append {#custom-id}:
  # <span class="net-node">Net Select Event</span> <span class="net-badge">NET</span> {#net-select-event}
*/}
