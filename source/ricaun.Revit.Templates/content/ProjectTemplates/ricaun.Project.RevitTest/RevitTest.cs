using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

namespace ProjectTemplates
{
    public class RevitTests
    {
        protected Application application;

        [OneTimeSetUp]
        public void Setup(Application application)
        {
            this.application = application;
        }

        [Test]
        public void RevitTests_VersionName()
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionName);
        }
    }
}
