using System;
using OpenQA.Selenium;
using System.Diagnostics;
using AventStack.ExtentReports;
using DocWorksQA.Utilities;
using System.Collections.Generic;

namespace DocWorksQA.Pages
{
    class Doc_HistoryPage : SeleniumHelpers.PageControl
    {
        public By DOC_HISTORY_BUTTON = By.XPath("(//button[@class='mat-raised-button'])[3]/span");
        public By SETTINGS_BUTTON = By.XPath("(//span[@class='mat-button-wrapper'])[10]");
        public By HISTORY_TEXT = By.XPath("(//div[@ngclass='node-history-details']//div[@class='mat-line'])[position()=1]");
        public By NODEHISTORY_CLOSEBUTTON = By.XPath("//i[@class='mdi mdi-close mdi-24px']");
        public By ACTIONS_BUTTON = By.XPath("//div[@class='mat-select-value']/span[contains(text(),'Actions')]");
        public By ACCEPTDRAFTTOLIVE_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[1]");
        public By CREATEDRAFT_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[2]");
        public By RENAMEDRAFT_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[3]");
        public By DELETEDRAFT_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[4]");
        public By CHANGENODELOCATION_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[5]");
        public By ADDTAGSTONODE_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[6]");
        public By REMOVETAGSFROMNODE_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[7]");
        public By UPDATESHORTTITLE_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[8]");
        public By UPDATETITLE_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[9]");
        public By UPDATEFILENAME_CHECKBUTTON = By.XPath("(//mat-pseudo-checkbox[contains(@class,'mat-option-pseudo-checkbox')])[10]");
        public By EMPTYSPACEIN_NODEHISTORY = By.XPath("(//mat-list[@class='mat-list'])[2]");
         ///publishing  //a[@class='mat-tab-link desktop-nav ng-star-inserted mat-tab-label-active']
        public By ACTIVITY_BUTTON = By.XPath("(//div[@class='mat-tab-label mat-ripple mat-tab-label-active ng-star-inserted'])[text()='Activity']");
        public By CHOOSE_DATE = By.XPath("//input[@class='mat-input-element mat-form-field-autofill-control ng-untouched ng-pristine ng-valid']");
        //public By CHOOSE_DATE_CALENDER = By.XPath("//button[@aria-label='Open calendar']");
        //public By CHOOSING_DATE_FROM_CALENDER = By.XPath("//*[@id='mat - datepicker - 0']/div[2]/mat-month-view/table/tbody/tr/td/div[contains(text(),'18')]");
        //public By CHOOSE_MONTH = By.XPath("//button[@aria-label='Choose month and year']");
        //public By NEXT_MONTH_BUTTON = By.XPath("//button[@class='mat-calendar-next-button mat-icon-button']");
        public By SEARCH_FIELD = By.XPath("//input[@placeholder='Search']");
        public By SEARCH_BUTTON = By.XPath("//app-document-activity//i[@class='mat-suffix mdi mdi-magnify mdi-24px']");
        //public By NEWDRAFT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary'])[1]");
        //public By DRAFT_NAME = By.XPath("//input[contains(@class,'ng-pristine ng-invalid ng-touched')]");
        //public By BLANKDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[2]");
        //public By EXISTINGDRAFTDROPDOWN = By.XPath("//mat-select[@aria-label='Existing Drafts']");
        //public By CODERDRAFT_CLICK = By.XPath("(//mat-option[@class='mat-option ng-star-inserted mat-selected mat-active']//span)[contains(text(),'Coder Draft')]");
        //public By CREATEDRAFT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Create Draft')]");
        public By ACCEPTDRAFTTOLIVE = By.XPath("//button[@ng-reflect-message='Accept to live overwrites live']");
        public By LEFT_CURSOR = By.XPath("//i[@class='mdi mdi-arrow-left mdi-24px']");
        public By ALLDRAFT = By.XPath("(//mat-panel-title[@class='mat-expansion-panel-header-title'])[1]");
        public By RENAMEDRAFT = By.XPath("(//div[@fxlayoutalign='space-between center']/span)[text()=@draftName]");
        public By DELETEDRAFT_ICON = By.XPath("(//mat-icon/i[@class='mdi mdi-delete mdi-24px cursor-pointer'])[last()]");    
        public By DELETEDRAFT_BUTTON = By.XPath("//button[@class='mat-raised-button mat-primary']/span[text()='Delete']");
        public By RENAME_RIGHT_MARK = By.XPath("(//button[@class='mat-menu-item']/i)[1]");
        public By LIST_OF_DRAFTS = By.XPath("//div[@class='tag-editing']/div/span");
        private ExtentTest test;
        public Doc_HistoryPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void ClickDoc_History()
        {
            WaitForElement(DOC_HISTORY_BUTTON);
            Click(DOC_HISTORY_BUTTON);
            Info(test, "Clicked on DocHistory Button.");
        }
        public void Settings_Button()
        {
            WaitForElement(SETTINGS_BUTTON);
            Click(SETTINGS_BUTTON);
            Info(test, "Clicked on Settings Button.");
        }

