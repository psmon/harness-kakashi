---
date: 2026-04-19T23:27:00+09:00
agent: harness-build
type: reference-update
mode: 2
---

# 스킬 분리 원칙 — 표준 vs 프로젝트 전용 문서화

## 변경 대상

- 신규: `plugins/harness-kakashi/skills/harness-kakashi-creator/references/skill-separation.md`
- 수정: `plugins/harness-kakashi/skills/harness-kakashi-creator/SKILL.md`
  - Mode B(Suggestion Tip): 트리거 등록 위치 판정 단계 추가 + references/skill-separation.md 링크
  - 6-Phase 워크플로우: Phase 2(팀 디자인)에 트리거 위치 판정 명시, Phase 6에 표준 스킬 오염 확인 추가
- 동기화: `.claude/skills/harness-kakashi-creator/` 전체 교체

## 변경 내용

하네스 에이전트/엔진을 추가할 때 **트리거를 어디에 등록할지**에 대한 거버넌스 원칙을 references에 코드화했다.

핵심 원칙:
- 하네스 파일(`harness/agents/`, `harness/engine/`, `harness/knowledge/`)은 프로젝트 고유해도 OK
- 표준 스킬 `harness-kakashi-creator` SKILL.md 트리거 테이블은 **범용만** 유지
- 프로젝트 고유 트리거(MCP 서버 의존, 프로젝트 용어, 프로젝트 경로 전제)는 프로젝트 전용 스킬 또는 `harness/` frontmatter 자동 발견에 맡긴다

분류 기준 4문항을 표로 제시하고, Notion 발행 에이전트 예시로 잘못된 배치(❌ 표준 스킬에 트리거 추가)와 올바른 배치를 대비시켰다.

SKILL.md에는 Mode B와 6-Phase 워크플로우 두 곳에 references/skill-separation.md 링크를 심어, 새 에이전트/엔진을 만들 때마다 이 판정을 강제하도록 했다.

## 테스트 결과

해당 없음 — 문서 및 프로세스 변경.

## 비고

배포판의 `templates/harness/agents/`에는 여전히 `tamer.md`만 존재해야 하며 이 변경은 그 규칙을 침범하지 않는다. 신규 문서는 references/에만 추가되므로 init 결과물에는 영향 없다.
