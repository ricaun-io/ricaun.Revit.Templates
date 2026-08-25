namespace ricaun.AutoCAD.Sdk.Sample;

public class AutoCADDefines
{
#if AUTOCAD2027
    public class AutoCAD2027 { }
#endif
#if AUTOCAD2026
    public class AutoCAD2026 { }
#endif
#if AUTOCAD2025
    public class AutoCAD2025 { }
#endif
#if AUTOCAD2024
    public class AutoCAD2024 { }
#endif
#if AUTOCAD2021
    public class AutoCAD2021 { }
#endif
#if AUTOCAD2019
    public class AutoCAD2019 { }
#endif
#if AUTOCAD2017
    public class AutoCAD2017 { }
#endif
#if AUTOCAD2027_OR_GREATER
    public class AutoCAD2027OrGreater { }
#endif
#if AUTOCAD2026_OR_GREATER
    public class AutoCAD2026OrGreater { }
#endif
#if AUTOCAD2025_OR_GREATER
    public class AutoCAD2025OrGreater { }
#endif
#if AUTOCAD2024_OR_GREATER
    public class AutoCAD2024OrGreater { }
#endif
#if AUTOCAD2021_OR_GREATER
    public class AutoCAD2021OrGreater { }
#endif
#if AUTOCAD2019_OR_GREATER
    public class AutoCAD2019OrGreater { }
#endif
#if AUTOCAD2017_OR_GREATER
    public class AutoCAD2017OrGreater { }
#endif
#if AUTOCAD
    public class AutoCAD { }
#endif
#if NET
    public class AutoCADNET { }
#endif
#if NETFRAMEWORK
    public class AutoCADNETFRAMEWORK { }
#endif
#if NETCOREAPP
    public class AutoCADNETCOREAPP { }
#endif
#if !AUTOCAD
#error The AUTOCAD define is not set.
#endif
}