        public String GetHistoryMessage()
        {
            Info(test, GetText(HISTORY_TEXT));
            return GetText(HISTORY_TEXT);

        }


        public void ClickActions()
        {
            WaitForElement(ACTIONS_BUTTON);
            Click(ACTIONS_BUTTON);
            Info(test, "Clicked on Actions Button.");
        }

        public void SuccessScreenshot(String path, String message)
        {
            Info(test, "<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }

        public void SuccessScreenshot(String message)
        {
            String path = TakeScreenshot();
            SuccessScreenshot(path, message);
        }

        public void ClickCheckBoxAcceptDraftToLive()
        {
            Click(ACCEPTDRAFTTOLIVE_CHECKBUTTON);
            Info(test,"Clicked AcceptDraftToLive Checkbox");
        }

        public void ClickCheckBoxCreateDraft()
        {
            Click(CREATEDRAFT_CHECKBUTTON);
            Info(test,"Clicked CreateDraft Checkbox");
        }

        public void ClickCheckBoxRenameDraft()
        {
            WaitForElement(RENAMEDRAFT_CHECKBUTTON);
            Click(RENAMEDRAFT_CHECKBUTTON);
            Info(test,"Clicked RenameDraft Checkbox");
        }

        public void ClickCheckBoxDeleteDraft()
        {
            Click(DELETEDRAFT_CHECKBUTTON);
            Info(test,"Clicked DeleteDraft Checkbox");
            Click(SEARCH_BUTTON);

        }

        public void ClickCheckBoxChangeNodeLocation()
        {
            Click(CHANGENODELOCATION_CHECKBUTTON);
            Info(test,"Clicked ChangeNodeLocation Checkbox");
        }

        public void ClickCheckBoxAddTagsToNode()
        {
            Click(ADDTAGSTONODE_CHECKBUTTON);
            Info(test,"Clicked AddTagsToNode Checkbox");
        }

        public void ClickCheckBoxRemoveTagsFromNode()
        {
            Click(REMOVETAGSFROMNODE_CHECKBUTTON);
            Info(test,"Clicked RemoveTagsFromNode Checkbox");
        }

        public void ClickCheckBoxUpdateShortTitle()
        {
            Click(UPDATESHORTTITLE_CHECKBUTTON);
            Info(test,"Clicked UpdateShortTitle Checkbox");
        }

        public void ClickCheckBoxUpdateTitle()
        {
            Click(UPDATETITLE_CHECKBUTTON);
            Info(test,"Clicked UpdateTitle Checkbox");
        }

        public void ClickCheckBoxUpdateFileName()
        {
            Click(UPDATEFILENAME_CHECKBUTTON);
            Info(test,"Clicked UpdateFileName Checkbox");

        }

        public void ClickEmptySpaceInNodeHistory()
        {
            ClickByJavaScriptExecutor(EMPTYSPACEIN_NODEHISTORY);
            Info(test, "Clicked on Empty space in NodeHistory");
        }

        public void ClickActivityTab()
        {
            System.Threading.Thread.Sleep(25000);
            MoveToelementAndClick(ACTIVITY_BUTTON);
            Info(test, "Clicked on Activity tab");
        }

        public void ChooseDate()
        {
            WaitForElement(CHOOSE_DATE);
            Click(CHOOSE_DATE);
            Info(test,"Clicked on ChooseDate");
            EnterValue(CHOOSE_DATE, "06/28/2018");
        }

        public void ClickChooseDateCalender()
        {
            Click(CHOOSE_DATE);
            Info(test,"Clicked on ChooseDateCalender");
        }

        /* public void ChooseDateFromCalender()
        {
            Click(CHOOSING_DATE_FROM_CALENDER);
            Info("Choosed date from Calender");
        }*/

        public void ClickSearchField(String searchvalue)
        {
            WaitForElement(SEARCH_FIELD);
            Clear(SEARCH_FIELD);
            System.Threading.Thread.Sleep(15000);
            EnterValue(SEARCH_FIELD, searchvalue);
            Info(test,"Entered value in SearchField");

        }

        public void ClickSearchButton()
        {
            WaitForElement(SEARCH_BUTTON);
            Click(SEARCH_BUTTON);
            Info(test,"Clicked on Searchbutton");

        }

        public void ClickAcceptDraftToLive()
        {
            Click(ACCEPTDRAFTTOLIVE);
            WaitForElement(ACCEPTDRAFTTOLIVE);
            Info(test,"Clicked on AcceptDraftToLive");

        }

        public void ClickLeftCursor()
        {
            Click(LEFT_CURSOR);
            Info(test,"Clicked on LeftCursor");

        }

        public void ClickAllDrafts()
        {
            Click(ALLDRAFT);
            Info(test,"Clicked on AllDrafts");

        }

        public void RenameDraft(String draftName, String newDraftName)
        {

            By RENAMEDRAFT = By.XPath("(//div[@fxlayoutalign='space-between center'])/span[text()='" + draftName + "']");
            By DRAFT_NAME = By.XPath("//input[@name='draftName']");
            WaitForElement(RENAMEDRAFT);
            MoveToelementAndClick(RENAMEDRAFT);
            Clear(DRAFT_NAME);
            Type(DRAFT_NAME, newDraftName);


        }

        public void ClickOnDraft()
        {
            Click(RENAMEDRAFT);
            Info(test,"Clicked on draft to rename");
        }

        public void ClickDeleteDraftIcon(String RenameDraft)
        {
          //  Click(DELETEDRAFT_ICON);
            MoveToelementAndClick(By.XPath("(//div[@class='tag-editing']//div/span[text()='" + RenameDraft + "\'])//following::mat-icon[1]"));

            Info(test,"Clicked on Delete draft Icon");
        }

        public void ClickDeleteDraftButton()
        {
          //  WaitForElement(DELETEDRAFT_BUTTON);
            Click(DELETEDRAFT_BUTTON);
            Info(test, "Clicked on Delete draft Button");
        }

        public void ClickOnRightMarkToRename()
        {
            Click(RENAME_RIGHT_MARK);
            Info(test,"Clicked on RightMarkToRename");
        }

        public void ClickOnNodeHistoryCloseButton()
        {
            System.Threading.Thread.Sleep(5000);
            WaitForElement(NODEHISTORY_CLOSEBUTTON);
            MoveToelementAndClick(NODEHISTORY_CLOSEBUTTON);
            Info(test, "Clicked on NodeHistoryCloseButton");
            
        }

        public void ClickDeleteIcon(string RenameDraft)
        {
            IList<IWebElement> draftList = GetElementList(LIST_OF_DRAFTS);

            foreach(IWebElement e in draftList)
            {
                if (e.Text == RenameDraft)
                {
                    Click(By.XPath("(//div[@class='tag-editing']//div/span[text()='"+RenameDraft+"\'])//following::mat-icon[1]"));
                    Info(test, "Clicked on delete draft icon");
                    break;

                }
            }

            
        }

    }

}
