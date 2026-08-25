using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace $rootnamespace$
{
    public class $safeitemname$ : IExternalEventHandler
    {
        /// <summary>
        /// This method is called to handle the external event.
        /// </summary>
        /// <param name="uiapp"></param>
        public void Execute(UIApplication uiapp)
        {

        }

        /// <summary>
        /// String identification of the event handler.
        /// </summary>
        public string GetName()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Create <see cref="Autodesk.Revit.UI.ExternalEvent"/> a new <see cref="$safeitemname$"/>
        /// </summary>
        public static ExternalEvent Create()
        {
            return ExternalEvent.Create(new $safeitemname$());
        }
    }
}