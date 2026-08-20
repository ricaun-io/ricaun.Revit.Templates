# ricaun.Revit.Sdk

Sdk for Revit API development to support multiple Revit versions in a single project.

## Features

* Automatic `TargetFrameworks` or `Configuration` for Revit versions.
* Automatic `Defines` for Revit versions.

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
    <TargetFrameworks>2027;2026;2025;2024;2023;2022;2021;2020;2019</TargetFrameworks>
  </PropertyGroup>
</Project>
```

**The `RevitVersion` is set based in the `TargetFrameworks` number.**

## Configurations

The `Sdk` support `Configurations` for Revit versions and the `TargetFramework` is automatically set by the `Sdk` depending on the `Configuration`:
```xml
<Project Sdk="ricaun.Revit.Sdk/<version>">
  <PropertyGroup>
    <Configuration>2027;Debug 2027</Configuration>
  </PropertyGroup>
</Project>
```
**The `RevitVersion` is set based in the `Configuration` number.**

## RevitVersion

The property group `RevitVersion` is set to the Revit version depending on the `TargetFrameworks` or `Configurations`.
```
<ItemGroup>
  <PackageReference Include="Revit_All_Main_Versions_API_x64" Version="$(RevitVersion).*-*" IncludeAssets="build; compile" PrivateAssets="All" />
</ItemGroup>
```

### IsRevitVersionNetCore and IsRevitVersionNetFramework

These properties `IsRevitVersionNetCore` and `IsRevitVersionNetFramework` are set depending on whether the Revit version is targeting .NET Core or .NET Framework.

```
<PropertyGroup Condition="$(IsRevitVersionNetFramework)">
  <UseWindowsForms>true</UseWindowsForms>
</PropertyGroup>
```

### Defines Constants

The defines `REVIT` and `REVIT<version>` are set depending on the Revit version.

The `REVIT<version>_OR_GREATER` defines are set for the Revit version and all greater versions.

| RevitVersion | Defines Constants |
|--------------|-------------------|
| 2019 | REVIT2019_OR_GREATER, REVIT2019, REVIT |
| 2021 | REVIT2019_OR_GREATER, REVIT2020_OR_GREATER, REVIT2021_OR_GREATER, REVIT2021, REVIT |
| 2024 | REVIT2019_OR_GREATER, REVIT2020_OR_GREATER, REVIT2021_OR_GREATER, REVIT2022_OR_GREATER, REVIT2023_OR_GREATER, REVIT2024_OR_GREATER, REVIT2024, REVIT |
| 2027 | REVIT2019_OR_GREATER, REVIT2020_OR_GREATER, REVIT2021_OR_GREATER, REVIT2022_OR_GREATER, REVIT2023_OR_GREATER, REVIT2024_OR_GREATER, REVIT2025_OR_GREATER, REVIT2026_OR_GREATER, REVIT2027_OR_GREATER, REVIT2027, REVIT |

By default the lowest version is set to 2019, the `RevitVersionMinimal` property can be set to a different version to change the lowest version for the `REVIT<version>_OR_GREATER` defines:

```xml
<PropertyGroup>
  <RevitVersionMinimal>2019</RevitVersionMinimal>
</PropertyGroup>
```

### TargetFrameworks defaults values

The `TargetFrameworks` defaults to the following values depending on the `RevitVersion` property:

| RevitVersion | TargetFramework |
|--------------|-----------------|
| 2017-2019 | net46 |
| 2019-2020 | net47 |
| 2021-2024 | net48 |
| 2025-2026 | net8.0-windows |
| 2027-2028 | net10.0-windows |
| 2029-2030 | net12.0-windows |
| 2031-2032 | net14.0-windows |

---