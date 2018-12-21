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

    class VerifySystemShouldThrowAnErrorWhileCreatingDistributionIfValuesAreNotEnteredInAnyOneMandatoryFields : BeforeTestAfterTest
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

        [Test, Description("Verify error message and create distribution button is disabled if values  are not entered in any one mandatory fields")]
        public void TC_VerifySystemShouldThrowAnErrorWhileCreatingDistributionIfValuesAreNotEnteredInAnyOneMandatoryFields()
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
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected1 = "Distribution name is required";

                distmodule.EnterEmptyDistributionName();
                distmodule.EnterDescription("Description");

                String actual1 = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                project.SuccessScreenshot(distmodule.INVALID_TITLE_LENGTH, "Validating Error Message");
                VerifyEquals(test, expected1, actual1, "Validation of Length Constraints for Distribution Name Field is successful", "Validation of Length Constraints for Distribution Name Field is Not successful");

                Boolean actual2 = distmodule.CreateDistributionButtonDisabled();
                project.SuccessScreenshot(distmodule.CREATE_DISTRIBUTION, "Create Distribution button is disabled");
                VerifyBoolean(test, false, actual2, "Create Distribution button is disabled", "Create Distribution button is not disabled");


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