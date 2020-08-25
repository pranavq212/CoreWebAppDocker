@echo off

set CURRENT_DIR=%cd%
set PROJECT_DIR=%CURRENT_DIR%\..\CoreWebAppDocker
:: set BRANCH_NAME="develop"
set BRANCH_NAME=%1
set CHECKOUT_PATH=%2

echo CURRENT_DIR=%CURRENT_DIR%
echo PROJECT_DIR=%PROJECT_DIR%
echo BRANCH_NAME=%BRANCH_NAME%

cd %CHECKOUT_PATH%

call "C:/Program Files/git/bin/git.exe" merge-base master  %BRANCH_NAME% > merge.tmp
set /p MERGE_BASE=<merge.tmp
echo %MERGE_BASE%

call "C:/Program Files/git/bin/git.exe" diff --name-only %BRANCH_NAME% %MERGE_BASE% >Delta.diff

type Delta.diff