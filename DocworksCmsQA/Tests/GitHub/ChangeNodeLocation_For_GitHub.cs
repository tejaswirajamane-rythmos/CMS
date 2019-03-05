using AventStack.ExtentReports;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.Tests.GitHub
{
    class ChangeNodeLocation_For_GitHub :BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;
        String projectName;

        [OneTimeSetUp]
        public void AddProjectModule()
        {
            projectName = "seleniumtest";
            // projectName = db.GetOneProjectForManual_GitHub();

            // distribution = db.GetOneDistributionFromProject(projectName);
           // projectName = db.GetOneProjectForManual_GitHub();
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
        }
        [Test, Description("Verifying User is able to Change Node Location For GitHub")]
        public void TC01_Validate_ChangeNodeLocation_For_GitHub()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                NodesPage node = new NodesPage(test, driver);
                System.Threading.Thread.Sleep(000);
                node.ClickDropDownBtn();
                System.Threading.Thread.Sleep(2000);
                node.ChangeNodeLocation();
                System.Threading.Thread.Sleep(2000);



            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }
        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");
            CloseDriver(driver);
        }
    }
}

