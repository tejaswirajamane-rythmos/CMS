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
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class Mercurial_Draft_AcceptToLive : BeforeTestAfterTest

    {
        private IWebDriver driver;
        private ExtentTest test;
        String projectName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
             projectName = db.GetOneProjectForManual_Mercurial();
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            projectName = "seleniumtest";

        }
        [Test, Description("Verifying User is able to do Draft Accept To Live")]
        public void TC1_MercurialAcceptToLive()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                createDraft.CreateDraft();
                PageControl page = new PageControl(test, driver);
                page.EscapeActionFromKeyboard();
                addProject.ClickNotifications();
                AddProjectPage project = new AddProjectPage(test, driver);
                String status1 = addProject.GetNotificationStatus();
                page.EscapeActionFromKeyboard();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Existing Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " draft has been created", status1, "draft has been created with name:" + draftName + "", "Draft is not created with status: " + status1 + "//");
                System.Threading.Thread.Sleep(3000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(2000);
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(2000);
                auth.ClickAcceptDraftToLive();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Accept Draft To live of Draft got Created Successfully");
                VerifyText(test, "draft has been accepted to live" + draftName + "draft has been accepted to live", status2, "draft has been accepted to live with name:" + draftName + "", "Draft is not been Accepted to live with status: " + status2 + "//");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
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
