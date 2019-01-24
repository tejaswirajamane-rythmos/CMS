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
    class GitHub_5_ValidateAddUpdateDeleteDraft : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String renameDraft;
        private string draftName;
        private object auth;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = "publishingproject";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }
        [Test, Description("Verify User is able to create a Blank Draft")]
        public void GitHub_5A_ValidationOfBlankDraftWithValidDraftName()
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
                //createDraft.ClickUnityManualTree();


                createDraft.ClickAnyNode();
                CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);

                //Creating draft

                CreateDraft.ClickNewDraft();
                draftName = createDraft.EnterValidDraftName();
                CreateDraft.ClickOnBlankDraft();
                CreateDraft.CreateDraft();
                // project.ClickNotifications();
                //String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                //  VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                //  project.BackToProject();
                System.Threading.Thread.Sleep(3000);
               
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);



            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is able to rename a Blank Draft")]
        public void GitHub_5B_ValidationOfRenameBlankDraftWithValidDraftName()
        {
            try
            {
                AddProjectPage project = new AddProjectPage(test, driver);
                //Renaming Draft
                renameDraft = "draft_kRename"+GenerateNumbers(3);
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);

                DocHistory.Settings_Button();
                // DocHistory.ClickLeftCursor();
                // DocHistory.ClickAllDrafts();
                DocHistory.RenameDraft(draftName, renameDraft);
                System.Threading.Thread.Sleep(2000);
                DocHistory.ClickOnRightMarkToRename();
                System.Threading.Thread.Sleep(2000);
                // project.ClickNotifications();
                // String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft Renamed Successfully");
                project.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                driver.Navigate().Refresh();
                auth.LeftDraftDropDown(renameDraft);
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is able to delete draft")]
        public void GitHub_5C_ValidationOfDeleteDraft()
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
                //createDraft.ClickUnityManualTree();


                createDraft.ClickAnyNode();
                CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);

                //Creating draft

                CreateDraft.ClickNewDraft();
                draftName = createDraft.EnterValidDraftName();
                CreateDraft.ClickOnBlankDraft();
                CreateDraft.CreateDraft();
                // project.ClickNotifications();
                //String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                System.Threading.Thread.Sleep(3000);
                DocHistory.Settings_Button();
                DocHistory.ClickDeleteDraftIcon(draftName);
                DocHistory.ClickDeleteDraftButton();
                project.SuccessScreenshot("Draft Deleted Successfully");         
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
        }
    }
}

