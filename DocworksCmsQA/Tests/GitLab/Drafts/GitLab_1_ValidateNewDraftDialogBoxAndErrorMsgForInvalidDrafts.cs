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
    class GitLab_1_ValidateNewDraftDialogBoxAndErrorMsgForInvalidDrafts : BeforeTestAfterTest
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

        [Test, Description("Verify New Draft Button is enabled or not")]
        public void GitLab_1A_ValidateNewDraftDialogBoxIsAppearedOrNot()
        {

            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                //String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                //addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test,driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                Boolean flag = createDraft.IsDraftPopUpEnabled();
                addProject.SuccessScreenshot("Draft Dialog Box Is appeared on screen");
                VerifyBoolean(test,true, flag, "Draft Dialog Box got Opened Successfully", "Draft Dialog Box is not Opened Successfully");
                createDraft.CloseDraft();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

        [Test, Description("Verify When User Enters Invalid Draft Name Then an error message is apeared")]
        public void GitLab_1B_ValidateErrorMesgForInvalidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
               //String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                //addProject.ClickDashboard();
                //addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                //createDraft.ClickOpenProject();
                //createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                String expected2 = "Please enter at least 5 characters.";
                createDraft.EnterInvalidnNameLength();
                String actual2 = createDraft.GetErrorText(createDraft.DRAFTNAMEERROR);
                addProject.SuccessScreenshot("Validating Draft Name Length");
                VerifyEquals(test,expected2, actual2, "Validation Of Length Constraints for Draft Name Field is successful", "Validation of Length Constraints for Draft Name Field is not successful");
                createDraft.CloseDraft();
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
