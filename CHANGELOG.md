# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.11.0] / 2026-02-12
### Features
- Support Revit 2027 with `net10.0`.
### Updated
- Update to support `ricaun.Nuke` version `1.11.1` using `net10.0`.
- Update `Build.csproj` files to use `net10.0`.
- Update `ItemTemplates` and remove `: Window` in views.
- Update `tools` to support Visual Studio `18` version.
- Update `ricaun.Project.Revit.Addin` and remove `Revit 2020` and `Revit 2019` support.
- Update `ricaun.Project.AutoCAD.Addin` and remove `AutoCAD 2020` and `AutoCAD 2019` support.

## [0.10.3] / 2025-08-04
### Updated
- Update `Version` in the `Directory.Build.props` to `1.0.0-alpha`.

## [0.10.2] / 2025-07-29
### Updated
- Update readme in `ricaun.Solution.AutoCAD.Addin.Template` Solution.

## [0.10.1] / 2025-07-24
### Fixed
- Fix `ricaun.Project.RevitTest` namespace.

## [0.10.0] / 2025-07-16
### Features
- Support `AutoCAD` solution and project.
### Updated
- Add `ide.host.json` to support custom `icon` with `symbolInfo`.
- Update `icon.png` to `128x128` with dark theme disable.
- Add `ricaun.Project.AutoCAD.Addin` project template.
- Rename templates to start with `Project` or `Solution` to reorder by name.
- Rename projects to use `ProjectTemplates` as name.
- Add `%(RecursiveDir)` in the `Copy` target to copy all files/directories recursively.
- Add `DeleteNupkg` target to delete `nupkg` files in the output directory.
- Update `ricaun.Project.Nuke` to support `IsTypeAutoCAD`.

## [0.9.1] / 2025-04-10
### Updated
- Support `Revit 2026` in `ricaun.Revit.Addin.Project`. (Fix: `template.json`)

