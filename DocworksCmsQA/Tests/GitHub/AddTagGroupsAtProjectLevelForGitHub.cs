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

namespace DocworksCmsQA.Tests.GitHub
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]
    class AddTagGroupsAtProjectLevelForGitHub : BeforeTestAfterTest 
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;

        public object GET_TAG_NAME { get; private set; }

        [OneTimeSetUp]
        public void AddProjectModule()
        {
          //  projectName = db.GetOneProjectForManual_GitHub();
            projectName = "ProjectForManualTest";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);

        }

        [Test, Description("Verify User is able to Add TagGroups At Project Level for GitHub")]
        public void TC1_Validate_AddTagGroupsAtProjectLevelForGitHub()
        {

            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                TagManagementSystemLevelPage SystemLevel = new TagManagementSystemLevelPage(test, driver);
                SystemLevel.ClickSystemTab();
                SystemLevel.ClickCreateTagGroup();
                String TagGroupName = SystemLevel.EnterTagGroupName();
                SystemLevel.ClickCheckBoxLimitToOne();
                SystemLevel.ClickCreateTagGroupAfterDone();
                Console.WriteLine(TagGroupName);
                SystemLevel.EnterSearchTagInTagGroup(TagGroupName);
                project.SuccessScreenshot(SystemLevel.GET_TAGGROUP_NAME, "TagGroup got Created Successfully");
                SystemLevel.ClickEditTagGroupIcon(TagGroupName);
                SystemLevel.ClickManageTags();
                SystemLevel.ClickAddTag();
                String TagName = SystemLevel.EnterTagName();
                SystemLevel.ClickAcceptTagName();
               project.SuccessScreenshot(SystemLevel.GET_TAG_NAME, "Tag got Created Successfully");
                SystemLevel.ClickBackToManageTags();
                System.Threading.Thread.Sleep(2000);
                project.ClickDashboard();
                System.Threading.Thread.Sleep(2000);
                project.SearchForProject(projectName);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                TagManagementProjectLevelPage ProjectLevel = new TagManagementProjectLevelPage(test, driver);
                ProjectLevel.ClickSettings();
                ProjectLevel.ClickOnManageTagGroups();
                ProjectLevel.SearchTagsAtProjectLevel(TagGroupName);
                String actual= ProjectLevel.GetTagNameAtProjectLevel();
                ProjectLevel.ClickPlusCircle();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE,"TagGroup added for Successfully for project" + projectName);
                project.BackToProject();
                VerifyText(test, "Adding tagGroups to project" + projectName + "TagGroups added successfully" ,status, "Taggroup added Successfully", "Taggroup is not added successfully with status: " + status + "//");
            

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
            db.FindProjectAndDelete(projectName);
        }

    }

    
}
