using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("Upload Images")]
    [Parallelizable]
    class ValidationOfUploadImage : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to Upload an Image in Media Screen")]
        public void TC21_ValidationOfUploadImage()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test=StartTest(TestName, description);
                Console.WriteLine("Entered into testcase");
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.ClickMedia();
                String ImageName = auth.UploadImage();
                AddProjectPage project = new AddProjectPage(test,driver);
                project.ClickNotifications();
                String status = project.GetNotificationStatus();
                project.SuccessScreenshot("Image Got Uploaded Successfully");
                VerifyText(test, "asset uploaded successffully" + ImageName + " asset uploaded", status, "Image: " + ImageName + " asset uploaded:", "Image is not Uploaded with status: " + status + "//");
               // VerifyText(test, "Adding tagGroups to project" + projectName + "TagGroups added successfully", status, "Taggroup added Successfully", "Taggroup is not added successfully with status: " + status + "//");

                project.BackToProject();
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
