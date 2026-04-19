---
name: harness-kakashi-creator
description: |
  카카시 하네스를 Codex에서 사용할 수 있게 하는 호환 스킬.
  `.claude/skills/harness-kakashi-creator`를 기준 문서로 삼아 하네스 초기화, 에이전트 추가, 전체 점검, 스킬 복사 워크플로우를 Codex에서 동일하게 수행한다.
  다음 상황에서 사용:
  - "카카시 하네스", "harness-kakashi-creator", "정원 초기화", "하네스를 개선해"
  - "새 에이전트 추가해", "전체 점검해", "변경 점검해", "스킬 복사해"
argument-hint: "[명령] [요구사항]"
---

# Harness Creator Kakashi for Codex

Codex용 호환 래퍼다. Claude용 원본 스킬은 유지하고, Codex는 이 문서를 통해 같은 워크플로우를 따라간다.

## 기준 문서

1. 먼저 `.claude/skills/harness-kakashi-creator/SKILL.md`를 읽고 전체 절차를 따른다.
2. 세부 사례나 평가 기준이 필요하면 `.claude/skills/harness-kakashi-creator/references/` 아래 문서를 추가로 읽는다.
3. init 템플릿이 필요하면 `.claude/skills/harness-kakashi-creator/templates/harness/`를 사용한다.

## Codex 적응 규칙

- Claude의 `/harness-kakashi-creator ...` 호출은 Codex에서는 같은 의미의 자연어 요청으로 해석한다.
- 사용자가 "카카시 하네스"라고 부르면 `harness-kakashi-creator`를 호출한 것처럼 처리한다.
- 작업 전에는 항상 `harness/harness.config.json` 존재 여부를 확인하고, 원본 Claude 스킬의 진입 분기 규칙을 그대로 따른다.

## 수정 규칙

- Codex 호환 때문에 기존 `.claude/skills/` 동작을 바꾸지 않는다.
- 배포 스킬 자체를 수정해야 하면 `plugins/harness-kakashi/skills/harness-kakashi-creator/`를 source of truth로 보고 수정한 뒤 `.claude/skills/harness-kakashi-creator/`에 동기화한다.
- Codex 전용 설명이나 설치 가이드는 이 `codex/skills/` 트리에서만 관리한다.

## 안전 원칙

- 기존 Claude 사용자 흐름, 명령어, 문서 구조를 깨는 변경은 하지 않는다.
- Codex 쪽에서 필요로 하는 차이는 래퍼 문서와 설치 안내로만 흡수한다.
