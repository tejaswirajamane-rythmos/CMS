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

namespace DocworksCmsQA.Tests.Mercurial
{
    class AddTagGroupsAtProjectLevelForMercurial: BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        [OneTimeSetUp]
        public void AddProjectModule()
        {
            projectName = db.GetOneProjectForManual_Mercurial();
            projectName = "ManualTestProject";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);

        }
        [Test, Description("Verify User is able to Add TagGroups At Project Level for Mercurial")]
        public void TC1_Validate_AddTagGroupsAtProjectLevelForMercurial()
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
                project.SuccessScreenshot("TagGroup got Created Successfully");
                Console.WriteLine(TagGroupName);
                SystemLevel.EnterSearchTagInTagGroup(TagGroupName);
                SystemLevel.ClickEditTagGroupIcon(TagGroupName);
                SystemLevel.ClickManageTags();
                SystemLevel.ClickAddTag();
                String TagName = SystemLevel.EnterTagName();
                SystemLevel.ClickAcceptTagName();
                SystemLevel.ClickBackToManageTags();
                project.SuccessScreenshot("Tag got Created Successfully");
                System.Threading.Thread.Sleep(2000);
                project.ClickDashboard();
                System.Threading.Thread.Sleep(2000);
                project.SearchForProject(projectName);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                TagManagementProjectLevelPage ProjectLevel = new TagManagementProjectLevelPage(test, driver);
                ProjectLevel.ClickSettings();
                ProjectLevel.ClickOnManageTagGroups();
                ProjectLevel.SearchTagsAtProjectLevel(TagGroupName);
                ProjectLevel.ClickPlusCircle();
                project.SuccessScreenshot("TagGroup added for Successfully for project" + projectName);
                project.BackToProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
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
