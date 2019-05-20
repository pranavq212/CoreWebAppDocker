@echo off

SET CURRENT_DIR=%cd%
SET PROJECT_DIR=%CURRENT_DIR%\..\CoreWebAppDocker
SET BRANCH_NAME="develop"

echo CURRENT_DIR=%CURRENT_DIR%
echo CURRENT_DIR=%PROJECT_DIR%

call "C:/Program Files/git/bin/git.exe" merge-base master  %BRANCH_NAME% > merge.tmp
SET /p MERGE_BASE=<merge.tmp
echo %MERGE_BASE%

call "C:/Program Files/git/bin/git.exe" diff --name-only %BRANCH_NAME% %MERGE_BASE% >Delta.diff

type Delta.diff