---
date: 2026-04-19T17:00:00+09:00
agent: tamer
type: creation
mode: suggestion-tip
trigger: "dotnet/skills 전체코드 파악 후 전문가 영입"
---

# dotnet/skills 분석 기반 전문가 5명 영입

## 실행 요약

1. https://github.com/dotnet/skills 레포를 clone하여 전체 구조 분석
2. 7개 플러그인(dotnet-diag, dotnet-test, dotnet-aspnet, dotnet-upgrade, dotnet-data, dotnet-ai, dotnet-experimental) + agentic-workflows 분석
3. 30+ 스킬, 11+ 에이전트 역할에서 인사이트 추출
4. 5명의 전문가 에이전트를 제안 → 사용자 승인 → 생성 완료

## 결과

### 생성된 에이전트 (5명)
- `harness/agents/performance-scout.md` — 성능 정찰병
- `harness/agents/test-sentinel.md` — 테스트 감시병
- `harness/agents/security-guard.md` — 보안 경비병
- `harness/agents/build-doctor.md` — 빌드 의사
- `harness/agents/code-modernizer.md` — 코드 현대화 전문가

### 생성된 지식 문서
- `harness/knowledge/dotnet-skills-insights.md` — 분석 인사이트 참조

### 갱신된 파일
- `harness/harness.config.json` — agents 목록, version 1.0.0 → 1.1.0
- `harness/docs/v1.1.0.md` — 버전 히스토리

### 차용된 설계 원칙
- 2단계 분석 (Pass 1 + Pass 2)
- 심각도 3단계 (Critical/Moderate/Info)
- 보정 규칙 (Context-Aware)
- 검증 체크리스트 필수화
- 경계 명시 (하는 것/하지 않는 것)

## 평가

| 축 | 평가 | 등급 |
|----|------|------|
| 워크플로우 개선도 | 기본 tamer 1명 → 6명 팀 구성, 수행부 활용 기반 마련 | A |
| Claude 스킬 활용도 | dotnet/skills의 에이전트-스킬 패턴을 하네스 구조에 적용 | 4/5 |
| 하네스 성숙도 | knowledge(1) + agents(6) + engine(0) — 엔진 미구성 | L2 |

## 다음 단계 제안

- 엔진(engine) 워크플로우 정의: 전문가들을 조합한 "전체 점검" 엔진 생성
- 실제 프로젝트에서 수행부 테스트: 각 에이전트 트리거로 실행해보기
- dotnet-ai, dotnet-data 인사이트를 추가 전문가로 확장 검토
