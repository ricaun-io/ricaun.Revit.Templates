using NUnit.Framework;
using ricaun.Revit.Templates.Tests.Utils;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests
{
    public class ProjectTests
    {
        [TestCase("ricaun-nuke-project")]
        [TestCase("ricaun-revit-addin-project")]
        [TestCase("ricaun-autocad-addin-project")]
        [TestCase("ricaun-revittest-addin-project")]
        public async Task HelpAsync(string template)
        {
            await DotNetRunner.RunAsync("new", template, "--help");
        }

        [TestCase("ricaun-nuke-project", "ricaun.Build", 1)]
        [TestCase("ricaun-revit-addin-project", "ricaun.RevitAddin.Project", 7)]
        [TestCase("ricaun-revit-addin-project", "ricaun.RevitAddin.Project2025", 2, "--TargetFrameworks 2025 2024")]
        [TestCase("ricaun-autocad-addin-project", "ricaun.AutoCADAddin.Project", 7)]
        [TestCase("ricaun-autocad-addin-project", "ricaun.AutoCADAddin.Project2025", 2, "--TargetFrameworks 2025 2024")]
        [TestCase("ricaun-revittest-project", "ricaun.RevitTest.Project", 7)]
        [TestCase("ricaun-revittest-project", "ricaun.RevitTest.Project2025", 2, "--TargetFrameworks 2025 2024")]
        public async Task CreateAsync(string template, string projectName, int expectedAssemblyCount, params string[] arguments)
        {
            var assemblyFiles = await RunBuildAsync(template, projectName, arguments);
            Assert.AreEqual(expectedAssemblyCount, assemblyFiles.Length);
        }

        [TestCase("ricaun-revit-addin-project", "ricaun.RevitAddin.Project.Configuration")]
        [TestCase("ricaun-autocad-addin-project", "ricaun.AutoCADAddin.Project.Configuration")]
        [TestCase("ricaun-revittest-project", "ricaun.RevitTest.Project.Configuration")]
        public async Task CreateConfigurationAsync(string template, string projectName)
        {
            var assemblyFiles = await RunBuildAsync(template, projectName, null, (creator) =>
            {
                var directory = creator.Directory;
                var csprojFile = Directory.GetFiles(directory, "*.csproj").FirstOrDefault();
                var content = File.ReadAllText(csprojFile);
                content = Regex.Replace(content,
                    @"^\s*<TargetFrameworks>.*?</TargetFrameworks>\s*$",
                    "    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>",
                    RegexOptions.Multiline);
                File.WriteAllText(csprojFile, content);
            });
            Assert.AreEqual(1, assemblyFiles.Length);

            var assembly = assemblyFiles[0];
            var directoryName = Path.GetFileName(Path.GetDirectoryName(assembly));
            Assert.AreEqual(DateTime.Now.Year.ToString(), directoryName, "The output directory name should be the current year.");
        }

        private static async Task<string[]> RunBuildAsync(string template, string projectName, string[] arguments, Action<DirectoryCreator> actionBeforeBuild = null)
        {
            using (var creator = new DirectoryCreator(projectName))
            {
                var newResult = await DotNetRunner.RunNewAsync(template, projectName, arguments);
                Assert.Zero(newResult);

                var directory = creator.Directory;
                var csprojFile = Directory.GetFiles(directory, "*.csproj").FirstOrDefault();
                Assert.IsNotNull(csprojFile, "File '.csproj' not exist.");

                actionBeforeBuild?.Invoke(creator);

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