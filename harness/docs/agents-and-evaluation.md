# Kakashi's Harness — 전문가 및 평가 체계

> **버전**: v1.1.0 | **최종 갱신**: 2026-04-19

---

## 전문가 팀 구성

| # | 에이전트 | 한국명 | 역할 요약 | 영감 출처 |
|---|---------|--------|----------|----------|
| 0 | tamer | 조련사 | 하네스 자체를 설명/개선/평가하는 메타 에이전트 | 기본 내장 |
| 1 | performance-scout | 성능 정찰병 | 성능 안티패턴 탐지 및 최적화 권고 | dotnet-diag |
| 2 | test-sentinel | 테스트 감시병 | 테스트 품질 감사 (냄새, 갭, 단정문) | dotnet-test |
| 3 | security-guard | 보안 경비병 | OWASP 기반 보안 취약점 점검 | dotnet-aspnet |
| 4 | build-doctor | 빌드 의사 | 빌드 실패 분석 및 빌드 성능 감사 | agentic-workflows |
| 5 | code-modernizer | 현대화 전문가 | 코드 현대화 및 마이그레이션 가이드 | dotnet-upgrade |

---

## 각 전문가 상세

### 0. Tamer (조련사)

**정의 파일**: `harness/agents/tamer.md`

**역할**: 하네스 자체를 길들이고 훈련시키는 메타 에이전트. 3-Layer 구조를 점검하고 개선 방향을 제시한다.

**트리거**:
- `하네스를 업데이트해` — 구조/내용 갱신
- `하네스를 개선해` — 평가 후 개선안 도출
- `하네스를 설명해` — 현재 상태 요약
- `평가로그를 점검해` — 로그 분석 및 트렌드

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| 워크플로우 개선도 | 기존 대비 효율성 향상 | A / B / C / D |
| Claude 스킬 활용도 | 프로젝트 스킬들의 연동/활용 | 1~5점 |
| 하네스 성숙도 | knowledge/agents/engine 충실도 | L1~L5 |

**성숙도 레벨 기준**:

| 레벨 | 기준 |
|------|------|
| L1 | config + tamer만 존재 |
| L2 | agents 2명 이상, knowledge 1건 이상 |
| L3 | engine 워크플로우 1개 이상 정의 |
| L4 | 로그 10건 이상, 피드백 루프 가동 |
| L5 | 전 레이어 충실, 자체 개선 사이클 정착 |

---

### 1. Performance Scout (성능 정찰병)

**정의 파일**: `harness/agents/performance-scout.md`

**역할**: 프로젝트 코드에서 성능 안티패턴을 탐지하고 심각도별로 분류하여 실행 가능한 최적화 권고를 제시한다.

**트리거**: `성능 점검해`, `성능 분석해`, `병목 찾아줘`, `performance review`

**점검 영역**:
- 비동기 패턴 (블로킹 호출, fire-and-forget)
- 메모리 & 문자열 (불필요한 할당, 연결 루프)
- 컬렉션 & LINQ (불필요한 ToList(), 다중 열거)
- I/O & 직렬화 (동기 I/O, 버퍼링 미사용)
- 구조적 패턴 (봉인 가능 클래스, 캐싱 기회)

**2단계 필수 분석**:
1. **Pass 1** — 도구 없이 코드 직접 읽기
2. **Pass 2** — Pass 1 신호 기반 심화 스캔

**심각도 분류**:

| 등급 | 기준 | 예시 |
|------|------|------|
| Critical | 데드락, 충돌, >10배 성능 회귀 | 블로킹 호출 in async |
| Moderate | 2-10배 개선 기회 (핫패스) | 불필요한 ToList() |
| Info | 패턴 해당하나 영향 낮음 | 봉인 가능 클래스 |

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| 탐지 정확도 | 발견 수 / 실제 이슈 수 (정밀도) | A / B / C / D |
| 심각도 분류 정확성 | Critical/Moderate/Info 분류의 적절성 | 1~5점 |
| 실행 가능성 | 수정안이 즉시 적용 가능한 비율 | 0~100% |

---

### 2. Test Sentinel (테스트 감시병)

**정의 파일**: `harness/agents/test-sentinel.md`

**역할**: 테스트 코드의 품질을 다각도로 감사한다. 테스트 냄새 탐지, 테스트 갭 분석, 단정문 다양성 평가를 수행한다.

**트리거**: `테스트 품질 점검해`, `테스트 분석해`, `테스트 냄새 찾아줘`, `test quality review`

**4단계 점검 절차**:

| Phase | 내용 | 분석 기법 |
|-------|------|----------|
| 1 | 테스트 냄새 탐지 | 19개 카테고리 스캔 |
| 2 | 테스트 갭 분석 | Pseudo-mutation 기반 |
| 3 | 단정문 품질 평가 | 12개 카테고리 다양성 |
| 4 | 종합 보고 | 우선순위 정리 |

**테스트 냄새 심각도**:

