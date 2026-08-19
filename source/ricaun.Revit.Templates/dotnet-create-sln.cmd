@ECHO OFF
CALL :CreateSolution ricaun-revit-addin-sln ricaun.RevitAddin
CALL :CreateSolution ricaun-revit-addin-sln ricaun.RevitAddin2023 --Revit2023 True
CALL :CreateSolution ricaun-revit-addin-sln ricaun.RevitAddin2024 --Revit2024 True
CALL :CreateSolution ricaun-revit-addin-sln ricaun.RevitAddin2025 --Revit2025 True --Revit2024 True
CALL :CreateSolution ricaun-revit-addin-sln ricaun.RevitAddin2026 --Revit2026 True
CALL :CreateSolution ricaun-autocad-addin-sln ricaun.AutoCADAddin
CALL :CreateSolution ricaun-autocad-addin-sln ricaun.AutoCADAddin2026 --AutoCAD2026 True
CALL :CreateSolution ricaun-autocad-addin-sln ricaun.AutoCADAddin2025 --AutoCAD2025 True --AutoCAD2024 True
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