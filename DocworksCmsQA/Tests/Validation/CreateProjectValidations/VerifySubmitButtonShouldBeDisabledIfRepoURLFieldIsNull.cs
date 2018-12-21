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
    class VerifySubmitButtonShouldBeDisabledIfRepoURLFieldIsNull : BeforeTestAfterTest
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



        [Test, Description("Verifying that the submit button should be disabled if the RepoUrl field is null")]
        public void TC46_VerifySubmitButtonShouldBeDisabledIfRepoURLFieldIsNull()
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
                addProject.SelectSourceControlProviderType("Ono");
                //addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.SuccessScreenshot(addProject.MERCURIAL_REPO_PATH, "Validating that the Repo Path is not given");
                Boolean actual1 = addProject.CreateProjectButtonDisabled();
                addProject.SuccessScreenshot(addProject.CREATE_PROJECT_BUTTON, "Validating whether the create project button is disabled");
                VerifyEquals(test, false, actual1, "Validation Got Successful", "Validation Got Failed");
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