| 심각도 | 항목 |
|--------|------|
| High | Conditional Logic, Mystery Guest, Sleepy Test, Empty Test, Exception Swallowing, Always-True Assertion |
| Medium | Magic Number, Sensitive Equality, Duplicate Test, Giant Test, Over-Mocking |
| Low | Meaningless Name, General Fixture, Ignored Test, Debug Leftovers |

**Pseudo-mutation 유형**:
- Boundary (< → <=), Boolean (&& → ||), Return Value (null, default)
- Exception Removal, Arithmetic (+→-), Null-Check Removal
- 점수 = Killed% / Total (Equivalent 제외)

**보정 규칙**:
- Integration 테스트 → Mystery Guest/Sleepy Test 심각도 하향
- 컨텍스트 명확한 숫자 → magic number 제외
- 예외 테스트 → low assertion count 페널티 제외

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| 테스트 냄새 탐지 | 19개 카테고리 커버리지 | A / B / C / D |
| 테스트 갭 분석 | Mutation killed 비율 | 1~5점 |
| 단정문 다양성 | 12개 카테고리 사용 비율 | 0~100% |

---

### 3. Security Guard (보안 경비병)

**정의 파일**: `harness/agents/security-guard.md`

**역할**: OWASP Top 10을 기준으로 프로젝트 코드의 보안 취약점을 점검하고 수정 방안을 제시한다.

**트리거**: `보안 점검해`, `취약점 분석해`, `보안 리뷰해`, `security review`

**OWASP Top 10 점검 항목**:

| 코드 | 항목 | 점검 내용 |
|------|------|----------|
| A01 | Broken Access Control | 인가 누락, 경로 순회, IDOR |
| A02 | Cryptographic Failures | 평문 저장, 약한 해시, 하드코딩 키 |
| A03 | Injection | SQL, OS 명령어, XSS |
| A04 | Insecure Design | 비즈니스 로직 결함, rate limiting 부재 |
| A05 | Security Misconfiguration | 디버그 모드, 기본 계정 |
| A06 | Vulnerable Components | 알려진 취약점 의존성 |
| A07 | Auth Failures | 약한 비밀번호 정책, 세션 관리 |
| A08 | Data Integrity Failures | 검증 없는 역직렬화 |
| A09 | Logging Failures | 민감 데이터 로깅 |
| A10 | SSRF | 검증 없는 외부 URL 요청 |

**파일 처리 보안 6단계** (해당 시):
1. 서버 레벨 크기 제한
2. 애플리케이션 레벨 크기 제한
3. MIME 타입 검증
4. 매직 바이트 검증
5. 안전한 파일명 생성 (UUID)
6. 저장 경로 격리

**심각도 분류**:

| 등급 | 기준 |
|------|------|
| Critical | 원격 코드 실행, 인증 우회, SQL 인젝션 |
| High | XSS, CSRF, 권한 상승, 민감 데이터 노출 |
| Medium | 정보 누출, 약한 암호화, 세션 설정 미흡 |
| Low | 불필요한 헤더 노출, 디버그 정보 잔여 |

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| OWASP 커버리지 | Top 10 중 점검된 비율 | A / B / C / D |
| 입력 검증 완전성 | 사용자 입력 경로 중 검증된 비율 | 1~5점 |
| 수정 긴급도 분류 | 심각도 분류의 적절성 | 0~100% |

---

### 4. Build Doctor (빌드 의사)

**정의 파일**: `harness/agents/build-doctor.md`

**역할**: 빌드 실패의 근본 원인을 분석하고 수정안을 제시한다. 빌드 성능을 감사하여 병목 지점을 식별한다.

**트리거**: `빌드 분석해`, `빌드 실패 원인 찾아줘`, `빌드 성능 점검해`, `build analysis`

**이중 모드**:

| 모드 | 목적 | 절차 |
|------|------|------|
| Mode A: 실패 분석 | 빌드 에러 원인 규명 | 에러 수집 → 근본 원인 → 수정안 |
| Mode B: 성능 감사 | 빌드 시간 최적화 | 구성 분석 → 병목 식별 → 최적화 권고 |

**빌드 안티패턴 (AP 코드)**:

| 코드 | 패턴 | 심각도 |
|------|------|--------|
| AP-01 | 절대 경로 하드코딩 | Critical |
| AP-02 | 빌드 출력 경로 충돌 | Critical |
| AP-03 | 순환 의존성 | Critical |
| AP-04 | 누락된 의존성 선언 | High |
| AP-05 | 불필요한 전체 재빌드 | Medium |
| AP-06 | 빌드 설정 조건 오류 | Medium |
| AP-07 | 미사용 의존성 | Low |

**성능 감사 임계값**:
- 빌드 시간 변화율 > 10% → 보고
- 병렬 처리 효율 < 70% → 플래그
- 분석기 오버헤드 > 30% → 최적화 권고
- No-op 빌드 > clean build의 10% → 증분 빌드 개선

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| 근본 원인 정확도 | 에러 코드 기반 분류 정확성 | A / B / C / D |
| 수정안 실행 가능성 | 제안이 빌드 성공으로 이어지는 비율 | 1~5점 |
| 성능 추세 감지 | 빌드 시간 변화율 임계값 감지 여부 | 0~100% |

