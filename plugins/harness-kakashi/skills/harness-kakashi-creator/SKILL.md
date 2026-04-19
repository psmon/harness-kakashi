---
name: harness-kakashi-creator
description: 카카시하네스 스킬을 생성하고 관리합니다. 하네스 기반 품질 관리 워크플로우를 구성하거나, 에이전트 팀을 정의하고, 스킬 리뷰 엔진을 실행할 때 사용합니다. harness, kakashi, 하네스, 카카시, 품질 관리, 워크플로우, 에이전트 팀 등의 키워드가 언급되면 이 스킬을 활용하세요.
argument-hint: "[명령] [요구사항]"
---

# 카카시하네스 (Harness-Kakashi) 스킬

카카시하네스는 AI 기반 품질 관리 및 워크플로우 자동화 프레임워크입니다.

## 참고 문서

- 하네스 설정: [harness/harness.config.json](../../../../harness/harness.config.json)
- 에이전트 정의: [harness/agents/](../../../../harness/agents/)
- 엔진 워크플로우: [harness/engine/](../../../../harness/engine/)
- 도메인 지식: [harness/knowledge/](../../../../harness/knowledge/)

## 구조

```
harness-kakashi/
├── .claude-plugin/marketplace.json    # 마켓플레이스 카탈로그
├── plugins/harness-kakashi/           # 플러그인 패키지
│   ├── .claude-plugin/plugin.json     # 플러그인 매니페스트
│   └── skills/                        # 스킬 정의
│       └── harness-kakashi-creator/SKILL.md
├── harness/                           # 품질 관리 프레임워크
│   ├── harness.config.json            # 하네스 설정
│   ├── agents/                        # AI 에이전트 팀
│   ├── engine/                        # 워크플로우 엔진
│   ├── knowledge/                     # 도메인 지식
│   ├── logs/                          # 실행 로그
│   └── docs/                          # 버전 히스토리
├── skill-maker/docs/                  # 스킬 제작 참고 문서
└── skill-test/                        # 스킬 테스트
    ├── plan/                          # 테스트 시나리오
    └── result/                        # 테스트 결과
```

## 사용 가능한 명령

### 하네스 상태 확인
현재 하네스 설정과 에이전트 팀 구성을 확인합니다.

### 에이전트 추가
새로운 에이전트를 harness/agents/ 에 추가하고 harness.config.json에 등록합니다.

### 워크플로우 실행
harness/engine/ 에 정의된 워크플로우를 실행합니다.

### 스킬 리뷰
등록된 에이전트 팀이 순차적으로 스킬 품질을 검증합니다.

## 버전 동기화 규칙

다음 세 위치의 버전이 항상 일치해야 합니다:
1. `.claude-plugin/marketplace.json` → `metadata.version` + `plugins[0].version`
2. `plugins/harness-kakashi/.claude-plugin/plugin.json` → `version`

## 향후 개발 예정

이 스킬은 초기 구조 단계입니다. 기능은 구조 생성 이후 점진적으로 개발됩니다.
