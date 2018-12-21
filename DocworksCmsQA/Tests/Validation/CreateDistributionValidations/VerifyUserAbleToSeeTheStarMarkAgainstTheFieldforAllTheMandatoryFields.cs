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
    class VerifyUserAbleToSeeTheStarMarkAgainstTheFieldforAllTheMandatoryFields : BeforeTestAfterTest
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

        [Test, Description("Verify user able to see the star mark against the field for all the mandatory fields")]
        public void TC_VerifyUserAbleToSeeTheStarMarkAgainstTheFieldforAllTheMandatoryFields()
        {
            try

            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);

                String expected = "*";
                AddProjectPage project = new AddProjectPage(test, driver);
                //project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String actual1 = project.GetText(distmodule.DISTRIBUTION_NAME_STAR);
                Info(test,actual1);
                project.SuccessScreenshot(distmodule.DISTRIBUTION_NAME_STAR, "Validating star mark against Distribution Name");                
                VerifyEquals(test, expected, actual1.Trim(), "Validating star mark against Distribution Name is successfull", "Validating star mark against Distribution Name is not successfull");

                String actual2 = project.GetText(distmodule.SELECT_BRANCH_STAR);
                project.SuccessScreenshot(distmodule.SELECT_BRANCH_STAR, "Validating star mark against Select Branch");
                VerifyEquals(test, expected, actual2.Trim(), "Validating star mark against Select Branch is successfull", "Validating star mark against Select Branch is not successfull");


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