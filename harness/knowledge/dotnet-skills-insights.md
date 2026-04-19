---
source: https://github.com/dotnet/skills
analyzed: 2026-04-19
purpose: 에이전트 설계 참조 — dotnet/skills 레포 분석 인사이트
---

# dotnet/skills 분석 인사이트

## 레포 개요

Microsoft의 공식 .NET 스킬 플러그인 저장소. 7개 플러그인, 30+ 스킬, 11+ 에이전트 역할을 포함.

## 플러그인 구조

| 플러그인 | 영역 | 스킬 수 | 영입된 전문가 |
|---------|------|---------|-------------|
| dotnet-diag | 성능 진단, 디버깅 | 7 | performance-scout |
| dotnet-test | 테스트 품질, 마이그레이션 | 11 | test-sentinel |
| dotnet-aspnet | 웹 보안, OpenTelemetry | 2 | security-guard |
| dotnet-msbuild (agentic-workflows) | 빌드 분석 | 3 | build-doctor |
| dotnet-upgrade | 프레임워크 마이그레이션 | 6 | code-modernizer |
| dotnet-ai | AI/ML 기술 선택 | 5 | (참조만) |
| dotnet-data | EF Core 최적화 | 1 | (참조만) |
| dotnet-experimental | 실험적 테스트 분석 | 7 | (test-sentinel에 통합) |

## 핵심 설계 패턴

### 1. 에이전트-스킬 분리
- 에이전트: 워크플로우 조율자 (무엇을 언제 할지)
- 스킬: 실행 전문가 (구체적 작업 수행)

### 2. 2단계 필수 분석 (Pass 1 + Pass 2)
- Pass 1: 직접 분석 (도구 없이 코드 읽기)
- Pass 2: 스킬/도구 기반 심화 분석
- 중복 제거: Pass 2에서는 새 발견만 보고

### 3. 심각도 3단계 분류
- Critical: 즉시 수정 필수 (데드락, 보안 구멍)
- Moderate/High: 개선 기회 (성능 2-10배, 보안 위험)
- Info/Low: 참고 사항 (패턴 해당하나 영향 낮음)

### 4. 보정 규칙 (Context-Aware Calibration)
- 테스트 유형에 따라 심각도 조정 (integration vs unit)
- 도메인 위험도 반영 (결제 로직 > 로깅)
- 스케일 기반 상향 (50+ 인스턴스 → 체계적 이슈)

### 5. Coordinator-Worker 패턴 (Agentic Workflows)
- Orchestrator: 신호 수집 + 워커 디스패치 (최대 10 병렬)
- Worker: Stateless, 개별 이슈 심층 분석
- Groomer: 결과 집계 + 대시보드 유지

### 6. 검증 체크리스트 필수화
- 모든 스킬에 `## Validation` 체크리스트 포함
- 완료 기준을 명시적으로 정의
- AI 한계 면책 고지 포함

## 평가 체계 참조

### 테스트 냄새 19개 카테고리 (testsmells.org 기반)
### 빌드 안티패턴 AP-01~AP-21
### Pseudo-mutation 6개 유형
### 단정문 12개 카테고리
### 파일 업로드 보안 6단계 검증

상세 내용은 각 에이전트 정의 파일 참조.
