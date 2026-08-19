using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities.Collections;
using ricaun.Nuke.Components;
using ricaun.Nuke.Extensions;
/// <summary>
/// Create Template Manual Installer
/// </summary>
public interface ITemplateInstaller : IRelease, IHazRelease, IHazContent, ISign, INukeBuild
{
    Target TemplateInstaller => _ => _
        .TriggeredBy(Compile)
        .After(Sign)
        .Before(Release)
        .Executes(() =>
        {
            CreateTemplateInstaller(MainProject);
        });

    /// <summary>
    /// CreateTemplateInstaller
    /// </summary>
    /// <param name="project"></param>
    public void CreateTemplateInstaller(Project project)
    {
        if (!ContentDirectory.DirectoryExists())
        {
            Serilog.Log.Warning($"Skip Not found: {ContentDirectory}");
            return;
        }

        var fileName = $"{project.Name}.Installer";
        var ProjectDirectory = ReleaseDirectory / fileName;

        Globbing.GlobFiles(ContentDirectory, "*.dll")
                .ForEach(file => file.DeleteFile());

        AbsolutePathExtensions.Copy(ContentDirectory, ProjectDirectory);

        var zipFile = ReleaseDirectory / $"{fileName}.zip";
        ZipExtension.CreateFromDirectory(ProjectDirectory, zipFile);

        Serilog.Log.Information($"Create: {fileName}.zip");
    }
}