using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace $rootnamespace$
{
    [Transaction(TransactionMode.Manual)]
    public class $safeitemname$ : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;
            
            return Result.Succeeded;
        }
    }
}