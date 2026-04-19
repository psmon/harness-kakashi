# Harness

이 프로젝트의 하네스 프레임워크.

## 구조

```
harness/
├── harness.config.json   # 메타정보 (버전, 에이전트 목록)
├── knowledge/            # Layer 1: 도메인 지식
├── agents/               # Layer 2: 에이전트 역할 정의
│   └── tamer.md          # 조련사 (기본 내장)
├── engine/               # Layer 3: 워크플로우
├── docs/                 # 하네스 문서
└── logs/                 # 활동 로그
```

## 사용법

```
/harness-kakashi-creator 하네스를 설명해
/harness-kakashi-creator 하네스를 개선해
/harness-kakashi-creator 새 에이전트 추가해
```

## 샘플: 하네스가 실제로 프로젝트를 평가하는 과정

하네스가 어떻게 동작하는지 궁금하다면, 아래 샘플 문서를 참고하세요.

- [Security Review: HelloPyramid](sample-security-review-hello-pyramid.md) — 보안 경비병(Security Guard) 에이전트가 .NET 콘솔 프로젝트를 평가한 실제 사례

이 문서에는 다음 내용이 포함되어 있습니다:

1. **하네스 워크플로우 전체 흐름** — init부터 에이전트 영입, 코드 작성, 전체 평가까지 4단계
2. **공격 표면 분석** — 프로젝트의 보안 경계를 어떻게 식별하는지
3. **OWASP Top 10 점검** — 10개 항목을 하나씩 점검한 결과
4. **3축 평가** — 커버리지, 입력 검증, 심각도 분류의 정량 평가
5. **에이전트 설명** — Security Guard가 무엇이고 어떻게 트리거하는지

### 빠른 시작: 내 프로젝트도 평가받으려면?

```
# 1. 하네스 초기화 (최초 1회)
/harness-kakashi-creator init

# 2. 보안 평가만 수행
/harness-kakashi-creator 보안 점검해

# 3. 전체 평가 수행 (5개 에이전트 동시)
/harness-kakashi-creator 전체 점검해
```
