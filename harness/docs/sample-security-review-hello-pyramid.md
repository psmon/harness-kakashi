# Security Review: HelloPyramid

> 이 문서는 하네스의 **보안 경비병(Security Guard)** 에이전트가 실제 프로젝트를 평가한 샘플입니다.
> 하네스가 어떻게 동작하는지 이해하기 위한 참고 자료로 활용하세요.

---

## 이 문서가 만들어지기까지 — 하네스 워크플로우

아래는 이 보안 평가가 수행되기까지의 전체 과정입니다.

```
[Step 1] 하네스 초기화
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
  /harness-kakashi-creator init

  → harness/ 디렉토리 생성
  → harness.config.json (메타 설정)
  → agents/tamer.md (조련사 에이전트 — 하네스 자체를 관리)
  → knowledge/, engine/, docs/, logs/ 디렉토리 구성

[Step 2] 전문가 에이전트 영입 (개선부)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
  /harness-kakashi-creator 새 에이전트 추가해

  → 5명의 전문가 에이전트를 harness/agents/에 추가:
     performance-scout  — 성능 안티패턴 탐지
     test-sentinel      — 테스트 품질 감사
     security-guard     — 보안 취약점 점검 ← 이 문서의 주인공
     build-doctor       — 빌드 실패 분석
     code-modernizer    — 코드 현대화 가이드

  각 에이전트는 .md 파일로 정의되며, 다음을 포함합니다:
     - 역할과 점검 절차
     - 트리거 문구 (어떤 요청에 반응하는지)
     - 심각도 분류 기준
     - 평가축 (3축)
     - 검증 체크리스트

[Step 3] 프로젝트 코드 작성 (일반 개발)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
  /harness-kakashi-creator projects 하위에 닷넷 콘솔프로젝트 생성

  → projects/HelloPyramid/ 생성
  → Program.cs — "HELLO WORLD" 아스키 아트 피라미드 (173줄)
  → dotnet build 성공 확인

[Step 4] 전체 평가 수행 (수행부)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
  /harness-kakashi-creator projects/HelloPyramid 프로젝트 전체평가 수행

  → 5개 에이전트가 동시에 프로젝트 코드를 분석
  → 각 에이전트가 자신의 점검 절차에 따라 평가
  → 결과를 harness/logs/에 자동 기록
  → 이 보안 평가 문서는 그 결과에서 추출한 것입니다
```

---

## 평가 대상

| 항목 | 값 |
|------|-----|
| 프로젝트 | projects/HelloPyramid |
| 프레임워크 | .NET 10.0 (preview) |
| 파일 | Program.cs (173줄), HelloPyramid.csproj |
| 평가일 | 2026-04-19 |
| 평가 에이전트 | security-guard |

---

## 공격 표면 분석

보안 평가의 첫 단계는 **공격 표면 식별**입니다.
이 프로젝트의 공격 표면은 다음과 같습니다:

| 경로 | 존재 여부 | 설명 |
|------|----------|------|
| API 엔드포인트 | 없음 | 웹 서버 없음 |
| 사용자 입력 (args) | **존재하나 미사용** | `string[] args` 선언만 있고 참조 없음 |
| 파일 I/O | 없음 | 파일 읽기/쓰기 없음 |
| 네트워크 통신 | 없음 | HTTP, 소켓 등 없음 |
| 데이터베이스 | 없음 | DB 연결 없음 |
| 외부 의존성 | 없음 | NuGet 패키지 0개 |

**결론**: 공격 표면이 극히 제한적입니다. `Console` 출력만 수행하는 순수 콘솔 앱입니다.

---

## OWASP Top 10 점검 결과

| # | 항목 | 결과 | 비고 |
|---|------|------|------|
| A01 | Broken Access Control | 해당 없음 | 인증/인가 로직 없음 |
| A02 | Cryptographic Failures | 해당 없음 | 암호화 사용 없음 |
| A03 | Injection | **안전** | args 미사용, 문자열은 모두 하드코딩 상수 |
| A04 | Insecure Design | 해당 없음 | 비즈니스 로직 없음 |
| A05 | Security Misconfiguration | 해당 없음 | 설정 파일 없음 |
| A06 | Vulnerable Components | **Info** | .NET 10 preview SDK — 아래 상세 |
| A07 | Auth Failures | 해당 없음 | 인증 없음 |
| A08 | Data Integrity Failures | 해당 없음 | 역직렬화 없음 |
| A09 | Logging Failures | 해당 없음 | 로깅 없음 |
| A10 | SSRF | 해당 없음 | 외부 요청 없음 |

---

## 발견사항

### S-01. Preview SDK 사용

| 항목 | 값 |
|------|-----|
| 심각도 | **Low** |
| 영향 | 프로덕션 배포 시 지원 정책 범위 밖 |
| 위치 | HelloPyramid.csproj:L5 |
| OWASP | A06 — Vulnerable and Outdated Components |

**현재 상태:**
```xml
<TargetFramework>net10.0</TargetFramework>
```

.NET 10.0은 아직 preview 단계입니다. Preview SDK는:
- 보안 패치가 GA(정식 출시) 대비 늦을 수 있음
- 프로덕션 환경에서는 Microsoft 지원 정책 범위 밖

**수정안:**
- 학습/데모 목적이라면 현재 상태 유지 가능
- 프로덕션 배포 시 안정 버전(net9.0 등)으로 전환 권장

---

## 보안 강점

이 프로젝트에서 확인된 보안 모범 사례:

1. **외부 입력 없음** — `args`를 선언만 하고 사용하지 않아 인젝션 경로 차단
2. **외부 의존성 없음** — 서드파티 NuGet 패키지 0개, 공급망 공격 표면 제로
3. **하드코딩 상수만 사용** — 모든 문자열이 컴파일 타임 상수, 런타임 조작 불가
4. **네트워크 미사용** — 외부 통신 없어 SSRF, 데이터 유출 경로 없음
5. **Nullable 활성화** — NullReferenceException 방지 컴파일러 지원

---

## 3축 평가

| 축 | 등급 | 근거 |
|----|------|------|
| OWASP 커버리지 | **A** | Top 10 전 항목 점검 완료, 해당 항목 모두 안전 |
| 입력 검증 완전성 | **5/5** | 외부 입력 자체가 없어 검증 불필요 |
| 수정 긴급도 분류 | **100%** | 유일한 발견(S-01)이 Low로 적절히 분류됨 |

### 종합 보안 등급: **A**

---

## 부록: Security Guard 에이전트란?

`harness/agents/security-guard.md`에 정의된 하네스 에이전트입니다.

**점검 절차:**
1. 공격 표면 식별 — API, 입력, 파일, 네트워크 경로 매핑
2. OWASP Top 10 기반 점검 — 10개 항목 전수 스캔
3. 입력 검증 완전성 — 타입, 길이, 화이트리스트, 인코딩
4. 파일 처리 보안 — 크기, MIME, 매직 바이트, 경로 순회
5. 분류 및 보고 — Critical/High/Medium/Low 심각도 분류

**트리거 문구:**
```
/harness-kakashi-creator 보안 점검해
/harness-kakashi-creator 취약점 분석해
/harness-kakashi-creator security review
```

이 에이전트는 코드 레벨 보안 취약점을 탐지하고 수정안을 제시합니다.
침투 테스트 실행이나 인프라 보안 점검은 수행하지 않습니다.
