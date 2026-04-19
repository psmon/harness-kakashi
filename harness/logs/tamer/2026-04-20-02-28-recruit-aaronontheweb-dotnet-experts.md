---
date: 2026-04-20T02:28:00+09:00
agent: tamer
type: improvement
mode: log-eval
trigger: "하네스에 Agent에 전문가 영입 그리고 문서추가 이 전문가 기준 평가 구성할것"
---

# .NET 전문가 6명 영입 (Aaronontheweb/dotnet-skills)

## 실행 요약

사용자 요청으로 `https://github.com/Aaronontheweb/dotnet-skills` 저장소를 `tmp/github/dotnet-skills/`에 clone.
구조 분석 후 상위 6개 specialist agent를 하네스에 영입하고, 30개 skill 인덱스를 knowledge 레이어에 추가.
6인 전문가 기준의 5대 관문(G1–G5) 통합 평가 체계 구성.

## 결과

### 신규 파일

- `harness/agents/akka-net-specialist.md`
- `harness/agents/dotnet-concurrency-specialist.md`
- `harness/agents/dotnet-performance-analyst.md`
- `harness/agents/dotnet-benchmark-designer.md`
- `harness/agents/docfx-specialist.md`
- `harness/agents/roslyn-incremental-generator-specialist.md`
- `harness/knowledge/aaronontheweb-dotnet-skills-index.md`
- `harness/knowledge/dotnet-expert-evaluation.md`
- `harness/docs/v1.2.0.md`

### 변경 파일

- `harness/harness.config.json` — 1.1.0 → 1.2.0, agents 배열에 6명 추가, lastUpdated 2026-04-20

### 외부 리소스

- `tmp/github/dotnet-skills/` — Aaronontheweb/dotnet-skills 전체 clone (depth=1)
  - 에이전트 6개, 스킬 30개 확인
  - MIT 라이선스

## 평가 (tamer 3축)

| 축 | 평가 | 근거 |
|----|------|------|
| 워크플로우 개선도 | **A** | 기존 5개 전문가가 커버하지 않던 Akka/벤치 설계/인크리멘털 생성기/DocFX 영역이 신규 확보됨. 위임 규칙(경계 섹션)으로 기존 전문가와 충돌 해소. |
| Claude 스킬 활용도 | **4점** | 스킬 원본은 복사하지 않고 인덱스로 참조(지식 레이어). `/skill-creator` 위임 규칙을 지켰다. 다만 아직 engine/ 워크플로가 없어 스킬을 직접 호출하는 자동화는 미완. |
| 하네스 성숙도 | **L3** | knowledge 2개 + agents 12개 구성이지만 engine 레이어가 여전히 비어 있음. G1–G5 집계 워크플로를 engine/full-review-dotnet.md 등으로 코드화하면 L4. |

### 관문 적용 샘플

프로젝트 성격별 추천 관문:
- `harness-kakashi` 자체 (문서/스킬 저장소) → **G5 only**
- Akka.NET 기반 분산 서비스 → **G1 + G2 + G3**
- Roslyn 소스 생성기 라이브러리 → **G3 + G4 + G5**

## 다음 단계 제안

1. **engine/full-review-dotnet.md** — 프로젝트 유형 감지 → 관문 자동 선정 → 전문가 순차 실행 엔진 작성
2. **engine/targeted-review-akka.md** — Akka 관련 변경만 트리거되는 타겟 리뷰 엔진
3. **기존 performance-scout와 dotnet-performance-analyst 역할 재정비** — docs/v1.2.0.md 경계 섹션에 정리했지만, 실제 사용 중 혼선이 생기면 scout를 analyst로 위임하는 라우팅 규칙을 agents/performance-scout.md에 명시
4. **업스트림 추적** — `tmp/github/dotnet-skills`를 주기적으로 `git pull`하고 skill 목록 변경 시 `aaronontheweb-dotnet-skills-index.md` 자동 갱신 스크립트 고려
5. **라이선스 고지** — 업스트림이 MIT이므로 영감 출처를 에이전트 frontmatter/본문에 명시했다. 향후 스킬 내용을 직접 복제한다면 LICENSE 동봉 필요.
