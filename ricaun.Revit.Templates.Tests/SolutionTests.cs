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
        [TestCase("ricaun-autocad-addin-sln", "ricaun.AutoCADAddin")]
        public async Task CreateAsync(string template, string projectName, params string[] arguments)
        {
            using (var creator = new DirectoryCreator(projectName))
            {
                var newResult = await DotNetRunner.RunNewAsync(template, projectName, arguments);
                Assert.Zero(newResult);

                var directory = creator.Directory;
                var buildFile = Directory.GetFiles(directory, "build.cmd").FirstOrDefault();
                if (buildFile is null) Assert.Fail("File 'build.cmd' not exist.");
                var cmdResult = await CmdRunner.RunAsync(buildFile);
                Assert.Zero(cmdResult);
            }
        }
    }
}