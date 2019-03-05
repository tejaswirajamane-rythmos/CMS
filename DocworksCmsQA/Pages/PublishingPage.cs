using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
   public class PublishingPage : SeleniumHelpers.PageControl
    {
        public By PUBLISHING_TAB = By.XPath("//a[@class='mat-tab-link ng-star-inserted'][text()=' Publishing ']");
        public By PUBLISH_HISTORY = By.XPath("//div[@class='mat-tab-label-content'][text()='Publish History']");
        public By PUBLISHED_PROJECT_SEARCHBAR = By.XPath("//input[@placeholder='Search']");
        public By DROPDOWN_BTN = By.XPath("//span[@class='mat-expansion-indicator ng-tns-c14-7 ng-trigger ng-trigger-indicatorRotate ng-star-inserted']");
        public By PUBLISHED_NODE_SEARCHBAR = By.XPath("//input[@placeholder='Search Documents']");
        public By ARROW_MARK_FOR_NODE_SEARCH = By.XPath("//i[@class='mdi mdi-arrow-right mdi-24px']");
        public By CHECK_BOX_FOR_SINGLE_NODE_SELECTION = By.XPath("(//div[@class='mat-checkbox-inner-container mat-checkbox-inner-container-no-side-margin'])[1]");
        public By SELECT_ALL_CHECK_BOX = By.XPath("//div[@class='mat-checkbox-inner-container']");
        public By PUBLISH_CONFIGURATION_BUTTON = By.XPath("//span[text()='Publish Configuration']");
        public By PUBLISH_ONLINEANDOFFLINE_RADIOBTN = By.XPath("(//div[@class='mat-radio-inner-circle'])[1]");
        public By PUBLISH_OFFLINE_RADIOBTN = By.XPath("(//div[@class='mat-radio-inner-circle'])[2]");
        public By PUBLISH_BUTTON = By.XPath("(//span[contains(text(),'Publish')])[last()]");
        public PublishingPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }
        private ExtentTest test;



        public string GetTextOfProjectAfterSearch(String ProjectName)
        {
            By xpath = By.XPath("//div[contains(text(),'" + ProjectName + "']");
            String str = GetText(xpath);
            ElementHighlight(WaitForElement(xpath));
            Info(test, "The Text of Project is:" + str);
            return str;
        }

        public string GetTextOfDistributionAfterSearch(String DistName)
        {
            By xpath = By.XPath("//span[contains(text(),'" + DistName + "']");
            String str = GetText(xpath);
            ElementHighlight(WaitForElement(xpath));
            Info(test, "The Text of Distribution is:" + str);
            return str;
        }

        public string GetCountOfAcceptedDraftsAfterSearch(String AcceptedDrafts)
        {
            By xpath = By.XPath("//span[contains(text(),'" + AcceptedDrafts + "']");
            String str = GetText(xpath);
            ElementHighlight(WaitForElement(xpath));
            Info(test, "The count of AcceptedDrafts is:" + str);
            return str;
        }

        public void ClickPublishOnline()
        {
            if(IsEnabled(PUBLISH_ONLINEANDOFFLINE_RADIOBTN))
            {
                Click(PUBLISH_OFFLINE_RADIOBTN);
            }
            Info(test, "Clicked on Publish Online Radio Button");
        }


    }
}
