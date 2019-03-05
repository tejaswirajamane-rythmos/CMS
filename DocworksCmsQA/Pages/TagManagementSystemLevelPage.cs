using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
namespace DocWorksQA.Pages
{
     class TagManagementSystemLevelPage : SeleniumHelpers.PageControl
    {
        public By SYSTEM_LEVEL = By.XPath("//a[@href='/system']");
        public By CREATE_TAGGROUP_BUTTON = By.XPath("(//span[@class='mat-button-wrapper'])[4]");
        public By TAG_GROUP_NAME = By.XPath("//input[@placeholder='Tag Group Name']");
        public By LIMITTOONE_CHECKBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[1]");
        public By CHILDNODESINHERITS_CHECKBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[2]");
        public By DISPLAYGROUPNAME_CHECHBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[3]");
        public By DISPLAYONPUBLISHEDPATH_CHECKBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[4]");
        public By INCLUDEINPUBLISHEDMETA_CHECKBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[5]");
        public By USERTAGGROUP_CHECKBOX = By.XPath("(//div[@class='mat-checkbox-inner-container'])[6]");
        public By DISPLAY_GROUP_NAME_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Display group name')]");
        public By COLOR_PICKER = By.XPath("//div[@class='ui-colorpicker-color']");
        //public By CSSVALUE = By.CssSelector(COLOR_PICKER);
        public By CREATE_TAGGROUP = By.XPath("//span[@class='mat-button-wrapper'][text()=' CREATE ']");
        public By GET_TAGGROUP_NAME = By.XPath("/html/body/app-root/app-main/mat-sidenav-container/mat-sidenav-content/div/div/app-system/div/app-tag-group-dashboard/div/mat-list/div[2]/div[1]/div/mat-list-item/div");
        public By EDIT_TAGGROUP_ICON = By.XPath("//i[@class='mdi mdi-dots-vertical mdi-24px cursor-pointer']");
        public By EDIT_TAG_GROUP = By.XPath("//button[@class='mat-menu-item'][contains(text(),'Edit Tag Group')]");
        public By MANAGE_TAG_GROUP = By.XPath("(//button[@class='mat-menu-item'])[text()='Manage Tags']");
        public By ADD_TAG = By.XPath("//span[@class='mat-button-wrapper'][text()='ADD TAG']");
        public By PENCIL_BUTTON = By.XPath("(//mat-icon//i[@class='mdi mdi-pencil mdi-24px'])[1]");
       public By ENTER_TAG_NAME = By.XPath("//input[@name='newTagName']");
        public By CHM_By_CLASS = By.ClassName("mat-suffix mdi mdi-check mdi-24px cursor-pointer");
        public By CHECK_THE_TAGNAME = By.XPath("//i[@class='mat-suffix mdi mdi-check mdi-24px cursor-pointer']");
        public By CROSS_TAG_NAME = By.XPath("//button[@class='mat-menu-item']//i[@class='mdi mdi-close mdi-24px']");
        public By MANAGETAGS_BACKDROP = By.XPath("//div[@class='cdk-overlay-backdrop cdk-overlay-dark-backdrop cdk-overlay-backdrop-showing']");
        public By CLOSE_MANAGE_TAGS = By.XPath("//button[@class='mat-button']//i[@class='mdi mdi-close mdi-24px']");
        public By GET_LATEST_MODIFIED_DATE = By.XPath("(//mat-list-item/div/div[3]/span)[last()]");
        public By GET_NO_OF_TAGS = By.XPath("(//mat-list-item/div/div[3]/span)[last()-1]");
        public By GET_PROJECTS_POINTED = By.XPath("(//mat-list-item/div/div[3]/span)[last()-2]");
        public By GET_PUBLIC_VALUE = By.XPath("(//mat-list-item/div/div[3]/span)[last()-3]");
        public By DELETE_TAG = By.XPath("//mat-icon/i[@class='mdi mdi-delete mdi-24px']");
        public By DELETE_TAGGROUP = By.XPath("//button[@class='mat-menu-item'][text()='Delete Tag group']");
        public By UPDATE_TAGGROUP = By.XPath("//button/span[contains(text(),'UPDATE')]");
        public By CLOSE_EDIT_TAGS = By.XPath("//button[@class='mat-button']//i[@class='mdi mdi-close mdi-24px']");
        public By GET_TAG_NAME = By.XPath("(//mat-dialog-container//mat-dialog-content//mat-list-item//div[@class='ng-star-inserted'])[last()]");
        public By SEARCH_TAGGROUP_COLLECTION = By.XPath("//input[@ngclass='form-control']");
        public By SEARCH_IN_MANAGETAGS = By.XPath("//input[@placeholder='Search Tags']");
        public By GET_SIZE_OF_NO_OF_TAGS = By.XPath("//mat-dialog-container//mat-list-item[@class='mat-list-item ng-star-inserted']/div");
        public By ENTER_EDIT_TAG = By.XPath("(//input[@class='form-control ng-pristine ng-valid ng-touched'])[2]");
        public By ENTER_TAG_NAME_1 = By.XPath("(//div[@class='custom-mat-input-wrapper']/input)[2]");
        //public By ENTER_TAG_NAME_2 = By.XPath("//div/input[@name='tagName']");
        public By BACK_DROP = By.XPath("//div[@class='cdk-overlay-backdrop cdk-overlay-dark-backdrop cdk-overlay-backdrop-showing']");
       // public By AUTHORING_TAB = By.XPath("//a[@class='mat-tab-link desktop-nav ng-star-inserted'][1]");
        public By DELETE_TAG_GROUP_CONFIRM_BUTTON = By.XPath("//span[@class='mat-button-wrapper'][contains(text(),'Confirm')]");
        private readonly ExtentTest test;

