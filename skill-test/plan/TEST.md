# 카카시하네스 스킬 테스트 시나리오

## 테스트 1: 하네스 상태 확인

```
/harness-kakashi-creator 하네스 상태 확인해줘
```

**기대 결과**: harness.config.json을 읽고 현재 등록된 에이전트, 엔진 목록을 출력

## 테스트 2: 버전 동기화 검증

```
/harness-kakashi-creator 버전 동기화 상태 확인
```

**기대 결과**: marketplace.json과 plugin.json의 버전 일치 여부를 검증하고 결과 출력

## 테스트 3: 전체 리뷰 실행

```
/harness-kakashi-creator 전체 리뷰
```

**기대 결과**: full-review 엔진이 순차적으로 에이전트를 실행하고 결과를 logs/에 저장
