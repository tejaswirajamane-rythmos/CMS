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
    class GitHub_1_ValidateDocHistoryBySearchingThroughUsernameandDraftnmaeInSearchField : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = new CreateProjectsApi().CreateGitHubProject();
            distributionName = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify User is able to view history details in DocHistory module for Action items")]
        public void ValidateDocHistoryBySearchingThroughUsernameandDraftnmaeInSearchField()
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
                createDraft.ClickAnyNode();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
             //   DocHistory.Click_Settings();
                DocHistory.ClickSearchField("Service");
                DocHistory.ClickSearchButton();
                System.Threading.Thread.Sleep(30000);
                String str = DocHistory.GetHistoryMessage();
                project.SuccessScreenshot("Action details loaded Successfully by username");
                VerifyContainsText(test,"Service", str, "Action details loaded successfully for username", "Action details are not loaded successfully for username");
                DocHistory.ClickSearchField("draft");
                DocHistory.ClickSearchButton();
                System.Threading.Thread.Sleep(30000);
                project.SuccessScreenshot("Action details loaded Successfully by draft name");              
                VerifyContainsText(test,"draft",str, "Action details loaded successfully for username", "Action details are not loaded successfully for username");
                


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