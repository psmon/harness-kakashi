---
source: harness/agents/{akka-net-specialist, dotnet-concurrency-specialist, dotnet-performance-analyst, dotnet-benchmark-designer, docfx-specialist, roslyn-incremental-generator-specialist}
written: 2026-04-20
purpose: .NET 전문가 6인 기준 평가 구성 — 하네스 수행부에서 통합 리뷰 시 사용
---

# .NET 전문가 기준 평가 체계

Aaronontheweb/dotnet-skills에서 영입한 6인의 전문가를 활용해 .NET 코드/설계/문서를 평가하는 통합 기준이다.
각 전문가는 자체 평가축(3축)을 가지며, 통합 리뷰는 아래 **5대 관문(Gate)** 으로 집계한다.

## 5대 관문 (통합 평가)

| Gate | 관문 이름 | 주관 전문가 | 통과 조건 | 실패 시 |
|------|---------|-----------|---------|--------|
| G1 | 액터/분산 건전성 | akka-net-specialist | 액터 설계 ≥ B, 분산 정합성 ≥ 3점 | 수정안 포함 재점검 |
| G2 | 동시성 안전성 | dotnet-concurrency-specialist | 공유 상태 보호율 ≥ 90%, async 정합성 ≥ B | 블로커 처리 |
| G3 | 성능/회귀 | benchmark-designer + performance-analyst | 측정 설계 ≥ B + 병목 지목 정확도 ≥ 70% | 권고 실행 |
| G4 | 소스 생성기 정합성 | roslyn-incremental-generator-specialist | 캐시 정합성 Pass + 결정론 ≥ 3점 | cache-hit 테스트 추가 |
| G5 | 문서 품질 | docfx-specialist | `warningsAsErrors` 빌드 Pass + 크로스레퍼런스 해석률 ≥ 95% | 린트 수정 |

> 프로젝트 성격에 따라 **관문 선택 적용**: 라이브러리는 G3+G4+G5, 서비스는 G1+G2+G3, 문서 저장소는 G5만.

## 전문가별 3축 평가 (세부)

### G1. akka-net-specialist

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 액터 설계 건전성 | 수명주기/감독/메시지 패턴 | A/B/C/D | ≥ B |
| 분산 정합성 | Cluster/Sharding/Persistence 구성 | 1~5점 | ≥ 3 |
| 테스트 가능성 | TestKit/TestProbe 적용 범위 | % | ≥ 60% |

### G2. dotnet-concurrency-specialist

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 공유 상태 안전성 | 보호된 경로 비율 | % | ≥ 90% |
| async 정합성 | 계층/토큰/ConfigureAwait 일관성 | A/B/C/D | ≥ B |
| 테스트 비결정성 제거 | flaky 원인 식별/수정 | 1~5점 | ≥ 3 |

### G3a. dotnet-benchmark-designer

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 측정 정확도 설계 | warmup/iteration/격리 | A/B/C/D | ≥ B |
| 도구 선택 적합성 | 시나리오 대비 도구 정합 | 1~5점 | ≥ 3 |
| 재현성/통계적 힘 | 샘플 크기, 환경 통제 | % | ≥ 80% |

### G3b. dotnet-performance-analyst

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 병목 지목 정확도 | 실제 핫스팟 대비 정합 | % | ≥ 70% |
| 회귀 판정 신뢰도 | 통계적 유의성/노이즈 통제 | A/B/C/D | ≥ B |
| 권고 실행가능성 | 구체 코드 수정 범위 | 1~5점 | ≥ 3 |

### G4. roslyn-incremental-generator-specialist

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 캐시 정합성 | equatable + 재실행 결정론 | Pass/Fail | Pass |
| 파이프라인 분해도 | Parser/Emitter/Tracking 분리 | A/B/C/D | ≥ B |
| 결정론 보장 | hint name 안정성 + 순서 통제 | 1~5점 | ≥ 3 |

### G5. docfx-specialist

| 축 | 평가 대상 | 척도 | 합격선 |
|----|----------|------|-------|
| 빌드 무결성 | `--warningsAsErrors` 통과 | Pass/Fail | Pass |
| 크로스레퍼런스 해석률 | 해석되는 링크 비율 | % | ≥ 95% |
| 마크다운 품질 | markdownlint 위반 수 | 1~5점 | ≥ 4 |

## 평가 실행 절차 (수행부)

1. 입력 분류: 대상 저장소/디렉터리/PR 범위를 식별
2. 적용 관문 선정: 프로젝트 성격에 따른 G1–G5 서브셋
3. 전문가 실행: 각 전문가의 `점검 절차` 순서대로 수행
4. 점수 집계: 전문가별 3축 점수 → 관문 통과/실패 판정
5. 통합 보고: 관문별 결과 + 전체 통과율
6. 로그 기록: `harness/logs/<agent-or-engine>/<timestamp>-<title>.md`

## 보고 템플릿 (요약)

```markdown
## 평가 결과 (v1)

- G1 액터/분산 : [PASS / FAIL — 사유]
- G2 동시성    : [PASS / FAIL — 사유]
- G3 성능/회귀 : [PASS / FAIL — 사유]
- G4 소스 생성기: [PASS / FAIL — 사유]
- G5 문서 품질  : [PASS / FAIL — 사유]

전체 통과율: n/m
우선 수정 항목 (Top 3):
1. ...
2. ...
3. ...
```

## 주의

- 평가축 점수는 **근거 포함**이 의무다. 숫자만 남기는 평가는 로그로 인정하지 않는다.
- 합격선은 프로젝트마다 조정 가능하지만, 조정 사실을 로그에 명시해야 한다.
- 관문 간 상호작용(예: G2 실패가 G3 측정 신뢰성을 훼손)은 판정에 반영한다.
