using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

<!--#if (IsTypeNone)
class Build : NukeBuild, IPublish
{
    // string IHazMainProject.MainName => "ProjectName";
    public static int Main() => Execute<Build>(x => x.From<IPublish>().Build);
}
#endif-->
<!--#if (IsTypePack)
class Build : NukeBuild, IPublishPack
{
    // string IHazMainProject.MainName => "ProjectName";
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}
#endif-->
<!--#if (IsTypeRevit)
class Build : NukeBuild, IPublishRevit
{
    // string IHazMainProject.MainName => "ProjectName";
    // string IHazRevitPackageBuilder.Application => "Revit.App";
    public static int Main() => Execute<Build>(x => x.From<IPublishRevit>().Build);
}
#endif-->
< !--#if (IsTypeAutoCAD)
class Build : NukeBuild, IPublishAutoCAD
{
    // string IHazMainProject.MainName => "ProjectName";
    public static int Main() => Execute<Build>(x => x.From<IPublishAutoCAD>().Build);
}
#endif-->