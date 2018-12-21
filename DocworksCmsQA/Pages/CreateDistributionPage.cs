using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
namespace DocWorksQA.Pages
{
    class CreateDistributionPage : SeleniumHelpers.PageControl
    {

        
        public By ENTER_SEARCH = By.XPath("//input[@type='Search']");
        public By GET_TITLE = By.XPath("//mat-card/mat-card-title/div");
        public By SETTINGS = By.XPath("//mat-card/mat-card-title/div//a");
        public By DISTRIBUTIONS = By.XPath("//button[contains(text(),'Distributions')]");
            //By.XPath("(//button[@class='mat-menu-item'])[2]");
        public By DISTRIBUTION_NAME = By.XPath("//input[@placeholder='Distribution Name']");
        public By DISTRIBUTION_NAME_STAR = By.XPath("//label[contains(@class,'mat-form-field-label mat-input-placeholder')][text()='Distribution Name']/span");
        public By SELECT_BRANCH_STAR = By.XPath("//label[contains(@class,'mat-form-field-label mat-input-placeholder')][text()='Select Branch']/span");
        public By DESCRIPTION = By.XPath("//input[@placeholder='Description']");
        public By SELECT_BRANCH = By.XPath("//mat-select[@placeholder='Select Branch']");
        public By BRANCH = By.XPath("//input[@placeholder='Branch']");
        public By BRANCH_OPTIONS_WITHTOC = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocworksManual3']");
        public By BRANCH_OPTIONS_WITHOUT_TOC = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocworksManual2']");
        public By BRANCH_OPTIONS_GITHUB = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocWorksManual3']");
        public By CLEAR_BUTTON = By.XPath("(//button[@class='mat-raised-button']/span)[1]");
        public By CLOSE_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']");
        //public By CREATE_DISTRIBUTION = By.XPath("//button//span[contains(text(),'Create Distribution')]");
        public By CREATE_DISTRIBUTION = By.XPath("//button[@class='mat-raised-button mat-primary ng-star-inserted']");
        public By AVAIL_DISTRIBUTION_NAME = By.XPath("(//mat-chip/div/strong)");
        public By AVAIL_DISTRIBUTION_EDIT = By.XPath("//mat-chip/div/mat-icon/i");
        //public By AVAIL_DISTRIBUTION_CREATED_DT = By.XPath("//mat-chip/small/strong");
        public By INVALID_TITLE_LENGTH = By.XPath("//mat-error[@class='mat-error ng-star-inserted']");
                                                   //mat-error[@class="mat-error ng-star-inserted"]
        public By TOC_PATH = By.XPath("//input[@placeholder='TOC Path']");
        public By ERROR = By.XPath("//mat-error[@role='alert']");


        private ExtentTest test;
        /**
        * Constructor: CreateDistributionPage()
        * Description: This constructor is used to initialize the webdriver
        */
        public CreateDistributionPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        /**
        * MethodName: SearchForProject()
        * Description: This method is used to search for the projectName
        */
        public void SearchForProject(String projectName)
        {
            Clear(ENTER_SEARCH);
            EnterValue(ENTER_SEARCH, projectName);
            Info(test, "ProjectName is" + projectName);
        }

        /**
       * MethodName: getProjectTitle()
       * Description: This method is used to get the project Title
       */
        public String GetProjectTitle()
        {
            Info(test, "ProjectTitle is" + this.GetText(GET_TITLE));
            return this.GetText(GET_TITLE);
        }

        /**
         * MethodName: ClickDistribution()
        * Description: This method is used to click the distribution
         */
        public void ClickDistribution()
        {
            Click(SETTINGS);
            Click(DISTRIBUTIONS);
            Info(test, "Clicked on Distributions");

        }

