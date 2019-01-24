using AventStack.ExtentReports;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.Tests.Nodes
{
    class DeleteNodeForGitHub : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        string projectName;
        string distribution;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = "SELENIUMGITHUBPKAEO";
            // projectName = "SELENIUMGITLABVHRIO ";
           // projectName = "SELENIUMOnoITBPH";


            // projectName = db.GetOneProjectForManual_GitHub();

            // distribution = db.GetOneDistributionFromProject(projectName);
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
        }
        [Test, Description("Verify User is able to Delete Node Under Tree")]
        public void TC1_VerifyUserAbleDeleteNodeForGitHub()
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
               
               // node.ClickUnityManualTree();
                String Actual = node.GetTextOfNode(NodeSubTitle);
                addProject.SuccessScreenshot("Created NodeSubTitle:  " + NodeSubTitle + "");
                VerifyEquals(test, NodeSubTitle, Actual, "Validation of the Node Created Under Tree is successful", "Validation of Node creation is unsuccessful");
                node.SearchBarAtTocLevel(NodeSubTitle);
                System.Threading.Thread.Sleep(2000);
                node.GetTextOfNodeAfterSearch(NodeSubTitle);
                System.Threading.Thread.Sleep(2000);
                node.RightClickOnNode(NodeSubTitle);
                node.ClickOnDeleteNode(NodeSubTitle);
                Console.WriteLine("Deleted node is:" + NodeSubTitle);
                driver.Navigate().Refresh();
               // node.ClickUnityManualTree();
                addProject.SuccessScreenshot("Deleted NodeSubTitle:  " + NodeSubTitle + "");
                node.SearchBarAtTocLevel(NodeSubTitle);
                System.Threading.Thread.Sleep(2000);

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
