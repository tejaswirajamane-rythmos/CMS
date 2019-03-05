using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    class TagManagementProjectLevelPage : SeleniumHelpers.PageControl
    {
        public By DASHBOARD = By.XPath("//a[@href='/dashboard']");
        public By SEARCH_IN_DASHBOARD = By.XPath("//input[@type='Search']");
        public By SETTINGS = By.XPath("(//i[@class='mdi mdi-chevron-down'])[1]");
        public By CLICK_MANAGE_TAG_GROUPS = By.XPath("//button[@class='mat-menu-item'][contains(text(),'Manage Tag Groups')]");
        public By SEARCH_TAGS_AT_PROJECTLEVEL = By.XPath("//input[@placeholder='Search Tag Group']");
        public By AVAILABLE_TAG_PLUS_CIRCLE = By.XPath("(//mat-expansion-panel//i[@class='mdi mdi-plus-circle mdi-18px'])[position()=1]");
        public By ASSIGNED_TAG_CLOSE_CIRCLE = By.XPath("//mat-expansion-panel//i[@class='mdi mdi-close-circle mdi-18px']");
        public By GET_TAG_NAME_AT_PROJECTLEVEL = By.XPath("//mat-chip/span");
        public By CLOSE_MANAGE_TAG_GROUPS = By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']");

        private readonly ExtentTest test;

        public TagManagementProjectLevelPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void ClickDashBoard()
        {
            Click(DASHBOARD);
            Info(test,"Clicked Onn DashBoard");
        }
        public String GetTagNameAtProjectLevel()
        {
            String str = GetText(GET_TAG_NAME_AT_PROJECTLEVEL);
            Console.WriteLine("####" + str);
            Info(test,"The Tag Name at Project Level is" + str);
            return str;
        }
        public void EnterSearchForProject(String ProjectName)
        {
            Clear(SEARCH_IN_DASHBOARD);
            EnterValue(SEARCH_IN_DASHBOARD, ProjectName);
            Info(test,"ProjectName is" + ProjectName);
        }

        public void ClickSettings()
        {
            WaitForElement(SETTINGS);
            Click(SETTINGS);
            Info(test,"Clicked on Settings");
        }

        public void ClickOnManageTagGroups()
        {
            WaitForElement(CLICK_MANAGE_TAG_GROUPS);
            Click(CLICK_MANAGE_TAG_GROUPS);
            Info(test,"Clicked on Manage Tag Groups");
        }

        public void SearchTagsAtProjectLevel(String TagName)
        {
            WaitForElement(SEARCH_TAGS_AT_PROJECTLEVEL);
            Clear(SEARCH_TAGS_AT_PROJECTLEVEL);
            EnterValue(SEARCH_TAGS_AT_PROJECTLEVEL, TagName);
            Info(test,"Searched Tags At Project Level");
        }
        public void ClickPlusCircle()
        {
            WaitForElement(AVAILABLE_TAG_PLUS_CIRCLE);
            Click(AVAILABLE_TAG_PLUS_CIRCLE);
            EscapeActionFromKeyboard();
            Info(test,"Clicked On Plus circle of Available Tag to Move into Assigned Tags");
        }
        public void ClickCloseCircle()
        {
            WaitForElement(ASSIGNED_TAG_CLOSE_CIRCLE);
            Click(ASSIGNED_TAG_CLOSE_CIRCLE);
            Info(test,"Clicked on Close circle to remove the tag from Assigned Tags");
        }
        public void ClickCloseManageTagGroups()
        {
            WaitForElement(CLOSE_MANAGE_TAG_GROUPS);
            Click(CLOSE_MANAGE_TAG_GROUPS);
            Info(test,"Clicked Close Manage Tag Groups");
        }
        public void SuccessScreenshot(String path, String message)
        {
            Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }
    }
}