        /**
        * MethodName: SuccessScreenshot()
        * Description: This method is used to take the success screenshots
        */
        public void SuccessScreenshot(String path, String message)
        {
         Info(test, "<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        /**
        * MethodName: EnterDistirbutionName()
        * Description: This method is used to enter the distribution name
        */
        public String EnterDistirbutionName()
        {
            String DistName = "SELENIUMDIST";
            EnterValue(DISTRIBUTION_NAME, DistName);
            Info(test, "Distribution Name is" + DistName);
            return DistName;
        }

        /**
       * MethodName: EnterDuplicateDistirbutionName()
       * Description: This method is used to enter the duplicate distribution name
       */
        public String EnterDuplicateDistirbutionName(String distNameduplicate)
        {            
            EnterValue(DISTRIBUTION_NAME, distNameduplicate);
            Info(test, "Distribution Name is" + distNameduplicate);
            return distNameduplicate;
        }
        /**
       * MethodName: EnterInvalidnNameLength()
       * Description: This method is used to enter the invalid name length
       */
        public String EnterInvalidnNameLength()
        {
            String DistributionTitle = "QA";
            EnterValue(DISTRIBUTION_NAME, DistributionTitle);
            Info(test, "Entered Distribution Title : " + DistributionTitle);
            return DistributionTitle;

        }

        /**
       * MethodName: EnterEmptyDistributionName()
       * Description: This method is used to enter the Empty Distribution Name
       */
        public String EnterEmptyDistributionName()
        {
            String DistributionTitle = "";
            EnterValue(DISTRIBUTION_NAME, DistributionTitle);
            Info(test, "Entered Distribution Title : " + DistributionTitle);
            return DistributionTitle;

        }

        /**
      * MethodName: EnterLeadingTrailingSpaceDistName()
      * Description: This method is used to enter the Empty Distribution Name
      */
        public String EnterLeadingTrailingSpaceDistName()
        {
            String DistributionTitle = " QA TEST ";
            EnterValue(DISTRIBUTION_NAME, DistributionTitle);
            Info(test, "Entered Distribution Title : " + DistributionTitle);
            return DistributionTitle;

        }

        /**
      * MethodName: EnterDescription()
      * Description: This method is used to enter the Description
      */
        public void EnterDescription(String Description)
        {
            EnterValue(DESCRIPTION, Description);
            Info(test, "Distribution Description is" + Description);
        }

        public void EnterTocPath()
        {
            EnterValue(TOC_PATH, "Tocfolder");
            Info(test, "Entered TOC Path");
        }
        /**
             * MethodName: ClickBranch()
            * Description: This method is used to click the branch
        */
        public void ClickBranchWithTOC()
        {
            WaitForElement(SELECT_BRANCH);
                this.Click(SELECT_BRANCH);
            Info(test, "Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
                    this.Click(BRANCH_OPTIONS_WITHTOC);
            Info(test, "Selected the branch");
        }

        public void SelectBranch(String value)
        {
            System.Threading.Thread.Sleep(5000);

            if (!GetText(SELECT_BRANCH).Equals(value))
            {
                Click(By.XPath("//mat-select//div[@class='mat-select-arrow']"));
                By OPTION = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='" + value + "']");
                try
                {
                    this.Click(OPTION);
                }catch(Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    Console.WriteLine("Retrying Select Branch ");
                    Click(By.XPath("//mat-select//div[@class='mat-select-arrow']"));
                    this.Click(OPTION);

                }
                Info(test, "Selected Branch as " + value);
            }
            else
            {
                Info(test, value + " Branch is already Selected.");
            }
        }

        public void RetryBranchSelection(String value)
        {
            if (!GetText(SELECT_BRANCH).Equals(value))
            {
                Click(By.XPath("//mat-select//div[@class='mat-select-arrow']"));
                By OPTION = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='" + value + "']");
                this.Click(OPTION);
                Info(test, "Retry Branch Selection for Branch " + value);
            }
        }

        public void ClickBranchWithOutTOC()
        {
            
            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            Info(test, "Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_WITHOUT_TOC);
            Info(test, "Selected the branch");
        }

      
        public void ClickBranchForGitHub()
        {
            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            Info(test, "Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_GITHUB);
            Info(test, "Selected the branch");
        }

        public void EnterBranchForMercurial( String str)
        {
            EnterValue(BRANCH,str);
            Info(test, "Entered Branch value");
        }
        public void EnterBranchWithoutTOCForMercurial(String str)
        {
         
            EnterValue(BRANCH, str);
            Info(test, "Entered Branch value");
        }
        /**
            * MethodName: ClickCreateDistribution()
            * Description: This method is used to click the Create Distribution
       */
        public void ClickCreateDistribution()
        {
            Click(CREATE_DISTRIBUTION);
            Info(test, "Clicked on Create distribution");
        }

        public Boolean CreateDistributionButtonDisabled()
        {
            Boolean actual = IsEnabled(CREATE_DISTRIBUTION);
            if (actual == false)
            {
                Info(test, "Create Distribution button is disabled");
            }
            if (actual == true)
            {
                Info(test, "Create Distribution button is enabled");
            }
           
            return actual;
        }

        

        /**
           * MethodName: ClickClearButton()
           * Description: This method is used to click the Clear Button
        */
        public void ClickClearButton()
        {
            Click(CLEAR_BUTTON);
            Info(test, "Click Clear Button");

        }



        /**
           * MethodName: ClickCloseButton()
           * Description: This method is used to click the close Button
        */
        public void ClickCloseButton()
        {
            Click(CLOSE_BUTTON);
            Info(test, "Clicked Close Button");
            

        }

        /**
          * MethodName: getDistributionName()
          * Description: This method is used to get the distribution name
       */
        public String GetDistributionName()
        {
            Info(test, "Available Distribution Name is" + this.GetText(AVAIL_DISTRIBUTION_NAME));
            return this.GetText(AVAIL_DISTRIBUTION_NAME);
        }

        public String GetTextOfErrorMsg()
        {
            String str = this.GetText(ERROR).ToString();
            Info("Error message is" +str);
            return str;
        }

        
       
    }
}
