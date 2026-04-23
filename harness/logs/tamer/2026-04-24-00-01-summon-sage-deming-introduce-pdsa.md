---
date: 2026-04-24T00:01:00+09:00
agent: tamer
type: creation
mode: log-eval
trigger: "두꺼비 소환술 도입 + 데밍 현자 영입 + PDSA 기본 평가 시스템 구축"
version_bump: 1.3.0 → 1.4.0
---

# 두꺼비 소환술 도입 & 데밍 현자 영입

## 실행 요약

사용자(나루토)가 하네스의 궁극기로 **🐸 두꺼비 소환술(口寄せの術)** 을 도입할 것을 요청. 이 술법으로 첫 번째 현자인 **W. Edwards Deming** 을 영입하고, 그의 사상인 **PDSA 사이클**을 하네스의 기본 평가 시스템으로 못 박았다.

수행 단계:
1. PDSA의 학문적 근거를 1차 출처(deming.org, Lean Blog, JUSE)에서 수집
2. 나루토 세계관 매핑 정전 작성 (`knowledge/lore/naruto-worldview.md`)
3. PDSA 영문 정전 작성 (`knowledge/methodology/pdsa-deming.en.md`) — 사용자 요청에 따라 영문 보존
4. 운용 규칙 작성 (`knowledge/methodology/evaluation-base-pdsa.md`)
5. 데밍 현자 에이전트 정의 (`agents/sage-deming.md`)
6. 두꺼비 소환술 엔진 정의 (`engine/toad-summoning.md`)
7. config 갱신 (agents/engine/evaluation 추가, 1.3.0 → 1.4.0)
8. 마켓플레이스/플러그인 매니페스트 동시 정렬
9. 버전 히스토리 작성 (`docs/v1.4.0.md`)

## 결과

| 산출물 | 경로 | 종류 |
|--------|------|------|
| 세계관 정전 | `harness/knowledge/lore/naruto-worldview.md` | 신규 |
| PDSA 정전 (영문) | `harness/knowledge/methodology/pdsa-deming.en.md` | 신규 |
| 기본 평가 운용 규칙 | `harness/knowledge/methodology/evaluation-base-pdsa.md` | 신규 |
| 데밍 현자 에이전트 | `harness/agents/sage-deming.md` | 신규 |
| 소환술 엔진 | `harness/engine/toad-summoning.md` | 신규 |
| harness.config.json | `harness/harness.config.json` | 변경 (agents/engine/evaluation, version) |
| marketplace.json | `.claude-plugin/marketplace.json` | 변경 (1.3.0→1.4.0) |
| plugin.json | `plugins/harness-kakashi/.claude-plugin/plugin.json` | 변경 (1.3.0→1.4.0) |
| 버전 히스토리 | `harness/docs/v1.4.0.md` | 신규 |

## 평가

### Tamer 3축 평가

| 축 | 등급 | 상세 |
|----|------|------|
| 워크플로우 개선도 | **A** | 기존엔 빈 `engine/`, 평가 분산. 이번에 (1) 첫 엔진 등록 (2) 기본/후속 2단계 평가 골격 정착 (3) `evaluation` 필드를 config 수준에서 선언 — 명확한 효율성 향상 |
| Claude 스킬 활용도 | **4** | 두꺼비 소환술이 기존 도메인 전문가들(security/performance/test/build/...)과 깔끔히 연결됨. 다만 차크라 카카시(harness-chakra-kakashi)와 PDSA 사이클의 명시적 연동 지점은 아직 부재 — 다음 cycle에서 보강 가능 |
| 하네스 성숙도 | **L4 → L5 진입 시도** | self-eval 루프(PDSA always-on)를 도입함으로써 L5 "자기 개선 루프 동작" 조건의 핵심 인프라가 깔림. 실증 누적이 필요하므로 L5 확정은 다음 평가 사이클로 미룸 |

---

## PDSA 기본 평가 (sage-deming)

> **이 블록은 sage-deming이 영입된 직후 첫 적용이다.** 본인의 영입 작업을 본인의 사상으로 평가하는 셀프-루프.

