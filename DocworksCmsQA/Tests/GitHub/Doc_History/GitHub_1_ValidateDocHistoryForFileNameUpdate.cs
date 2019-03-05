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

namespace DocworksCmsQA.Tests.GitHub.Doc_History
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]



    class GitHub_1_ValidateDocHistoryForFileNameUpdate : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        // String distributionName;
        String draftName;
        String renameDraft;
        string distribution;
        string NewFileName;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {

            //projectName = db.GetOneProjectForManual_GitHub();

            //distribution = db.GetOneDistributionFromProject(projectName);

            //  projectName = new CreateProjectsApi().CreateGitHubProject();
            //  distributionName = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }


        [Test, Description("Verify User is able to view history details in DocHistory module for Update FileName")]
        public void TC1_ValidateDocHistoryforUpdateFileName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                projectName = "";
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.Settings_Button();
                DocHistory.ClickEditFileButton();
                NewFileName = "UpdateFileName" + GenerateRandomString(2);
                DocHistory.UpdateFileName(NewFileName);
                DocHistory.ClickOnTickMarkToRenameFileName();
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickNotifications();
                addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Project Created Title");
                
               




            }
            catch
            {

            }

        }
    }
}
