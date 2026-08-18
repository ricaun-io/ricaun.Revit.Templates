using NUnit.Framework;
using ricaun.Revit.Templates.Tests.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests
{
    public class SolutionTests
    {
        [TestCase("ricaun-revit-addin-sln", "ricaun.RevitAddin")]
        [TestCase("ricaun-revit-addin-sln", "ricaun.RevitAddin2025", "--Revit2025 True --Revit2024 True")]
        [TestCase("ricaun-autocad-addin-sln", "ricaun.AutoCADAddin")]
        [TestCase("ricaun-autocad-addin-sln", "ricaun.AutoCADAddin2025", "--AutoCAD2025 True --AutoCAD2024 True")]
        public async Task CreateAsync(string template, string projectName, params string[] arguments)
        {
            using (var creator = new DirectoryCreator(projectName))
            {
                var newResult = await DotNetRunner.RunNewAsync(template, projectName, arguments);
                Assert.Zero(newResult);

                var directory = creator.Directory;
                var solutionFile = Directory.GetFiles(directory, "*.sln").FirstOrDefault() ?? Directory.GetFiles(directory, "*.slnx").FirstOrDefault();
                Assert.IsNotNull(solutionFile, "File '.sln' not exist.");
                var buildResult = await DotNetRunner.RunBuildAsync(solutionFile);
                Assert.Zero(buildResult);
            }
        }
    }
}