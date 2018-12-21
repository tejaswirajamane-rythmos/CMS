using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;
using System.Collections.Generic;

namespace DocWorksQA.Tests
{

    [TestFixture, Category("AddNodeModule")]
    [Parallelizable]
    class AddNode : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        string projectName;
        string distribution;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {

           projectName = db.GetOneProjectForManual_GitHub();

           distribution = db.GetOneDistributionFromProject(projectName);
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            //System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to Add Node Under Tree")]
        public void TC1_VerifyUserAbleToAddNodeForGitHubWithDraft()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                NodesPage node = new NodesPage(test, driver);
                node.RightClickOnParentTree();
                node.ClickOnNewNode();
                String NodeTitle = node.EnterNodeTitle();
                String NodeSubTitle = node.EnterNodeSubTitle();
                String DraftName = node.EnterDraftName();
                node.ClickCreateNode();
                // addProject.ClickNotifications();
                // String status2 = addProject.GetNotificationStatus();
                // VerifyText(test, "adding a node " + NodeTitle + " is successful", status2, "Node: " + NodeTitle + " is Created with status:" + status2 + "", "Node is not created with status: " + status2 + "");
                // addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Node: " + NodeTitle + " Created Successfully");
                addProject.BackToProject();
                node.ClickUnityManualTree();
                String Actual = node.GetTextOfNode(NodeSubTitle);
                addProject.SuccessScreenshot("Created NodeSubTitle:  " + NodeSubTitle + "");
                // VerifyEquals(test,NodeSubTitle, Actual, "Validation of the Node Created Under Tree is successful","Validation of Node creation is unsuccessful");
                node.ClickDashboard();
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }
        }
   
        [Test, Description("Verify User is able to Add Node without draft name  Under Tree")]
        public void TC2_VerifyUserAbleToAddNodeForGitHubWithoutDraft()
        {
           try
          {


               String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                NodesPage node = new NodesPage(test, driver);
                node.RightClickOnParentTree();
               node.ClickOnNewNode();
                String NodeTitle = node.EnterNodeTitle();
                String NodeSubTitle = node.EnterNodeSubTitle();
                node.ClickBlankRadioButton();
                node.ClickCreateNode();
               // addProject.ClickNotifications();
                 //String status2 = addProject.GetNotificationStatus();
               //  VerifyText(test, "adding a node " + NodeTitle + " is successful", status2, "Node: " + NodeTitle + " is Created with status:" + status2 + "", "Node is not created with status: " + status2 + "");
                //addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Node: " + NodeTitle + " Created Successfully");
                addProject.BackToProject();
                node.ClickUnityManualTree();
                String Actual = node.GetTextOfNode(NodeSubTitle);
                 addProject.SuccessScreenshot("Created NodeSubTitle:  " + NodeSubTitle + "");
                 VerifyEquals(test,NodeSubTitle, Actual, "Validation of the Node Created Under Tree is successful","Validation of Node creation is unsuccessful");
                node.ClickDashboard();
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