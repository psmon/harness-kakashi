# 카카시하네스 (Harness-Kakashi)

AI 기반 품질 관리 및 워크플로우 자동화를 위한 [Claude Code](https://docs.anthropic.com/en/docs/claude-code) 스킬 플러그인입니다.

하네스 프레임워크를 통해 에이전트 팀을 구성하고, 스킬 리뷰 워크플로우를 자동화할 수 있습니다.

> 현재 v0.2.0 — init 기능 및 모드 시스템이 포함된 초기 버전입니다.

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

## 시작하기: 하네스 초기화 (init)

플러그인 설치 후 가장 먼저 해야 할 일은 **하네스 초기화**입니다.
초기화를 하면 프로젝트에 `harness/` 디렉토리가 생성되고, 기본 에이전트(조련사)와 3-Layer 구조가 세팅됩니다.

### Step 1: 초기화 명령 실행

```
/harness-kakashi-creator init
```

### Step 2: 하네스 정보 입력

초기화 명령을 실행하면 두 가지를 질문합니다:

```
하네스를 초기화합니다. 다음 정보를 입력해 주세요:

1. 하네스 이름: (예: MyProject Harness)
2. 하네스 설명: (예: 프론트엔드 QA 워크플로우 관리)
```

- **이름**: 이 하네스를 식별하는 이름을 지정합니다.
- **설명**: 이 하네스의 목적을 한 줄로 작성합니다.

### Step 3: 생성되는 구조

초기화가 완료되면 프로젝트 루트에 다음 구조가 생성됩니다:

```
harness/
├── harness.config.json       # 하네스 설정 (이름, 버전, 에이전트 목록)
├── agents/
│   └── tamer.md              # 조련사 — 기본 내장 메타 에이전트
├── engine/                   # 워크플로우 (빈 상태, 필요 시 추가)
├── knowledge/                # 도메인 지식 (빈 상태, 필요 시 추가)
├── docs/
│   └── README.md             # 하네스 개요
└── logs/                     # 활동 로그 (자동 기록)
```

> 이미 `harness/` 디렉토리가 존재하는 경우 덮어쓸지 확인합니다.

### Step 4: 초기화 후 바로 사용

```
/harness-kakashi-creator 하네스를 설명해     # 현재 하네스 상태 확인
/harness-kakashi-creator 하네스를 개선해     # 하네스 평가 및 개선
/harness-kakashi-creator 새 에이전트 추가해  # 새 역할 제안
```

---

## 사용법

Claude Code에서 슬래시 명령으로 실행합니다.

### 개선부 — 하네스 자체를 만들고 고치는 작업

| 명령 | 설명 |
|------|------|
| `/harness-kakashi-creator init` | 하네스 초기화 (최초 1회) |
| `/harness-kakashi-creator 하네스를 설명해` | 현재 하네스 상태 요약 보고 |
| `/harness-kakashi-creator 하네스를 개선해` | 3축 평가 후 개선안 도출 |
| `/harness-kakashi-creator 하네스를 업데이트해` | 프로젝트 변경에 맞춰 하네스 갱신 |
| `/harness-kakashi-creator 평가로그를 점검해` | 기존 로그 분석 및 트렌드 보고 |
| `/harness-kakashi-creator 새 에이전트 추가해` | 새 역할 제안 → 승인 후 생성 |
| `/harness-kakashi-creator 카카시 복사해줘` | 다른 스킬 복사/통합 |

### 수행부 — 하네스에 정의된 에이전트/엔진을 실행

| 명령 | 설명 |
|------|------|
| `/harness-kakashi-creator 하네스 수행해` | 전체 점검 (등록된 에이전트 순차 실행) |
| `/harness-kakashi-creator 전체 점검해` | 위와 동일 |
| `/harness-kakashi-creator 변경 점검해` | git diff 기반 변경 영역만 선별 점검 |

### 플러그인 네임스페이스

```
/harness-kakashi:harness-kakashi-creator [명령]
```

### 조련사 (Tamer) — 기본 내장 에이전트

초기화 시 자동으로 포함되는 메타 에이전트로, 하네스 자체를 관리합니다.

| 평가축 | 평가 대상 | 척도 |
|--------|----------|------|
| 워크플로우 개선도 | 효율성 향상 여부 | A / B / C / D |
| Claude 스킬 활용도 | 프로젝트 스킬 연동 | 1~5점 |
| 하네스 성숙도 | 3-Layer 충실도 | L1~L5 |

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
