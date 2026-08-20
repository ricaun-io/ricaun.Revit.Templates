# ricaun.AutoCAD.Sdk

Sdk for AutoCAD API development to support multiple AutoCAD versions in a single project.

## Features

* Automatic `TargetFrameworks` or `Configuration` for AutoCAD versions.
* Automatic `Defines` for AutoCAD versions.

## Installation

To install the SDK, you need to specify in the `Sdk` attribute of the `Project` element in your project file.
```xml
<Project Sdk="ricaun.AutoCAD.Sdk/<version>">
</Project>
```

## TargetFrameworks

The `Sdk` support the following `TargetFrameworks` for AutoCAD versions:
```xml
<Project Sdk="ricaun.AutoCAD.Sdk/<version>">
  <PropertyGroup>
    <TargetFrameworks>2027;2026;2025;2024;2023;2022;2021</TargetFrameworks>
  </PropertyGroup>
</Project>
```

**The `AutoCADVersion` is set based in the `TargetFrameworks` number.**

## Configurations

The `Sdk` support `Configurations` for AutoCAD versions and the `TargetFramework` is automatically set by the `Sdk` depending on the `Configuration`:
```xml
<Project Sdk="ricaun.AutoCAD.Sdk/<version>">
  <PropertyGroup>
    <Configuration>2027;Debug 2027;2026;Debug 2026;2025;Debug 2025;2024;Debug 2024</Configuration>
  </PropertyGroup>
</Project>
```
**The `AutoCADVersion` is set based in the `Configuration` number.**

## AutoCADVersion

The property group `AutoCADVersion` is set to the AutoCAD version depending on the `TargetFrameworks` or `Configurations`.
```
<ItemGroup>
  <PackageReference Include="Chuongmep.Acad.Api.acmgd" Version="$(AutoCADVersion).*-*" IncludeAssets="build; compile" PrivateAssets="All" />
</ItemGroup>
```

### IsAutoCADVersionNetCore and IsAutoCADVersionNetFramework

These properties `IsAutoCADVersionNetCore` and `IsAutoCADVersionNetFramework` are set depending on whether the AutoCAD version is targeting .NET Core or .NET Framework.

```
<PropertyGroup Condition="$(IsAutoCADVersionNetFramework)">
  <UseWindowsForms>true</UseWindowsForms>
</PropertyGroup>
```

### Defines Constants

The defines `AUTOCAD` and `AUTOCAD<version>` are set depending on the AutoCAD version.

The `AUTOCAD<version>_OR_GREATER` defines are set for the AutoCAD version and all greater versions.

| AutoCADVersion | Defines Constants |
|--------------|-------------------|
| 2019 | AUTOCAD2019_OR_GREATER, AUTOCAD2019, AUTOCAD |
| 2021 | AUTOCAD2019_OR_GREATER, AUTOCAD2020_OR_GREATER, AUTOCAD2021_OR_GREATER, AUTOCAD2021, AUTOCAD |
| 2024 | AUTOCAD2019_OR_GREATER, AUTOCAD2020_OR_GREATER, AUTOCAD2021_OR_GREATER, AUTOCAD2022_OR_GREATER, AUTOCAD2023_OR_GREATER, AUTOCAD2024_OR_GREATER, AUTOCAD2024, AUTOCAD |
| 2027 | AUTOCAD2019_OR_GREATER, AUTOCAD2020_OR_GREATER, AUTOCAD2021_OR_GREATER, AUTOCAD2022_OR_GREATER, AUTOCAD2023_OR_GREATER, AUTOCAD2024_OR_GREATER, AUTOCAD2025_OR_GREATER, AUTOCAD2026_OR_GREATER, AUTOCAD2027_OR_GREATER, AUTOCAD2027, AUTOCAD |

By default the lowest version is set to 2019, the `AutoCADVersionMinimal` property can be set to a different version to change the lowest version for the `AUTOCAD<version>_OR_GREATER` defines:

```xml
<PropertyGroup>
  <AutoCADVersionMinimal>2019</AutoCADVersionMinimal>
</PropertyGroup>
```

## Sdk Properties

The `Sdk` sets the following properties automatically:

| Property | Value | Description |
| -------- | ----- | ----------- |
| TargetFramework | *dynamic* | Automatically sets the `TargetFramework` based on the `AutoCADVersion` property. |
| LangVersion | latest | Sets the latest C# language version |
| PlatformTarget | AnyCPU | The platform target any CPU |
| ResolveAssemblyWarnOrErrorOnTargetArchitectureMismatch | None | Ignore the warning for assembly architecture mismatch |
| Optimize | *dynamic* | Enabled for `Release` configurations. |
| DebugSymbols | *dynamic* | Enabled for `Debug` configurations. |
| DebugType | *dynamic* | `portable` for `Debug`, `none` for `Release` configurations. |

### TargetFrameworks defaults values

The `TargetFrameworks` defaults to the following values depending on the `AutoCADVersion` property:

| AutoCADVersion | TargetFramework |
|--------------|-----------------|
| 2017-2019 | net46 |
| 2019-2020 | net47 |
| 2021-2024 | net48 |
| 2025-2026 | net8.0-windows |
| 2027-2028 | net10.0-windows |
| 2029-2030 | net12.0-windows |
| 2031-2032 | net14.0-windows |

---
