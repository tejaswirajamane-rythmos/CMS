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
    class RenameNodeForGitHub : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        string projectName;
        string distribution;
        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = "SELENIUMGITHUBKCBVJ";
            // projectName = "SELENIUMGITLABVHRIO ";
            //projectName = "SELENIUMOnoITBPH";

            // projectName = db.GetOneProjectForManual_GitHub();

            // distribution = db.GetOneDistributionFromProject(projectName);
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
        }
        [Test, Description("Verify User is able to Rename Node Under Tree")]
        class GitHub_5_ValidateOfCreateDraftUpdateAndDeleteDraft
        {
        }
    }
}
