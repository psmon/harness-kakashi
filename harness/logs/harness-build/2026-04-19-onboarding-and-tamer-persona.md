---
date: 2026-04-19
agent: harness-build
type: engine-update
mode: Mode 1 + Mode 2 + Mode 3
---

# 온보딩 기능 탑재 및 정원지기 페르소나 주입

## 변경 대상
1. `plugins/.../SKILL.md` — 온보딩 모드 추가, 정원 메타포 적용
2. `plugins/.../templates/harness/agents/tamer.md` — 정원지기 카카시 페르소나
3. `plugins/.../references/tamer-agent.md` — 페르소나 반영
4. `plugins/.../templates/harness/docs/README.md` — 정원 컨셉 적용

## 변경 내용

### SKILL.md (Mode 1: 엔진 개선)
- Case 1 (하네스 없음): 기존 기술적 튜토리얼 → 정원 메타포 온보딩 안내로 교체
- Case 2 분기: tamer만 있으면 → Case 2-A 온보딩 모드 (정원 상태 안내 + 초기 전문가 제안)
- Case 2 분기: 에이전트 2명 이상 → Case 2-B 일반 안내 모드
- init Step 5: 완료 후 자동으로 온보딩 모드(Case 2-A) 진입
- 조련사 섹션: "정원지기 카카시" 명칭으로 변경, 정원 메타포 반영
- 용어 변경: "꽃을 심다(개선부)" / "꽃을 피우다(수행부)"

### tamer.md 템플릿 (Mode 3: 템플릿 수정)
- persona 필드 추가: "정원지기 카카시"
- 정원 메타포 내러티브 삽입 (세 겹의 토양, 코드플라워)
- 카카시 선생 + 사륜안 컨셉 반영

### tamer-agent.md 참조 (Mode 2: 참조 문서 수정)
- The Garden Metaphor 섹션 추가
- 사륜안(스킬 복사) 연결
- 전체 페르소나 톤 통일

### docs/README.md 템플릿 (Mode 3: 템플릿 수정)
- 정원 구조 설명으로 교체
- 호출 방법 안내 추가
- "꽃을 심다/피우다" 용어 적용

## 동기화
- plugins/ → .claude/skills/ 동기화 완료 (diff 검증 통과)

## 추가 변경 (2차)
- `plugins/.../references/onboarding-best-case.md` 신규 생성
  - 실제 harness/logs/ 4건 기반 베스트 케이스 사례 문서
  - Scene 1~4: 코드 생성 → 전체 평가 → 코칭 → 보안 리포트
  - "비개발자도 시니어 5명에게 코드 리뷰 받는 경험" 포지셔닝
  - 하네스 있을 때 vs 없을 때 비교표 포함
- `plugins/.../SKILL.md` 온보딩 절차에 베스트 케이스 인용 단계 추가 (Step 4)

## 비고
- templates/harness/agents/ 에는 tamer.md만 존재 확인 (절대 규칙 준수)
- onboarding-best-case.md는 references/에만 존재 — 기본 하네스에 설치되지 않음
- 온보딩 모드는 로그를 기록하지 않음 (안내 모드)
- 사용자가 제안을 수락하여 에이전트 생성 시에만 로그 기록 시작
