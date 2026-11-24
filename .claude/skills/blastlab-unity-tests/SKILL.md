---
name: blastlab-unity-tests
description: Run BlastLab EditMode tests headlessly with the Unity 6000.6.10f1 CLI and read the results. Use when asked to run tests, verify compilation, or check that an asmdef or script change still builds.
---

# Run BlastLab EditMode tests

Unity: `/c/Program Files/Unity/Hub/Editor/6000.6.10f1/Editor/Unity.exe`. Requires an active license in Unity Hub; close the Editor first (one project cannot be open twice).

## Steps
1. From the repo root (`/c/Users/vadim/BlastLab`), delete an old `../tests.xml` if present.
2. Run:
   ```bash
   "/c/Program Files/Unity/Hub/Editor/6000.6.10f1/Editor/Unity.exe" -batchmode -nographics \
     -projectPath "$(pwd -W)" -runTests -testPlatform EditMode \
     -testResults "$(pwd -W)/../tests.xml" -logFile /tmp/ul/test.log
   ```
   Use a `timeout` of 600000 ms. Create `/tmp/ul` first, or pick another log path.
3. Exit code `0` means success. Exit code `198` means no license (see step 5).
4. Read the summary: `grep -oE '<test-run [^>]*' ../tests.xml`. Check `failed="0"`.
5. Compile errors: `grep -n "error CS" <log>`. A license failure shows `No valid Unity Editor license found`. Report it to the user; do not try to work around it.

## Reporting
Report the counts (`passed/failed/skipped`) and the exit code. If the run did not happen, say so. Never say "tests pass" without a run.

## Known warnings (not errors)
- "Assembly ... will not be compiled, because it has no scripts" for asmdefs that are still empty (Simulation, Presentation, Infrastructure before TASK 003+).
- `Access token is unavailable` from Licensing: harmless when the run still exits 0.
