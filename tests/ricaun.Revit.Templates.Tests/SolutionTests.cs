using NUnit.Framework;
using ricaun.Revit.Templates.Tests.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests
{
    public class SolutionTests
    {
        [TestCase("ricaun-revit-addin-sln", "ricaun.RevitAddin", 9)]
        [TestCase("ricaun-revit-addin-sln", "ricaun.RevitAddin2025", 2, "--TargetFrameworks 2025 2024")]
        [TestCase("ricaun-autocad-addin-sln", "ricaun.AutoCADAddin", 7)]
        [TestCase("ricaun-autocad-addin-sln", "ricaun.AutoCADAddin2025", 2, "--TargetFrameworks 2025 2024")]
        public async Task CreateAsync(string template, string projectName, int expectedAssemblyCount, params string[] arguments)
        {
            var assemblyFiles = await RunBuildAsync(template, projectName, arguments);
            Assert.AreEqual(expectedAssemblyCount, assemblyFiles.Length);
        }

        private static async Task<string[]> RunBuildAsync(string template, string projectName, params string[] arguments)
        {
            using (var creator = new DirectoryCreator(projectName))
            {
                await DotNetRunner.RunAsync("new", template, "--help");

                var newResult = await DotNetRunner.RunNewAsync(template, projectName, arguments);
                Assert.Zero(newResult);

                var directory = creator.Directory;
                var solutionFile = Directory.GetFiles(directory, "*.sln").FirstOrDefault() ?? Directory.GetFiles(directory, "*.slnx").FirstOrDefault();
                Assert.IsNotNull(solutionFile, "File '.sln' not exist.");
                var buildResult = await DotNetRunner.RunBuildAsync(solutionFile);
                Assert.Zero(buildResult);

                var assemblyFiles = GetOutputFiles(directory, projectName);

                System.Console.WriteLine($"Files build found: {assemblyFiles.Length}");
                Assert.IsNotEmpty(assemblyFiles, "File '.dll' not exist.");

                return assemblyFiles;
            }
        }

        private static string[] GetOutputFiles(string directory, string projectName)
        {
            return Directory.GetFiles(directory, $"{projectName}*.dll", SearchOption.AllDirectories)
                .Where(f => !f.Contains("\\obj\\"))
                .ToArray();
        }
    }
}