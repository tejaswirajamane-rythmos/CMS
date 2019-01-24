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

namespace DocworksCmsQA.Tests.GitHub.Drafts
{
    [TestFixture, Category("Create Draft")]
    [Parallelizable]
    class CreateUpdateandDeleteProjectForGitHub : BeforeTestAfterTest
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

        [Test, Description("Verifying User is able to Add Project For GitLab  with all Fields")]
        public void TC01_ValidateCreateProjectForGitHubWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                projectName = "SELENIUMGITLAB" + GenerateRandomString(5); ;
                addProject.EnterProjectTitle(projectName);
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("GitLab");
                addProject.SelectRepository("AssetPullTest");
                addProject.EnterPublishedPath("Manual");
                addProject.EnterDescription("This is to create Project for gitlab");
                addProject.ClickCreateProject();
                addProject.SearchForProject(projectName);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot(addProject.GET_TITLE, "Project Available on Search");
                // VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                // return projectName;

                //Updating project
               

                addProject.ClickProjectSettingsButton();
              
                addProject.EnterDescription("This is to update Project Description for GitHub");
                addProject.ClickUpdateProject();
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Project Description has been updated");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }


        }
        //[Test, Description("Verifying User is able to Update Project For GitLab  with all Fields")]
        //public void TC01_ValidateUpdateProjectForGitHubWithAllFields()
        //{
        //    try
        //    {
        //        AddProjectPage addProject = new AddProjectPage(test, driver);
        //        addProject.SearchForProject(projectName);
        //        addProject.ClickProjectSettings();
        //        addProject.EnterDescription("This is to update Project for GitHub");
        //        addProject.ClickUpdateProject();


        //    }
        //    catch (Exception e)
        //    {
        //        ReportExceptionScreenshot(test, driver, e);
        //        Fail(test, e);
        //        throw;
        //    }

        //}
    }
}


