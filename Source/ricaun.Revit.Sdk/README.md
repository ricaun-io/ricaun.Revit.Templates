# ricaun.Revit.Sdk

Sdk for Revit API development to support multiple Revit versions in a single project.

## Features

* Automatic `TargetFrameworks` using [TFM-Aliases](https://github.com/NuGet/Home/blob/dev/accepted/2025/Multiple-Equivalent-Framework-Support-TFM-As-Aliases.md) for Revit versions. 
* Automatic `Defines` using [or-greater-defines](https://github.com/dotnet/designs/blob/main/accepted/2020/or-greater-defines/or-greater-defines.md) for Revit versions.

## Installation

To install the SDK, you need to specify in the `Sdk` attribute of the `Project` element in your project file.
```xml
<Project Sdk="ricaun.Revit.Sdk/<version>">
</Project>
```

## TargetFrameworks

The `Sdk` support the following `TargetFrameworks` for Revit versions:
```xml
<Project Sdk="ricaun.Revit.Sdk/<version>">
  <PropertyGroup>
    <TargetFrameworks>2027;2026;2025;2024;2023;2022;2021</TargetFrameworks>
  </PropertyGroup>
</Project>
```

**The `RevitVersion` is set based in the `TargetFrameworks` number.**

## Configurations

The `Sdk` support `Configurations` for Revit versions and the `TargetFramework` is automatically set by the `Sdk` depending on the `Configuration`:
```xml
<Project Sdk="ricaun.Revit.Sdk/<version>">
  <PropertyGroup>
    <Configuration>2027;Debug 2027;2026;Debug 2026;2025;Debug 2025;2024;Debug 2024</Configuration>
  </PropertyGroup>
</Project>
```

**The `RevitVersion` is set based in the `Configuration` number.**

The `OutputPath` is automatically set between `bin\Debug\<RevitVersion>` and `bin\Release\<RevitVersion>` depending on the `Configuration` name, and the `DefineConstants` is set between `DEBUG` or `RELEASE`.

### AppendRevitVersionToOutputPath

The property `AppendRevitVersionToOutputPath` is automatically set to `true` when using the `Configuration` property. You can override this behavior by setting it to `false` in your project file.

## RevitVersion

The property group `RevitVersion` is set to the Revit version depending on the `TargetFrameworks` or `Configurations`.
```
<ItemGroup>
  <PackageReference Include="Revit_All_Main_Versions_API_x64" Version="$(RevitVersion).*-*" IncludeAssets="build; compile" PrivateAssets="All" />
</ItemGroup>
```

### IsRevitVersion

These properties `IsRevitVersionNetCore` and `IsRevitVersionNetFramework` are set depending on whether the Revit version is targeting .NET Core or .NET Framework.

```
<PropertyGroup Condition="$(IsRevitVersionNetFramework)">
  <Reference Include="System.IO.Compression" />
</PropertyGroup>
```

### Defines Constants

The defines `REVIT` and `REVIT<version>` are set depending on the Revit version.

The `REVIT<version>_OR_GREATER` defines are set for the Revit version and all greater versions.

| RevitVersion | Define | Define with or-greater |
|--------------|--------|------------------------|
| 2019 | `REVIT`, `REVIT2019` | `REVIT2019_OR_GREATER` |
| 2020 | `REVIT`, `REVIT2020` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER` |
| 2021 | `REVIT`, `REVIT2021` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER` |
| 2022 | `REVIT`, `REVIT2022` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER` |
| 2023 | `REVIT`, `REVIT2023` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER`, `REVIT2023_OR_GREATER` |
| 2024 | `REVIT`, `REVIT2024` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER`, `REVIT2023_OR_GREATER`, `REVIT2024_OR_GREATER` |
| 2025 | `REVIT`, `REVIT2025` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER`, `REVIT2023_OR_GREATER`, `REVIT2024_OR_GREATER`, `REVIT2025_OR_GREATER` |
| 2026 | `REVIT`, `REVIT2026` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER`, `REVIT2023_OR_GREATER`, `REVIT2024_OR_GREATER`, `REVIT2025_OR_GREATER`, `REVIT2026_OR_GREATER` |
| 2027 | `REVIT`, `REVIT2027` | `REVIT2019_OR_GREATER`, `REVIT2020_OR_GREATER`, `REVIT2021_OR_GREATER`, `REVIT2022_OR_GREATER`, `REVIT2023_OR_GREATER`, `REVIT2024_OR_GREATER`, `REVIT2025_OR_GREATER`, `REVIT2026_OR_GREATER`, `REVIT2027_OR_GREATER` |

By default the lowest version is set to 2019, the `RevitVersionMinimal` property can be set to a different version to change the lowest version for the `REVIT<version>_OR_GREATER` defines:

```xml
<PropertyGroup>
  <RevitVersionMinimal>2019</RevitVersionMinimal>
</PropertyGroup>
```

## AppLoader

The property `AppLoader` is used change how the `AssemblyName` is generated. 
* The `Version` keywork is used to generate the `AssemblyName` with the assembly version.
* The `Debug` keyword is used to generate the `AssemblyName` with a timestamp number. (Only available with `Debug` configuration.)
```xml
<PropertyGroup>
  <AppLoader>Debug;Version</AppLoader>
</PropertyGroup>
```
This property is used work with the plugin [ricaun.AppLoader](https://ricaun.com/AppLoader/).

## Sdk Properties

The `Sdk` sets the following properties automatically:

| Property | Value | Description |
| -------- | ----- | ----------- |
| TargetFramework | *dynamic* | Automatically sets the `TargetFramework` based on the `RevitVersion` property. |
| LangVersion | latest | Sets the latest C# language version |
| PlatformTarget | AnyCPU | The platform target any CPU |
| ResolveAssemblyWarnOrErrorOnTargetArchitectureMismatch | None | Ignore the warning for assembly architecture mismatch |
| Optimize | *dynamic* | Enabled for `Release` configurations. |
| DebugSymbols | *dynamic* | Enabled for `Debug` configurations. |
| DebugType | *dynamic* | `portable` for `Debug`, `none` for `Release` configurations. |

### TargetFrameworks defaults values

The `TargetFrameworks` defaults to the following values depending on the `RevitVersion` property:

| RevitVersion | TargetFramework |
|--------------|-----------------|
| 2017-2018 | net46 |
| 2019-2020 | net47 |
| 2021-2024 | net48 |
| 2025-2026 | net8.0-windows |
| 2027-2028 | net10.0-windows |
| 2029-2030 | net12.0-windows |
| 2031-2032 | net14.0-windows |

---