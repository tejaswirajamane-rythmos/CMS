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
    class VerifyUserAbleToClickOnCloseButtonInCreateDistributionWindow : BeforeTestAfterTest
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

        [Test, Description("Verify user able to click on Close button  in Create Distribution window")]
        public void TC_VerifyUserAbleToClickOnCloseButtonInCreateDistributionWindow()
        {
            try

            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);


                String expected = "https://docworksfrontendqa.azurewebsites.net/dashboard";
                AddProjectPage project = new AddProjectPage(test, driver);
                //project.ClickDashboard();
                project.SearchForProject(projectName);               
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String distributionName = distmodule.EnterDistirbutionName();
                distmodule.SelectBranch("DocWorksManual3");
                distmodule.EnterTocPath();
                project.SuccessScreenshot(distmodule.CLOSE_BUTTON, "Clicking on close button");
                distmodule.ClickCloseButton();
                String actual = project.GetURl();                
                VerifyText(test, expected, actual, "Authoring page loaded successfully", "Authoring page not loaded successfully");


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