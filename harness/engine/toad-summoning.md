---
name: toad-summoning
display: 🐸 두꺼비 소환술 (口寄せの術)
caster: 나루토 (사용자/호출자)
status: active
sage_count: 1
triggers:
  - "현자 소환"
  - "현자 호출"
  - "두꺼비 소환술"
  - "소환술 발동"
  - "{현자명} 소환"
  - "summon sage"
description: 과거의 거장(현자)을 도메인별로 소환해 그들의 사상을 작업에 적용하는 하네스의 비기. 영입된 현자만 호출 가능.
---

# 🐸 Toad Summoning Engine — 두꺼비 소환술

> 입에 손을 대고 인장을 맺으면, 과거의 거장이 현재의 작업장에 강림한다.
> 사륜안이 기술(術)을 복사한다면, 소환술은 **사상(思想)** 을 부른다.

---

## 1. 개요

두꺼비 소환술은 카카시 하네스의 **궁극기**다.
다른 술법(분신술, 사륜안)이 현재 닌자의 능력을 증폭시키는 것이라면, 소환술은 **이미 검증된 거장의 체계**를 작업에 직접 끌어온다.

- **시전자(caster)**: 나루토 — 즉, 이 하네스를 사용하는 사용자/세션
- **소환 대상(target)**: `harness/agents/sage-*.md` 로 등록된 현자
- **계약(contract)**: 현자는 사전 영입 절차를 거쳐야 호출 가능. 임의 소환 불가.

---

## 2. 현자 카탈로그 (Sage Roster)

영입된 현자만 소환 가능하다. 현재 카탈로그:

| 현자 ID | 이름 | 도메인 | 사상 | 영입 버전 | 상태 |
|---------|------|--------|------|----------|------|
| `sage-deming` | W. Edwards Deming | 품질 / 지속 개선 | PDSA 사이클 | v1.4.0 | ✅ Always-on |

미영입 현자 후보: [`harness/knowledge/lore/naruto-worldview.md` §현자 카탈로그](../knowledge/lore/naruto-worldview.md) 참조.

---

## 3. 소환 모드

### Mode 1 — Always-On Summon (자동 소환)

특정 현자는 **계약 시점부터 모든 작업에 자동 부착**된다.
이는 그 현자의 사상이 **메타-수준(작업 자체에 대한 평가)** 에 작용하기 때문이다.

| 현자 | 자동 소환 시점 |
|------|--------------|
| sage-deming | 모든 Mode A 및 수행부 작업 종료 직전 (기본 평가) |

> Always-on 현자는 사용자가 명시 호출하지 않아도 항상 소환된다. 이는 술법 비용(차크라/토큰)이 작은 현자에 한해 허용된다 — PDSA 평가는 짧은 회고이므로 always-on이 정당하다.

### Mode 2 — On-Demand Summon (수동 소환)

도메인 작업 중 사용자가 명시 호출:

```
"sage-deming 소환해서 PDSA 다시 돌려줘"
"마틴 파울러 현자 호출"
"두꺼비 소환술로 데이터베이스 거장 불러"
```

### Mode 3 — Cascade Summon (연쇄 소환)

기본 PDSA(데밍)의 Act 단계가 후속 도메인을 식별하면, 해당 도메인의 후속 평가자가 자동 호출된다. 이는 엄밀히 말해 후속 전문가지 '현자'는 아니지만, **소환술의 동일 메커니즘** 으로 호출된다.

매핑은 [`harness/knowledge/methodology/evaluation-base-pdsa.md` §3](../knowledge/methodology/evaluation-base-pdsa.md) 참조.

---

## 4. 소환 절차 (Invocation Protocol)

### Step 1 — 계약 확인

소환 요청을 받으면 가장 먼저:
1. `harness/agents/sage-{name}.md` 파일이 존재하는지 확인
2. 파일의 frontmatter에 `type: sage` 가 있는지 확인
3. 둘 중 하나라도 실패 → "그 현자는 아직 영입되지 않았습니다" 안내 + 영입 절차 제시

