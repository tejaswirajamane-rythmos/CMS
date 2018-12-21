using System;
using OpenQA.Selenium;
using System.Diagnostics;
using AventStack.ExtentReports;
using DocWorksQA.Utilities;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace DocWorksQA.Pages
{
    public class AddProjectPage : SeleniumHelpers.PageControl
    {
        public By GET_TITLE = By.XPath("//mat-card/mat-card-title/div");
        public By ADDPROJECT_BUTTON = By.XPath("//button[contains(text(),'Create Project')]");
        public By PROJECT_TITLE_FIELD = By.XPath("//input[@placeholder='Project Title']");
        public By BELL_NOTIFICATION = By.XPath("//mat-chip[@class='mat-chip notification cursor-pointer mat-warn mat-chip-selected ng-star-inserted']");
        public By NOTIFICATION_MESSAGE = By.XPath("//div[@class='operation-status-wrapper custom-tooltip-parent']//small");
        public By NOTIFICATION_PROGRESS = By.XPath("//mat-progress-spinner[@class='mat-progress-spinner mat-primary mat-progress-spinner-indeterminate-animation']");
        public By NOTIFICATION_NAME = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/span");
        public By NOTIFICATION_STATUS = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/small[@class='bg_Success']");
        public By ENTER_SEARCH = By.XPath("//input[@type='Search']");
        public By TYPE_OF_CONTENT_DROPDOWN = By.XPath("//mat-select[@placeholder='Type of Content']");
        public By SOURCE_CONTROL_PROVIDER_DROPDOWN = By.XPath("//mat-select[@placeholder='Source Control Provider']");
        public By REPOSITORY_DROPDOWN = By.XPath("//mat-select[@placeholder='Repository']");
        public By REPOSITORY_VALUE = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Docworks')]");
        public By CONTENT_VALUE = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Manual')]");
        public By SOURCE_CONTROL_VALUE_GITLAB = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'GitLab')]");
        public By SOURCE_CONTROL_VALUE_GITHUB = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'GitHub')]");
        public By SOURCE_CONTROL_VALUE_ONO = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Ono')]");
        public By MERCURIAL_REPO_PATH = By.XPath("//input[@placeholder='Mercurial Repo Path']");
        public By SIZE_EXCEED_100 = By.XPath("(//mat-dialog-content//div/small)[1]");
        public By SIZE_EXCEED_1000 = By.XPath("(//mat-dialog-content//div/small)[4]");
        public By DESCRIPTION_FIELD = By.XPath("//textarea[@placeholder='Description']");
        public By PUBLISHED_PATH = By.XPath("//input[@placeholder='Published Path']");
        public By BACK_BUTTON = By.XPath("//button[@class='mat-raised-button']/span");
        public By CLEAR_BUTTON = By.XPath("//button[@class='mat-raised-button mat-warn']/span");
        public By CREATE_PROJECT_BUTTON = By.XPath("(//span[@class='mat-button-wrapper'])[4]");
        public By INVALID_TITLE_LENGTH = By.XPath("//mat-error[@class='mat-error ng-star-inserted']");
        public By FOOTER_TEXT = By.XPath("//*/snack-bar-container/app-custom-snack-bar-component");
        public By NOTIFICATION_BELL = By.XPath("//i[@class='mdi mdi-bell mdi-24px']");
        public By GET_CREATEDPROJECT = By.XPath("//div/mat-list-item/div/div[2]");
        public By BACKDROP = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By DESCRIPTION_MAT_CARD = By.XPath("//mat-card-content/p");
        public By FAVOURITE_ICON = By.XPath("(//i[@class='mdi-star-outline mdi mdi-24px'])[1]");
        public By AUTHORING_BUTTON = By.XPath("(//a[@class='mat-tab-link ng-star-inserted'])[contains(text(),'Authoring')]");
        public By ERROR = By.XPath("//mat-error");

        public object DriverWaitUtil { get; private set; }

        private ExtentTest test;


        public AddProjectPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }



        public Boolean IsProjectEnable()
        {
            Boolean Flag =
            this.IsEnabled(ADDPROJECT_BUTTON);
            Debug.WriteLine("Is Add Project Button Enabled " + Flag);

            return Flag;
        }

        public void SearchForProject(String projectName)
        {
            Clear(ENTER_SEARCH);
            System.Threading.Thread.Sleep(15000);
            EnterValue(ENTER_SEARCH, projectName);
            Info(test, "Entered the Project Name: " + projectName + " in search bar");

        }

        public void SuccessScreenshot(String path, String message)
        {

            test.Pass("SUCCESS : " + message, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
            // test.AddScreenCaptureFromPath(path, message);
            //            PassScreenshot(test, path, message);
            //Info(test, "<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }

        public void SuccessScreenshot(String message)
        {

            String path = TakeScreenshot();
            SuccessScreenshot(path, message);
        }


        public void SuccessScreenshot(By by, String message)
        {
            String path = TakeElementScreenshot(by);
            //String path = TakeScreenshot();
            SuccessScreenshot(path, message);
        }




        public String GetDescriptionSize()
        {
            Info(test, "Description Size is" + this.GetSize(DESCRIPTION_FIELD));
            return this.GetSize(DESCRIPTION_FIELD);
        }

        public String GetDescriptionLength()
        {
            String str = GetText(SIZE_EXCEED_1000).ToString();
            Info(test, "Description Exceeds 1000 characters*** " + str);
            return str;
        }

        public String GetDescriptionText()
        {
            String str = GetText(DESCRIPTION_MAT_CARD).ToString();
            Info(test, "The Description Text is " + str);
            return str;
        }
        public String GetTitleLength()
        {
            String str = GetText(SIZE_EXCEED_100).ToString();
            Info(test, "Title Exceeds 100 characters*** " + str);
            return str;
        }

        public void ClickDashboard()
        {
            String url = GetDriver().Url;
            url = url.Substring(0, url.LastIndexOf("/"));
            GetDriver().Navigate().GoToUrl(url + "/dashboard");
            //Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            //Info(test, "Clicked On DashBoard");
        }

        public String GetURl()
        {
            String url = GetDriver().Url;
            Info(test, "Current URL is " + url);
            return url;
        }

        public void NavigateDistributionUsingUrl(Dictionary<string, string> map)
        {
            String url = GetDriver().Url;
            url = url.Substring(0, url.LastIndexOf("/"));
            GetDriver().Navigate().GoToUrl(url + "/project/" + map["projectID"] + "/distribution/" + map["id"]);
            //Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            //Info(test, "Clicked On DashBoard");
        }

        public void ClickAddProject() {
            ClickDashboard();
            Click(ADDPROJECT_BUTTON);
            WaitForElement(CREATE_PROJECT_BUTTON);
            Info(test, "Clicked on AddProject Button.");
        }

        public String EnterProjectTitle() {
            String ProjectTitle = "SELENIUM" + "_" + GenerateRandomNumbers(15);
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info(test, "Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public void EnterProjectTitle(String name)
        {
            EnterValue(PROJECT_TITLE_FIELD, name);
            Info(test, "Entered Project Title : " + name);
        }

        public void NoProjectTitle()
        {
            Click(PROJECT_TITLE_FIELD);
            Info(test, "Did not enter the project title");
        }

        public String ProjectTitleInvalidLength()
        {
            String ProjectTitle = "QA";
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info(test, "Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String ProjectLengthMoreThan100()
        {
            String ProjectTitle = "SELENIUM" + RandomValueOfLengthMorethan100();
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info(test, "Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String ProjectNameAsSapce()
        {
            String ProjectTitle = "  QA   ";
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info(test, "Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String GetProjectTitle()
        {
            Info(test, "ProjectTitle is " + this.GetText(GET_TITLE));
            return this.GetText(GET_TITLE);
        }

        public String ProjectDescriptionMorethan1000()
        {
            // String Description = "<mat-menu>"+RandomValueOfLengthMorethan1000();
            try
            {
                String Description = "(WCM or WCMS)isa CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded";
                EnterDescription(Description);
                Info(test, "Entered Project Description : " + Description);
                return Description;
            } catch (Exception e)
            {
                throw e;
            }
        }
        public String GetFooterTitle()
        {
            IWebElement element = WaitForElement(FOOTER_TEXT);
            String FooterText = this.GetText(FOOTER_TEXT);
            Info(test, "Footer Title is************* " + FooterText);
            return FooterText;
        }

        public void EnterDescription(String description) {
            EnterValue(DESCRIPTION_FIELD, description);
            Info(test, "Entered Description : " + description);
        }

        public void EnterPublishedPath(String path)
        {
            EnterValue(PUBLISHED_PATH, path);
            Info(test, "Entered Published Path : " + path);
        }

        public void EscapePopUp()
        {
            // WaitForElement(CREATE_PROJECT_BUTTON).SendKeys(Keys.Escape);
        }

        public void ClickClose()
        {

            Click(By.XPath("//button//i[@class='mdi mdi-close mdi-24px']"));
            Info(test, "Clicked on Close Button");
        }

        public void ClickBack()
        {
            Click(BACK_BUTTON);
            Info(test, "Clicked on Back Button.");

        }
        public void ClickClear()
        {
            Click(CLEAR_BUTTON);
            Info(test, "Clicked on Clear Button.");

        }
        public void ClickCreateProject()
        {


            Click(CREATE_PROJECT_BUTTON);
            Info(test, "Clicked on Create project Button.");
            //WaitForElement(BELL_NOTIFICATION);

        }

        public void ClickNotifications()
        {
            System.Threading.Thread.Sleep(1000);
            Click(NOTIFICATION_BELL);
            Info(test, "Clicked on Notification Bell.");
        }

        public void WaitForProcessCompletion() {
            for (int i = 0; i < 1000; i++)
            {

                String tmp = GetText(NOTIFICATION_MESSAGE);

                if (tmp.Contains("successful") || tmp.Contains("failed"))
                {
                    Console.WriteLine(i + " : " + tmp);
                    Info(test, "Total time taken for completion : " + (3000 * 1000) + " ms");
                    break;
                }
                else
                {
                    Console.WriteLine(tmp);
                    System.Threading.Thread.Sleep(3000);
                }

            }
        }

        public String GetNotificationStatus()
        {

            WaitForProcessCompletion();
            return GetText(NOTIFICATION_MESSAGE);

        }

        public String GetNotificationName()
        {
            String text = GetText(NOTIFICATION_NAME);
            return text;
        }

        public String GetCreatedProject()
        {
            for (int i = 1; i <= 5; i++)
            {
                String text = GetText(NOTIFICATION_STATUS);
                if (text.ToString() == "Pending")
                {
                    System.Threading.Thread.Sleep(5000);
                }
                else
                {
                    break;
                }
            }

            String str = this.GetText(GET_CREATEDPROJECT);
            Info(test, "Status of the created Project is :   " + str);
            return str;
        }

        public void BackToProject()
        {
            System.Threading.Thread.Sleep(5000);
            WaitForElement(BACKDROP);
            MoveToelementAndClick(BACKDROP);
            Info(test, "Clicked On BackDrop");
        }

        public void SelectContentType(String value)
        {
            this.Click(TYPE_OF_CONTENT_DROPDOWN);
            By OPTION = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'" + value + "')]");
            this.Click(OPTION);
            Info(test, "Selected ContentType as " + value);
        }

        public void SelectSourceControlProviderType(String value)
        {
            if (!GetText(SOURCE_CONTROL_PROVIDER_DROPDOWN).Equals(value))
            {
                this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
                By OPTION = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'" + value + "')]");
                this.Click(OPTION);

                Info(test, "Selected Source Control Provider Type as " + value);
            }
            else
            {
                Info(test, value + " Source Control Provider Type already Selected.");
            }
        }

        public void SelectRepository(String value)
        {
            System.Threading.Thread.Sleep(50000);
            if (!GetText(REPOSITORY_DROPDOWN).Equals(value))
            {
                this.Click(REPOSITORY_DROPDOWN);
                By REPOPTION = By.XPath("(//mat-option/span[@class='mat-option-text'])[contains(text(),'unitydemo2/"+value+"')]");
                this.Click(REPOPTION);
               

            // ReadOnlyCollection<IWebElement> options = GetDriver().FindElements(By.XPath("(//div[@class='mat-select-arrow-wrapper'])[3]"));
            //foreach (IWebElement e in options)
           // {
                //  Console.WriteLine(e.Text);

                //  if (e.Text.Equals("unitydemo2/ + value"))
                //{
                //   Console.WriteLine(e.Text);
                //   e.Click();
                // System.Threading.Thread.Sleep(3000);
                // break;
           // }
        
                Info(test, "Selected Repository as " + value);
            }
            else
            {
                Info(test, value+" Repository already Selected.");
            }
        }

        public void ClickContentType()
        {

            this.Click(TYPE_OF_CONTENT_DROPDOWN);
            Info(test, "Clicked On the TypeOfContent DropDown.");
            this.Click(CONTENT_VALUE);
            Info(test, "Selected the content from drop down "+CONTENT_VALUE);
        }

        public void ClickSourceControlTypeGitLab()
        {
          
                this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info(test, "Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITLAB);
            Info(test, "selected the SOURCE_CONTROL_VALUE as GITLAB from drop down");

        }

        public void ClickSourceControlTypeGitHub()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info(test, "Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITHUB);
            Info(test, "selected the SOURCE_CONTROL_VALUE as GITHUB from drop down");

        }
        public void ClickSourceControlTypeOno()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info(test, "Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_ONO);
            Info(test, "selected the SOURCE_CONTROL_VALUE as Ono from drop down");

        }
        public void EnterMercurialRepoPath()
        {
            var path = ConfigurationHelper.Get<String>("MercurialRepo");
            EnterValue(MERCURIAL_REPO_PATH,path);
            Info(test, "Entered Mercurial repo Path as" + path);
        }




        public void ClickRepository()
        {
            this.Click(REPOSITORY_DROPDOWN);
            Info(test, "Clicked On the Repository DropDown");
            this.Click(REPOSITORY_VALUE);
            Info(test, "selected the Reppository_Value from drop down");


        }

        public void ClickFavouriteIcon()
        {
            System.Threading.Thread.Sleep(1000);
            Click(FAVOURITE_ICON);
            Info(test, "Clicked on Favourite icon");
        }

        public void ClickOnAuthoring()
        {
            System.Threading.Thread.Sleep(10000);
            Click(AUTHORING_BUTTON);
            Info(test, "Clicked on Authoring tab");
        }

        public Boolean CreateProjectButtonDisabled()
        {
            Boolean actual = IsEnabled(CREATE_PROJECT_BUTTON);
            //Assert.AreEqual(false, IsEnabled(CREATE_PROJECT_BUTTON));
            Info(test, "The create project button is Disabled");
            return actual;

        }

    }
}