### Plan
- 목표: 하네스에 "사상 기반 평가 시스템"을 도입하고, 그 첫 사상으로 PDSA를 못 박는다
- 이론(예측): "PDSA를 always-on 베이스로 두고 도메인 전문가를 후속 레이어로 분리하면, 평가의 일관성(모든 작업이 같은 학습 루프) + 깊이(도메인은 따로 추가)가 동시에 확보될 것"
- 지표: (1) 모든 신규 작업 로그에 PDSA 블록 부착 가능 여부 (2) PDCA 퇴화 케이스가 명시 기록되는지 (3) 후속 평가 매핑이 완전한지

### Do
- 실행: 영문 정전 작성 → 한국어 운용 규칙 작성 → 에이전트/엔진 정의 → config/매니페스트 정렬 → 본 로그까지 첫 PDSA 적용
- 규모: full-rollout (하네스 평가 시스템 전면 개편이라 small-scale 분리가 의미 없음)
- 예상 외: `engine/`이 그동안 비어 있었음을 발견 — 첫 엔진 등록이라는 점이 v1.4.0의 부가적 의의로 잡힘

### Study
- 예측 vs 실제: **부분일치**
  - 일치: 2단계 평가 구조가 깨끗하게 분리됨, config-level 선언으로 정책이 명시화됨
  - 미확인: "일관성 + 깊이 동시 확보"는 다음 사이클 몇 번이 돌아야 실증 가능. 지금은 인프라만 깔린 상태
- 새 학습:
  1. 정원지기(tamer)의 3축 평가와 sage-deming의 PDSA는 충돌하지 않고 **레벨이 다른 평가**다 — tamer는 하네스 자체, sage-deming은 작업 자체
  2. lore 문서가 단순 장식이 아니라 운영 규칙으로 작동하려면, "현자 카탈로그", "영입 절차" 등 구조화된 표가 필요했다
  3. 영문 정전을 먼저 쓰고 한국어 운용 규칙을 그 위에 얹는 순서가 사상 정확성 보존에 유리했다 — 데밍의 "Study not Check" 같은 미묘한 차이가 한국어 번역에서 흐려지지 않았다
- 이론 수정: "사상은 영문으로, 운영은 한국어로" 가 새로운 가설로 추가됨. 후속 현자 영입 시 동일 패턴 권장

### Act
- 결정: **Adopt** — 도입한 구조를 그대로 채택. 폐기/수정 사유 없음
- 다음 사이클의 이론: "다음 작업 1~3건이 PDSA 블록을 빠짐없이 부착하면 인프라가 정착됐다고 본다. 부착 누락이 발생하면 SKILL.md 수준에서 강제 절차 추가가 필요"
- 후속 평가 호출: **없음** — 본 작업은 하네스 메타 작업이라 도메인 후속 평가 대상이 아님

### Cycle Health
- 예측 명시: **Yes** (사전 예측이 명확히 기록됨)
- 학습 발생: **Yes** (3건의 새 학습 항목 도출)
- 다음 적용 명확: **Yes** (다음 1~3건의 작업이 검증 대상)

---

## 다음 단계 제안

1. **차크라 카카시와 PDSA의 연동 정의** — 차크라 카카시는 토큰 회고를, sage-deming은 작업 회고를 한다. 두 회고가 한 작업에 동시 부착되는 케이스의 출력 순서/형식 정리 필요.
2. **두 번째 현자 영입 후보 결정** — 마틴 파울러(아키텍처) 또는 E.F. 코드(데이터베이스). 사용자 요청 대기.
3. **PDSA 블록 부착을 SKILL.md 절차에 강제** — 현재는 sage-deming.md에만 명시. SKILL.md "Mode A" 절차에도 "결과 보고 직전 PDSA 블록 부착" 한 줄 추가하는 것이 안전.
4. **README에 "두꺼비 소환술" 섹션 추가** — 사용자에게 비기 노출. 정원지기/사륜안과 나란히 소개.

---

## 참조

- [세계관 정전](../../knowledge/lore/naruto-worldview.md)
- [PDSA 영문 정전](../../knowledge/methodology/pdsa-deming.en.md)
- [기본 평가 운용 규칙](../../knowledge/methodology/evaluation-base-pdsa.md)
- [데밍 현자 에이전트](../../agents/sage-deming.md)
- [두꺼비 소환술 엔진](../../engine/toad-summoning.md)
- [v1.4.0 버전 히스토리](../../docs/v1.4.0.md)