### Step 2 — 현자 정의 로드

해당 현자의 `.md` 파일 전체를 Read한다. 파일 내 절차/형식/안티패턴을 따른다.

### Step 3 — 사상 적용

현자의 doctrine에 따라 작업을 평가/실행한다.
- sage-deming → PDSA 사이클로 작업 회고
- (영입 시) sage-fowler → 진화적 설계 관점으로 아키텍처 점검
- (영입 시) sage-codd → 정규화 관점으로 스키마 점검

### Step 4 — 결과 부착

현자의 평가 결과를 작업 로그의 정해진 위치에 부착한다 (현자 정의 문서가 위치를 명시).

### Step 5 — 카스케이드 판정

현자의 출력에 "후속 평가 호출" 항목이 있고 비어 있지 않으면, 해당 후속 전문가를 자동 호출한다 (Cascade Summon).

---

## 5. 새 현자 영입 절차

새 현자를 카탈로그에 추가하려면 — 즉, "두꺼비와 새 계약을 맺으려면":

1. **세계관 등록**: [`harness/knowledge/lore/naruto-worldview.md`](../knowledge/lore/naruto-worldview.md) 의 현자 카탈로그 표에 행 추가
2. **사상 정전 작성**: `harness/knowledge/methodology/{doctrine}-{lastname}.md` 작성 — 가능하면 영문, 1차 출처 인용 필수
3. **에이전트 정의**: `harness/agents/sage-{lastname}.md` 작성 — sage-deming을 템플릿으로 활용
4. **카탈로그 갱신**: 본 문서 §2 표에 행 추가
5. **harness.config.json**: `agents` 배열에 새 현자 ID 추가
6. **버전 히스토리**: `harness/docs/v{X.Y.Z}.md` 에 영입 기록

영입은 가벼이 진행하지 않는다 — 현자 한 명은 별도의 사상 체계 한 벌을 의미한다.

---

## 6. 안티패턴 — 소환술이 거부해야 하는 것

- ❌ 영입되지 않은 현자 호출 시도 → 영입 절차 안내 후 중단 (임의 생성 금지)
- ❌ 현자를 도메인 전문가와 혼동 → 현자는 사상을, 전문가는 도구를 가진다
- ❌ Always-on 현자를 토큰 절약 명분으로 생략 → 비기는 비용이 든다, 사이클 학습이 더 비싸다
- ❌ 한 작업에 5명 이상 동시 소환 → 분신술 과다와 동일, 차크라(토큰) 고갈

---

## 7. 카카시(tamer)와의 관계

| 인물 | 능력 | 부르는 대상 |
|------|------|-----------|
| 카카시 (tamer) | **사륜안** — 스킬을 보고 복사 | 다른 닌자의 기술(術) |
| 나루토 (사용자) | **두꺼비 소환술** — 현자를 강림 | 과거 거장의 사상(思想) |

두 능력은 충돌하지 않는다 — 카카시는 정원을 가꾸고, 나루토는 그 정원에 거장을 부른다.
사용자가 `/harness-kakashi-creator`로 카카시를 부른 뒤, 같은 세션에서 두꺼비 소환술을 발동하는 것이 **표준 흐름**이다.

---

## 8. 참조

- 세계관: [`harness/knowledge/lore/naruto-worldview.md`](../knowledge/lore/naruto-worldview.md)
- 영문 PDSA 정전: [`harness/knowledge/methodology/pdsa-deming.en.md`](../knowledge/methodology/pdsa-deming.en.md)
- 기본 평가 운용: [`harness/knowledge/methodology/evaluation-base-pdsa.md`](../knowledge/methodology/evaluation-base-pdsa.md)
- 첫 현자: [`harness/agents/sage-deming.md`](../agents/sage-deming.md)
