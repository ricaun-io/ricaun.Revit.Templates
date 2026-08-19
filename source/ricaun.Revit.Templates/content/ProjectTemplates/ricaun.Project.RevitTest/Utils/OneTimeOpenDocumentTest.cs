using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ProjectTemplates.Utils
{
    /// <summary>
    /// OneTimeOpenDocumentTest
    /// </summary>
    public class OneTimeOpenDocumentTest
    {
        protected Document document;
        protected Application application;
        protected virtual string FileName => null;

        [OneTimeSetUp]
        public void NewProjectDocument(Application application)
        {
            this.application = application;
            if (string.IsNullOrEmpty(FileName))
            {
                document = application.NewProjectDocument(UnitSystem.Metric);
                return;
            }
            document = application.OpenDocumentFile(FileName);
        }

        [OneTimeTearDown]
        public void CloseProjectDocument()
        {
            document.Close(false);
            document.Dispose();
        }
    }
}