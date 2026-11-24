---
name: blastlab-android-build
description: Build a BlastLab Android APK headlessly with Unity 6000.6.10f1 to verify the build pipeline. Use when asked to build for Android, verify the APK, or check Android settings. Never claim a build succeeded without running it.
---

# Build BlastLab for Android (verification build)

Only a verification build. Output goes outside the repo (scratchpad), never into a committed folder.

## Prerequisites
- Unity 6000.6.10f1 with Android Build Support. The JDK, SDK and NDK are inside `Editor/Data/PlaybackEngines/AndroidPlayer` (verified on this machine).
- Unity Hub license active; Editor closed.
- Scenes in Build Settings: `Assets/_BlastLab/Scenes/MainMenu.unity` (first), `Sandbox.unity`.

## Steps
1. Create a temporary editor script in `Assets/_TempBuild/Editor/TempBuild.cs` with a static method that calls `BuildPipeline.BuildPlayer` with `BuildTarget.Android` and the two scenes. Read the output path from an environment variable, and exit with the result code.
2. Run:
   ```bash
   APK_OUT="<scratchpad>/blastlab.apk" "/c/Program Files/Unity/Hub/Editor/6000.6.10f1/Editor/Unity.exe" \
     -batchmode -nographics -projectPath "$(pwd -W)" -buildTarget Android \
     -executeMethod TempBuild.Android -logFile /tmp/ul/build.log
   ```
3. Check `grep -n "BUILD_RESULT\|Build Finished" /tmp/ul/build.log`.
4. **Delete** `Assets/_TempBuild` and its `.meta` right after the run, and check `git status` that it is gone.
5. Report the result and the APK path. Say that the APK was not run on a device.

## Not covered
- Release signing (keystore is never committed; `*.keystore` and `*.jks` are gitignored).
- Performance on real devices (profile first; see AGENTS.md).
- Unity may rewrite some ProjectSettings values on build. Review `git diff ProjectSettings` before committing and mention it.
