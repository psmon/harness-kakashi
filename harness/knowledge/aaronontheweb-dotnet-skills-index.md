---
source: https://github.com/Aaronontheweb/dotnet-skills
analyzed: 2026-04-20
purpose: Aaronontheweb/dotnet-skills 레포지토리의 에이전트·스킬 인덱스 (하네스 전문가 영입 기준)
---

# Aaronontheweb/dotnet-skills 인덱스

이 저장소는 **Microsoft 공식 dotnet/skills와는 다른** 커뮤니티 플러그인이다.
Aaron Stannard(Akka.NET/Petabridge 창시자)가 큐레이션한 **5 specialized agents + 30 skills**.
프로덕션 시스템(Akka.NET, Petabridge, Sdkbin)에서 검증된 패턴에 기반.

## 레포 개요

- 루트: `https://github.com/Aaronontheweb/dotnet-skills`
- 구조: `agents/`(6개), `skills/`(30개), 플랫: skill별 디렉터리에 `SKILL.md`
- 배포: Claude Code plugin marketplace, GitHub Copilot skills, OpenCode
- 라이선스: MIT

## 영입된 전문가 (agents → harness/agents/)

| 업스트림 에이전트 | 하네스 에이전트 | 담당 영역 |
|----------------|---------------|----------|
| akka-net-specialist | `akka-net-specialist` | 액터/클러스터/퍼시스턴스/스트림 |
| dotnet-concurrency-specialist | `dotnet-concurrency-specialist` | 스레딩/async/레이스 |
| dotnet-performance-analyst | `dotnet-performance-analyst` | 프로파일/벤치 해석 |
| dotnet-benchmark-designer | `dotnet-benchmark-designer` | 벤치 설계/계측 |
| docfx-specialist | `docfx-specialist` | DocFX 빌드/린트 |
| roslyn-incremental-generator-specialist | `roslyn-incremental-generator-specialist` | 인크리멘털 소스 생성기 |

> 위임 규칙: Akka 시스템 이슈 → akka-net-specialist, 일반 .NET 동시성 → dotnet-concurrency-specialist, 결과 해석 → performance-analyst, 벤치 작성 → benchmark-designer.

## 스킬 카테고리 (30개)

### Akka.NET (5)
- `akka-net-best-practices` — EventStream vs DistributedPubSub, supervision, Props vs DI
- `akka-hosting-actor-patterns` — GenericChildPerEntityParent, message extractors, sharding
- `akka-net-testing-patterns` — Akka.Hosting.TestKit, TestProbe, persistence 테스트
- `akka-net-aspire-configuration` — Akka + Aspire, HOCON + IConfiguration
- `akka-net-management` — cluster bootstrap, health checks, K8s discovery

### C# Language (4)
- `modern-csharp-coding-standards` — records, pattern matching, value objects, no AutoMapper
- `csharp-concurrency-patterns` — Task vs Channel vs lock vs actors 선택 기준
- `api-design` — extend-only 디자인, API/wire 호환성, 버전 전략
- `type-design-performance` — sealed, readonly struct, static pure, Span<T>

### Aspire / ASP.NET Core (5)
- `aspire-service-defaults` — OTel, health, resilience, service discovery 공통화
- `aspire-integration-testing` — DistributedApplicationTestingBuilder
- `aspire-configuration` — AppHost에서 env vars로 명시적 구성 주입
- `mailpit-integration` — 로컬 이메일 테스트 컨테이너
- `mjml-email-templates` — MJML → cross-client HTML

### Data (2)
- `efcore-patterns` — NoTracking 기본값, query splitting, 마이그레이션 관리
- `database-performance` — read/write 분리, N+1 방지, AsNoTracking, row limit

### Testing (6)
- `testcontainers-integration-tests` — PostgreSQL/Redis/RabbitMQ 컨테이너
- `playwright-blazor-testing` — Blazor E2E, page objects
- `playwright-ci-caching` — 브라우저 바이너리 캐시
- `snapshot-testing` — Verify 기반
- `verify-email-snapshots` — MJML 렌더 스냅샷
- `crap-analysis` — CRAP score + ReportGenerator

### .NET 생태계 (7)
- `dotnet-project-structure` — .slnx, Directory.Build.props, CPM
- `dotnet-local-tools` — dotnet-tools.json
- `package-management` — CPM + dotnet CLI
- `serialization` — Protobuf/MessagePack vs reflection-based
- `dotnet-devcert-trust` — Linux HTTPS cert 신뢰 체인
- `ilspy-decompile` — .NET API 내부 구현 조사
- `dotnet-slopwatch` — LLM reward hacking 탐지(테스트 비활성화, 경고 억제)

### Microsoft.Extensions (2)
- `microsoft-extensions-configuration` — IOptions, IValidateOptions, 시작 시 검증
- `dependency-injection-patterns` — IServiceCollection 확장 조직화

### Observability (1)
- `OpenTelemetry-NET-Instrumentation` — Activities/Spans, Metrics, 명명 규칙

### Meta (2)
- `marketplace-publishing` — plugin.json, 릴리즈 워크플로
- `skills-index-snippets` — CLAUDE.md/AGENTS.md 라우터 스니펫 생성

## 핵심 원칙 (업스트림 선언)

- **Immutability by default** — records, readonly struct, value objects
- **Type safety** — nullable reference types, strongly-typed IDs
- **Composition over inheritance** — sealed by default, no abstract base
- **Performance-aware** — Span<T>, pooling, 지연 열거
- **Testable** — DI 전면, 순수 함수, 명시적 의존
- **No magic** — AutoMapper 금지, 리플렉션 프레임워크 금지

## 하네스에서 스킬 사용 규약

- 스킬 파일 자체는 **복사하지 않는다** — 필요 시 `/skill-creator`로 위임.
- 에이전트는 이 인덱스를 참조하여 **"이 작업은 이 스킬을 따르라"** 고 지시할 수 있다.
- 스킬 원본 경로: `tmp/github/dotnet-skills/skills/<name>/SKILL.md`
- 업스트림 업데이트 추적: `git -C tmp/github/dotnet-skills pull` 후 diff 확인.

## 라우팅 힌트 (작업 → 스킬/에이전트)

| 작업 키워드 | 참조 스킬 | 최우선 에이전트 |
|-----------|---------|--------------|
| 액터 이슈, 메시지 누락, cluster split | akka-net-* | akka-net-specialist |
| async 데드락, 레이스 | csharp-concurrency-patterns | dotnet-concurrency-specialist |
| dotTrace/dotMemory 해석 | — | dotnet-performance-analyst |
| BenchmarkDotNet 작성 | — | dotnet-benchmark-designer |
| DocFX 빌드 실패 | — | docfx-specialist |
| IIncrementalGenerator | — | roslyn-incremental-generator-specialist |
| EF Core N+1 | efcore-patterns, database-performance | (project agent) |
| Aspire 통합 테스트 | aspire-integration-testing | (project agent) |
| 이메일 템플릿 | mjml-email-templates, verify-email-snapshots | (project agent) |
