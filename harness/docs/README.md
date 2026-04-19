# Harness

이 프로젝트의 하네스 프레임워크.

## 구조

```
harness/
├── harness.config.json   # 메타정보 (버전, 에이전트 목록)
├── knowledge/            # Layer 1: 도메인 지식
├── agents/               # Layer 2: 에이전트 역할 정의
│   └── tamer.md          # 조련사 (기본 내장)
├── engine/               # Layer 3: 워크플로우
├── docs/                 # 하네스 문서
└── logs/                 # 활동 로그
```

## 사용법

```
/harness-kakashi-creator 하네스를 설명해
/harness-kakashi-creator 하네스를 개선해
/harness-kakashi-creator 새 에이전트 추가해
```
