---
sidebar_position: 1
---

# Send xAPI Statement

Records one thing the learner did — an answer, a choice, a score — as an xAPI statement in your LMS's learning record store (LRS). Use it to report what happens *inside* a course, such as which option a learner picked or how they scored on one question, in addition to the completion and pass/fail the LMS already tracks.

**Category:** Action

## When it sends

The node sends only when the course was launched from an LMS that has a learning record store connected. In any other session — previewing in the editor, testing with Build and Run, or a learner opening the course from the library — nothing is recorded. Either way the node never stops your flow: the flow always continues through its exit.

:::caution Minimum app version
Learners need EducationXR **[minimum version, filled in at release]** or later. On an older app the course stops at this node, as it does with any node the app doesn't know yet.
:::

## What is sent

Each run sends one statement with these parts:

| Part | Where it comes from |
|---|---|
| **Verb** — what happened | The Verb you pick on the node. |
| **Activity** — what it happened to | **Activity id**, and optionally **Activity name**. If you leave Activity id empty, the statement is about the step that is running. |
| **Score** (optional) | The Score setting and its ports. |
| **Success** (optional) | The `success` port, when **Send success** is on. |
| **Response** (optional) | The `response` port, when **Send response** is on. |
| **Time** | The moment the node ran. |
| **Who and which launch** | Filled in for you. You never set the learner. |

The statement describes something *within* the course. It never changes the launch's completion, pass/fail result or grade, and it doesn't appear in Caffeine analytics.

## Inputs

The node shows only the ports for the parts you turn on.

| Port | Type | Description |
|---|---|---|
| activityId | String | Names the activity. Letters, digits and `.` `_` `~` `-` only, up to 64 characters. Leave it empty to make the statement about the running step. |
| activityName | String | A readable name for the activity, up to 128 characters, with no control or invisible formatting characters. Optional. |
| scoreRaw | Float | The score. Shown when **Score** is *Raw, with a range* or *Raw, with a scaled value*. Every score number must be an ordinary number no larger than 1,000,000,000 either way. |
| scoreMin | Float | The lowest possible score. Shown with *Raw, with a range*. Must be below `scoreMax`, with `scoreRaw` between them. |
| scoreMax | Float | The highest possible score. Shown with *Raw, with a range*. |
| scoreScaled | Float | The score as a fraction from -1 to 1. Shown with *Raw, with a scaled value*. |
| success | Bool | Whether the learner got it right. Shown when **Send success** is on. |
| response | String | What the learner answered, up to 1,000 characters (longer text is cut). Shown when **Send response** is on. |

Wire any of these ports to use a value from elsewhere in your graph, or type a value on the node. A wired value wins.

## Inspector parameters

| Field | Type | Description |
|---|---|---|
| verb | Popup | The verb to send, from the list below. Defaults to *experienced*. |
| customVerb | String | Shown when you pick **Custom IRI…** in the Verb popup. A verb of your own, as a full web address. Used instead of the popup's verb. |
| scoreMode | Enum | **No score**, **Raw, with a range** (Raw, Min and Max) or **Raw, with a scaled value** (Raw and Scaled). |
| sendSuccess | Bool | Include a success value. Turns on the `success` port. |
| sendResponse | Bool | Include a response. Turns on the `response` port. |

## Verbs

Pick one of these, or choose **Custom IRI…** to use your own:

*experienced*, *attempted*, *answered*, *interacted*, *progressed*, *responded*, *commented*, *shared*, *asked*, *attended*, *mastered*, *scored*, *preferred*.

A custom verb is a full web address starting with `http://` or `https://`, with a path that ends in the verb's word (for example `https://example.com/verbs/watched`), at most 256 characters. The learning record store shows that last word as the verb's name.

### Reserved verbs

The launch itself reports these, from the learner's real progress, so a course can't send them:

*initialized*, *launched*, *completed*, *passed*, *failed*, *terminated*, *satisfied*, *abandoned*, *waived* and *voided*.

This includes a custom address that ends in one of these words in any capitalisation, such as `https://example.com/verbs/Completed`. A word that merely contains one, such as `completed-quiz`, is fine.

## When a statement is not valid

If the values you typed can't make a valid statement, the node's header turns red, and hovering the warning icon says why. Values that arrive through a wire can only be checked when the course runs. A statement that isn't valid is not sent, and one warning appears in the console for that node; the flow carries on.

## Good to know

- A statement is sent in the background and normally appears in your learning record store a short while after the node runs. If the LMS is briefly unreachable, it is held and tried again.
- A single launch accepts about 500 statements in all, including the ones the launch records itself. Statements beyond that are dropped. The app also sends at most 500 from one run of the course, and after that warns once in the console.
- A statement carries the time from the learner's device. If the device's clock is off by more than a few minutes, the LMS may not record it.
- Statements sent after the launch has ended — completed, failed or expired — are not recorded.

:::tip Report results, not every click
Send a statement at the moments that matter — an answer submitted, a decision made, a score earned — rather than on every interaction, so your records stay easy to read.
:::

## See also

- [Analytic](/docs/Flow/Nodes/Components/Analytics/analytic) — emit a Caffeine analytic event, which is separate from xAPI statements
