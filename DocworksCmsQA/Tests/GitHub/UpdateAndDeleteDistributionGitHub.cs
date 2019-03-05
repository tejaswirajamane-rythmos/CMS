﻿using AventStack.ExtentReports;
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
    [TestFixture, Category("GitHub")]
    [Parallelizable]
    class UpdateAndDeleteDistributionGitHub : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;
        String projectName;
        private string distribution;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
         
            // projectName = "scriptproject21";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            projectName = db.GetOneProjectForManual_GitHub();
            distribution = db.GetOneDistributionFromProject(projectName);

        }
        [Test, Description("Verifying User is able to Update Distribution For GitHub")]
        public void TC01_ValidateUpdateDistributionForGitHub()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                AuthoringScreenEnhancements authoringScreen = new AuthoringScreenEnhancements(test, driver);
                String str = authoringScreen.GetTextOfAvailableDistribution();
                distmodule.ClickEditDistButton();
                distmodule.EnterDescription("Updating Distribution");
                distmodule.ClickUpdateDistribution();
                Console.WriteLine("Distribution has been updated");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;


            }
        }
        [Test, Description("Verifying User is able to Delete Distribution For GitHub")]
        public void TC02_ValidateDeleteDistributionForGitHub()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                AuthoringScreenEnhancements authoringScreen = new AuthoringScreenEnhancements(test, driver);
                String str = authoringScreen.GetTextOfAvailableDistribution();
                distmodule.ClickDeleteDistribution();
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
