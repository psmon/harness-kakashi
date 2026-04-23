---
title: 기본 평가 시스템 — PDSA 기반 (운용 규칙)
domain: methodology
status: canonical
language: ko
---

# 기본 평가 시스템 — PDSA 기반

> 이 문서는 카카시 하네스의 **기본 평가(Base Evaluation)** 운용 규칙이다.
> 학문적 정의는 영문 정전 [`pdsa-deming.en.md`](./pdsa-deming.en.md)를 따른다 — 이 문서는 그 사상을 하네스가 어떻게 구현하는가에 관한 것이다.

---

## 0. 두 가지 평가 — 기본과 후속

이 하네스는 **두 단계 평가**를 가진다.

```
[모든 작업]
     │
     ├─ [기본 평가]  PDSA 사이클 — 데밍 (sage-deming)
     │              · 항상 작동
     │              · 작업 유형/도메인과 무관하게 부착
     │              · 학습 루프(Plan→Do→Study→Act) 기록
     │
     └─ [후속 평가]  도메인 전문가 (Type별 선택)
                    · 작업 유형이 호출할 때만 발동
                    · 보안 → security-guard
                    · 성능 → performance-scout
                    · 테스트 → test-sentinel
                    · 빌드 → build-doctor
                    · 코드 현대화 → code-modernizer
                    · 아키텍처 → (영입 시) sage-fowler
                    · 데이터베이스 → (영입 시) sage-codd
```

### 핵심 원칙

1. **기본 평가는 생략 불가** — 어떤 Mode A 또는 수행부 동작도, 결과를 보고하기 전에 PDSA 평가가 로그에 기록되어야 한다.
2. **후속 평가는 도메인이 부른다** — 작업이 도메인을 가질 때(예: 보안 점검), 해당 전문가가 PDSA 위에 얹혀 추가 평가를 수행한다.
3. **후속이 기본을 대체하지 않는다** — security-guard가 보안 점수를 줬다고 해서 PDSA 학습 단계가 면제되지 않는다.

---

## 1. 기본 평가 절차 — PDSA 4단계

`sage-deming`이 수행한다. 작업이 끝나는 즉시(보고 직전) 호출된다.

### Plan — 계획 (예측 명시 필수)

작업 시작 시 또는 작업 회고 시 **사후적으로라도** 다음을 명시한다:

- **목표(goal)**: 무엇을 달성하려 했는가
- **이론(theory)**: "X를 하면 Y가 일어날 것이다" 형식의 **예측**
- **성공 지표(metric)**: 어떻게 결과를 측정할 것인가

> **[CRITICAL] 예측 누락은 학습 루프의 붕괴**
> Plan에 예측이 없으면 Study가 불가능하다(비교 대상이 없다). 이 경우 PDSA 로그는 `prediction: missing` 으로 표시되며, 평가는 **PDC*A* — 퇴화 사이클** 로 명시 기록된다. 다음 작업부터는 사전 예측을 반드시 추가한다.

### Do — 실행

- 실제로 무엇을 했는가
- 작은 단위로(small scale) 시도했는가, 한 번에 크게 했는가
- 예상치 못한 일은 무엇이었는가

### Study — 학습 (Check 아님)

- **예측 vs 실제**: 결과는 Plan의 이론과 얼마나 일치했는가
- **새로 알게 된 것**: 작업 전엔 모르고 있었는데, 이번에 알게 된 사실은 무엇인가
- **이론의 수정**: 원래 가설이 어떻게 갱신되어야 하는가

> **"검사" 또는 "확인"으로 번역하지 않는다.** 이 단계의 한국어 표기는 항상 **학습**이다. (영문 정전의 §6.4 번역 규칙 참조)

### Act — 적용

- **채택(Adopt)** / **수정(Adapt)** / **폐기(Abandon)** 중 하나를 명시
- 다음 사이클을 위한 **갱신된 이론**을 한 줄로 적는다
- 후속 평가가 필요한 도메인이 있으면 여기서 호출 트리거를 남긴다

---

## 2. 평가 결과 형식

PDSA 평가는 모든 로그에 다음 블록으로 부착된다:

```markdown
## PDSA 기본 평가 (sage-deming)

### Plan
- 목표: {한 줄}
- 이론(예측): {"X하면 Y일 것" — 미기록 시 prediction: missing}
- 지표: {측정 방법}

### Do
- 실행: {실제 수행 내용 핵심}
- 규모: {small-scale | full-rollout}
- 예상 외: {있었다면 무엇}

### Study
- 예측 vs 실제: {일치 | 부분일치 | 불일치}
- 새 학습: {이번에 알게 된 것}
- 이론 수정: {갱신된 가설}

### Act
- 결정: {Adopt | Adapt | Abandon}
- 다음 사이클의 이론: {한 줄}
- 후속 평가 호출: {없음 | security-guard | performance-scout | ...}

### Cycle Health
- 예측 명시: {Yes | No → PDCA 퇴화}
- 학습 발생: {Yes | No → 단순 컴플라이언스 체크에 그침}
- 다음 적용 명확: {Yes | No}
```

