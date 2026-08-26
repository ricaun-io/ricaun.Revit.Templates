using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace $rootnamespace$
{
    /// <summary>
    /// The Command will be available on Project and Family environment
    /// </summary>
    public class $safeitemname$ : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication uiapp, CategorySet categorySet)
        {
            if (uiapp.ActiveUIDocument == null) return false;
            if (uiapp.ActiveUIDocument.Document == null) return false;

            return true;
        }
    }
}