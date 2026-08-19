@ECHO OFF
CALL :CreateSolution ricaun-nuke-project ricaun.Build
CALL :CreateSolution ricaun-revit-addin-project ricaun.RevitAddin.Project
CALL :CreateSolution ricaun-revit-addin-project ricaun.RevitAddin.Project2025 --Revit2025 True --Revit2024 True
CALL :CreateSolution ricaun-autocad-addin-project ricaun.AutoCAD.Project
CALL :CreateSolution ricaun-autocad-addin-project ricaun.AutoCAD.Project2025 --AutoCAD2025 True --AutoCAD2024 True
CALL :CreateSolution ricaun-revittest-project ricaun.RevitTest.Project
CALL :CreateSolution ricaun-revittest-project ricaun.RevitTest.Project2025 --Revit2025 True --Revit2024 True
CALL :CreateSolution ricaun-revittest-project ricaun.RevitTest.Project2026 --Revit2026 True --Revit2025 True
timeout 5
EXIT /B 0

:CreateSolution
echo CreateSolution - %~1 - %~2
rmdir /s /q %~2
mkdir %~2
cd %~2
dotnet new %~1 -n %~2 %~3 %~4 %~5 %~6 %~7 %~8 
cd ..
EXIT /B 0