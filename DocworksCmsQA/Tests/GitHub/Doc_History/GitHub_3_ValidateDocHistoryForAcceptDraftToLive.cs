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
    class GitHub_3_ValidateDocHistoryForAcceptDraftToLive : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
    //    String distributionName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            // projectName = new CreateProjectsApi().CreateGitHubProject();
            //distributionName = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            projectName = "ProjectForManualTest";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify User is able to view history details in DocHistory module for Accept drft to Live")]
        public void ValidateDocHistoryForAcceptDraftToLive()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);

                AddProjectPage project = new AddProjectPage(test, driver);
               // project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
               // createDraft.ClickUnityManualTree();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                //createDraft.ClickOnBlankDraft();
                createDraft.SelectCoderDraft();
                createDraft.CreateDraft();
                // project.ClickNotifications();
                // String status2 = project.GetNotificationStatus();
                 project.SuccessScreenshot(createDraft.GetTextOfdraftName(draftName),"Existing Draft got Created Successfully");
                //project.SuccessScreenshot("Blank Draft got Created Successfully");
                //   VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                System.Threading.Thread.Sleep(3000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                auth.ClickAcceptDraftToLive();
                // project.ClickNotifications();
                //   String status = project.GetNotificationStatus();
                //   project.SuccessScreenshot("Accept Draft To live of Draft got Created Successfully");
                // project.BackToProject();
                System.Threading.Thread.Sleep(5000);
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();
                //driver.Navigate().Refresh();
               // DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(2000);
                String str = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot(DocHistory.GetHistoryMessage(), "Accept Draft To Live history details loaded Successfully");
               // VerifyText(test,"Service Staging pushed Draft "+draftName+" to Live",str, "Accept Draft To Live history details loaded Successfully", "Accept Draft To Live history details are not loaded Successfully");
                DocHistory.ClickOnNodeHistoryCloseButton();

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
          //  db.FindDistributionAndDelete(distributionName);
            db.FindProjectAndDelete(projectName);
        }

    }
}