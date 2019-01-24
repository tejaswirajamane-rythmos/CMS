using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("ViewCoderWIPAndFinalDraftHistory")]
    [Parallelizable]
    class GitHub_6_ValidateCreateDraftSnapShot : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distribution;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
           // projectName = db.GetOneProjectForManual_GitHub();

           // distribution = db.GetOneDistributionFromProject(projectName);
            projectName = "SELENIUMGITHUBKCBVJ";
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to Create a Draft Snapshot")]
        public void TC32_VerifyCreateDraftSnapShot()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                //String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
             //   addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
               // createDraft.ClickUnityManualTree();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
               // createDraft.ClickOnBlankDraft();
                createDraft.SelectCoderDraft();
                addProject.SuccessScreenshot("Creating a Existing Draft");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(3000);
               // driver.Navigate().Refresh();
               /// System.Threading.Thread.Sleep(5000);
              //  driver.Navigate().Refresh();
                // addProject.ClickNotifications();
                //String status2 = addProject.GetNotificationStatus();
                 addProject.SuccessScreenshot("Existing Draft got Created Successfully");
                // VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                // addProject.BackToProject();
               // System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);
                auth.RightDraftDropDown(draftName);
                auth.HistoryRightTab();
                System.Threading.Thread.Sleep(3000);
                String DraftSnapshot = auth.CreateDraftFromSnapshot();
               // addProject.ClickNotifications();
               // String status3 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
               // VerifyText(test, "creating a draft " + DraftSnapshot + " with snapshot is successful", status2, "DraftSnapshot: " + DraftSnapshot + " is Created with status:" + status2 + "", "DraftSnapshot is not created with status: " + status2 + "");
              //  addProject.BackToProject();
                //AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(DraftSnapshot);
                auth.RightDraftDropDown(DraftSnapshot);
                auth.HistoryRightTab();
                auth.ViewDraft1();
              //  addProject.SuccessScreenshot("History of created Draft SnapShot with content same as the Draft");
                //auth.CloseViewDraft();
                auth.GdocLeftTab();
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                //driver.SwitchTo().ActiveElement().Click();
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(DraftSnapshot);
                auth.PreviewRightTab();
                auth.HistoryRightTab();
                addProject.SuccessScreenshot("Number of Instances after Clicked on Gdoc for long time");
                auth.LeftDraftDropDown(DraftSnapshot);
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
        }
    }
}
