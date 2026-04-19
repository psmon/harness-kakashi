---
name: harness-build
description: |
  하네스 빌더를 Codex에서 사용할 수 있게 하는 repo-local 스킬.
  `.claude/skills/harness-build`를 기준 문서로 삼아 에이전트 설계, 지식 구축, 엔진 정의, 구조 검증, 버전 관리 절차를 Codex에서 동일하게 수행한다.
  다음 상황에서 사용:
  - "harness-build", "에이전트 설계해", "엔진 설계해", "구조 검증해"
  - "하네스 빌드 상태 확인", "버전 올려", "배포 준비해"
---

# Harness Build for Codex

Codex의 repo-local 자동발견 경로인 `.agents/skills/`용 스킬이다.
설계 절차의 기준은 `.claude/skills/harness-build/SKILL.md`이며, 이 문서는 Codex에서 그 절차를 안전하게 재사용하기 위한 얇은 진입점이다.

## 기준 문서

1. `.claude/skills/harness-build/SKILL.md`를 먼저 읽는다.
2. 배포판 설계나 동기화 작업이면 해당 문서가 지정한 `plugins/harness-kakashi/skills/` 경로를 그대로 따른다.
3. 참조 문서 수정이 필요하면 `plugins/harness-kakashi/skills/harness-kakashi-creator/references/`를 사용한다.

## Codex 적응 규칙

- Claude의 `/harness-build ...` 호출은 Codex에서 동일한 의미의 자연어 요청으로 취급한다.
- 실행 전에 항상 `harness/harness.config.json` 존재 여부를 확인한다.
- 이 스킬은 하네스를 설계하는 역할이다. 사용 흐름은 `harness-kakashi-creator`, 설계 흐름은 `harness-build`로 분리한다.

## 수정 규칙

- Codex 호환성 추가를 이유로 Claude 전용 스킬을 깨지 않는다.
- 배포 자산을 수정할 때는 `.claude/skills/harness-build/`와 `plugins/harness-kakashi/skills/harness-build/`의 역할 차이를 유지한다.
- repo-local Codex 스킬은 `.agents/skills/`를 기준으로 유지하고, `.codex/skills/`가 있으면 같은 내용을 미러링한다.
