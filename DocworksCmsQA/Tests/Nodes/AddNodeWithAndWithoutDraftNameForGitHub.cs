using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;
using Xunit;
using System.Collections.Generic;

namespace DocWorksQA.Tests
{

    [TestFixture, Category("AddNodeModule")]
    [Parallelizable]
    public class AddNode : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test; 
        string projectName;
        string distribution;

        [OneTimeSetUp]

        public void AddPProjectModule()
        {
                  projectName = "publishtest04";
                //   projectName = "SELENIUMGITLABVHRIO ";
                // projectName = "SELENIUMOnoITBPH";
                driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
           // projectName = db.GetOneProjectForManual_GitHub();
            //if (projectName == null)

            //{
            //    CreateProjectGitHub cpg = new CreateProjectGitHub();
            //    cpg.TC03_ValidateCreateProjectForGitHubWithAllFields();


            //}
            //else
            //{
            //    TC1_VerifyUserAbleToAddNodeForGitHubWithDraft();
            //}




        }
        [Test, Description("Verify User is able to Add Node Under Tree")]
        public void TC1_VerifyUserAbleToAddNodeForGitHubWithDraft()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString();
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
                PageControl page = new PageControl(test, driver);
                 page. EscapeActionFromKeyboard();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                page.EscapeActionFromKeyboard();
               // VerifyText(test, "Adding tagGroups to project" + projectName + "TagGroups added successfully", status, "Taggroup added Successfully", "Taggroup is not added successfully with status: " + status + "//");
                VerifyText(test, "Adding Nodes for project" + NodeSubTitle + "Node has been created successfully", status2, "Node has been created successfully", "Node has not been created successfully with status: " + status2 + "//");
                addProject.SuccessScreenshot(addProject.NOTIFICATION_MESSAGE, "Node: " + NodeTitle + " Created Successfully");
                page.EscapeActionFromKeyboard();
               // node.ClickUnityManualTree();
                String Actual = node.GetTextOfNode(NodeSubTitle);
                addProject.SuccessScreenshot("Created NodeSubTitle:  " + NodeSubTitle + "");
                VerifyEquals(test,NodeSubTitle, Actual, "Validation of Node has been added succsssfully", "Validation of Node hasnot  been added succsssfully");
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
                
               // node.ClickUnityManualTree();
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

       //// [OneTimeTearDown]
       // //public void CloseBrowser()
       // {
       //     Console.WriteLine("Quiting Browser");
       //     CloseDriver(driver);
       // }
    }
}