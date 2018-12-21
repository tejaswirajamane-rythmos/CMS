using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    class TagManagmentProjectLevelPage : SeleniumHelpers.PageControl
    {
        public By NODELEVEL_TAGGROUP_ICON = By.XPath("//i[@class='mdi mdi-tag mdi-24px']");
        public By FILTERHIERARCHY_ICON = By.XPath("//i[@class='mdi mdi-tune mdi-24px']");
        public By GET_TEXT_OF_TAGGROUP = By.XPath("(//mat-panel-title//div/span)[text()='TagGroupName']");
        //public By TAGGROUP_CHECKBOX = By.XPath("(//mat-panel-title//div/span)[text()='TagGroupName']//following::mat-checkbox");
        public By CLOSEBUTTON = By.XPath("//button[@class='mat-button']//i");
        public By APPLY_BUTTON = By.XPath("(//span[@class='mat-button-wrapper'])[text()='APPLY']");
        
        private ExtentTest test;

        public TagManagmentProjectLevelPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void ClickNodeLevelTagGroupIcon()
        {
            Click(NODELEVEL_TAGGROUP_ICON);
            Info(test, " Clicked on Nodelevel TagGroup Icon ");
        }

        public void ClickFilterHierarchyIcon()
        {
            Click(FILTERHIERARCHY_ICON);
            Info(test, " Clicked on FilterHierarchy Icon ");
        }

        public void ClickCloseButton()
        {
            Click(CLOSEBUTTON);
            Info(test,"Clicked on Close Button");
        }

        public void ClickOnApply()
        {
            Click(APPLY_BUTTON);
            Info(test, "Clicked on Apply button at Nodelevel");
        }

        public void CheckTagGroupAtNode(String TagGroupName)
        {
            By TAGGROUP_CHECKBOX_AT_NODE= By.XPath("(//mat-panel-title//div/span)[text()='" + TagGroupName + "']//following::mat-checkbox[1]");
            MoveToelementAndClick(TAGGROUP_CHECKBOX_AT_NODE);

            Click(TAGGROUP_CHECKBOX_AT_NODE);
            Info(test, "Assigned TagGroup at NodeLevel");

        }

        public void CheckTagGroupAtFilter(String TagGroupName)
        {
            By TAGGROUP_CHECKBOX_AT_FILTER = By.XPath("(//mat-panel-title//div/span)[text()='" + TagGroupName + "']//following::mat-checkbox[1]");
            MoveToelementAndClick(TAGGROUP_CHECKBOX_AT_FILTER);

            Click(TAGGROUP_CHECKBOX_AT_FILTER);
            Info(test, "Filtered TagGroup at NodeLevel");

        }

    }
}