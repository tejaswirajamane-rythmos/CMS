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
        public By PUBLISHING_TAB = By.XPath("//a[@class='mat-tab-link ng-star-inserted desktop-nav'][text()=' Publishing ']");
        public By PUBLISH_HISTORY = By.XPath("//div[@class='mat-tab-label-content'][text()='Publish History']");

        public PublishingPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }
        private ExtentTest test;
    


    }
}