## [0.9.0] / 2025-04-09
### Features
- Support `Revit 2026` projects and solutions.
### Updated
- Change debug to include `RevitVersion` when `!NoRevitVersion`. (Fix: #21)

## [0.8.3] / 2025-04-04
### Features
- Support `Revit 2026` projects and solutions.
### Updated
- Support `Revit 2026` in `
- `.
- Support `Revit 2026` in `ricaun.Revit.Addin.Project`.
- Support `Revit 2026` in `ricaun.Solution.Revit.Addin.Template`.

## [0.8.2] / 2025-03-17
### Updated
- Update MIT License year.

## [0.8.1] / 2024-11-28
### Updated
- Fix `ricaun.Revit.Addin.Project` package id name.
- Update `ricaun.RevitTest.Project` to use multiple target frameworks by default.
- Update `ricaun.Revit.Addin.Project` to use multiple target frameworks by default.
- Update `ricaun.Solution.Revit.Addin.Template` to use multiple target frameworks by default.

## [0.8.0] / 2024-11-21
### Updated
- Add `Directory.Build.props` in the main solution.
### Build
- Update `FileSystemTasks.CopyDirectoryRecursively` to `AbsolutePathExtensions.Copy` in `Build` project.
- Update `CreateTemplateInstaller` before and after to release in `GitHub`.

## [0.7.0] / 2024-09-06
### Fixed
- Fix `Build` project install dotnet sdk to `LTS` version.
- Fix `build.sh` to use correct project name.

## [0.6.2] / 2024-05-07 - 2024-07-02
### Updated
- Remove `<ProjectGuid>{$guid1$}</ProjectGuid>` not working.
- Clear `.template.config` folder.
### Fixed
- Fix typo license

## [0.6.1] / 2024-04-15
### Features
- Remove `ProjectTemplates` from tools.
- Add `ProjectTemplates` in the `content`.
- Update `Build` to net8.0
- Update `Image` icon with cyan.

## [0.6.0] / 2024-03-25
### Features
- Support `Revit 2025` with `net8.0`
- Add `PageView`
- Remove `Revit 2017` and `Revit 2018`
- Update `Image` icon.
- Remove `ide.host.json` to fix create solution issue.

## [0.5.2] / 2023-12-22
### Added
- Add `ricaun.AppLoader` on readme

## [0.5.1] / 2023-12-05
### Features
- Remove `Resources` from the main Solution
- Update `ricaun.Revit.UI` to `0.6.0`

## [0.5.0] / 2023-04-05
### Features
- Add Revit 2024 in the base template

## [0.4.4] / 2022-11-25
### Fixed
- Fix `README` SolutionTemplates for low revit version
- `DescriptionReplace` PropertyGroup

## [0.4.3] / 2022-10-12
### Features
- Update `Readme` Template Options, ProjectTemplates and Snippets
### Fixed
- Rollback `PropertyChanged.Fody` version to `3.*`

## [0.4.2] / 2022-10-10
### Features
- Update `SolutionTemplate` Readme Installation

## [0.4.1] / 2022-08-24 - 2022-10-05
### Features
- Update `Revit.ico`
- Update `Newtonsoft.Json` version to `9.*`
- Update `PropertyChanged.Fody` version to `*`

## [0.4.0] / 2022-08-23 - 2022-08-09
### Features
- Update Icons as Dark Theme
- Update/Remove ItemTemplates
- Update Base Template - Multiple Version
- Add NoRevitVersion
- Update `ricaun.Revit.UI` version `0.3.*`

## [0.3.0] / 2022-07-26
### Features
- Add Mvvm ItemTemplates
- Add ricaun.Revit.Mvvm Reference
### Updated
- Update `ProjectTemplates` and `SolutionTemplates`
- Set `csproj` `IncludePackageReferencesDuringMarkupCompilation` to `false`

## [0.2.0] / 2022-07-09
### Updated
- Update `CreatePushButton`
### Fixed
- Fix `tools` install.cmd

## [0.1.0] / 2022-07-08
### Templates
- Solution `ricaun-revit-addin-sln`
- Solution `ricaun-revit-addin-23-20-sln`
- Solution `ricaun-revit-addin-23-17-sln`

[vNext]: ../../compare/1.0.0...HEAD
[0.11.0]: ../../compare/0.10.3...0.11.0
[0.10.3]: ../../compare/0.10.2...0.10.3
[0.10.2]: ../../compare/0.10.1...0.10.2
[0.10.1]: ../../compare/0.10.0...0.10.1
[0.10.0]: ../../compare/0.9.1...0.10.0
[0.9.1]: ../../compare/0.9.0...0.9.1
[0.9.0]: ../../compare/0.8.3...0.9.0
[0.8.3]: ../../compare/0.8.2...0.8.3
[0.8.2]: ../../compare/0.8.1...0.8.2
[0.8.1]: ../../compare/0.8.0...0.8.1
[0.8.0]: ../../compare/0.7.0...0.8.0
[0.7.0]: ../../compare/0.6.2...0.7.0
[0.6.2]: ../../compare/0.6.1...0.6.2
[0.6.1]: ../../compare/0.6.0...0.6.1
[0.6.0]: ../../compare/0.5.2...0.6.0
[0.5.2]: ../../compare/0.5.1...0.5.2
[0.5.1]: ../../compare/0.5.0...0.5.1
[0.5.0]: ../../compare/0.4.4...0.5.0
[0.4.4]: ../../compare/0.4.3...0.4.4
[0.4.3]: ../../compare/0.4.2...0.4.3
[0.4.2]: ../../compare/0.4.1...0.4.2
[0.4.1]: ../../compare/0.4.0...0.4.1
[0.4.0]: ../../compare/0.3.0...0.4.0
[0.3.0]: ../../compare/0.2.0...0.3.0
[0.2.0]: ../../compare/0.1.0...0.2.0
[0.1.0]: ../../compare/0.1.0