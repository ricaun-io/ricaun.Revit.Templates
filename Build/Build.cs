using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

class Build : NukeBuild, IPublishPack, ICompileBefore, ICompileAfter, IPrePack, ITest, ITemplateInstaller
{
    string IHazCompileBefore.Name => "ricaun.*.Sdk";
    string IHazCompileAfter.Name => "ricaun.*.Sdk.Sample";
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}
