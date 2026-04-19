# 카카시하네스 (Harness-Kakashi)

AI 기반 품질 관리 및 워크플로우 자동화를 위한 [Claude Code](https://docs.anthropic.com/en/docs/claude-code) 스킬 플러그인입니다.

하네스 프레임워크를 통해 에이전트 팀을 구성하고, 스킬 리뷰 워크플로우를 자동화할 수 있습니다.

> 현재 v0.1.0 — 초기 구조 단계이며, 기능은 점진적으로 개발 중입니다.

## 사전 요구사항

- [Claude Code](https://docs.anthropic.com/en/docs/claude-code) CLI가 설치되어 있어야 합니다.

```bash
npm install -g @anthropic-ai/claude-code
```

## 설치 방법

### 방법 1: 마켓플레이스에서 설치 (권장)

Claude Code를 실행한 후 아래 명령을 입력합니다.

```
/plugin marketplace add psmon/harness-kakashi
/plugin install harness-kakashi@harness-kakashi-skills
```

### 방법 2: Git 클론 후 직접 사용

```bash
git clone https://github.com/psmon/harness-kakashi.git
cd harness-kakashi
claude
```

프로젝트 내 `.claude/skills/` 디렉토리가 자동 인식되어 별도 설정 없이 바로 사용할 수 있습니다.

### 방법 3: settings.json에 수동 등록

프로젝트의 `.claude/settings.json` 또는 전역 `~/.claude/settings.json`에 추가합니다.

```json
{
  "enabledPlugins": {
    "harness-kakashi@harness-kakashi-skills": true
  }
}
```

## 사용법

Claude Code에서 슬래시 명령으로 실행합니다.

```
/harness-kakashi-creator 하네스 상태 확인
/harness-kakashi-creator 전체 리뷰
/harness-kakashi-creator 에이전트 추가
```

플러그인 네임스페이스를 포함한 형태도 가능합니다.

```
/harness-kakashi:harness-kakashi-creator [명령]
```

## 프로젝트 구조

```
harness-kakashi/
├── .claude-plugin/marketplace.json          # 마켓플레이스 카탈로그
├── plugins/harness-kakashi/                 # 플러그인 배포 패키지
│   ├── .claude-plugin/plugin.json           #   플러그인 매니페스트
│   └── skills/harness-kakashi-creator/      #   스킬 정의
│       └── SKILL.md
│
├── harness/                                 # 품질 관리 프레임워크
│   ├── harness.config.json                  #   하네스 설정
│   ├── agents/                              #   AI 에이전트 팀 정의
│   ├── engine/                              #   워크플로우 엔진
│   ├── knowledge/                           #   도메인 지식
│   ├── logs/                                #   실행 로그
│   └── docs/                                #   버전 히스토리
│
├── skill-maker/docs/                        # 스킬 제작 참고 문서
└── skill-test/                              # 스킬 테스트
    ├── plan/                                #   테스트 시나리오
    └── result/                              #   테스트 결과
```

### 핵심 개념

| 개념 | 설명 |
|------|------|
| **Skill** | Claude Code에서 슬래시 명령으로 호출할 수 있는 기능 단위 (`SKILL.md`) |
| **Agent** | 특정 역할을 수행하는 AI 에이전트 (`harness/agents/`) |
| **Engine** | 에이전트들을 조합하여 실행하는 워크플로우 (`harness/engine/`) |
| **Knowledge** | 에이전트가 참조하는 도메인 지식 (`harness/knowledge/`) |

## 스킬 개발에 참여하기

이 프로젝트는 [skill-actor-model](https://github.com/psmon/skill-actor-model)의 플러그인 구조를 참고하여 만들어졌습니다.

### 새 에이전트 추가

1. `harness/agents/`에 에이전트 마크다운 파일을 작성합니다.
2. `harness/harness.config.json`의 `agents` 배열에 에이전트 이름을 등록합니다.
3. 필요시 `harness/engine/`의 워크플로우에 실행 순서를 추가합니다.

### 버전 업데이트

아래 두 파일의 버전을 항상 동기화해야 합니다.

| 파일 | 필드 |
|------|------|
| `.claude-plugin/marketplace.json` | `metadata.version`, `plugins[0].version` |
| `plugins/harness-kakashi/.claude-plugin/plugin.json` | `version` |

## 라이선스

MIT
