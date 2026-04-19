---
name: harness-kakashi-creator
description: |
  하네스(Harness) 통합 관리 스킬 - 에이전트/지식/엔진 워크플로우의 생성, 사용, 평가를 하나로 통합.
  이 스킬은 자동 트리거하지 않는다. 반드시 /harness-kakashi-creator 명령으로만 활성화할 것.
  다음 상황에서 사용:
  [개선부] 하네스 자체를 만들고 고치는 작업:
  - "하네스를 업데이트해", "하네스를 개선해", "하네스를 설명해", "평가로그를 점검해"
  - "하네스에 새 에이전트 추가해", "워크플로우 만들어줘", "엔진 정의해줘"
  - "이 스킬을 하네스에 복사해", "카카시 복사해줘", "스킬 복제해줘"
  - "하네스 초기화", "harness init", "/harness-kakashi-creator init"
  [수행부] 하네스에 정의된 에이전트/엔진을 실행하는 작업:
  - "하네스 수행해", "전체 점검해", "변경 점검해"
argument-hint: "[명령] [요구사항]"
---

# Harness Creator Kakashi

카카시(복사 닌자)처럼 유용한 스킬을 복사하고, 하네스 에이전트/지식/엔진을 생성/사용/평가하는 통합 스킬.

> **자동 트리거 금지** — `/harness-kakashi-creator` 명령으로만 활성화한다.
> 이유: 하네스가 필요한 상황과 아닌 상황이 있으며, 그 판단은 사용자의 몫이다.

---

## 하네스 존재 확인 (최우선)

활성화 시 가장 먼저 `harness/harness.config.json`을 Read로 읽는다.

**파일이 없는 경우** (harness/ 디렉토리 자체가 없거나 비어 있는 경우):
- 다른 모드로 진행하지 않는다
- 사용자에게 다음과 같이 안내한다:

```
하네스가 아직 초기화되지 않았습니다.
먼저 초기화를 진행해 주세요:

  /harness-kakashi-creator init

이 명령은 harness/ 디렉토리와 기본 구조(조련사 에이전트, config 등)를 생성합니다.
```

**파일이 있는 경우** → 정상적으로 모드 판별로 진행한다.

---

## 모드 판별

$ARGUMENTS를 분석하여 **개선부** 또는 **수행부**를 먼저 판별한 뒤, 세부 모드를 결정한다.

```
/harness-kakashi-creator <요청>
        │
        ├─ 개선부 (하네스 자체를 만들고 고치는 작업)
        │   ├── Mode A: Log & Eval — 조련사(tamer)가 하네스를 설명/개선/평가
        │   ├── Mode B: Suggestion Tip — 새 에이전트/워크플로우/지식 제안
        │   ├── Mode C: Kakashi Copy — 스킬 복사 (skill-creator 위임)
        │   └── Mode D: Initialize — 하네스 초기화
        │
        └─ 수행부 (하네스에 정의된 에이전트/엔진을 실행하는 작업)
            ├── "하네스 수행해" — 전체 점검 (full-review engine)
            ├── "전체 점검해" — full-review engine
            ├── "변경 점검해" — targeted-review engine
            └── 개별 에이전트 트리거 — 해당 에이전트 단독 실행
```

---

### 개선부

#### Mode A: Log & Eval (로그 & 평가)

**조건**: 조련사(tamer) 트리거와 매칭되는 요청

**동작**:
1. 매칭된 에이전트의 역할 정의(`harness/agents/{name}.md`)를 읽는다
2. 매칭된 워크플로우가 있으면 `harness/engine/{name}.md`를 읽는다
3. 에이전트 역할에 따라 작업을 수행한다
4. **[필수] 로그 기록** — `harness/logs/{agent-name}/{yyyy-MM-dd-HH-mm-title}.md`
5. **[필수] 평가 실행** — 해당 에이전트의 평가축에 따라 결과 평가

> **CRITICAL**: 4~5단계는 생략 불가. 작업 완료 후 사용자에게 결과를 보고하기 **직전에** 반드시 로그 파일을 생성하고 평가를 수행할 것. 로그 없는 Mode A 실행은 불완전한 실행이다.

#### Mode B: Suggestion Tip (제안 모드)

**조건**: 매칭되는 에이전트/워크플로우가 없음

**동작**:
1. 사용자 요청을 분석하여 필요한 역할/워크플로우를 식별
2. 구조화된 제안 생성:
   - 제안 에이전트명, 역할 설명
   - 트리거 문구
   - 배치할 하네스 레이어
   - 예상 효과
3. **사용자 확인 후에만** 생성 진행
4. 승인 시 해당 레이어에 파일 생성 + 로그 기록

#### Mode C: Kakashi Copy (카카시 복사)

**조건**: "스킬 복사", "카카시 복사", "스킬 복제" 등의 요청

**동작**:
1. 복사 대상 식별 (경로, 설명, 또는 기존 스킬 참조)
2. `/skill-creator`에 위임하여 스킬 생성/복사
3. 복사 후 `harness/knowledge/`에 참조 문서 등록
4. 로그 기록: `harness/logs/kakashi-copy/`

