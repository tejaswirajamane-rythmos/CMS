﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Pages;
using System.Diagnostics;
using AventStack.ExtentReports;
using System.Collections.Generic;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class CreateProjectMercurial : BeforeTestAfterTest
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



        [Test, Description("Verifying User is able to Add Project For Mercurial with all Fields")]
        public void TC04_ValidateCreateProjectForMercurialWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                projectName = "SELENIUMOno" + GenerateRandomString(5);
                addProject.EnterProjectTitle(projectName);
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project for Mercurial");
                addProject.ClickCreateProject();
                //addProject.ClickNotifications();
               // String status = addProject.GetNotificationStatus();
               // addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Project Created Successfully");
               // VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot(addProject.GET_TITLE, "Project Available on Search");
                VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
              
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
