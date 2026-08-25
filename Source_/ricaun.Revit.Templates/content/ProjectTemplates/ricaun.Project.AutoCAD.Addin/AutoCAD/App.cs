using ricaun.AutoCAD.UI;
using ProjectTemplates.AutoCAD;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;

[assembly: ExtensionApplication(typeof(App))]

namespace ProjectTemplates.AutoCAD
{
    public class App : ExtensionApplication
    {
        private RibbonPanel ribbonPanel;
        public override void OnStartup(RibbonControl ribbonControl)
        {
            ribbonPanel = ribbonControl.CreateOrSelectPanel("ProjectTemplates");
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