---

## 3. 후속 평가 트리거 매핑

기본 PDSA가 끝난 뒤, 작업 유형이 다음 중 하나에 해당하면 후속 평가를 자동 호출한다.

| 작업 유형 | 후속 전문가 | 호출 조건 |
|----------|-----------|----------|
| 보안 변경, 인증/인가, 입력 검증 | security-guard | 코드 변경이 인증/입력 경계에 닿음 |
| 성능 최적화, 핫패스 변경 | performance-scout | 벤치마크 또는 핫패스 수정 |
| 테스트 추가/수정 | test-sentinel | tests/ 디렉토리 변경 |
| 빌드/CI 변경 | build-doctor | csproj/yml/Dockerfile 수정 |
| 레거시 코드 현대화 | code-modernizer | API/패턴 마이그레이션 |
| .NET 동시성 / 액카 | dotnet-concurrency-specialist, akka-net-specialist | 동시성 코드 변경 |
| 벤치마크 설계 | dotnet-benchmark-designer | BenchmarkDotNet 변경 |
| 컴파일러/제너레이터 | roslyn-incremental-generator-specialist | Source Generator 변경 |
| API 문서화 | docfx-specialist | docs 토폴로지 변경 |

> 후속 평가가 없는 작업도 **기본 평가는 반드시 있다**. 후속이 없다는 것은 "이 작업은 도메인 특화 검토가 불필요하다"는 의미이지, "평가가 없다"는 의미가 아니다.

---

## 4. 기존 3축 평가와의 관계

기존 정원지기(tamer)의 3축 평가(워크플로우 개선도 / 스킬 활용도 / 하네스 성숙도)는 **하네스 자체에 대한 평가**다. 이는 PDSA와 충돌하지 않고 다음 위치에 자리한다:

```
[하네스 자체에 관한 작업 — Mode A: tamer]
   ├─ PDSA 기본 평가 (sage-deming)        ← 학습 루프
   └─ 3축 평가 (tamer)                   ← 하네스 구조 점검

[프로젝트 코드에 관한 작업 — 수행부 또는 도메인 에이전트]
   ├─ PDSA 기본 평가 (sage-deming)        ← 학습 루프
   └─ 도메인 후속 평가 (해당 전문가)        ← 코드 품질 점검
```

즉, **PDSA는 모든 작업의 베이스**이고, 기존 평가들은 작업 유형에 따라 그 위에 얹힌다.

---

## 5. 작동 시점

| 시점 | 동작 |
|------|------|
| 개선부 Mode A 동작 종료 직전 | PDSA 평가 + (필요 시) tamer 3축 평가 |
| 수행부 엔진/에이전트 종료 직전 | PDSA 평가 + 도메인 후속 평가(매핑 시) |
| Mode B(Suggestion Tip) | PDSA 평가 (계획 단계에 머무름 — Do 미수행 시 Plan-only 로그) |
| Mode C(Kakashi Copy) | PDSA 평가 (위임 결과까지 포함) |
| Mode D(Initialize) | PDSA 평가 면제 — 메타 작업 (단, 초기화 자체에 대한 별도 init 로그는 남긴다) |

---

## 6. 운영 안티패턴 — 하면 안 되는 것

- ❌ Plan에 예측 없이 "하기로 했다"만 기록 → Study가 의미 없어진다
- ❌ Study 단계에 "잘 됐음", "문제 없음" 같은 비학습 문구만 적기 → Check로 퇴화
- ❌ Act를 "다음에 잘하자"로 마무리 → 이론 갱신 없음
- ❌ 도메인 후속 평가가 있다고 해서 PDSA 생략 → 학습 루프 단절
- ❌ PDSA를 "검사 절차"라고 부르거나 "확인 단계"로 번역 → 데밍 사상의 정면 위반

---

## 7. 참조

- 영문 정전: [`pdsa-deming.en.md`](./pdsa-deming.en.md)
- 데밍 현자 에이전트: [`harness/agents/sage-deming.md`](../../agents/sage-deming.md)
- 소환술 엔진: [`harness/engine/toad-summoning.md`](../../engine/toad-summoning.md)
- 세계관 매핑: [`harness/knowledge/lore/naruto-worldview.md`](../lore/naruto-worldview.md)
- 기존 tamer 3축 평가: [`.claude/skills/harness-kakashi-creator/references/evaluation.md`](../../../.claude/skills/harness-kakashi-creator/references/evaluation.md)
