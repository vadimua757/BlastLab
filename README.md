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
| BlastLab.Tests | усі модулі |

`Scripts/Core` без asmdef (Assembly-CSharp) — composition root (`Bootstrap`), бачить усі модулі.

## Запуск
Відкрити папку проєкту в Unity Hub → сцена `Assets/_BlastLab/Scenes/Bootstrap.unity`.

## Прогрес
Див. `AGENTS.md` (правила роботи) і git log.
