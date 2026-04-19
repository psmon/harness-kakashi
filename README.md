# 카카시하네스 (Harness-Kakashi)

> "카카시 하네스"라고 부르면 된다. 그것이 전부다.

AI 전문가 에이전트 팀을 구성하고, 코드 품질 관리를 자동화하는 [Claude Code](https://docs.anthropic.com/en/docs/claude-code) 플러그인.

---

## 이게 뭔가요?

하네스(harness)는 정원이고, 에이전트는 그 안에 피는 꽃이다.

나루토의 카카시 선생처럼 — 직접 싸우지 않고, 전문가 에이전트를 적재적소에 배치한다.
사륜안(写輪眼)을 개안하면 — 스킬을 보기만 해도 복제할 수 있다.

**코드를 만드는 도구가 아니다. 코드를 더 잘 만들도록 돕는 정원이다.**

---

## 사전 요구사항

[Claude Code](https://docs.anthropic.com/en/docs/claude-code) CLI가 설치되어 있어야 합니다.

```bash
npm install -g @anthropic-ai/claude-code
```

---

## 설치 방법

### 방법 1: 마켓플레이스에서 설치 (권장)

```
/install-plugin psmon/harness-kakashi
```

### 방법 2: Git 클론 후 직접 사용

```bash
git clone https://github.com/psmon/harness-kakashi.git
cd harness-kakashi
claude
```

### 포함된 스킬

| 스킬 | 명령 | 역할 | 설치 |
|------|------|------|------|
| **harness-kakashi-creator** | `/harness-kakashi-creator` | 정원 사용 — 에이전트 관리, 코드 점검, 평가 | 기본 |
| **harness-build** | `/harness-build` | 정원 설계 — 에이전트/엔진/지식 직접 설계 | 선택 |

- **harness-kakashi-creator**: 모든 사용자에게 필요. 하네스 초기화부터 전문가 추가, 코드 리뷰까지.
- **harness-build**: 하네스를 직접 커스터마이징하고 싶은 사용자용. 에이전트 스펙 설계, 엔진 워크플로우 정의, 구조 검증.

---

## 빠른 시작: 4줄이면 된다

```
/harness-kakashi-creator init            ← 정원을 연다
/harness-kakashi-creator 새 에이전트 추가해  ← 꽃을 심는다
/harness-kakashi-creator 코드 만들어줘      ← 코드를 만든다
/harness-kakashi-creator 전체 점검해        ← 코칭을 받는다
```

---

## 온보딩 — 정원이 열리기까지

### Step 1: 정원을 연다 (init)

```
/harness-kakashi-creator init
```

하네스 이름과 설명을 입력하면 정원이 만들어집니다:

```
harness/
├── harness.config.json   ← 정원의 이름표
├── agents/tamer.md       ← 정원지기 카카시 (기본 내장)
├── knowledge/            ← 햇빛 — 도메인 지식
├── engine/               ← 물길 — 워크플로우
├── docs/                 ← 정원 일지
└── logs/                 ← 활동 기록
```

### Step 2: 정원지기가 안내한다

init이 끝나면 정원지기 카카시가 나타납니다.
현재 정원 상태를 보여주고, 프로젝트에 맞는 첫 번째 전문가를 제안합니다.

```
정원이 열렸습니다 — MyProject (v1.0.0)

정원지기 카카시가 문 앞에 서 있습니다.
지금 이 정원에는 정원지기 혼자뿐입니다.

정원의 이름과 설명을 보고, 어울리는 전문가를 제안합니다:
  · security-guard (보안 경비병)
  · performance-scout (성능 정찰병)
  · test-sentinel (테스트 감시병)

제안을 수락하시면 에이전트를 심어드립니다.
```

### Step 3: 꽃을 심는다

제안을 수락하거나, 직접 추가할 수 있습니다:

```
/harness-kakashi-creator 새 에이전트 추가해
```

### Step 4: 코칭을 받는다

에이전트가 심어지면, 코드를 대상으로 전문가 리뷰를 받을 수 있습니다:

```
/harness-kakashi-creator 전체 점검해
```

5명의 전문가가 동시에 코드를 분석하고, 구체적 개선안을 제시합니다.

---

## 실제 사례: "피라미드를 만들었을 뿐인데"

개발 경험이 많지 않은 사용자가 카카시 하네스를 처음 사용했습니다.

```
사용자 입력              카카시 하네스의 응답
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
"피라미드 만들어줘"    → 173줄 .NET 코드 생성 + 빌드 + 실행
"전체평가 해줘"        → 5명 전문가 동시 투입, 종합 등급 B+
"보안 문서 만들어줘"   → OWASP Top 10 기반 공식 리포트
```

그 과정에서 사용자는 자연스럽게 배웠습니다:

| 카카시가 가르쳐준 것 | 교과서에서의 이름 |
|---------------------|------------------|
| "메서드를 분리하세요" | 단일 책임 원칙 (SRP) |
| "StringWriter로 캡처하세요" | 테스트 가능한 설계 |
| "args 미사용으로 안전합니다" | 공격 표면 최소화 |
| "컬렉션 표현식을 잘 쓰셨네요" | 최신 언어 기능 활용 |

**코드를 만들어달라고 했을 뿐인데, 시니어 개발자 5명에게 코드 리뷰를 받은 셈입니다.**

---

## 사용법

### `/harness-kakashi-creator` — 정원 사용

#### 꽃을 심다 (개선부)

| 명령 | 설명 |
|------|------|
| `/harness-kakashi-creator init` | 정원 초기화 |
| `/harness-kakashi-creator 하네스를 설명해` | 정원 상태 보고 |
| `/harness-kakashi-creator 하네스를 개선해` | 3축 평가 후 개선안 |
| `/harness-kakashi-creator 하네스를 업데이트해` | 프로젝트 변경에 맞춰 갱신 |
| `/harness-kakashi-creator 평가로그를 점검해` | 로그 분석 및 트렌드 |
| `/harness-kakashi-creator 새 에이전트 추가해` | 새 꽃 심기 |
| `/harness-kakashi-creator 스킬 복사해` | 사륜안 발동 — 스킬 복제 |

#### 꽃을 피우다 (수행부)

| 명령 | 설명 |
|------|------|
| `/harness-kakashi-creator 전체 점검해` | 전체 리뷰 (전 에이전트 투입) |
| `/harness-kakashi-creator 변경 점검해` | git diff 기반 변경분만 리뷰 |
| `/harness-kakashi-creator 하네스 수행해` | 전체 점검과 동일 |

### `/harness-build` — 정원 설계 (선택 설치)

하네스의 내부 구조를 직접 설계하고 커스터마이징하는 고급 도구.

| 명령 | 설명 |
|------|------|
| `/harness-build 에이전트 설계해` | 에이전트 스펙을 직접 설계 (트리거, 평가축, 절차) |
| `/harness-build 지식 문서 만들어` | knowledge/ 도메인 지식 체계적 구축 |
| `/harness-build 엔진 설계해` | 워크플로우 파이프라인 정의 |
| `/harness-build 구조 검증해` | config ↔ 실제 파일 정합성 확인, 3-Layer 균형 점검 |
| `/harness-build 버전 올려` | 버전 넘버링 + 히스토리 작성 |

**언제 쓰나?**
- `/harness-kakashi-creator 새 에이전트 추가해`로 제안받는 것으로 충분하다면 → build 불필요
- 에이전트의 평가축, 심각도 분류, 점검 절차를 **직접 정의**하고 싶다면 → `/harness-build`

---

## 정원의 구조 — 세 겹의 토양

카카시 하네스는 세 개의 층(Layer)으로 구성됩니다.

| 층 | 디렉토리 | 비유 | 역할 |
|----|----------|------|------|
| Layer 1 | `knowledge/` | 햇빛 | 도메인 지식 — 무엇이 올바른지 판단하는 기준 |
| Layer 2 | `agents/` | 영양분 | 전문 에이전트 — 실제 검수를 수행하는 주체 |
| Layer 3 | `engine/` | 물길 | 워크플로우 — 검수가 흐르는 순서와 범위 |

햇빛 없이는 방향을 잃고,
영양분 없이는 꽃이 피지 않으며,
물길 없이는 꽃이 말라간다.
세 층이 모두 갖춰져야 코드플라워가 피어난다.

---

## 하네스 있을 때 vs 없을 때

| | Claude만 | 카카시 하네스 |
|---|---------|-------------|
| 코드 생성 | O | O |
| 전문가 리뷰 | X | 5명 동시 |
| OWASP 보안 점검 | X | Top 10 전 항목 |
| 성능 안티패턴 분석 | X | 2-Pass 스캔 |
| 구체적 코드 코칭 | X | 줄 번호 지정 수정안 |
| 공식 문서 산출 | X | 리포트 자동 생성 |
| 활동 로그 | X | 모든 활동 자동 기록 |
| 에이전트 팀 관리 | X | 추가/제거/평가 |

---

## 프로젝트 구조

```
harness-kakashi/
├── .claude-plugin/marketplace.json           # 마켓플레이스 카탈로그
├── plugins/harness-kakashi/                  # 플러그인 배포 패키지
│   ├── .claude-plugin/plugin.json            #   매니페스트
│   └── skills/
│       ├── harness-kakashi-creator/          #   정원 사용 스킬 (기본)
│       │   ├── SKILL.md
│       │   ├── references/                   #   참조 문서
│       │   └── templates/harness/            #   init 템플릿
│       └── harness-build/                    #   정원 설계 스킬 (선택)
│           └── SKILL.md
│
├── harness/                                  # 이 저장소의 하네스 (개발용)
│   ├── harness.config.json
│   ├── agents/                               #   에이전트 정의
│   ├── engine/                               #   워크플로우
│   ├── knowledge/                            #   도메인 지식
│   ├── logs/                                 #   실행 로그
│   └── docs/                                 #   버전 히스토리
│
└── projects/                                 # 샘플 프로젝트
```

---

## 핵심 개념

| 개념 | 비유 | 설명 |
|------|------|------|
| **하네스** | 정원 | 프로젝트의 품질 관리 프레임워크 |
| **에이전트** | 꽃 | 특정 역할(보안, 성능, 테스트 등)을 수행하는 전문가 |
| **정원지기(Tamer)** | 관리인 | 하네스 자체를 관리하는 메타 에이전트 |
| **Knowledge** | 햇빛 | 에이전트가 참조하는 도메인 지식 |
| **Engine** | 물길 | 에이전트를 조합하여 실행하는 워크플로우 |
| **사륜안** | 복사 능력 | 기존 스킬을 보고 복제하는 기능 |

---

## 스킬 개발에 참여하기

### 새 에이전트 추가

1. `harness/agents/`에 에이전트 마크다운 파일 작성
2. `harness/harness.config.json`의 `agents` 배열에 등록
3. 필요시 `harness/engine/`에 워크플로우 추가

또는 `/harness-build 에이전트 설계해`로 가이드를 받으며 생성할 수 있습니다.

### 버전 업데이트

| 파일 | 필드 |
|------|------|
| `.claude-plugin/marketplace.json` | `metadata.version`, `plugins[0].version` |
| `plugins/harness-kakashi/.claude-plugin/plugin.json` | `version` |

## 라이선스

MIT
