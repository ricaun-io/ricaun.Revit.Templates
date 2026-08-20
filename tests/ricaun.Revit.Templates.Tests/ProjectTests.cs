using NUnit.Framework;
using ricaun.Revit.Templates.Tests.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests
{
    public class ProjectTests
    {
        [TestCase("ricaun-nuke-project", "ricaun.Build", 1)]
        [TestCase("ricaun-revit-addin-project", "ricaun.RevitAddin.Project", 7)]
        [TestCase("ricaun-revit-addin-project", "ricaun.RevitAddin.Project2025", 2, "--TargetFrameworks 2025 2024")]
        [TestCase("ricaun-autocad-addin-project", "ricaun.AutoCAD.Project", 7)]
        [TestCase("ricaun-autocad-addin-project", "ricaun.AutoCAD.Project2025", 2, "--TargetFrameworks 2025 2024")]
        [TestCase("ricaun-revittest-project", "ricaun.RevitTest.Project", 7)]
        [TestCase("ricaun-revittest-project", "ricaun.RevitTest.Project2025", 2, "--TargetFrameworks 2025 2024")]
        public async Task CreateAsync(string template, string projectName, int expectedAssemblyCount, params string[] arguments)
        {
            var assemblyFiles = await RunBuildAsync(template, projectName, arguments);
            Assert.AreEqual(expectedAssemblyCount, assemblyFiles.Length);
        }

        private static async Task<string[]> RunBuildAsync(string template, string projectName, string[] arguments)
        {
            using (var creator = new DirectoryCreator(projectName))
            {
                await DotNetRunner.RunAsync("new", template, "--help");

                var newResult = await DotNetRunner.RunNewAsync(template, projectName, arguments);
                Assert.Zero(newResult);

                var directory = creator.Directory;
                var csprojFile = Directory.GetFiles(directory, "*.csproj").FirstOrDefault();
                Assert.IsNotNull(csprojFile, "File '.csproj' not exist.");
                var buildResult = await DotNetRunner.RunBuildAsync(csprojFile);
                Assert.Zero(buildResult);

                var assemblyFiles = creator.GetOutputFiles(projectName);

                System.Console.WriteLine($"Files build found: {assemblyFiles.Length}");
                Assert.IsNotEmpty(assemblyFiles, "File '.dll' not exist.");

                return assemblyFiles;
            }
        }
    }
}