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
    class VerifyUserAbleToCreateDistributionWithLeadingAndTrailingSpaceInDistributionNameTextbox : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;

        [OneTimeSetUp]

        public void AddPProjectModule()
        {
            projectName = new CreateProjectsApi().CreateGitHubProject();
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify user able to create distribution with leading and trailing space in Distribution Name textbox")]
        public void TC_VerifyUserAbleToCreateDistributionWithLeadingAndTrailingSpaceInDistributionNameTextbox()
        {
            try

            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);


                String expected = "Leading and trailing whitespaces not allowed";
                AddProjectPage project = new AddProjectPage(test, driver);
                //project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String distributionName = distmodule.EnterLeadingTrailingSpaceDistName();
                //distmodule.SelectBranch("DocWorksManual3");
                //distmodule.EnterTocPath();
                String actual = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                project.SuccessScreenshot(distmodule.INVALID_TITLE_LENGTH, "Validating Leading and Trailing space in Distribution Name textbox");
                VerifyEquals(test, expected, actual, "Validation of Leading and Trailing Space in Distribution Name Field is successful", "Validation of Leading and Trailing Space in Distribution Name Field is Not successful");


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