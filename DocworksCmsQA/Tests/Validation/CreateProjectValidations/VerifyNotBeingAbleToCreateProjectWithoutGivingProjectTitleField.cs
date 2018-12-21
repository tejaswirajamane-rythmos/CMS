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
    class VerifyNotBeingAbleToCreateProjectWithoutGivingProjectTitleField : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;
        


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
        }



        [Test, Description("Verifying that the user is unable to create project when the project name is not given")]
        public void TC48_VerifyNotBeingAbleToCreateProjectWithoutGivingProjectTitleField()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                //projectName = "SELENIUM-Ono" + "_" + GenerateRandomNumbers(5) + System.DateTime.Now.TimeOfDay;
                //addProject.EnterProjectTitle(projectName);
                addProject.NoProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project with project title as space");
                String expected = "Project Title is required";
                String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                addProject.SuccessScreenshot(addProject.INVALID_TITLE_LENGTH, "Validating the title name");
                VerifyEquals(test, expected, actual2, "Validation of  no Project title Got Successful", "Validation of no Project title Got Failed");
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
            
        }
    }
}
