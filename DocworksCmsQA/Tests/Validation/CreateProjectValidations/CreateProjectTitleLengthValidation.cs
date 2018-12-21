using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Pages;
using System.Diagnostics;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class CreateProjectTitleLengthValidation : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }




        [Test, Description("Verify Project Title throws an error message When User gives Invalid Length")]
        public void TC06_ValidateProjectTitleLengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                Trace.TraceInformation("");
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                addProject.ProjectTitleInvalidLength();
                String expected = "Please enter at least 5 characters";
                addProject.SelectContentType("Manual");
                String actual = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                addProject.SuccessScreenshot(addProject.INVALID_TITLE_LENGTH, "Validating Length of the Title");
                VerifyEquals(test, expected, actual, "Validation Got Successful", "Validation Got Failed");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }

        }

        [Test, Description("Verifying Whether User is able to send More Than 100 characters to the Project Title")]
        public void TC07_ValidateProjectTitleLengthWithMoreThan100Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickDashboard();
                addProject.ClickAddProject();
                addProject.ProjectLengthMoreThan100();
                addProject.SelectContentType("Manual");
                addProject.SuccessScreenshot(addProject.SIZE_EXCEED_100, "Length of the Title exceeded its limit");
                String str = addProject.GetTitleLength();
                VerifyEquals(test, "100/100", str, "Length Of Project Title got exceeded to its limit as " + str + "", "Length Of Project Title Not got exceeded to its limit as " + str + "");

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
