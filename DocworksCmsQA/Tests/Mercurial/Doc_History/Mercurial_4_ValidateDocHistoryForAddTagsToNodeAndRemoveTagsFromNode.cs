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
    class Mercurial_4_ValidateDocHistoryForAddTagsToNodeAndRemoveTagsFromNode : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        //String distributionName;
       // string TagGroupName;
     

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = db.GetOneProjectForManual_Mercurial();

           // projectName = "SELENIUMOno";
           // projectName = new CreateProjectsApi().CreateMercurialProject();
           // distributionName = new CreateDistributionsApi().CreateOnoDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify User is able to view history details in DocHistory module for AddingTagsToNode and RemoveTagsFromNode")]
        public void ValidateDocHistoryForAddTagsToNodeAndRemoveTagsFromNode()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
              //  String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                //project.ClickDashboard();
                TagManagementSystemLevelPage createTagGroup = new TagManagementSystemLevelPage(test, driver);
                TagManagementSystemLevelPage SystemLevel = new TagManagementSystemLevelPage(test, driver);
                SystemLevel.ClickSystemTab();
                SystemLevel.ClickCreateTagGroup();
                String TagGroupName = SystemLevel.EnterTagGroupName();
                SystemLevel.ClickCheckBoxLimitToOne();
                SystemLevel.ClickCreateTagGroupAfterDone();
                //project.ClickNotifications();
                //String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("TagGroup got Created Successfully");
               // project.BackToProject();
           
               // SystemLevel.EnterTagGroupName();
                Console.WriteLine(TagGroupName);
               // SystemLevel.ClickEditTagGroup(TagGroupName);
               // SystemLevel.EnterSearchTagInTagGroup(TagGroupName);
                SystemLevel.ClickEditTagGroupIcon(TagGroupName);
              
                SystemLevel.ClickManageTags();
                SystemLevel.ClickAddTag();
                String TagName = SystemLevel.EnterTagName();
                SystemLevel.ClickAcceptTagName();
                SystemLevel.ClickBackToManageTags();
                // SystemLevel.ClickCloseManageTags();
                // project.ClickNotifications();
                //String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Tag got Created Successfully");
               // project.BackToProject();
                project.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                project.SearchForProject(projectName);
                TagManagementProjectLevelPage ProjectLevel = new TagManagementProjectLevelPage(test, driver);
                ProjectLevel.ClickSettings();
                ProjectLevel.ClickOnManageTagGroups();
                ProjectLevel.SearchTagsAtProjectLevel(TagName);
                ProjectLevel.ClickPlusCircle();
                project.BackToProject();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickLeftCursor();
               // TagManagmentNodeLevelPage NodeLevel = new TagManagmentNodeLevelPage(test, driver);
                //NodeLevel.ClickEditTags();
                //NodeLevel.SearchTagGroupAtNodeLevel();


                /*Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();*/


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
           // db.FindDistributionAndDelete(distributionName);
            db.FindProjectAndDelete(projectName);
        }

    }
}

