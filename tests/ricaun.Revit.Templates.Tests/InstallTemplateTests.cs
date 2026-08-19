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
            var directory = GetMainProjectDirectory(template);
            System.Console.WriteLine(directory);
            var templateFile = Directory.GetFiles(directory, $"{template}.*.nupkg").FirstOrDefault();
            Assert.NotNull(templateFile, $"The '{template}.nupkg' file was not found.");
            await DotNetRunner.RunAsync("new", "uninstall", template);
            await DotNetRunner.RunAsync("new", "install", templateFile);
        }

        private static string GetMainProjectDirectory(string projectName)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            while (directory != null)
            {
                if (string.Equals(
                        Path.GetFileName(directory),
                        projectName,
                        System.StringComparison.OrdinalIgnoreCase))
                {
                    return directory;
                }

                directory = Path.GetDirectoryName(directory);
            }

            return null;
        }
    }
}