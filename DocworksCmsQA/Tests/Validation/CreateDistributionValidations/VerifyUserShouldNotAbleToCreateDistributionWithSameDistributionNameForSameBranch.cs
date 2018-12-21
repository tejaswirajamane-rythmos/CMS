using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class VerifyUserShouldNotAbleToCreateDistributionWithSameDistributionNameForSameBranch : BeforeTestAfterTest
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

        //[Test, Description("Verify user should not able to create distribution with same distribution name for same branch")]
        public void TC_VerifyUserShouldNotAbleToCreateDistributionWithSameDistributionNameForSameBranch()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                // project.ClickDashboard();

                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String distributionName1 = distmodule.EnterDistirbutionName();
                distmodule.SelectBranch("DocWorksManual3");
                distmodule.EnterTocPath();
                //distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + distributionName1 + " in " + projectName + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");

                project.BackToProject();
                project.SearchForProject(projectName);
                distmodule.ClickDistribution();
                String distributionName2 = distmodule.EnterDuplicateDistirbutionName(distributionName1);
                distmodule.SelectBranch("DocWorksManual3");
                distmodule.EnterTocPath();
                //distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + distributionName2 + " in " + projectName + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");


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