---
name: harness-build
description: |
  하네스 빌더 — 자신의 하네스를 설계하고 확장하는 도구.
  에이전트 설계, 지식 구축, 엔진 워크플로우 정의, 구조 검증을 지원한다.
  이 스킬은 자동 트리거하지 않는다. 반드시 /harness-build 명령으로만 활성화할 것.
  다음 상황에서 사용:
  - "에이전트 설계해", "지식 문서 만들어", "엔진 워크플로우 정의해"
  - "하네스 구조 검증해", "하네스 빌드 상태 확인"
  - "버전 올려", "배포 준비해"
argument-hint: "[명령] [요구사항]"
---

# Harness Build — 하네스 빌더

> 정원의 토양을 직접 설계하고 싶다면, 이 도구를 쓴다.

`/harness-kakashi-creator`가 정원을 **사용**하는 도구라면,
`/harness-build`는 정원을 **설계**하는 도구다.

> **자동 트리거 금지** — `/harness-build` 명령으로만 활성화한다.
> **선택 설치** — 이 스킬은 하네스의 기본 기능 없이도 동작하지 않는다. 반드시 harness-kakashi-creator와 함께 사용할 것.

---

## 언제 쓰는가

| 상황 | 사용할 도구 |
|------|-----------|
| 하네스 초기화, 에이전트 추가, 전체 점검 | `/harness-kakashi-creator` |
| 에이전트를 **직접 설계**, 평가축 커스터마이징 | `/harness-build` |
| 엔진 워크플로우를 **직접 정의** | `/harness-build` |
| 지식 문서를 **체계적으로 구축** | `/harness-build` |
| 하네스 구조 검증, 버전 관리 | `/harness-build` |

**쉽게 말하면:**
- `/harness-kakashi-creator` = 정원에서 꽃을 심고 가꾸기 (사용)
- `/harness-build` = 정원의 토양과 물길을 직접 설계하기 (설계)

---

## 사전 조건

활성화 시 가장 먼저 `harness/harness.config.json`을 Read로 읽는다.

- **파일 없음** → "먼저 `/harness-kakashi-creator init`으로 하네스를 초기화하세요" 안내 후 종료
- **파일 있음** → $ARGUMENTS 분석하여 빌드 모드 판별

---

## 빌드 모드

```
/harness-build <요청>
      │
      ├── Mode 1: 에이전트 설계
      ├── Mode 2: 지식 구축
      ├── Mode 3: 엔진 설계
      ├── Mode 4: 구조 검증
      └── Mode 5: 버전 관리
```

### Mode 1: 에이전트 설계

**트리거**: "에이전트 설계해", "에이전트 만들어", "새 역할 정의해"

기존 `/harness-kakashi-creator 새 에이전트 추가해`와 차이:
- creator는 제안 → 승인 → 생성의 간편 경로
- build는 에이전트의 **내부 구조를 직접 설계**하는 상세 경로

**절차:**
1. 에이전트의 목적과 범위를 사용자와 협의
2. 에이전트 스펙 설계:

```markdown
---
name: {에이전트명}
persona: {페르소나 이름} (선택)
triggers:
  - "{트리거 문구 1}"
  - "{트리거 문구 2}"
description: {한 줄 설명}
---

# {에이전트 이름}

## 역할
{무엇을 하는 에이전트인지}

## 점검 절차
### Step 1: ...
### Step 2: ...

## 심각도 분류
| 등급 | 기준 |
|------|------|
| Critical | ... |
| Moderate | ... |
| Info | ... |

## 평가축 (3축)
| 축 | 평가 대상 | 등급 |
|----|----------|------|
| ... | ... | ... |

## 검증 체크리스트
- [ ] ...

## 경계
- **하는 것**: ...
- **하지 않는 것**: ...
```

3. `harness/agents/{name}.md`에 저장
4. `harness/harness.config.json`의 agents 배열에 추가
5. 로그 기록

### Mode 2: 지식 구축

**트리거**: "지식 문서 만들어", "knowledge 추가해", "도메인 지식 정리해"

**절차:**
1. 프로젝트의 도메인 지식 범위 파악
2. 기존 `harness/knowledge/` 스캔
3. 지식 문서 설계:
   - 참조 문서 (레퍼런스, 규약, 표준)
   - 방법론 (점검 기준, 베스트 프랙티스)
   - 분석 인사이트 (외부 소스 분석 결과)
4. `harness/knowledge/{name}.md`에 저장
5. 로그 기록

### Mode 3: 엔진 설계

**트리거**: "엔진 만들어", "워크플로우 정의해", "파이프라인 설계해"

**절차:**
1. 기존 에이전트 목록 확인
2. 워크플로우 설계:

```markdown
---
name: {엔진명}
triggers:
  - "{트리거 문구}"
description: {한 줄 설명}
agents:
  - {참여 에이전트 1}
  - {참여 에이전트 2}
---

# {엔진 이름}

## 실행 순서
1. {에이전트1} — {수행 내용}
2. {에이전트2} — {수행 내용}

## 병렬 실행 가능 구간
- [{에이전트1}, {에이전트2}] — 동시 실행 가능

## 결과 집계
{개별 에이전트 결과를 어떻게 종합할지}
```

3. `harness/engine/{name}.md`에 저장
4. `harness/harness.config.json`의 engine 배열에 추가
5. 로그 기록

### Mode 4: 구조 검증

**트리거**: "구조 검증해", "하네스 상태 확인", "빌드 체크"

**절차:**
1. `harness/harness.config.json` 읽기
2. config에 등록된 에이전트 ↔ 실제 `harness/agents/*.md` 파일 대조
3. config에 등록된 엔진 ↔ 실제 `harness/engine/*.md` 파일 대조
4. 에이전트의 triggers 중복 검사
5. 3-Layer 균형 점검:
   - knowledge/가 비어 있으면 → "햇빛 부족" 경고
   - agents/가 tamer만 있으면 → "영양분 부족" 경고
   - engine/가 비어 있으면 → "물길 부족" 경고
6. 보고

### Mode 5: 버전 관리

**트리거**: "버전 올려", "버전 확인해", "릴리즈 준비해"

**절차:**
1. 현재 `harness/harness.config.json` 버전 확인
2. 최근 변경사항 분석 (git log 또는 로그 기반)
3. 버전 넘버 결정:
   - **Patch** (x.y.Z): 문서 보강, 기존 에이전트 수정
   - **Minor** (x.Y.0): 새 에이전트/엔진 추가
   - **Major** (X.0.0): 아키텍처 변경
4. `harness/harness.config.json` 버전 갱신
5. `harness/docs/vX.Y.Z.md` 변경 히스토리 작성
6. 로그 기록

---

## 로그 체계

**경로**: `harness/logs/harness-build/{yyyy-MM-dd-HH-mm-title}.md`

**형식**:
```markdown
---
date: {ISO 8601}
agent: harness-build
type: {agent-design | knowledge-build | engine-design | validation | version}
mode: {Mode 1~5}
---

# {활동 제목}

## 변경 대상
{수정/생성한 파일 목록}

## 변경 내용
{구체적 변경 사항}

## 검증 결과
{구조 검증 결과 — Mode 4 시}
```

---

## 주의사항

- 이 스킬은 **하네스가 초기화된 후에만** 동작한다
- 에이전트 설계 시 기존 에이전트와 triggers가 충돌하지 않도록 확인할 것
- 엔진에 참조하는 에이전트가 실제 `harness/agents/`에 존재하는지 확인할 것
- 모든 변경 후 Mode 4(구조 검증)를 실행하여 정합성을 확인하는 것을 권장