---

### 5. Code Modernizer (코드 현대화 전문가)

**정의 파일**: `harness/agents/code-modernizer.md`

**역할**: 프로젝트 코드의 현대화 기회를 식별하고 마이그레이션 가이드를 제시한다. 호환성을 유지하면서 최신 패턴을 적용한다.

**트리거**: `코드 현대화해`, `마이그레이션 점검해`, `업그레이드 가이드해`, `modernize code`

**현대화 카테고리**:

| 카테고리 | 예시 |
|----------|------|
| 언어 기능 | 패턴 매칭, 레코드 타입, 범위 연산자 |
| API 현대화 | 폐기 API → 최신 대체 API |
| 의존성 업그레이드 | 프레임워크/라이브러리 버전 업 |
| 아키텍처 개선 | DI 패턴 적용, 정적 의존성 제거 |
| 빌드 최적화 | AOT 호환성, 트림 가능성 |

**빌드-분석-수정 반복 루프**:
```
기능 플래그 ON → 빌드 → 경고 수집 → 분류 → 수정 → 재빌드 (0 경고까지)
```

**수정 원칙**:
- 경고 억제 절대 금지 (`#pragma warning disable` 사용 불가)
- 애노테이션 우선 (타입 정보 보존)
- 점진적 적용 (한 파일/모듈씩)
- 테스트 동반 (각 변경에 검증 방법 명시)

**평가축**:

| 축 | 평가 대상 | 척도 |
|----|----------|------|
| 경고 제거율 | 마이그레이션 전후 경고 감소율 | A / B / C / D |
| 호환성 유지 | breaking change 없음 여부 | 1~5점 |
| 현대화 완성도 | 적용 가능한 패턴 중 실제 적용 비율 | 0~100% |

---

## 평가 체계 종합

### 공통 설계 원칙 (dotnet/skills에서 차용)

| 원칙 | 설명 |
|------|------|
| 2단계 분석 | Pass 1 직접 분석 + Pass 2 도구 기반 심화 |
| 심각도 3단계 | Critical / Moderate(High) / Info(Low) |
| 보정 규칙 | 컨텍스트에 따라 심각도 조정 (integration vs unit, 도메인 위험도) |
| 검증 체크리스트 | 각 에이전트에 완료 기준 명시 |
| 경계 명시 | "하는 것" / "하지 않는 것" 구분 |
| 스케일 기반 상향 | 50+ 동일 이슈 → 체계적 문제로 격상 |

### 전문가별 평가축 비교

| 에이전트 | 축 1 | 축 2 | 축 3 |
|---------|------|------|------|
| tamer | 워크플로우 개선도 (A~D) | 스킬 활용도 (1~5) | 성숙도 (L1~L5) |
| performance-scout | 탐지 정확도 (A~D) | 심각도 분류 (1~5) | 실행 가능성 (%) |
| test-sentinel | 냄새 탐지 커버리지 (A~D) | 갭 분석 점수 (1~5) | 단정문 다양성 (%) |
| security-guard | OWASP 커버리지 (A~D) | 입력 검증 완전성 (1~5) | 긴급도 분류 (%) |
| build-doctor | 원인 정확도 (A~D) | 수정안 실행 가능성 (1~5) | 성능 추세 감지 (%) |
| code-modernizer | 경고 제거율 (A~D) | 호환성 유지 (1~5) | 현대화 완성도 (%) |

### 등급 기준

**축 1 (A~D) 공통 기준**:
- **A**: 해당 영역 90% 이상 커버, 오탐 5% 미만
- **B**: 70~89% 커버, 오탐 10% 미만
- **C**: 50~69% 커버, 일부 주요 항목 누락
- **D**: 50% 미만, 핵심 영역 다수 누락

**축 2 (1~5점) 공통 기준**:
- **5**: 완벽한 분류/검증, 전문가 수준
- **4**: 대부분 정확, 경미한 개선 여지
- **3**: 보통, 일부 부정확한 분류 존재
- **2**: 미흡, 다수의 분류 오류
- **1**: 부적절, 대부분 부정확

**축 3 (%) 공통 기준**:
- 80% 이상: 우수
- 60~79%: 양호
- 40~59%: 보통
- 40% 미만: 개선 필요

---

## 트리거 빠른 참조

```
/harness-kakashi-creator 성능 점검해        → performance-scout
/harness-kakashi-creator 테스트 품질 점검해  → test-sentinel
/harness-kakashi-creator 보안 점검해        → security-guard
/harness-kakashi-creator 빌드 분석해        → build-doctor
/harness-kakashi-creator 코드 현대화해      → code-modernizer
/harness-kakashi-creator 하네스를 설명해    → tamer
/harness-kakashi-creator 하네스를 개선해    → tamer
```
