using ricaun.AutoCAD.UI;
using SolutionTemplates.AutoCAD;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;

[assembly: ExtensionApplication(typeof(App))]

namespace SolutionTemplates.AutoCAD
{
    public class App : ExtensionApplication
    {
        private RibbonPanel ribbonPanel;
        public override void OnStartup(RibbonControl ribbonControl)
        {
            ribbonPanel = ribbonControl.CreateOrSelectPanel("SolutionTemplates");
            ribbonPanel.CreateButton("Command")
                .SetCommand(Commands.Command.ThemeChange)
                .SetLargeImage("Resources/Cube-Grey-Light.tiff");
        }

        public override void OnShutdown(RibbonControl ribbonControl)
        {
            ribbonPanel?.Remove();
        }
    }

}