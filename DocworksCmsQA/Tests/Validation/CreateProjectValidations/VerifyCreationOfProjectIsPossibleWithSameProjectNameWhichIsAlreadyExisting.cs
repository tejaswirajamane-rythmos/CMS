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
    class VerifyCreationOfProjectIsPossibleWithSameProjectNameWhichIsAlreadyExisting : BeforeTestAfterTest
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



        [Test, Description("Verifying that the user is able to create project when the project name is same as the name of the existing project")]
        public void TC54_VerifyCreationOfProjectIsPossibleWithSameProjectNameWhichIsAlreadyExisting()
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
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Project Created Successfully");
                VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot(addProject.GET_TITLE, "Project Available on Search");
                VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                addProject.ClickAddProject();
                Info(test, "Giving name as existing project name");
                addProject.EnterProjectTitle(projectName);
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Project Created Successfully");
                VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                String actual1 = addProject.GetProjectTitle();
                addProject.SuccessScreenshot(addProject.GET_TITLE, "Project Available on Search");
                VerifyEquals(test, projectName, actual1, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                addProject.SuccessScreenshot(actual, "Project created first");
                addProject.SuccessScreenshot(actual1, "Project created with same name as first project");
                VerifyEquals(test, actual1, actual, "Created successfully the project with same name as existing project", "Creating project with same name as existing project has failed ");
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