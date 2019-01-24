using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Draft")]
    [Parallelizable]
    class GitHub_2_ValidationOfCreateDraftsOfExistingAndBlankWithValidDraftNames : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String renameDraft;
        private object project;

        // String distributionName;
        // string distribution;

        [OneTimeSetUp]
        //public void AddPProjectModule()
        //{

        //   // projectName = db.GetOneProjectForManual();

        //   // distribution = db.GetOneDistributionFromProject(projectName);
        //     projectName = "SELENIUMGITHUB";
        //    // projectName1 = "SELENIUMGIT";

        //    driver = new DriverFactory().Create();
        //    new LoginPage(driver).Login();
        //    System.Threading.Thread.Sleep(5000);
        //}
        public void AddPProjectModule()
        {
            projectName = "SELENIUMGITHUBGDIRN";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }



        [Test, Description("Verify User is able to create a Blank Draft")]
        public void GitHub_2A_ValidationOfBlankDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
               // createDraft.ClickUnityManualTree();
                createDraft.ClickAnyNode();
                //createDraft.ClickNode();
                System.Threading.Thread.Sleep(2000);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
               // addProject.SuccessScreenshot("Creating a Blank Draft");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(4000);
                // createDraft.CreateDraft();
                // createDraft.ClickOnPreview();
               
               // System.Threading.Thread.Sleep(5000);
                //addProject.ClickNotifications();
                // String status2 = addProject.GetNotificationStatus();
                 addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                // VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                // addProject.BackToProject();
                // createDraft.ClickNewDraft();
                // String str = "Duplicate Draft Name";
                // createDraft.EnterDraftName(draftName);
                //addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                // String Actual = createDraft.GetTextOfdraftName();
                //System.Threading.Thread.Sleep(6000);
                String Actual = createDraft.GetTextOfdraftName(draftName);
                // String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                //  VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                // createDraft.CloseDraft();

            }
            catch (Exception ex)
            {
               // ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }  

        [Test, Description("Verify User is able to create a Existing draft")]
        public void GitHub_2B_ValidationOfExistingDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                //String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
               // addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
               // createDraft.ClickUnityManualTree();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                addProject.SuccessScreenshot("Creating Existing Draft");
                createDraft.CreateDraft();
                // addProject.ClickNotifications();
                //  String status2 = addProject.GetNotificationStatus();
                //  addProject.SuccessScreenshot("Draft got Created Successfully");
                // VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                // addProject.BackToProject();
                // createDraft.ClickNewDraft();
                // driver.Navigate().Refresh();
                //String str = "Duplicate Draft Name";
                System.Threading.Thread.Sleep(3000);
                String Actual = createDraft.GetTextOfdraftName(draftName);
                // addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                //  String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                // VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                // createDraft.CloseDraft();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is able to Rename a  draft")]
        public void GitHub_2C_ValidationOfRenamingExistingDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                //String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                // addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                // createDraft.ClickUnityManualTree();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();

               // createDraft.SelectCoderDraft();
                addProject.SuccessScreenshot("Creating Existing Draft");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(5000);
                String Actual = createDraft.GetTextOfdraftName(draftName);
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.Settings_Button();
                //Renaming Draft
                renameDraft = "SeleniiumDraftRename";

                DocHistory.RenameDraft(draftName, renameDraft);
                System.Threading.Thread.Sleep(2000);
                DocHistory.ClickOnRightMarkToRename();
                System.Threading.Thread.Sleep(2000);
                project.SuccessScreenshot("Draft Renamed Successfully");
                project.BackToProject();
                System.Threading.Thread.Sleep(2000);
                String Actual1 = createDraft.GetTextOfdraftName(renameDraft);
            }
            catch (Exception ex)
            {
                // ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
       

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");

            CloseDriver(driver);
           // db.FindDistributionAndDelete(distributionName);
           // db.FindProjectAndDelete(projectName);
        }

    }
}