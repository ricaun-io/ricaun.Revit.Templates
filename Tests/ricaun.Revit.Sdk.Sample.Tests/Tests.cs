using NUnit.Framework;

namespace ricaun.Revit.Sdk.Sample.Tests;

public class Tests
{
    [Test]
    public void TestDefines()
    {
        _ = typeof(RevitDefines.Revit2019OrGreater);
#if NET
        _ = typeof(RevitDefines.RevitNET);
#endif
#if NETFRAMEWORK
        _ = typeof(RevitDefines.RevitNETFRAMEWORK);
#endif
#if NETCOREAPP
        _ = typeof(RevitDefines.RevitNETCOREAPP);
#endif
    }

    [Test]
    public void Test()
    {
#if REVIT2019
        System.Console.WriteLine("2019");
#endif
#if REVIT2020
        System.Console.WriteLine("2020");
#endif
#if REVIT2021
        System.Console.WriteLine("2021");
#endif
#if REVIT2022
        System.Console.WriteLine("2022");
#endif
#if REVIT2023
        System.Console.WriteLine("2023");
#endif
#if REVIT2024
        System.Console.WriteLine("2024");
#endif
#if REVIT2025
        System.Console.WriteLine("2025");
#endif
#if REVIT2026
        System.Console.WriteLine("2026");
#endif
#if REVIT2027
        System.Console.WriteLine("2027");
#endif
    }
}