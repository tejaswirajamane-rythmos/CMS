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

    class VerifyUserAbleToSelectAnyOneDistributionInDistributionsDropdownList : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName1, distributionName2;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = new CreateProjectsApi().CreateGitHubProject();
            distributionName1 = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            distributionName2 = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify user able to select any one distribution in distributions dropdown list")]
        public void TC_VerifyUserAbleToSelectAnyOneDistributionInDistributionsDropdownList()
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
                authoringScreen.ClickOnAvailableDistribution2();
                String str = authoringScreen.GetTextOfOpenedDistribution();
                System.Threading.Thread.Sleep(6000);
                project.SuccessScreenshot(authoringScreen.OPENED_DISTRIBUTION, "Selected one distribution in distribution dropdown list");
                VerifyText(test, distributionName2, str, "Able to select one distribution in distribution dropdown list", "Not Able to select one distribution in distribution dropdown list");




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
            db.FindDistributionAndDelete(distributionName1);
            db.FindDistributionAndDelete(distributionName2);
            db.FindProjectAndDelete(projectName);
        }

    }
}