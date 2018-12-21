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
    class GitHub_5_ValidateDocHistoryforCreateRenameDeleteDraft : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
       // String distributionName;
        String draftName;
        String renameDraft;
        string distribution;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = db.GetOneProjectForManual_GitHub();

            distribution = db.GetOneDistributionFromProject(projectName);

          //  projectName = new CreateProjectsApi().CreateGitHubProject();
          //  distributionName = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);

        }


        [Test, Description("Verify User is able to view history details in DocHistory module for Create draft")]
        public void TC1_ValidateDocHistoryforCreateDraft()
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
                createDraft.ClickUnityManualTree();


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
                System.Threading.Thread.Sleep(2000);
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
               // DocHistory.Settings_Button();
               DocHistory.ClickDoc_History();
              // driver.Navigate().Refresh();
               // DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(20000);
                String str = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot("Created draft history details loaded Successfully");
                VerifyContainsText(test,draftName,str, "Created draft history details loaded Successfully", "Created draft history details are not loaded Successfully");
                project.BackToProject();

                
               
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);             
                throw;
            }

        }

        [Test, Description("Verify User is able to view history details in DocHistory module for Rename draft")]
        public void TC2_ValidateDocHistoryforRenameDraft()
        {
            try
            {
                //String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                //Console.WriteLine("Starting Test Case : " + TestName);
                //String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                //test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                ////project.ClickDashboard();
                //project.SearchForProject(projectName);
                //CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                //createDraft.ClickOpenProject();
                //createDraft.ClickUnityManualTree();


                //createDraft.ClickAnyNode();
                //CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);



                //CreateDraft.ClickNewDraft();
                //draftName = createDraft.EnterValidDraftName();
                //CreateDraft.ClickOnBlankDraft();
                //CreateDraft.CreateDraft();
                //// project.ClickNotifications();
                ////String status2 = project.GetNotificationStatus();
                //project.SuccessScreenshot("Blank Draft got Created Successfully");
                ////  VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                ////  project.BackToProject();
                //System.Threading.Thread.Sleep(2000);


                //Renaming Draft
                renameDraft = "draft_kk";

                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);

                DocHistory.Settings_Button();
               // DocHistory.ClickLeftCursor();
               // DocHistory.ClickAllDrafts();
                DocHistory.RenameDraft(draftName, renameDraft);
                System.Threading.Thread.Sleep(3000);
                DocHistory.ClickOnRightMarkToRename();
                System.Threading.Thread.Sleep(3000);
                // project.ClickNotifications();
                // String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft Renamed Successfully");
                project.BackToProject();
                DocHistory.ClickDoc_History();
                //driver.Navigate().Refresh();
                //DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(20000);
                String str1 = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot("Rename draft history details loaded Successfully");
                VerifyContainsText(test, renameDraft, str1, "Rename draft history details loaded Successfully", "Rename draft history details are not loaded Successfully");
                DocHistory.ClickOnNodeHistoryCloseButton();


                

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }

        }

        [Test, Description("Verify User is able to view history details in DocHistory module for delete draft")]
        public void TC3_ValidateDocHistoryforDeleteDraft()
        {
            try
            {
                //String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                //Console.WriteLine("Starting Test Case : " + TestName);
                //String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                //test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                ////project.ClickDashboard();
                //project.SearchForProject(projectName);
                //CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                //createDraft.ClickOpenProject();
                //createDraft.ClickUnityManualTree();


                //createDraft.ClickAnyNode();
                //CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);



                //CreateDraft.ClickNewDraft();
                //draftName = createDraft.EnterValidDraftName();
                //CreateDraft.ClickOnBlankDraft();
                //CreateDraft.CreateDraft();
                //// project.ClickNotifications();
                ////String status2 = project.GetNotificationStatus();
                //project.SuccessScreenshot("Blank Draft got Created Successfully");
                ////  VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                ////  project.BackToProject();
                //System.Threading.Thread.Sleep(2000);

                //Deleting Draft

                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);

                DocHistory.Settings_Button();
               // DocHistory.ClickAllDrafts();
               // DocHistory.ClickDeleteIcon(renameDraft);
                DocHistory.ClickDeleteDraftIcon(renameDraft);
                DocHistory.ClickDeleteDraftButton();
               

              //  project.ClickNotifications();
              //  String status4 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft Deleted Successfully");
                project.BackToProject();
                DocHistory.ClickDoc_History();
                //driver.Navigate().Refresh();
                //DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(20000);
                String str2 = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot("Deleted draft history details loaded Successfully");
                VerifyContainsText(test, renameDraft, str2, "Deleted draft history details loaded Successfully", "Deleted draft history details are not loaded Successfully");
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
            db.FindDistributionAndDelete(distribution);
            db.FindProjectAndDelete(projectName);
        }

    }
}