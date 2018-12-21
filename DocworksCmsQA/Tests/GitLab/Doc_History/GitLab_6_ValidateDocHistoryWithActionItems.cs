using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]
    class GitLab_6_ValidateDocHistoryWithActionItems : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName;


        [OneTimeSetUp]
        public void AddPProjectModule()

        {
            projectName = new CreateProjectsApi().CreateGitLabProject();
            distributionName = new CreateDistributionsApi().CreateGitLabDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);

        }

        [Test, Description("Verify User is able to view history details in DocHistory module for Action items")]
        public void ValidateDocHistoryWithActionItems()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);               
                AddProjectPage project = new AddProjectPage(test, driver);
                //project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                //CreateDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();
                DocHistory.ClickActions();
                DocHistory.ClickCheckBoxCreateDraft();
                //DocHistory.ClickCheckBoxRenameDraft();
                //DocHistory.ClickCheckBoxAcceptDraftToLive();
                // DocHistory.ClickEmptySpaceInNodeHistory();
                //DocHistory.ClickActivityTab();
                //project.BackToProject();
                DocHistory.ClickOnNodeHistoryCloseButton();
                DocHistory.ClickSearchButton();
                System.Threading.Thread.Sleep(10000);
                String str = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot("Action details loaded Successfully");
                VerifyContainsText(test, draftName, str, "Action details loaded Successfully for create draft", "Action details are not loaded Successfully for create draft");

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");
            CloseDriver(driver);
            db.FindDistributionAndDelete(distributionName);
            db.FindProjectAndDelete(projectName);

        }

    }
}
