# BlastLab Sandbox

Мобільний 3D sandbox-полігон (Unity 6, URP, Android first). Лише вигадані, абстрактні ігрові сценарії.

## Вимоги
- Unity `6000.6.10f1` (див. `ProjectSettings/ProjectVersion.txt`)
- Android Build Support (IL2CPP, ARM64)

## Структура
```
Assets/_BlastLab/
  Art/ Audio/ Prefabs/ Scenes/ ScriptableObjects/ Settings/
  Scripts/{Core,Domain,Application,Presentation,Simulation,Infrastructure}
  Scenes: MainMenu (початкова), Sandbox (підлога, камера, світло)
  Tests/EditMode
```

## Assembly Definitions
| Assembly | Залежить від |
|---|---|
| BlastLab.Domain | — (без UnityEngine) |
| BlastLab.Application | Domain |
| BlastLab.Simulation | Domain |
| BlastLab.Presentation | Application, Simulation, Domain |
| BlastLab.Infrastructure | Domain, Application |
| BlastLab.Core | Domain, Application (composition root: GameBootstrapper, GameStateMachine, AppSettings) |
| BlastLab.Tests (Editor) | усі модулі |


## Запуск
Відкрити папку проєкту в Unity Hub → сцена `Assets/_BlastLab/Scenes/MainMenu.unity`.

## Прогрес
Див. `AGENTS.md` (правила роботи) і git log.

## Тести
Unity: Window ▸ General ▸ Test Runner ▸ EditMode ▸ Run All.
CLI: `Unity.exe -batchmode -nographics -projectPath <path> -runTests -testPlatform EditMode -testResults results.xml` (потрібна активована ліцензія).

## Збірка Android
File ▸ Build Profiles ▸ Android ▸ Switch Platform ▸ Build. Application ID: `com.blastlab.sandbox`, орієнтація — лише landscape, IL2CPP/ARM64. Збірка потребує JDK/SDK/NDK з Unity Hub (Android Build Support).