        public  TagManagementSystemLevelPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void ClickSystemTab()
        {
            WaitForElement(SYSTEM_LEVEL);
            Click(SYSTEM_LEVEL);
            Info(test,"Clicked on System Screen");
        }
        public void BackToProject()
        {
            
            Click(BACK_DROP);
            Info(test, "Clicked Back Drop");
        }

        public void ClickCreateTagGroup()
        {
            WaitForElement(CREATE_TAGGROUP_BUTTON);
            Click(CREATE_TAGGROUP_BUTTON);
            Info(test,"Clicked on Create Tag Group Button");
        }

        public String EnterTagGroupName()
        {
            String str = "GROUPTAG" + GenerateRandomNumbers(3);
            Clear(TAG_GROUP_NAME);
            EnterValue(TAG_GROUP_NAME, str);
            Info(test,"Entered tag Group Name as" + str);
            return str;
        }
        public void EditTagGroupName(String newTagGroupName)
        {
           
            By Tag_Group_Name = By.XPath("//input[@placeholder='Tag Group Name']");
          
           Info(test, "Edited tag Group Name as" + newTagGroupName);
           Clear(Tag_Group_Name);
           Type(Tag_Group_Name, newTagGroupName);
           // return str;
        }

         public  void EnterTagInEditTag(string newTagName)
        {
         

            System.Threading.Thread.Sleep(5000);
            Clear(ENTER_TAG_NAME_1);

           
            Type(ENTER_TAG_NAME_1, newTagName);
            Info(test, "Edited tag  Name  is " + newTagName);

        }



        public void ClickDeleteTagGroup(string TagGroupName)
        {
            Click(DELETE_TAGGROUP);
            WaitForElement(DELETE_TAG_GROUP_CONFIRM_BUTTON);
            System.Threading.Thread.Sleep(7000);
            Click(DELETE_TAG_GROUP_CONFIRM_BUTTON);
            Info(test, "Deleted tag Group Name  is " + TagGroupName);


        }

        public void ClickEditTagInManageTags(string newTagName)
        {
            Click(PENCIL_BUTTON);
           // Info(test, "Clicked on EditTagIcon");
            System.Threading.Thread.Sleep(5000);
          //  MoveToelementAndClick(ENTER_TAG_NAME_1);
           // Info(test, "Clicked");
            //System.Threading.Thread.Sleep(7000);
            //ClickByJavaScriptExecutor(ENTER_TAG_NAME_1);
           // Info(test, "Clicked on Textbox of Edit Tag");
            //ClearByJavaScriptExecutor(ENTER_TAG_NAME_1);
            //Info(test, "Cleared");
            //System.Threading.Thread.Sleep(7000);
            SendKeysByJavaScriptExecutor(ENTER_TAG_NAME_1, newTagName);
           // Info(test, "Edited tag  Name  is " + newTagName);
            System.Threading.Thread.Sleep(7000);
            ClickByJavaScriptExecutor(CHECK_THE_TAGNAME);
            //ClickByJavaScriptExecutor(CHECK_THE_TAGNAME);
            System.Threading.Thread.Sleep(7000);
          //  Info(test, "Clicked on Check Mark Icon");
            ////EnterSearchInManageTags("TAG123");
        }

