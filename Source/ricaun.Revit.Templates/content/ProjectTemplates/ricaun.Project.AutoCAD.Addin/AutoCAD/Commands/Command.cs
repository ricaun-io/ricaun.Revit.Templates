using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using System;

namespace ProjectTemplates.AutoCAD.Commands
{
    public static class Command
    {
        [CommandMethod("ThemeChange")]
        public static void ThemeChange()
        {
            Application.SetSystemVariable("COLORTHEME", 1 ^ (short)Application.GetSystemVariable("COLORTHEME"));
        }
    }
}