> 스킬 생성/복사는 직접 하지 않는다 — 반드시 `/skill-creator`를 호출하여 위임한다.

#### Mode D: Initialize (초기화)

**조건**: `harness/` 디렉토리가 없거나 "하네스 초기화" 요청

**동작**: 아래 "하네스 초기화" 섹션 참조

---

### 수행부

수행부는 하네스에 정의된 에이전트와 엔진 워크플로우를 **실제 코드/프로젝트에 대해 실행**하는 작업이다.
개선부가 하네스 자체를 다듬는 것이라면, 수행부는 하네스가 프로젝트를 위해 일하는 것이다.

#### 수행부 동작

1. 트리거에 매칭된 에이전트/엔진의 정의 파일을 읽는다
   - 엔진: `harness/engine/{name}.md` (실행 순서, 참여 에이전트 정의)
   - 에이전트: `harness/agents/{name}.md` (점검 절차, 평가 기준)
2. 정의에 따라 **실제 프로젝트 코드를 대상으로** 작업을 수행한다
3. **[필수] 로그 기록** — `harness/logs/{agent-or-engine-name}/{yyyy-MM-dd-HH-mm-title}.md`
4. **[필수] 평가 실행** — 3축 평가 (코드 안전성 / 아키텍처 정합성 / 테스트 가능성)

> **프로젝트별 트리거 자동 발견**: `harness/agents/*.md`와 `harness/engine/*.md`의 frontmatter `triggers:` 항목을 스캔하면 발견된다. 트리거 테이블에서 매칭이 안 되면 이 디렉토리들을 스캔하여 다시 매칭한 뒤 동일한 수행부 동작을 따른다. 끝까지 매칭이 안 될 때만 Mode B(Suggestion Tip)로 폴백한다.

> 수행부도 로그/평가 의무는 동일하다. 로그 없는 수행은 불완전한 실행이다.

---

## 3-Layer 아키텍처

하네스 경로: `{project_root}/harness/`

| 계층 | 디렉토리 | 용도 |
|------|----------|------|
| Layer 1 | `harness/knowledge/` | 도메인 지식, 방법론 |
| Layer 2 | `harness/agents/` | 에이전트 역할 정의 |
| Layer 3 | `harness/engine/` | 워크플로우, 오케스트레이션 |
| 문서 | `harness/docs/` | 버전 히스토리, 가이드 |
| 로그 | `harness/logs/{part}/` | 활동별 개별 로그 |

상세: [references/layer-guide.md](references/layer-guide.md)

---

## 조련사 (Tamer) — 기본 내장 에이전트

하네스의 메타 에이전트로, 하네스 자체를 설명/개선/평가한다.

**트리거**:
- "하네스를 업데이트해" → 하네스 구조/내용 갱신
- "하네스를 개선해" → 평가 후 개선안 도출 및 적용
- "하네스를 설명해" → 현재 하네스 상태 요약 보고
- "평가로그를 점검해" → 기존 로그 분석 및 트렌드 보고

상세: [references/tamer-agent.md](references/tamer-agent.md)

### 조련사 평가축 (3축)

| 축 | 평가 대상 | 등급 |
|----|----------|------|
| 워크플로우 개선도 | 기존 대비 효율성 향상 | A/B/C/D |
| Claude 스킬 활용도 | 프로젝트 스킬들의 연동/활용 | 1~5점 |
| 하네스 성숙도 | knowledge/agents/engine 충실도 | L1~L5 |

상세: [references/evaluation.md](references/evaluation.md)

---

## MD-Style 자동 로그

Mode A(Log & Eval) 및 수행부 동작 시 자동으로 로그를 기록한다.

### 로그 경로

`harness/logs/{part}/{yyyy-MM-dd-HH-mm-title}.md`

- `{part}`: 에이전트명 또는 워크플로우명 (예: `tamer`, `kakashi-copy`)
- `{title}`: 영문 kebab-case 활동 요약

### 로그 형식

```markdown
---
date: {ISO 8601}
agent: {agent-name}
type: {evaluation | improvement | explanation | review | creation | copy}
mode: {log-eval | suggestion-tip | kakashi-copy}
trigger: "{매칭된 트리거 문구}"
---

# {활동 제목}

## 실행 요약
{수행한 작업 내용}

## 결과
{산출물, 변경사항}

## 평가
{해당 에이전트의 평가축에 따른 평가 결과}

## 다음 단계 제안
- {개선 제안 1}
- {개선 제안 2}
```

---

## 하네스 초기화 (init)

`/harness-kakashi-creator init` 명령으로 실행한다.

이 스킬은 초기화 템플릿을 내장하고 있다:
```
.claude/skills/harness-kakashi-creator/templates/harness/
├── harness.config.json
├── agents/
│   └── tamer.md
├── docs/
│   └── README.md
├── engine/.gitkeep
├── knowledge/.gitkeep
└── logs/.gitkeep
```