        internal void ClickDeleteTag(string TagName)
        {
            Click(EDIT_TAGGROUP_ICON);
            Click(MANAGE_TAG_GROUP);
            Click(DELETE_TAG);
            Info(test, "Tag deleted is:" + TagName);
        }

        public void ClickBackToManageTags()
        {
            EscapeActionFromKeyboard();
            Info(test, "Clicked On Escape Action From KeyBoard");
        }

        public void SuccessScreenshot(String path, String message)
        {
            Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }
        public void ClickColorPicker()
        {
            Click(COLOR_PICKER);
            System.Threading.Thread.Sleep(5000);
            Click(COLOR_PICKER);
            Info(test,"Selected Tag Color");
        }

        public void ClickCheckBoxLimitToOne()
        {
            Click(LIMITTOONE_CHECKBOX);
            Info(test,"Clicked LIMITTOONE Checkbox");
        }

        public void ClickChildNodeInheritCheckBox()
        {
            Click(CHILDNODESINHERITS_CHECKBOX);
            Info(test,"Clicked oon Child Node Inherit checkbox");
        }

        public void ClickDisplayOnPublishPathCheckBox()
        {
            Click(DISPLAYONPUBLISHEDPATH_CHECKBOX);
            Info(test,"Clicked DisplayOnPublishPath Checkbox");
        }

        public void ClickDisplayGroupNameCheckBox()
        {
            Click(DISPLAYGROUPNAME_CHECHBOX);
            Info(test,"Clicked DisplayGroupName Checkbox");
        }

        public void ClickIncludeInPublishedMetaCheckBox()
        {
            Click(INCLUDEINPUBLISHEDMETA_CHECKBOX);
            Info(test,"Clicked IncludeInPublishedMeta Checkbox");
        }

        public void ClickUserTagGroupCheckBox()
        {
            Click(USERTAGGROUP_CHECKBOX);
            Info(test,"Clicked UserTagGroup Checkbox");
        }

        public void ClickCreateTagGroupAfterDone()
        {
            Click(CREATE_TAGGROUP);
            Info(test,"Clicked Create Tag group");
        }

      
        public String GetTagGroupName(String TagGroupName)
        {
            String s = "//mat-list-item//div/span/span" + "[text()='" + TagGroupName + "']";
            Console.WriteLine("The group name");
            String str1 = GetTextOfHiddenElement(By.XPath(s));
            Console.WriteLine("The group name is :" + str1.ToString());
            Info(test, "The Tag Group Name Created is " + str1.ToString());
            return str1.ToString();

        }
        public String GetTextOfEditedTag(String TAG123)
        {
            String s = "//mat-list-item//div/span/span" + "[text()='" + TAG123 + "']";
            //Console.WriteLine("The Tag name");
            String str1 = GetTextOfHiddenElement(By.XPath(s));
            Console.WriteLine("The Tag name is :" + str1.ToString());
            Info(test, "The Tag Name Created is " + str1.ToString());
            return str1.ToString();

        }
        public String GetNoOfTagsInSystemLevel(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[3]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The No of Tags is :" + str1.ToString());
            Info(test,"The No of Tags is " + str1.ToString());
            return str1.ToString();
        }
        public String GetPublicValue(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[1]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The public value is :" + str1.ToString());
            Info(test,"The public value  is " + str1.ToString());
            return str1.ToString();
        }
        public String GetProjctsPointed(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[2]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("TheProjects Pointed is :" + str1.ToString());
            Info(test,"The Projects Pointed  is " + str1.ToString());
            return str1.ToString();
        }
        public String GetLastModified(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[4]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The Get Last Modified value is :" + str1.ToString());
            Info(test,"The Get Last Modified  value  is " + str1.ToString());
            return str1.ToString();

        }
        public void ClickTagGroupUpdate()
        {
            Click(UPDATE_TAGGROUP);
            Info(test,"Clicked On Update tag Group ");
        }
        public String GetTagName(String EditTag)
        {
            Console.WriteLine("The Tag name");
            String str = GetText(GET_TAG_NAME);
            Console.WriteLine("The Tag name is :" + str);
            Info(test,"The Tag Created is " + str);
            return str;
        }
        public void ClickGetDetails(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::mat-icon[1]/i";
            System.Threading.Thread.Sleep(15000);

            ClickByJavaScriptExecutor(By.XPath(s1));
            System.Threading.Thread.Sleep(10000);
            Info(test,"Clicked On the Get Details of Tag Group");
        }

       
        public void ClickManageTags()
        {
            WaitForElement(MANAGE_TAG_GROUP);
            Click(MANAGE_TAG_GROUP);
            Info(test,"Clicked on Manage tags");
        }

