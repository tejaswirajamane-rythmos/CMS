﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Authoring Screen Enhancements")]
    [Parallelizable]
    class GitLab_3_ValidateScreenEnhancementsWhenUserEditsExistingDraftContent : BeforeTestAfterTest
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
        [Test, Description("Verify User is able to edit the existing draft content in Left side GDOC")]
        public void GitLab_3A_ValidateScreenEnhancementsWhenUserEditsExistingContentInLeftGdoc()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
               // String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.LeftDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                project.SuccessScreenshot("Editing Existing Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
       
         [Test, Description("Verify User is Able to view changes made of Existing Draft in Left GDOC are reflected in Right Side Tabs")]
        public void GitLab_3B_ValidationWhenEditedExistingDraftInLeftGDocGetsReflectedInRightSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AddProjectPage addProject = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in GDOC Right");
                auth.HtmlRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in HTML Right");
                auth.MDRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in MD Right");
                auth.PreviewRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft  Contains String: " + expected + "in Preview Right");
                auth.GdocRightTab();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }  

        [Test, Description("Verify User is able to edit the existing draft content in Right side GDOC")]
        public void GitLab_3C_ValidationOfScreenEnhancementsUserEditsExistingContentInRightGdoc()

        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test=StartTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(test,driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                createDraft.CreateDraft();  
                AddProjectPage addProject = new AddProjectPage(test,driver);
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();  
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.RightDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoRightFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocRight();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                addProject.SuccessScreenshot("Editing Existing Draft in GDOC Right");
                driver.SwitchTo().DefaultContent();
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
      [Test, Description("Verify User is Able to view changes made of Existing Draft in Right GDOC are reflected in Left Side Tabs")]
        public void GitLab_3D_ValidationWhenUserEditedRightGDocGetsReflectedInLeftSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test=StartTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AddProjectPage addProject = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in GDOC Left");
                auth.HtmlLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in HTML Left");
                auth.MDLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in MD Left");
                auth.PreviewLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft  Contains String: " + expected + "in Preview Left");
                auth.GdocLeftTab();  
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