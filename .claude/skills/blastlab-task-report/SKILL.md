---
name: blastlab-task-report
description: Finish a BlastLab TASK (001-011) correctly: check scope, verify, commit, push and write the required report. Use at the end of any TASK in docs/ROADMAP.md or when asked for the TASK report.
---

# Finish a BlastLab TASK

Rules come from AGENTS.md. Work on one TASK at a time. Do not start the next TASK without confirmation.

## Before finishing
1. Check scope: `git status`. Only files that belong to the TASK may change. Do not touch unrelated files.
2. Check the architecture rules: Domain has no `UnityEngine` reference, no cycles in asmdef references, no global Singleton, no `FindObjectOfType` in runtime code.
3. Check the simulation boundary: only abstract game parameters, no real explosives, weapons, casualty or lethal-distance models.
4. Run tests with the `blastlab-unity-tests` skill and the build with `blastlab-android-build`, if the TASK touches them.
5. Check `git diff ProjectSettings` for changes made by Unity itself.

## Commit and push
Commit only when the user asks. Use this trailer:
```
Co-Authored-By: <current model name and version> <noreply@anthropic.com>
```
Push to `origin main` only when the user asks.

## Report (required format)
1. What was done.
2. Files created or changed (list).
3. Decisions and why.
4. Verification: what ran and the result. What was not verified.
5. Remaining work and known issues.
6. How the developer checks it in Unity (concrete steps).

Mark anything not run as "not verified". Never write "build successful" without a build run.