        public void ClickEditTagGroups(String TagGroupName)
        {
            Click(EDIT_TAG_GROUP);
            Info(test,"Clicked on Edit Tag Group");
        }
        public void ClickAddTag()
        {
            WaitForElement(ADD_TAG);
            Click(ADD_TAG);
            Info(test,"Clicked on Add Tag Button");
        }

        public String EnterTagName()
        {
            String str = "TAG" + GenerateRandomNumbers(3);
            WaitForElement(ENTER_TAG_NAME);
            EnterValue(ENTER_TAG_NAME, str);
            Info(test,"Entered Tag Name as" + str);
            return str;
        }

        public void ClickAcceptTagName()
        {
            WaitForElement(CHECK_THE_TAGNAME);
            ClickByJavaScriptExecutor(CHECK_THE_TAGNAME);
            Info(test,"Clicked the Accept Button of Tags");
            System.Threading.Thread.Sleep(8000);
        }

        public String GetSizeOfTagsInManageTags()
        {

            String str = GetSizeOfElements(GET_SIZE_OF_NO_OF_TAGS);
            Console.WriteLine("Size of Tags" + str);
            return str;
        }

        public void ClickCloseManageTags()
        {
            System.Threading.Thread.Sleep(10000);
            Click(CLOSE_MANAGE_TAGS);
            Info(test,"Clicked on Close Manage Tags");
        }
        public void ClickCloseEditTags()
        {
            System.Threading.Thread.Sleep(10000);
            Click(CLOSE_EDIT_TAGS);
            Info(test, "Clicked on Close Edit Tags");
        }
        public void EnterSearchTagInTagGroup(String TagGroupName)
        {
            WaitForElement(SEARCH_TAGGROUP_COLLECTION);
            Clear(SEARCH_TAGGROUP_COLLECTION);
            EnterValue(SEARCH_TAGGROUP_COLLECTION, TagGroupName);
            Info(test,"Entered Tag group Name in Search Bar of Tag Group Collection");
          
        }

        public void EnterSearchInManageTags(String TagName )
        {
            Clear(SEARCH_IN_MANAGETAGS);
            EnterValue(SEARCH_IN_MANAGETAGS ,TagName);
            Info(test, "Entered Tag Name in Search Bar of ManageTags is:"+ TagName);

        }
        public void EnterSearchInManageTagsAfterEdit(String TAG123)
        {
            Clear(SEARCH_IN_MANAGETAGS);
            EnterValue(SEARCH_IN_MANAGETAGS, TAG123);
            Info(test, "Entered Edited Tag Name in Search Bar of ManageTags is:" + TAG123);

        }


        public void ClickEditTagGroup(String TagGroupName)
        {
            By GET_DETAILS_OF_TAGGROUP = By.XPath("(//mat-list-item//div/span/span)[text()='"+ TagGroupName + "']//following::mat-icon/i[1]");
            MoveToelementAndClick(GET_DETAILS_OF_TAGGROUP);

            Click(GET_DETAILS_OF_TAGGROUP);


        }
    
        public void ClickEditTagGroupIcon(String TagGroupName)
        {
            WaitForElement(EDIT_TAGGROUP_ICON);
            Click(EDIT_TAGGROUP_ICON);
            Info(test, "Clicked on edit tag group icon");
        }

}
}