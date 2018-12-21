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

namespace DocworksCmsQA.Tests.OtherValidations.CreateProjectValidations
{
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class VerifyUserNavigatesToMainPageIfClicksCancel_button_while_creating_new_project : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;
        String projectName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
        }



        [Test, Description("Verifying that the user is able to navigate to the main page when the close button is clicked ")]
        public void TC51_VerifyUserNavigatesToMainPageIfClicksCancel_button_while_creating_new_project()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                projectName = "SELENIUM-Ono" + "_" + GenerateRandomNumbers(5) + System.DateTime.Now.TimeOfDay;
                addProject.EnterProjectTitle(projectName);
                addProject.SelectContentType("Manual");
                addProject.ClickClose();
                String actual1 = addProject.GetCurrentUrl();
                String expected = "https://docworksfrontendqa.azurewebsites.net/dashboard";
                //String actual1 = addProject.MainPage();
                addProject.SuccessScreenshot("Validating whether we are returning to the main page");
                VerifyEquals(test, expected, actual1, "Validation Got Successful", "Validation Got Failed");
                //VerifyText(expected, actual1 , "Verification successful", "Verification Failed");

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
            db.FindProjectAndDelete(projectName);
        }
    }
}