### init 절차

#### Step 1: 기존 디렉토리 확인

```bash
ls -d harness/ 2>/dev/null
```

- **디렉토리가 없는 경우** → Step 2로 진행
- **디렉토리가 있는 경우** → 사용자에게 확인:
  ```
  harness/ 디렉토리가 이미 존재합니다.
  기존 내용을 덮어쓰시겠습니까? (기존 로그 등이 삭제될 수 있습니다)
  ```
  - 사용자가 승인 → 기존 디렉토리 삭제 후 Step 2로 진행
  - 사용자가 거부 → 초기화 중단

#### Step 2: 사용자 정보 질의

사용자에게 다음 두 가지를 질문한다:

1. **하네스 이름 (name)**: 이 하네스를 식별하는 이름
2. **하네스 설명 (description)**: 이 하네스의 목적을 한 줄로 설명

질문 예시:
```
하네스를 초기화합니다. 다음 정보를 입력해 주세요:

1. 하네스 이름: (예: MyProject Harness)
2. 하네스 설명: (예: 프론트엔드 QA 워크플로우 관리)
```

#### Step 3: 템플릿 복사

```bash
cp -r .claude/skills/harness-kakashi-creator/templates/harness ./harness
```

#### Step 4: harness.config.json 설정

복사된 `harness/harness.config.json`의 플레이스홀더를 실제 값으로 채운다:

- `__USER_INPUT__` (name) → 사용자가 입력한 하네스 이름
- `__USER_INPUT__` (description) → 사용자가 입력한 하네스 설명
- `__INIT_DATE__` → 현재 날짜 (yyyy-MM-dd)

최종 config 예시:
```json
{
  "$schema": "kakashi-harness",
  "$schemaVersion": "1.0.0",
  "name": "사용자가 입력한 이름",
  "description": "사용자가 입력한 설명",
  "version": "1.0.0",
  "agents": ["tamer"],
  "engine": [],
  "created": "2026-04-19",
  "lastUpdated": "2026-04-19"
}
```

`$schema`와 `$schemaVersion`은 고정값이다:
- `$schema`: `"kakashi-harness"` — 이 JSON이 카카시 하네스 설정임을 식별
- `$schemaVersion`: `"1.0.0"` — config 스키마의 버전

#### Step 5: 초기화 완료 보고

```
하네스 초기화 완료!
- 이름: {name}
- 설명: {description}
- 경로: harness/
- 스키마: kakashi-harness v1.0.0
- 기본 에이전트: tamer (조련사)
- 버전: 1.0.0

이제 /harness-kakashi-creator 명령으로 하네스를 사용할 수 있습니다.
  - "하네스를 설명해" — 현재 하네스 상태 확인
  - "하네스를 개선해" — 하네스 평가 및 개선
  - "새 에이전트 추가해" — 새 역할 제안
```

---

## 하네스 요소 추가 워크플로우 (6-Phase)

Mode B에서 사용자 승인 후 새 요소를 추가할 때:

1. **도메인 분석** — 관련 knowledge/ 문서 검색, 프로젝트 구조 파악
2. **팀 디자인** — 기존 agents/ 구조 확인, 새 요소의 위치 결정
3. **에이전트 정의** — 역할/능력 스펙 작성 (`harness/agents/`)
4. **지식 설계** — `harness/knowledge/`에 도메인 지식 매핑
5. **워크플로우** — `harness/engine/`에 워크플로우 통합
6. **검증** — 3계층에 올바르게 배치되었는지 확인

> 단순 문서 추가는 Phase 1, 6만 수행해도 됨.

---

## 필수 산출물 체크리스트

하네스 구조 변경 시 반드시 갱신:

- [ ] **harness/docs/vX.Y.Z.md** — 버전 히스토리
- [ ] **harness/harness.config.json** — version 필드 갱신

### 버전 넘버링

- **Patch** (0.1.x): 하위 요소 추가, 문서 보강
- **Minor** (0.x.0): 새 워크플로우, 에이전트 추가
- **Major** (x.0.0): 아키텍처 변경

---

## 피드백 루프

```
/harness-kakashi-creator 로 활동 수행 (Mode A)
     |
harness/logs/{part}/{timestamp}.md 에 로그 기록
     |
평가 점수 < 기준 또는 개선 제안 발견
     |
조련사가 하네스 업그레이드 제안
     |
사용자 승인 후 하네스 구조 개선
     |
harness/docs/vX.Y.Z.md 에 변경 기록
```

---

## 주의사항

- 하네스는 **구조화 프레임워크** — 기존 스킬을 대체하지 않고 오케스트레이션한다
- 기존 스킬 호출 시 해당 스킬의 SKILL.md 가이드를 따른다
- **로그 기록은 개선부(Mode A) 및 수행부 동작 시 절대 생략하지 않는다** — 결과 보고 직전에 반드시 로그 파일을 먼저 생성할 것
