@ECHO OFF
powershell -ExecutionPolicy ByPass -NoProfile -File "%~dp0uninstall.ps1" %*
timeout 1