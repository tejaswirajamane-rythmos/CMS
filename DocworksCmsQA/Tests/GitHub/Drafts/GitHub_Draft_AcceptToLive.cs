using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.Tests.GitHub.Drafts
{
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class GitHub_Draft_AcceptToLive

    {
        private IWebDriver driver;
        private AventStack.ExtentReports.ExtentTest test;
        String projectName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            projectName = "scriptproject21";

        }
        [Test, Description("Verifying User is able to do Draft Accept To Live")]
        public void TC_GitHubAcceptToLive()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
             //  test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);

                addProject.SearchForProject(projectName);
               // addProject.

            }
            catch
            {

            }
        }
    }
}
