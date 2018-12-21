using NUnit.Framework;
using DocWorksQA.Utilities;
using System;
using DocworksCmsQA.DatabaseScripts;

namespace DocWorksQA.Tests
{
    public class BeforeTestAfterTest : CommonMethods
    {

        public DatabaseScripts db;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            String path = GetCurrentProjectPath() + "/bin/Release/Reports";

            if (GetReporter()) { 
                InitReports(path, "CMS-Selenium");
                db = new DatabaseScripts();
            }

            

        }
       

        [OneTimeTearDown]
        public void GenerateReport()
        {
            //KillProcess();
            ReportFlusher();
        }

       

    }
}
