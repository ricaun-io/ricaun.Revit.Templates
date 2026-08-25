using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ricaun.Revit.Templates.Tests.Utils;

public class DirectoryCreator : IDisposable
{
    private string currentDirectory;
    private string createdDirectory;
    public string Directory => createdDirectory;
    public DirectoryCreator(string folderName)
    {
        currentDirectory = System.IO.Directory.GetCurrentDirectory();
        createdDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), folderName);
        if (System.IO.Directory.Exists(createdDirectory))
            System.IO.Directory.Delete(createdDirectory, true);
        System.IO.Directory.CreateDirectory(createdDirectory);
        System.IO.Directory.SetCurrentDirectory(createdDirectory);
    }

    public string[] GetOutputFiles(string projectName)
    {
        return System.IO.Directory.GetFiles(Directory, $"{projectName}*.dll", SearchOption.AllDirectories)
            .Where(f => !f.Contains("\\obj\\"))
            .ToArray();
    }

    public void Dispose()
    {
        System.IO.Directory.SetCurrentDirectory(currentDirectory);
    }

}
