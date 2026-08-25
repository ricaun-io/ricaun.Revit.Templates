# ricaun.Revit.Templates

RevitAddin and AutoCADAddin Templates and ItemTemplates for C# Applications.

[![Visual Studio 2026](https://img.shields.io/badge/Visual%20Studio-2026-blue)](https://github.com/ricaun-io/ricaun.Revit.Templates)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/ricaun.Revit.Templates/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/ricaun.Revit.Templates/actions)

[![Templates](https://img.shields.io/nuget/v/ricaun.Revit.Templates?logo=nuget&label=Templates&color=blue)](https://www.nuget.org/packages/ricaun.Revit.Templates)
[![Revit.Sdk](https://img.shields.io/nuget/v/ricaun.Revit.Sdk?logo=nuget&label=Revit.Sdk&color=blue)](https://www.nuget.org/packages/ricaun.Revit.Sdk)
[![AutoCAD.Sdk](https://img.shields.io/nuget/v/ricaun.AutoCAD.Sdk?logo=nuget&label=AutoCAD.Sdk&color=blue)](https://www.nuget.org/packages/ricaun.AutoCAD.Sdk)

[![Create a new project](./Source/ricaun.Revit.Templates/Resources/create.png)](https://github.com/ricaun-io/ricaun.Revit.Templates)

## Installation

This package is automatically installed when using the [ricaun.AppLoader](https://ricaun.com/AppLoader/) plugin.

* Install [.Net SDK](https://dotnet.microsoft.com/download) or [Visual Studio 2026](https://visualstudio.microsoft.com/vs/)
* Run `dotnet new install ricaun.Revit.Templates` 

## SolutionTemplates

Solution Name | Short Name | Description
--------|-------------|-------------
Solution Autodesk Revit Addin Template | ricaun-revit-addin-sln | Solution for Revit C# .NET add-in project with Build
Solution Autodesk AutoCAD Addin Template | ricaun-autocad-addin-sln | Solution for AutoCAD C# .NET add-in project with Build

### Solution Autodesk Revit Addin Template

* Run `dotnet new ricaun-revit-addin-sln -n ProjectName`

#### Options
* Run `dotnet new ricaun-revit-addin-sln --help` 

Options | Description | Default
--------|-------------|--------
--Authors | Set Project Authors PropertyGroup | Authors
--Company | Set Project Company PropertyGroup | Company
--License |  Set Project License MIT | true
--Description | Set Project Description PropertyGroup | Revit Plugin $(PackageId)
--TargetFrameworks | Target Frameworks for Revit versions | 2027,2026,2025,2024,2023,2022,2021

### Solution Autodesk AutoCAD Addin Template

* Run `dotnet new ricaun-autocad-addin-sln -n ProjectName`

#### Options
* Run `dotnet new ricaun-autocad-addin-sln --help` 

Options | Description | Default
--------|-------------|--------
--Authors | Set Project Authors PropertyGroup | Authors
--Company | Set Project Company PropertyGroup | Company
--License |  Set Project License MIT | true
--Description | Set Project Description PropertyGroup | AutoCAD Plugin $(PackageId)
--TargetFrameworks | Target Frameworks for AutoCAD versions | 2027,2026,2025,2024,2023,2022,2021

## ProjectTemplates
The `ProjectTemplates` are installed automatically in `Visual Studio 2026` when [ricaun.AppLoader](https://ricaun.com/AppLoader/) plugin installs the package.

Project Name | Short Name | Description
--------|-------------|-------------
Project Autodesk Revit Addin Template | ricaun-revit-addin-project | Template for Revit C# .NET add-in project
Project Autodesk RevitTest Template | ricaun-revittest-project | Template for Revit C# .NET test project
Project Autodesk AutoCAD Addin Template | ricaun-autocad-addin-project | Template for AutoCAD C# .NET add-in project
Project Nuke Automation Template | ricaun-nuke-project | Build Nuke Automation Template

### ItemTemplates
The `ItemTemplates` are installed automatically in `Visual Studio 2026` when [ricaun.AppLoader](https://ricaun.com/AppLoader/) plugin installs the package.

#### Github
Item | Description
--------|-------------
CHANGELOG | Create CHANGELOG.md template file
LICENCE | Create LICENSE.md template file with MIT License
README | Create README.md template file

#### Revit
Item | Description
--------|-------------
App | Basic Revit Application with IExternalApplication
Command | Basic Revit Command with IExternalCommand
todo | ...

### Snippets
The `Snippets` are installed automatically in `Visual Studio 2026` when [ricaun.AppLoader](https://ricaun.com/AppLoader/) plugin installs the package.

Snippet | Description
--------|-------------
rdoc | Creates new Document statement
rdocfull | Creates new Document statement with View and Selection 
relement | Creates GetElement in Document GetElement statement
rfec | Creates new FilteredElementCollector() statement
rmpickelement | Creates new PickElement Method
rmselect | Creates new Select Method by Category
rmselectelement | Creates new Select Method by Element
rmselectelementtype | Creates new Select Method by ElementType
rparameter | Creates Get Parameter statement
rparameterif | Creates Get Parameter statement with if
rsids | Selection ElementId to Element statement
rt | Creates new Transaction() statement
rtg | Creates new TransactionGroup() statement
rapp | Creates new class App with IExternalApplication
rappdb | Creates new class AppDB with IExternalDBApplication
rcommand | Creates new class Command with IExternalCommand

## Manual Installation

Download the latest [ricaun.Revit.Templates.Install.zip](https://github.com/ricaun-io/ricaun.Revit.Templates/releases/latest) and extract the files.

* The `dotnet install.cmd` force to install file `ricaun.Revit.Templates.{version}.nupkg`.
* The `dotnet uninstall.cmd` force to uninstall `ricaun.Revit.Templates` from the `dotnet`.

### Manual Installation Tools

Inside the `tools` folder are the `install.cmd` and `uninstall.cmd` files to install/uninstall the item and snippets `Visual Studio 2026` templates.

* The `install.cmd` force to install the `ItemTemplates` and `Snippets` in the `Visual Studio 2026` user folder.
* The `uninstall.cmd` force to uninstall the `ItemTemplates` and `Snippets` in the `Visual Studio 2026` user folder.

## Release

* [Latest release](https://github.com/ricaun-io/ricaun.Revit.Templates/releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/ricaun.Revit.Templates/stargazers)!