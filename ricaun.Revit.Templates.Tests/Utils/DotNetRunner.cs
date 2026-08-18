using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests.Utils;

public class DotNetRunner
{
    public static async Task<int> RunNewAsync(string template, string projectName, params string[] arguments)
    {
        var runArguments = new List<string>();
        runArguments.Add(template);
        runArguments.Add("-n");
        runArguments.Add(projectName);
        runArguments.AddRange(arguments);
        return await RunAsync("new", runArguments.ToArray());
    }
    public static async Task<int> RunBuildAsync(string projectPath, params string[] arguments)
    {
        var runArguments = new List<string>();
        runArguments.Add(projectPath);
        runArguments.AddRange(arguments);
        return await RunAsync("build", runArguments.ToArray());
    }
    public static async Task<int> RunAsync(string command, params string[] arguments)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"{command} {string.Join(" ", arguments)}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8,
                CreateNoWindow = true
            }
        };

        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data != null)
                Console.WriteLine(e.Data);
        };

        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data != null)
                Console.Error.WriteLine(e.Data);
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit(120000);

        return process.ExitCode;
    }
}