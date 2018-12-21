using AventStack.ExtentReports;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace DocworksCmsQA.Tests.Taggroupscreation
{
    [TestFixture, Category("TagGroupCreation")]
    [Parallelizable]
    class TagGroupCreationEditManageDelete : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
         String newTagGroupName;
        readonly String TagGroupName;
        readonly string newTagName;
        string EditTag; 


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }


        [Test, Description("Verify User is able to Create and Edit TagGroups ")]
        public void TC_VerifyCreateTagGroupEdit()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                TagManagementSystemLevelPage createTagGroup = new TagManagementSystemLevelPage(test, driver);
                createTagGroup. ClickSystemTab();
                createTagGroup.ClickCreateTagGroup();
                String TagGroupName = createTagGroup.EnterTagGroupName();
                createTagGroup.ClickDisplayGroupNameCheckBox();
                createTagGroup.ClickIncludeInPublishedMetaCheckBox();
                createTagGroup.ClickChildNodeInheritCheckBox();
                createTagGroup.ClickDisplayOnPublishPathCheckBox();
                createTagGroup.ClickColorPicker();

                createTagGroup.ClickCreateTagGroupAfterDone();

                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SuccessScreenshot("TagGroup got Created Successfully");
                createTagGroup.EnterSearchTagInTagGroup(TagGroupName);
                System.Threading.Thread.Sleep(6000);
                String Acutal = createTagGroup.GetTagGroupName(TagGroupName);
                addProject.SuccessScreenshot("Created TagGroup:  " + TagGroupName + "");
                createTagGroup.ClickEditTagGroupIcon(TagGroupName);
                createTagGroup.ClickEditTagGroup(TagGroupName);
                //Editing,Renaming Draft
                newTagGroupName = "TagGroupedit";
               createTagGroup.EditTagGroupName(newTagGroupName);
                System.Threading.Thread.Sleep(2000);
                createTagGroup.ClickTagGroupUpdate();
                Console.WriteLine("Edited TagGroup");
                createTagGroup.EnterSearchTagInTagGroup(newTagGroupName);
                System.Threading.Thread.Sleep(2000);

                Console.WriteLine(" searched Edited TagGroup");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }
        }
        [Test, Description("Verify User is able to do Manage(Add,Edit&Delete) tag  ")]
       public void TC_VerifyCreateTagGroupManage()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                TagManagementSystemLevelPage createTagGroup = new TagManagementSystemLevelPage(test, driver);
                createTagGroup.ClickSystemTab();
                createTagGroup.ClickCreateTagGroup();
                String TagGroupName = createTagGroup.EnterTagGroupName();
                //createTagGroup.ClickDisplayGroupNameCheckBox();
                //createTagGroup.ClickIncludeInPublishedMetaCheckBox();
                //createTagGroup.ClickChildNodeInheritCheckBox();
                //createTagGroup.ClickDisplayOnPublishPathCheckBox();
                //createTagGroup.ClickColorPicker();
                createTagGroup.ClickCheckBoxLimitToOne();

                createTagGroup.ClickCreateTagGroupAfterDone();

                    AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SuccessScreenshot("TagGroup got Created Successfully");
                createTagGroup.EnterSearchTagInTagGroup(TagGroupName);
                System.Threading.Thread.Sleep(6000);
                String Acutal = createTagGroup.GetTagGroupName(TagGroupName);
                addProject.SuccessScreenshot("Created TagGroup:  " + TagGroupName + "");
                createTagGroup.ClickEditTagGroupIcon(TagGroupName);
                //createTagGroup.ClickEditTagGroup(TagGroupName);
                //Editing,Renaming 

                createTagGroup.ClickManageTags();
                System.Threading.Thread.Sleep(7000);
                createTagGroup.ClickAddTag();
                String TagName = createTagGroup.EnterTagName();
                createTagGroup.ClickAcceptTagName();
                addProject.SuccessScreenshot("Tag got Created Successfully");
                createTagGroup.EnterSearchInManageTags(TagName);
                //Edit Tag
                createTagGroup.ClickEditTagInManageTags("TAG123");
                System.Threading.Thread.Sleep(2000);
                createTagGroup.EnterSearchInManageTagsAfterEdit("TAG123");
               // String Acutal1 = createTagGroup.GetTextOfEditedTag("TAG123");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Searched Edited Tag");
                //createTagGroup.EnterTagInEditTag("newTagName");

                //  createTagGroup.ClickAcceptTagName();
                addProject.SuccessScreenshot("Created TagGroup:  " + newTagName + "");
                //Delete Tag
                //createTagGroup.ClickDeleteTag(TagName);
                //System.Threading.Thread.Sleep(2000);
                //createTagGroup.ClickBackToManageTags();

                ////createTagGroup.ClickCloseManageTags();
                //Console.WriteLine(" Added Tag name is:"+ TagName +"");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
                throw;
            }
        }
        [Test, Description("Verify User is able to do Manage(Add) tag  ")]
        public void TC_VerifyCreateTagGroupDelete()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                TagManagementSystemLevelPage createTagGroup = new TagManagementSystemLevelPage(test, driver);
                createTagGroup.ClickSystemTab();
                createTagGroup.ClickCreateTagGroup();
                String TagGroupName = createTagGroup.EnterTagGroupName();
                //createTagGroup.ClickDisplayGroupNameCheckBox();
                //createTagGroup.ClickIncludeInPublishedMetaCheckBox();
                //createTagGroup.ClickChildNodeInheritCheckBox();
                //createTagGroup.ClickDisplayOnPublishPathCheckBox();
                //createTagGroup.ClickColorPicker();
                createTagGroup.ClickCheckBoxLimitToOne();

                createTagGroup.ClickCreateTagGroupAfterDone();

                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SuccessScreenshot("TagGroup got Created Successfully");
                createTagGroup.EnterSearchTagInTagGroup(TagGroupName);
                System.Threading.Thread.Sleep(6000);
                String Acutal = createTagGroup.GetTagGroupName(TagGroupName);
                addProject.SuccessScreenshot("Created TagGroup:  " + TagGroupName + "");
                // addProject.SuccessScreenshot("TagGroup got Created Successfully");
                createTagGroup.EnterSearchTagInTagGroup(TagGroupName);

                //Delete TagGroup
                createTagGroup.ClickEditTagGroupIcon(TagGroupName);
                System.Threading.Thread.Sleep(2000);

                createTagGroup.ClickDeleteTagGroup(TagGroupName);
                System.Threading.Thread.Sleep(6000);
                addProject.SuccessScreenshot("Deleted TagGroup:  " + TagGroupName + "");

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
           // db.FindProjectAndDelete(projectName);
        }

    }
}
