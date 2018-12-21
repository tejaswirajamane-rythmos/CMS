using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using NUnit.Framework;


namespace DocWorksQA.Pages
{
    class NodesPage : SeleniumHelpers.PageControl
    {
        public By UNITYMANUAL_TREE = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By UNITYMANUAL_SIDEBAR = By.XPath("//span[@class='ui-tree-toggler fa fa-fw fa-caret-right']");
        public By NEW_NODE_CLICK = By.XPath("(//a[@class='ui-menuitem-link ui-corner-all ng-star-inserted'])[1]");
        public By NODE_Title = By.XPath("//input[@placeholder='Title']");
        public By CLICK_RENAME_SHORT_TITLE = By.XPath("(//a[@class='ui-menuitem-link ui-corner-all ng-star-inserted'])[4]");
        public By Node_SubTitle = By.XPath("//input[@placeholder='Short Title']");
        public By DRAFT_NAME = By.XPath("//input[@placeholder='Draft Name']");
        public By CREATE_NODE = By.XPath("(//button/span)[contains(text(),'Create Node')]");
        public By NONE_RADIO_BUTTON = By.XPath("(//mat-radio-button//div[@class='mat-radio-outer-circle'])[2]");
        public By RIGHT_CLICK_ON_NODE = By.XPath("((//div[@class='ng-star-inserted'])/span)[2]");
        public By LAST_CREATED_NODE = By.XPath("(//li/div[@class='ui-treenode-content ui-treenode-selectable'])[last()]");
        public By LAST_CREATED_NODE_SIDEBAR = By.XPath("(//li/div[@class='ui-treenode-content ui-treenode-selectable'])[last()]/span[@class='ui-tree-toggler fa fa-fw fa-caret-right']");
        public By SEARCH_BAR_TOC_LEVEL = By.XPath("//input[@placeholder='Search Documents...']");
        public ExtentTest test;
        public NodesPage(ExtentTest test,IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void RightClickOnParentTree()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndRightClick(UNITYMANUAL_TREE);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Right Click on Unity Manual is performed");
        }

        public void RightClickOnNode(String NodeSubTitle)
        {
            System.Threading.Thread.Sleep(7000);
            RightClick(Node_SubTitle);
            System.Threading.Thread.Sleep(7000);
            Info(test, "Clicked on Node");
        }

        public void ClickOnNewNode()
        {
            MoveToelementAndClick(NEW_NODE_CLICK);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on New Node");
        }
        public void ClickRenameShortTitleNode(String NodeSubTitle)
        {
            MoveToelementAndClick(CLICK_RENAME_SHORT_TITLE);
            System.Threading.Thread.Sleep(7000);
            Info(test, "Clicked on New Node");
        }

        public String EnterNodeTitle()
        {
            String str = "NodeTitle" + GenerateRandomNumbers(3);
            EnterValue(NODE_Title, str);
            Info(test,"Entered Node Title with :" + str);
            System.Threading.Thread.Sleep(7000);
            return str;
        }

        public String EnterNodeSubTitle()
        {
            String str = "NodeSubtitle" + GenerateRandomNumbers(3);
            EnterValue(Node_SubTitle, str);
            Info(test,"Entered Node Sub Title with :" + str);
            System.Threading.Thread.Sleep(7000);
            return str;
        }

        public String EnterDulicateNodeName(String NodeName)
        {
            EnterValue(NODE_Title, NodeName);
            Info(test,"Entered Node Name with :" + NodeName);
            System.Threading.Thread.Sleep(7000);
            return NodeName;
        }

        public String EnterDraftName()
        {
            String str = "Draft" + GenerateRandomNumbers(3);
            EnterValue(DRAFT_NAME, str);
            Info(test,"Entered Draft Name with : " + str);
            System.Threading.Thread.Sleep(7000);
            return str;

        }


        public void ClickNoneRadioButton()
        {
            Click(NONE_RADIO_BUTTON);
            Info(test,"Clicked on None Radio Button");
            System.Threading.Thread.Sleep(7000);
        }

    
        public void ClickCreateNode()
        {
            Click(CREATE_NODE);
            Info(test,"Clicked Create Node Button");
            System.Threading.Thread.Sleep(7000);
        }
        
        public void ClickUnityManualTree()
        {
            Click(UNITYMANUAL_SIDEBAR);
            Info(test,"Clicked Unity Manual Side Bar for extensions");
            System.Threading.Thread.Sleep(7000);

        }

        public void ClickLastNodeSideBar()
        {
            Click(UNITYMANUAL_SIDEBAR);
            Click(LAST_CREATED_NODE_SIDEBAR);
           Info(test,"Clicked Side Bar of Parent Node for extensions");
            System.Threading.Thread.Sleep(7000);
        }
        public void ClickDashboard()
        {
            Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on Dashboard");
        }

        public void RightClickOnParentNode()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndRightClick(LAST_CREATED_NODE);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Right Click on Parent Node is performed");
        }

    

        public String GetTextOfNode(String NodeName)
        {
            System.Threading.Thread.Sleep(7000);
            By xpath = By.XPath("//p-treenode//div//span[text()='" + NodeName + "']");
            String str = GetText(xpath);
            ElementHighlight(WaitForElement(xpath));
            Info(test,"The Text of Node Created is" + str);
            return str;
        }
        public String GetTextOfNodeAfterSearch(String NodeName)
        {
            System.Threading.Thread.Sleep(7000);
            By xpath = By.XPath("//p-treenode//div//span[text()='" + NodeName + "']");
            String str = GetText(xpath);
            ElementHighlight(WaitForElement(xpath));
            Info(test, "The Text of Node Created is" + str);
            return str;
        }

        public void ClickOnNode(String NodeName)
        {
            String str = "(//li/div[@class='ui-treenode-content ui-treenode-selectable']//span)"+ "[text()='"+NodeName+"']";
            Click(By.XPath(str));
            Info(test,"Clicked On Node" + NodeName);
        }

        public void ClickBlankRadioButton()
        {
            Click(NONE_RADIO_BUTTON);
            Info(test, "Clicked On None Radio Button");
        }
        public void SearchBarAtTocLevel(String NodeSubTitle)
        {
            Click(SEARCH_BAR_TOC_LEVEL);
            EnterValue(SEARCH_BAR_TOC_LEVEL, NodeSubTitle);
            Info(test, "Searched Created node");
        }
    }
}
