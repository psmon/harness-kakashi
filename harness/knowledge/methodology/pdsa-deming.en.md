---
title: The PDSA Cycle — Deming's Doctrine
domain: methodology
status: canonical
language: en
sources_verified: 2026-04-23
---

# The PDSA Cycle — Deming's Doctrine

> **This document is the canonical English reference for the Plan–Do–Study–Act cycle as defined by Dr. W. Edwards Deming. It is the foundation of the harness base evaluation system. Do not paraphrase Deming's distinction between Study and Check — quote it.**

---

## 1. Definition

The **PDSA Cycle** (Plan–Do–Study–Act), also called the **Deming Cycle** or **Shewhart Cycle for Learning and Improvement**, is — in the words of the W. Edwards Deming Institute —

> *"a systematic process for gaining valuable learning and knowledge for the continual improvement of a product, process, or service."*
> — [The W. Edwards Deming Institute, *PDSA Cycle*](https://deming.org/explore/pdsa/)

It is **not** a checklist for compliance. It is a learning loop driven by a **theory** that gets tested against reality.

---

## 2. The Four Steps

| Step | What it is | What it is NOT |
|------|-----------|----------------|
| **Plan** | Identify a goal, formulate a *theory*, define success metrics, and develop an action plan. The theory is a prediction: *"If we do X, we expect Y."* | A vague intention or a backlog item |
| **Do** | Carry out the plan, ideally on a **small scale**. Document what actually happened — including the unexpected. | Full rollout |
| **Study** | Compare the **actual results** against the **predicted results**. Look for *what we did not yet know*. The gap between prediction and reality is where new knowledge lives. | Confirming that staff "followed the procedure" |
| **Act** | Decide what to do with the new knowledge. Adopt, adapt, or abandon. Then begin the next cycle, with a refined theory. | Closing the ticket |

Source: [The W. Edwards Deming Institute, *PDSA Cycle*](https://deming.org/explore/pdsa/) — see also [*Deming on Management: PDSA Cycle*](https://deming.org/deming-on-management-pdsa-cycle/).

---

## 3. Why "Study" — Not "Check"

This is the single most important distinction Deming insisted on. The harness inherits it.

### 3.1 Deming's Position

> *"In the 1980s, Deming expressed his view that owing to translation difficulties from Japanese to English, the PDCA cycle had been corrupted."*
> — Karen Martin, *Words Matter: Why I Prefer PDSA over PDCA* (Lean Blog, 2013)
> Source: [leanblog.org](https://www.leanblog.org/2013/01/guest-post-words-matter-why-i-prefer-pdsa-over-pdca/)

Deming continued to refer to the cycle as **PDSA** through the 1990s and renamed it the **Shewhart Cycle for Learning and Improvement**.

### 3.2 The Operational Difference

> *"The words **check** and **act** in PDCA mask the intent of those steps, which are to **study** the results of one's experiment and then make **adjustments** based on the results from the countermeasure(s) put in place to test the hypothesis."*
> — Karen Martin (ibid.), summarizing the practical consequence of the corruption

| | Check (PDCA) | Study (PDSA) |
|---|---|---|
| Question asked | "Did we do what we said?" | "What did we learn?" |
| Posture | Compliance / verification | Hypothesis testing |
| Output | Pass/fail | Revised theory |
| Cultural effect | Audit | Learning |

The Deming Institute summarizes the same distinction:

> *"Check focuses on implementation success/failure and corrections, while Study emphasizes predicting results, comparing actual outcomes against predictions, and developing new knowledge through learning."*
> — [The W. Edwards Deming Institute, *PDSA Cycle*](https://deming.org/explore/pdsa/)

---

## 4. Historical Anchors

| Year | Event |
|------|-------|
| **1939** | Walter A. Shewhart of Bell Laboratories publishes *Statistical Method from the Viewpoint of Quality Control*, the source of the cycle. Deming was Shewhart's student. |
| **1950** | Deming travels to Japan and teaches statistical quality control to Japanese executives, managers, and engineers under invitation from JUSE (Union of Japanese Scientists and Engineers). |
| **1951** | The **Deming Prize** is established by JUSE. The first award ceremony is held on **September 22, 1951**. It honors Deming's contribution to Japan's post-war quality movement. The prize is the **longest-running national quality award in the world**. |
| **1980s** | Deming publicly objects that the Japanese-to-English translation has corrupted the cycle as "PDCA." |
| **1993** | Deming publishes *The New Economics for Industry, Government, Education* — the PDSA cycle appears formally on **p. 132**. |

Source: [Wikipedia — *Deming Prize*](https://en.wikipedia.org/wiki/Deming_Prize), [JUSE — *History of the Deming Prize*](https://www.juse.or.jp/deming_en/award/01.html), [Wikipedia — *PDCA*](https://en.wikipedia.org/wiki/PDCA).

### Why the Deming Prize Matters

The Deming Prize is not just an award — it is the **institutional proof** that quality methodology is treated as national infrastructure. Japan's reputation for high-quality manufacturing in the latter half of the 20th century is, by historical consensus, materially attributable to the methods Deming taught. He is regarded as having had **more impact on Japanese manufacturing and business than any other individual not of Japanese heritage** (Deming Institute / JUSE biographical record).

This matters to the harness because it answers a recurring question: *"Why bother with a learning loop instead of just a checklist?"* The empirical answer is that the country which adopted the learning-loop interpretation became, for several decades, the world reference for quality.

---

## 5. PDSA and Anthropic Skill 2.0 — Structural Alignment

The Anthropic Skill 2.0 self-learning loop (Define → Execute → Evaluate & Reflect → Improve) is structurally isomorphic to PDSA:

| PDSA (Deming) | Skill 2.0 |
|---------------|-----------|
| Plan | Define |
| Do | Execute |
| Study | Evaluate & Reflect |
| Act | Improve |

The harness treats this not as coincidence but as convergent design: any agentic system that genuinely learns must, structurally, do these four things in sequence — and the third step must be *Study*, not *Check*, or the loop degrades into compliance theatre.

---

## 6. The Harness Adoption Rule

The harness adopts PDSA as its **base evaluation system** under the following non-negotiable rules:

1. **Every action runs PDSA as its baseline evaluation** — not just "agent runs," but every Mode A and every execution-phase action.
2. **The Study step requires a predicted outcome stated during Plan.** No prediction → no Study → no learning. If a Plan does not include a prediction, the action is recorded but the PDSA log marks `prediction: missing` and the cycle degrades to PDC*A* — explicitly flagged as degenerate.
3. **Specialist evaluations are follow-ups, not replacements.** Domain experts (security, performance, architecture) run *after* the PDSA base, layered on top — they never substitute for it.
4. **Translate, do not paraphrase.** When the harness logs PDSA evaluations in Korean (default working language), the four step names are translated as: 계획(Plan) / 실행(Do) / **학습(Study)** / 적용(Act). The third step is **학습**, never **검사** or **확인** — those would re-import the PDCA corruption.

---

## 7. Primary Sources

These are the canonical references the harness cites. Do not replace them with secondary summaries without checking these first.

- **The W. Edwards Deming Institute — PDSA Cycle**: <https://deming.org/explore/pdsa/>
- **The W. Edwards Deming Institute — Deming on Management: PDSA Cycle**: <https://deming.org/deming-on-management-pdsa-cycle/>
- **Karen Martin, *Words Matter: Why I Prefer PDSA over PDCA*** (Lean Blog, 2013): <https://www.leanblog.org/2013/01/guest-post-words-matter-why-i-prefer-pdsa-over-pdca/>
- **W. Edwards Deming, *The New Economics for Industry, Government, Education*** (1993), MIT CAES — PDSA cycle definition on p. 132. (Print source.)
- **JUSE — Deming Prize**: <https://www.juse.or.jp/deming_en/award/01.html>
- **Wikipedia — Deming Prize**: <https://en.wikipedia.org/wiki/Deming_Prize>
- **Wikipedia — PDCA** (notes the PDSA distinction): <https://en.wikipedia.org/wiki/PDCA>
- **Wikipedia — W. Edwards Deming**: <https://en.wikipedia.org/wiki/W._Edwards_Deming>
- **NHS HEE — *PDSA cycle.pdf*** (operational template, healthcare): <https://www.hee.nhs.uk/sites/default/files/documents/PDSA%20cycle.pdf>
- **PMC — *Systematic review of PDSA in healthcare quality improvement***: <https://pmc.ncbi.nlm.nih.gov/articles/PMC3963536/>

---

## 8. Document Provenance

- **Sources verified**: 2026-04-23 (current date at time of writing)
- **Maintained by**: tamer (정원지기 카카시) on behalf of sage-deming
- **Status**: canonical — changes require re-verification against deming.org primary sources
- **Cross-references**: `harness/knowledge/lore/naruto-worldview.md` (worldview), `harness/knowledge/methodology/evaluation-base-pdsa.md` (operational rules), `harness/agents/sage-deming.md` (agent definition)
