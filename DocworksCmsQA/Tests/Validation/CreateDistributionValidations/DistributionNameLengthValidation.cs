using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class TC_11_ValidateDistributionNameLengthWithLessThan5Characters : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {

            projectName = new CreateProjectsApi().CreateMercurialProject();
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }
        [Test, Description("Verify When User sends an Invalid Length to Distribution Name Then it throws an Error Message")]
        public void TC11_ValidateDistributionNamelengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
              //  project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected1 = "Please enter at least 5 characters.";
                distmodule.EnterInvalidnNameLength();
                distmodule.EnterDescription("Description");
                String actual1 = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                project.SuccessScreenshot(distmodule.INVALID_TITLE_LENGTH,  "Validating Distribution Name Length");
                VerifyEquals(test, expected1, actual1, "Validation of Length Constraints for Distribution Name Field is successful", "Validation of Length Constraints for Distribution Name Field is Not successful");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");
            CloseDriver(driver);
            db.FindProjectAndDelete(projectName);
        }

    }
}
