@ECHO OFF
powershell -ExecutionPolicy ByPass -NoProfile -File "%~dp0init.ps1" %*
timeout 1