---
date: 2026-04-19
status: pending
owner: harness-build
priority: medium
tags: [log-schema, evaluation, templates, tamer-persona]
---

# 하네스 로그 스키마 & 평가축 정합성 개선

하네스 로그 7건 스캔(2026-04-19) 결과 발견된 문제점 정리. 추후 진행 예정.

## 증거: 분석한 로그 파일

- `harness/logs/execution/2026-04-19-hello-pyramid-dotnet-console.md`
- `harness/logs/full-review/2026-04-19-hello-pyramid-full-evaluation.md`
- `harness/logs/harness-build/2026-04-19-23-27-skill-separation-principle.md`
- `harness/logs/harness-build/2026-04-19-onboarding-and-tamer-persona.md`
- `harness/logs/harness-build/2026-04-19-plugin-harness-build-and-readme.md`
- `harness/logs/security-guard/2026-04-19-hello-pyramid-security-doc.md`
- `harness/logs/tamer/2026-04-19-17-00-recruit-5-agents-from-dotnet-skills.md`

## 발견된 문제

### 1. 템플릿 이탈 (harness-build 로그 3건)

- `변경 대상 / 변경 내용 / 테스트 결과 / 비고` 자체 섹션으로 작성
- SKILL.md §"MD-Style 자동 로그"가 정의한 `실행 요약 / 결과 / 평가 / 다음 단계 제안` 형식 미준수
- **`## 평가` 섹션을 통째로 생략** — SKILL.md는 "로그 없는 Mode A 실행은 불완전"이라 선언했지만 마더 빌드 작업은 예외인지 명시 없음

### 2. 평가축 이중화 — 문서화 안 됨

두 축 시스템이 병존:

| 시스템 | 축 | 등급 | 용도 |
|--------|----|------|------|
| 정원지기(tamer) | 워크플로우 개선도 / 스킬 활용도 / 하네스 성숙도 | A-D / 1-5 / L1-L5 | Mode A (개선부) |
| 수행부 | 코드 안전성 / 아키텍처 정합성 / 테스트 가능성 | ? | 수행부 |

- SKILL.md L356(수행부)와 L404-411(tamer) 둘 다 "3축"이라 부르는데 내용이 다름
- 언제 어느 축을 쓰는지 guidance 없음
- `full-review` 로그는 `종합 등급: B+`라는 문서화되지 않은 합성 등급을 발명

### 3. `mode:` 필드 freeform화

관측된 실제 값: `Mode 1 + Mode 2 + Mode 3`, `Mode 1 + Mode 5`, `수행부`, `2`, `suggestion-tip`, `log-eval`

SKILL.md L434가 명시한 enum: `log-eval | suggestion-tip | kakashi-copy` — 3개뿐이고 마더 빌드/수행부를 커버 못함.

### 4. `agent:` 값이 실제 에이전트가 아님

- `execution`, `full-review`, `harness-build` 는 `harness/agents/`에 등록되지 않음
- 엔진(engine)/메타(meta) vs 에이전트 네임스페이스 구분 문서화 없음

### 5. `trigger:` 필드 누락

harness-build 로그 3건 모두 `trigger:` 없음 — SKILL.md 형식상 필수인데 강제 메커니즘 없음.

### 6. 정원지기 페르소나 불일치

- 온보딩 UI(SKILL.md Case 2-A): "정원이 열렸습니다", "정원지기가 문 앞에 서 있습니다" — 은유 무거움
- 실제 tamer 로그: 분석 톤, 은유 없음
- `tamer-agent.md`에 "어디서 페르소나 쓰고 어디서 안 쓰는지" 규칙 없음

### 7. 반복 패턴 미템플릿화

- full-review 로그의 "에이전트별 발견 수 / 에이전트별 요약" 표는 매번 같은 모양인데 템플릿 없음

---

## 개선 제안 (우선순위)

### 묶음 A — 로그 스키마 정합 (함께 처리 권장)

세 항목이 동일한 "로그 스키마 불일치" 뿌리를 공유. 한 번에 수정하면 templates / evaluation.md / SKILL.md가 정합을 맞춤.

| # | 변경 | 파일 | 난이도 |
|---|------|------|--------|
| A1 | `templates/log-template.md` 신규 — frontmatter 스키마 + 필수 섹션 + 선택 섹션(에이전트별 요약 등) | 새 파일 | 중 |
| A2 | 평가축 분리 명문화 — Mode A(tamer 3축) vs 수행부(코드/아키텍처/테스트) 언제 어느 쪽 쓰는지 | evaluation.md + SKILL.md L404 | 중 |
| A3 | `mode:` enum 확장 — `engine-update`, `reference-update`, `template-update`, `execution`, `full-review`, `targeted-review` 추가 | SKILL.md L434 + 새 log-template | 하 |

### 묶음 B — 의무 규칙 강화

| # | 변경 | 파일 | 난이도 |
|---|------|------|--------|
| B1 | harness-build 로그에도 `## 평가` 의무화 OR 면제 명시(그리고 면제 이유) | SKILL.md §"주의사항" | 하 |
| B2 | `agent:` 네임스페이스 규칙 — 엔진/메타는 `engine:name` / `meta:name` 또는 별도 필드 | SKILL.md §"로그 경로" L420 | 하 |
| B3 | `trigger:` 필수/선택 명확화 (메타 작업에는 `command:` 필드가 더 맞을 수도) | SKILL.md L434 | 하 |

### 묶음 C — 페르소나·합성 규칙

| # | 변경 | 파일 | 난이도 |
|---|------|------|--------|
| C1 | 정원지기 페르소나 사용 범위 명시 — 로그는 분석 톤, UI(온보딩/안내)만 은유 | tamer-agent.md | 하 |
| C2 | 종합 등급(B+ 등) 합성 규칙 정의 또는 금지 | evaluation.md | 하 |

---

## 추후 진행 시 체크리스트

- [ ] 묶음 A 일괄 처리 (A1 → A2 → A3 순서)
- [ ] 기존 로그 7건 retrofit 여부 결정 (새 스키마에 맞춰 재작성 vs 이후 로그만 적용)
- [ ] 묶음 B 처리 — A 완료 후 규칙 강화 단계
- [ ] 묶음 C 처리 — 독립적, 언제든 가능
- [ ] 버전 bump 범위 결정 (Minor 추천 — 스키마 변경이므로)
- [ ] `harness/docs/vX.Y.Z.md` 변경 히스토리 작성

## 비고

- 이 todo는 `/harness-build` 마더 생성기의 작업 범위. 배포판 수정 시 `plugins/` → `.claude/skills/` 동기화 절차 준수.
- 기존 로그 retrofit은 선택 사항 — git 이력에 남으므로 새 스키마만 이후 로그에 강제해도 됨.
