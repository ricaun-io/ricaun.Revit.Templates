using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace $rootnamespace$
{
    /// <summary>
    /// The Command will only be available on Project environment
    /// </summary>
    public class $safeitemname$ : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication uiapp, CategorySet categorySet)
        {
            if (uiapp.ActiveUIDocument == null) return false;
            if (uiapp.ActiveUIDocument.Document == null) return false;
            if (uiapp.ActiveUIDocument.Document.IsFamilyDocument) return false;

            return true;
        }
    }
}