---
date: 2026-04-19
agent: harness-build
type: engine-update
mode: Mode 1 + Mode 5
---

# 플러그인에 harness-build 스킬 추가 및 README 전면 개편

## 변경 대상
1. `plugins/harness-kakashi/skills/harness-build/SKILL.md` — 신규 생성
2. `README.md` — 전면 재작성

## 변경 내용

### harness-build 플러그인 스킬 (신규)
- 마더 생성기(.claude/skills/harness-build)와 분리된 **사용자용** 빌더 스킬
- 5개 빌드 모드: 에이전트 설계, 지식 구축, 엔진 설계, 구조 검증, 버전 관리
- harness-kakashi-creator와의 역할 구분 명확화:
  - creator = 정원 사용 (꽃을 심고 가꾸기)
  - build = 정원 설계 (토양과 물길을 직접 설계)
- 선택 설치 — 기본 사용에는 creator만으로 충분

### README.md 전면 개편
- 정원 메타포 기반 온보딩 내러티브 추가
- "피라미드를 만들었을 뿐인데" 실제 사례 포함
- 2개 스킬(creator + build) 사용법 테이블
- "하네스 있을 때 vs 없을 때" 비교표
- 프로젝트 구조에 harness-build 반영
- 세 겹의 토양 설명 추가

## 비고
- plugins/에 harness-build 추가됨 — 배포판에 포함
- .claude/skills/harness-build는 마더 생성기로 별도 유지 (이 저장소 전용)
- plugins/ 내 harness-build는 사용자의 하네스를 설계하는 도구
