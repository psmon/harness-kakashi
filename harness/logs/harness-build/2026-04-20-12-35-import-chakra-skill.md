---
date: 2026-04-20T12:35:00+09:00
agent: harness-build
type: engine-update
mode: 1
---

# 차크라 카카시 스킬 영입 (독립 하위 컴포넌트)

## 변경 대상

신규 추가:
- `plugins/harness-kakashi/skills/harness-chakra-kakashi/SKILL.md`
- `plugins/harness-kakashi/skills/harness-chakra-kakashi/references/chakra-masking.md`
- `plugins/harness-kakashi/skills/harness-chakra-kakashi/references/jutsu-patterns.md`
- `plugins/harness-kakashi/skills/harness-chakra-kakashi/references/claude-code-2-token-sources.md`
- `plugins/harness-kakashi/skills/harness-chakra-kakashi/logs/.gitkeep`
- `harness/docs/v1.3.0.md`

수정:
- `.claude-plugin/marketplace.json` — 0.1.0 → 1.3.0 (metadata + plugins[0])
- `plugins/harness-kakashi/.claude-plugin/plugin.json` — 0.1.0 → 1.3.0
- `harness/harness.config.json` — 1.2.0 → 1.3.0, plugins 필드 추가

동기화:
- plugins/ → `.claude/skills/harness-chakra-kakashi/` 전체 복사

## 변경 내용

### 영입 출처
- 소스: `D:\Code\AI\AgentWin\.claude\skills\harness-chakra-kakashi`
- 협업 모드 다른 브랜치(AgentWin)에서 개발 중이던 토큰 효율 감사 스킬
- 요청 사항: 우리 하네스의 **독립 하위 컴포넌트**로 편입, 플러그인 배포 핵심

### 어댑테이션
원본 SKILL.md 대비 변경점:
1. 자동 발동 트리거에서 `agent-zero`, `agent-zero-vibe` 참조 삭제 — AgentWin 전용 스킬이라 본 플러그인 사용자 환경에 부재
2. 카카시 하네스 수행부 엔진(`full-review`, `targeted-review`, `full-inspection`) 종료 트리거로 일반화
3. "하네스 연동" 섹션에 `chakra-auditor` 에이전트 미등록 시에도 단독 동작 명시
4. 본 스킬이 `harness-kakashi` 플러그인의 독립 하위 컴포넌트임을 명시
5. references 3종은 verbatim 복사 (마스킹/술법/토큰소스 모두 일반론이라 어댑테이션 불요)

### 플러그인 구조 변경
이전: `plugins/harness-kakashi/skills/` 안에 `harness-kakashi-creator` 단일 스킬
이후: 동일 위치에 `harness-chakra-kakashi` 추가 → **2-스킬 구조**

두 스킬은 서로 독립이며, 사용자는 각각 단독 호출 가능.

### 버전 정렬
이전 드리프트 상태:
- harness.config.json: 1.2.0
- marketplace.json + plugin.json: 0.1.0 (.NET 영입 작업이 플러그인 버전을 안 올렸음)

본 작업에서 세 파일을 1.3.0으로 일괄 정렬. 향후 harness-build 규칙대로 동기화 유지.

### harness.config.json 보강
`plugins` 필드 신규 추가 — 플러그인과 그 하위 스킬 구조를 config에 명시:
```json
"plugins": {
  "harness-kakashi": {
    "skills": ["harness-kakashi-creator", "harness-chakra-kakashi"]
  }
}
```

## 테스트 결과

- `.claude/skills/` 동기화 후 시스템이 새 스킬 인식 확인 (system-reminder 의 available skills 목록에 `harness-chakra-kakashi` 노출됨)
- 스킬 description이 frontmatter에서 정상 파싱됨 (트리거 문구 5종 노출)
- templates/ 영향 없음 (tamer.md만 유지) — 배포판 init 시 사용자가 받는 기본 구조 변동 없음

## 비고

- 이 영입은 **플러그인 모드** 작업. 참고 모드(AgentWin 측)와 다른 점:
  - 참고 모드: `.claude/skills/`만 신경, 플러그인 무관
  - 플러그인 모드: `plugins/` 가 source of truth, `.claude/skills/`는 로컬 테스트 미러
- 차크라가 자동 발동되려면 호출 측(수행부 엔진 등)이 명시적으로 발동 위임을 해야 함 — 본 영입에서는
  스킬 자체만 추가했고, 수행부 엔진(`harness/engine/full-review.md` 등)에 위임 호출을 삽입하는 작업은 별도 후속.
- `harness/agents/chakra-auditor.md`는 아직 생성하지 않음. 사용자가 본인 하네스에서 필요 시 등록 가능
  (스킬 단독으로 5축 감사 가능하므로 에이전트 등록은 선택).

## 후속 권고

1. (선택) 수행부 엔진 정의에 차크라 감사 위임 라인 추가: 엔진 종료 직전에 `/harness-chakra-kakashi 차크라 점검해` 호출
2. (선택) `harness/agents/chakra-auditor.md` 템플릿을 references에 두고 사용자가 필요 시 복사하도록 안내
3. (배포 준비 시) `.claude-plugin/marketplace.json`의 keywords에 "token-audit" 추가 검토
