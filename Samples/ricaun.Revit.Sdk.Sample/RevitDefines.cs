namespace ricaun.Revit.Sdk.Sample;

public class RevitDefines
{
#if REVIT2027
    public class Revit2027 { }
#endif
#if REVIT2026
    public class Revit2026 { }
#endif
#if REVIT2025
    public class Revit2025 { }
#endif
#if REVIT2024
    public class Revit2024 { }
#endif
#if REVIT2021
    public class Revit2021 { }
#endif
#if REVIT2019
    public class Revit2019 { }
#endif
#if REVIT2017
    public class Revit2017 { }
#endif
#if REVIT2027_OR_GREATER
    public class Revit2027OrGreater { }
#endif
#if REVIT2026_OR_GREATER
    public class Revit2026OrGreater { }
#endif
#if REVIT2025_OR_GREATER
    public class Revit2025OrGreater { }
#endif
#if REVIT2024_OR_GREATER
    public class Revit2024OrGreater { }
#endif
#if REVIT2021_OR_GREATER
    public class Revit2021OrGreater { }
#endif
#if REVIT2019_OR_GREATER
    public class Revit2019OrGreater { }
#endif
#if REVIT2017_OR_GREATER
    public class Revit2017OrGreater { }
#endif
#if REVIT
    public class Revit { }
#endif
#if NET
    public class RevitNET { }
#endif
#if NETFRAMEWORK
    public class RevitNETFRAMEWORK { }
#endif
#if NETCOREAPP
    public class RevitNETCOREAPP { }
#endif
#if !REVIT
#error The REVIT define is not set.
#endif
}