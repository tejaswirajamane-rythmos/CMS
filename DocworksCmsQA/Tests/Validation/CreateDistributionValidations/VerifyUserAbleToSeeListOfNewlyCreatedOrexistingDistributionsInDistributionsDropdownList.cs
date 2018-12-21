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
    class VerifyUserAbleToSeeListOfNewlyCreatedOrexistingDistributionsInDistributionsDropdownList : BeforeTestAfterTest
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

        [Test, Description("Verify user able to see list of newly created or existing distributions in Distributions dropdown list")]
        public void TC_VerifyUserAbleToSeeListOfNewlyCreatedOrexistingDistributionsInDistributionsDropdownList()
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
                AuthoringScreenEnhancements authoringScreen = new AuthoringScreenEnhancements(test, driver);
                authoringScreen.ClickOnDistributionDropdown();
                String str = authoringScreen.GetTestofDistributions();
                project.SuccessScreenshot(authoringScreen.DISTRIBUTION_DROPDOWN, "Created distribution loaded successfully in distribution dropdown list");
                VerifyText(test, distributionName,str, "Created distribution loaded successfully in distribution dropdown list", "Created distribution is not loaded successfully in distribution dropdown list");




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