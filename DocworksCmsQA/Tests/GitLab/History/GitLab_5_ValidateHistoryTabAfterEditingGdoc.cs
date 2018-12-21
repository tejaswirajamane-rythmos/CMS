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
    class GitLab_5_ValidateHistoryTabAfterEditingGdoc : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to View History Tab After Editing GDOC")]
        public void TC31_VerifyHistoryTabAfterEditingGdoc()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickAnyNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.ClickOnExistingDraft();
                addProject.SuccessScreenshot("Creating a Blank Draft");
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + "Draft_-8" + " in UnityManual is successful", status2, "Draft: " + "Draft_-8" + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.LeftDraftDropDown(draftName);
                auth.RightDraftDropDown(draftName);
                auth.HistoryRightTab();
                auth.ViewDraft();
                addProject.SuccessScreenshot("History of View Draft Before Editing the Blank Draft in Gdoc");
                auth.CloseViewDraft();
                auth.GdocLeftTab();
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_AUTOMATION");
                addProject.SuccessScreenshot("Editing Blank Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                auth.PreviewRightTab();
                auth.HistoryRightTab();
                auth.ViewDraft1();
                addProject.SuccessScreenshot("History of View Draft After Editing the Blank draft in GDoc");
                String Actual = auth.GetViewDraft();
                Console.WriteLine("The text is ****" + Actual);
                auth.CloseViewDraft();
              VerifyText(test,"SELENIUM_AUTOMATION", Actual, "Validating the changes in ViewDraft is successful", "Validating the changes in ViewDraft is not successful");
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