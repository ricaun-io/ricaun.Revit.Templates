using NUnit.Framework;
using ricaun.Revit.Templates.Tests.Utils;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ricaun.Revit.Templates.Tests
{
    public class InstallTemplateTests
    {
        [TestCase("ricaun.Revit.Templates")]
        public async Task InstallLocalAsync(string template)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var templateFile = Directory.GetFiles(Path.Combine(directory, "..", "..", "..", ".."), $"{template}.*.nupkg", SearchOption.AllDirectories).FirstOrDefault();
            System.Console.WriteLine(directory);
            Assert.NotNull(templateFile, $"The '{template}.nupkg' file was not found.");
            await DotNetRunner.RunAsync("new", "uninstall", template);
            await DotNetRunner.RunAsync("new", "install", templateFile);
        }

        [Explicit]
        [TestCase("ricaun.Revit.Templates")]
        public async Task InstallLastVersionAsync(string template)
        {
            await DotNetRunner.RunAsync("new", "uninstall", template);
            await DotNetRunner.RunAsync("new", "install", template);
        }
    }
}