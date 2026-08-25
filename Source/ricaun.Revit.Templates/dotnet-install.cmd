@ECHO OFF
dotnet new uninstall ricaun.Revit.Templates
for /f %%f in ('dir /b *.nupkg') do dotnet new install "%%f"
timeout 5