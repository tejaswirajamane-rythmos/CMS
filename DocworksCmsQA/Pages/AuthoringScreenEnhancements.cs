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
    class AuthoringScreenEnhancements : SeleniumHelpers.PageControl
    {
        public By UNITYMANUAL_CLICK = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By DISTRIBUTION_DROPDOWN = By.XPath("//div[@class='mat-select-trigger']");
        //public By DISTRIBUTION_TEXT = By.XPath("//span[@class='ng-tns-c18-245 ng-star-inserted'][text()='" +distributionName+ "']");
        public By AVAILABLE_DISTRIBUTION = By.XPath("//mat-chip[@class='mat-chip mat-primary mat-standard-chip ng-star-inserted']/div/strong");
        public By AVAILABLE_DISTRIBUTION_1 = By.XPath("(//div[@class='mat-select-content ng-trigger ng-trigger-fadeInContent']/mat-option/span)[1]");
        public By AVAILABLE_DISTRIBUTION_2 = By.XPath("(//div[@class='mat-select-content ng-trigger ng-trigger-fadeInContent']/mat-option/span)[2]");
        public By OPENED_DISTRIBUTION = By.XPath("//div[@class='mat-select-value']");
        public By BACKDROP_CLICK = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By NEWDRAFT_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-plus mdi-18px']");
        public By CLOSEDRAFT_BUTTON = By.XPath("//button[@aria-label='Close dialog']");
        public By DRAFTNAME_EDT = By.XPath("//input[@ng-reflect-placeholder='Draft Name']");
        public By BLANKDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[2]");
        public By EXISTINGDRAFTDROPDOWN = By.XPath("//mat-select[@aria-label='Existing Drafts']");
        public By CODERDRAFT_CLICK = By.XPath("//mat-option/span[@class='mat-option-text'][text()=' Coder Draft ']");
        public By CREATEDRAFT_BUTTON = By.XPath("//button[@class='mat-raised-button mat-primary']");
        public By DRAFTNAMEERROR = By.XPath("//mat-error[text()='Please enter at least 5 characters.']");
        public By OPENPROJECT = By.XPath("//button[@class='mat-raised-button mat-primary']/span[text()='Open']");
        public By LEFT_DRAFTDROPDOWN = By.XPath("//div[@class='authoring-tabview left-window']//mat-select");
        public By RIGHT_DRAFTDROPDOWN = By.XPath("//div[@class='authoring-tabview right-window']//mat-select");
        public By LEFT_GDOC_TAB = By.XPath("//div[@class='authoring-tabview left-window']//div//div//div/div/div/i[@class='tab-title-icon mdi mdi-24px mdi-file-document']");
        public By LEFT_HTML_TAB = By.XPath("//div[@class='authoring-tabview left-window']//div/div/i[@class='tab-title-icon mdi mdi-24px mdi-code-not-equal-variant']");
        public By LEFT_MD_TAB = By.XPath("//div[@class='authoring-tabview left-window']//div/i[@class='tab-title-icon mdi mdi-24px mdi-markdown']");
        public By LEFT_PREVIEW_TAB = By.XPath("//div[@class='authoring-tabview left-window']//div/i[@class='tab-title-icon mdi mdi-24px mdi-eye']");
        public By LEFT_HISTORY_TAB = By.XPath("(//i[@class='tab-title-icon mdi mdi-24px mdi-history'])[1]");
        public By RIGHT_GDOC_TAB = By.XPath("//div[@class='authoring-tabview right-window']//div/i[@class='tab-title-icon mdi mdi-24px mdi-file-document']");
        public By RIGHT_HTML_TAB = By.XPath("(//div[@class='authoring-tabview right-window']//div[@class='mat-tab-label mat-ripple ng-star-inserted'])[1]");
        public By Right_HTML_EDT = By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='right']//div[@ng-reflect-ng-class='authoring-tabview-body']/div");
        public By RIGHT_MD_TAB = By.XPath("//div[@class='authoring-tabview right-window']//div/i[@class='tab-title-icon mdi mdi-24px mdi-markdown']");
        public By RIGHT_PREVIEW_TAB = By.XPath("(//div/i[@class='tab-title-icon mdi mdi-24px mdi-eye'])[2]");
        public By RIGHT_HISTORY_TAB = By.XPath("(//i[@class='tab-title-icon mdi mdi-24px mdi-history'])[2]");
        public By EDT_LEFT_TAB = By.XPath("//div[@class='authoring-tabview left-window']/div[2]/div");
        public By EDT_RIGHT_TAB = By.XPath("//div[@class='authoring-tabview right-window']/div[2]/div");
        public By EDT_GDOC = By.XPath("(//div[@class='kix-appview-editor']//span[@class='goog-inline-block kix-lineview-text-block']/span)[1]");
        public By EDT_GDOC_HDR = By.XPath("(//div[@class='kix-appview-editor']//div[@class='kix-print-block kix-page-header'])[1]");
        public By EDT_GDOC_HDR_RT = By.XPath("(//div[@class='kix-appview-editor']//div[@class='kix-print-block kix-page-header'])[2]");
        public By INSERT = By.XPath("//button/span/i[@class='mdi mdi-menu-down mdi-18px']");
        public By SELECT_INSERT_IMAGE = By.XPath("(//button[@class='mat-menu-item']//mat-icon)[1]");
        public By SELECT_INSERT_CODEBLOCK = By.XPath("(//button[@class='mat-menu-item']//mat-icon)[2]");
        public By CLICK_UPLOADED_BY_ME = By.XPath("//mat-dialog-container//div[text()='Uploaded by me']");
        public By SELECT_IMAGE_FROM_UPLOAD = By.XPath("(//div[@class='media-image'])[last()]");
        public By SELECT_CODEBLOCK_FROM_UPLOAD = By.XPath("(//div[@class='media-image']/mat-icon)[last()]");
        public By CLICK_CODEBLOCK_TAB = By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Code Blocks']");
        public By CLICK_ACCEPTDRAFTTOLIVE = By.XPath("//button/span/i[@class='mdi mdi-checkbox-marked-circle-outline mdi-18px']");
        public By SELECT_DRAFT_FROM_CLICK_ACCEPTDRAFTTOLIVE = By.XPath("(//button[@class='mat-menu-item ng-star-inserted'])[1]");
        public By UPLOAD_BUTTON = By.XPath("(//input[@type='file'])[1]");
        public By REPLACE_BUTTON = By.XPath("(//input[@type='file'])[2]");
        public By ACCEPTDRAFTTOLIVE_DROPDOWN = By.XPath("//div[@class='mat-menu-content ng-trigger ng-trigger-fadeInItems']");
        public By SEARCH_ASSETTEXT = By.XPath("//input[@type='Search']");
        public By SEARCH_ASSET_BAR = By.XPath("//button//span/i[@class='mdi mdi-magnify mdi-24px']");
        public By HISTORY_VALID_DRAFT1 = By.XPath("(//mat-list[@class='mat-list valid-draft ng-star-inserted']//div[@class='mat-list-item-content'])[last()]");
        public By HISTORT_VALID_DRAFT2 = By.XPath("(//mat-list-item[@class='draft-history-content mat-list-item']//div[@class='mat-list-item-content'])[1]");
        public By ViewDraft_DraftName = By.XPath("//input[@placeholder='Draft Name']");

        private ExtentTest test;

        public AuthoringScreenEnhancements(ExtentTest test,IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        public void OpenProject()
        {
            Click(OPENPROJECT);
            Info(test,"Clicked on open Project");
        }

        public void ClickOnDistributionDropdown()
        {
            Click(DISTRIBUTION_DROPDOWN);
            Info(test,"Clicked on distribution dropdown");
        }

        public String GetTestofDistributions()
        {
            //String str = GetText(By.XPath("//span[@class='ng-tns-c18-245 ng-star-inserted'][text()='" + distributionName + "']"));
            String str = GetText(By.XPath("//span[@class='mat-option-text']")).ToString();
            return str;
        }
        public void ClickOnAvailableDistribution2()
        {
            Click(AVAILABLE_DISTRIBUTION_2);
        }

        public String GetTextOfAvailableDistribution2()
        {

            String str = GetText(AVAILABLE_DISTRIBUTION_2).ToString();
            return str;
        }

        public String GetTextOfOpenedDistribution()

        {
            String str = GetText(OPENED_DISTRIBUTION).ToString();
            Info(test, str);
            return str;
        }

        public string GetTextOfAvailableDistribution()
        {
            WaitForElement(AVAILABLE_DISTRIBUTION);
            String str = GetText(AVAILABLE_DISTRIBUTION);
            return str;
        }

        public void ClickNode()
        {
            Click(UNITYMANUAL_CLICK);
            Info(test,"Clicked on Unity Manual Node");
        }

        //public void ClickBackDrop()
        //{
        //    Click(BACKDROP_CLICK);
        //     Info(test,"Clicked Backdrop");
        //}

        public void LeftDraftDropDown(String str)
        {
            System.Threading.Thread.Sleep(7000);
             Click(LEFT_DRAFTDROPDOWN);
            String s = "//div[@class='mat-list-item-content']//div[@fxlayout='row']//span[text()='" + str + "']";
            ClickByJavaScriptExecutor(By.XPath(s));
            System.Threading.Thread.Sleep(5000);
            Info(test,"selected Draft:  "+str+"  in left Drop Down");
        }

        public void RightDraftDropDown(String str)
        {
            System.Threading.Thread.Sleep(7000);
            Click(RIGHT_DRAFTDROPDOWN);
            String s = "//div[@class='mat-list-item-content']//div[@fxlayout='row']//span[text()='" + str + "']";
            ClickByJavaScriptExecutor(By.XPath(s));
            System.Threading.Thread.Sleep(5000);
            Info(test, "selected Draft:  " + str + "  in Right Drop Down");
        }


        public void LeftLiveDraft()
        {
            System.Threading.Thread.Sleep(7000);
            Click(LEFT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option//mat-list-item//div/span)[text()='Live Draft']"));
            Info(test,"selected a Live draft in Left Drop Down");

        }


        public void LeftCoderDraft()
        {
            Click(LEFT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option//mat-list-item//div/span)[text()='Coder Draft']"));
            Info(test,"selected a Coder draft in Left Drop Down");
        }
        public IWebElement EnterIntoLeftFrame()
        {
            //IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='left']//div//iframe"));
            IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view//div[@class='ng-star-inserted']/iframe"));
            return framel;
        }

        public void ClickGdocLeft( )
        {
            WaitForElement(EDT_GDOC_HDR);
            MoveToelementAndClick(EDT_GDOC_HDR);
            //Click(EDT_GDOC_HDR);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Click on left Gdoc");
            

        }

        public void RightLiveDraft()
        {
            Click(RIGHT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option//mat-list-item//div/span)[text()='Live Draft']"));
            Info(test,"selected a Live draft in Right Drop Down");

        }
        public Boolean IsAcceptDraftToLiveButtonEnabled()
        {
            Boolean Flag = this.IsEnabled(By.XPath("//button[@ng-reflect-disabled='true'] /span/i[@class='mdi mdi-checkbox-marked-circle-outline mdi-18px']"));

           Info(test,"AddProject Button id Enabled");


            return Flag;
        }
        public void RightCoderDraft()
        {
            Click(RIGHT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option//mat-list-item//div/span)[text()='Coder Draft']"));
            Info(test,"selected a Coder draft in Right Drop Down");

        }
        public String GetTextInRightDropDown()
        {
           String str= GetText(RIGHT_DRAFTDROPDOWN);
           Info(test,"Right Drop Down Value is " + str);
            return str;
        }
        public IWebElement EnterIntoRightFrame()
        {
            //IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='right']//div//iframe"));
            IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view//div[@class='authoring-tabview right-window']//div[@class='ng-star-inserted']/iframe"));

            return framel;
        }
        public void SuccessScreenshot(String path, String message)
        {
           Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        public void HtmlRightTab()
        {
            Click(RIGHT_HTML_TAB);
            System.Threading.Thread.Sleep(20000);
            Info(test,"Clicked On Right HTML Tab");

        }
        public void GdocLeftTab()
        {
            WaitForElement(LEFT_GDOC_TAB);
            MoveToelementAndClick(LEFT_GDOC_TAB);
            //Click(LEFT_GDOC_TAB);
            Info(test,"Clicked On Left GDOC Tab");
        }

        public void HtmlLeftTab()
        {
            Click(LEFT_HTML_TAB);
            System.Threading.Thread.Sleep(80000);
            Info(test,"Clicked On Left HTML Tab");

        }

        public void HistoryLeftTab()
        {
            Click(LEFT_HISTORY_TAB);
            System.Threading.Thread.Sleep(20000);
            Info(test,"Clicked On Left History Tab");

        }
        public void HistoryRightTab()
        {
            WaitForElement(RIGHT_HISTORY_TAB);
            MoveToelementAndClick(RIGHT_HISTORY_TAB);
            System.Threading.Thread.Sleep(50000);
            Info(test,"Clicked On Right History Tab");
        }
        public void GdocRightTab()
        {
            Click(RIGHT_GDOC_TAB);
            System.Threading.Thread.Sleep(20000);
            Info(test,"Clicked on Right GDOC Tab");
            System.Threading.Thread.Sleep(5000);
        }
        public void MDRightTab()
        {
            Click(RIGHT_MD_TAB);
            System.Threading.Thread.Sleep(20000);
            Info(test,"Clicked on Right MD Tab");
        }
        public void MDLeftTab()
        {
            Click(LEFT_MD_TAB);
            System.Threading.Thread.Sleep(50000);
            Info(test,"Clicked On Left MD Tab");
        }
        public void PreviewRightTab()
        {
            Click(RIGHT_PREVIEW_TAB);
           
            System.Threading.Thread.Sleep(20000);
            Info(test,"Clicked On Right Preview Tab");
        }
        public void PreviewLeftTab()
        {
            System.Threading.Thread.Sleep(40000);
            Click(LEFT_PREVIEW_TAB);
            System.Threading.Thread.Sleep(40000);
            Info(test,"Clicked on Left Preview Tab");
        }

        public void  ClickGdocRight()
        {
            Click(EDT_GDOC_HDR);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked On GDOC Right");
            
        }

        public void ClickInsertImage()
        {
            Click(INSERT);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked On Insert Menu");
            Click(SELECT_INSERT_IMAGE);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Selected Insert Image");
            Click(CLICK_UPLOADED_BY_ME);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on Uploaded By Me Tab");
        }
        public void ClickInsertCodeBlock()
        {
            Click(INSERT);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on Insert Menu");
            Click(SELECT_INSERT_CODEBLOCK);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Selected Insert CodeBlock");
            Click(CLICK_UPLOADED_BY_ME);
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on Uploaded By Me Tab");
        }

        public void SearchAssetName()
        {
            System.Threading.Thread.Sleep(7000);
            EnterValue(SEARCH_ASSETTEXT, Keys.Control + "v");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-magnify mdi-24px']"));
           Info(test,"Clicked the search button");
        }

        public void ReplaceTheImage()
        {

            
            String Image_Path = GetImagePath();
            Console.WriteLine("********" + Image_Path);
            System.Threading.Thread.Sleep(7000);

            EnterValue(REPLACE_BUTTON, Image_Path);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//mat-dialog-actions/div/button/span[text()='REPLACE']"));
            System.Threading.Thread.Sleep(27000);
            Info(test,"Replaced the Image");
        }

        public void ReplaceCodeBlocks()
        {
           
            String Image_Path = GetCodeBlockPath();
            Console.WriteLine("********" + Image_Path);
            System.Threading.Thread.Sleep(7000);
            EnterValue(REPLACE_BUTTON, Image_Path);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//mat-dialog-actions/div/button/span[text()='REPLACE']"));
            System.Threading.Thread.Sleep(27000);
            Info(test,"Replaced the codeBlocks");

        }
        public void SelectImageFromUpload(String Name)
        {
            Info(test,"Selecting image: "+Name+" from the Upload");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-content-copy']"));
            Info(test,"copying the clipboard content of Image");
            System.Threading.Thread.Sleep(8000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"copied the Asset Id and Closed the dialog box");
        }

        public void SelectCodeBlockFromUpload(String Name)
        {
          
           Info(test,"Selecting CodeBlock: "+Name+" from Upload");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-content-copy']"));
            Info(test,"copying the clipboard content");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"copied the Asset Id and Closed the dialog box");
        }
        public void CloseUploadPage()
        {
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"Closed the Uppload Image Dialog box");
        }

        public void EnterAssetID()
        {
            EnterValue(SEARCH_ASSETTEXT, Keys.Control + "V");
            Info(test,"ENtered the Asset ID in Search Bar");
        }
        public void EnterAssetName(String Name)
        {
            EnterValue(SEARCH_ASSETTEXT, Name);
            Info(test,"ENtered Asset Name: " + Name);
            Click(SEARCH_ASSET_BAR);
            Info(test,"Clicked On Search Bar");
            System.Threading.Thread.Sleep(5000);
        }
        public void ClickMedia()
        {
            Click(By.XPath("//a[@href='/media']"));
            System.Threading.Thread.Sleep(17000);
            Info(test, "Clicked on Media");
        }
        public void ClickCodeBlocksTab()
        {
            Click(CLICK_CODEBLOCK_TAB);
            System.Threading.Thread.Sleep(5000);
            Info(test,"Clicked on CodeBlock Tab");
        }

        public String UploadCodeBlock()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
              String CodeBlock_Path = GetCodeBlockPath();
                Console.WriteLine("********" + CodeBlock_Path);
                EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                String result = CodeBlock_Path.Split(new[] { '\\' }).Skip(6).FirstOrDefault();
                String res = result.Split(new[] { '.' }).First();
                Console.WriteLine("&&&&&****%%%%" + res);
                Info(test, "Uploaded CodeBlock: " + res + "");
                return res;
           
        }
        public void UploadInvalidCodeBlock()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String CodeBlock_Path = GetInvalidCodeBlockPath();
                var fileLength = new FileInfo(CodeBlock_Path).Length;
                fileLength = fileLength / 1000;
                Console.WriteLine("The random CodeBlock size" + fileLength);
                Console.WriteLine("********" + CodeBlock_Path);
                if (fileLength < 100)
                {
                    EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                    System.Threading.Thread.Sleep(7000);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));

                    VerifyText(test,"Only .txt/.cs format allowed.", str, "Validating error message for Invalid Type codeblocks is successful", "Validating error message for Invalid Type codeblocks is Not successful");

                }
                else
                {
                    EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));

                    VerifyText(test,"Max 100KB size allowed", str, "Validating error message for CodeBlocks size greater than 100KB is successful", "Validating error message for CodeBlocks size greater than 100KB is not successful");

                }
                System.Threading.Thread.Sleep(17000);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public String UploadImage()
        {
            Click(By.XPath("//div[@class='mat-tab-label-content'][text()='Uploaded By Me']"));
                String Image_Path = GetImagePath();
                Console.WriteLine("********" + Image_Path);
                EnterValue(UPLOAD_BUTTON, Image_Path);
                System.Threading.Thread.Sleep(7000);
               String result = Image_Path.Split(new[] { '\\' }).Skip(6).FirstOrDefault();
                String res = result.Split(new[] { '.' }).First();
                Console.WriteLine("&&&&&****%%%%" + res);
                Info(test,"Uploaded Image: "+ res + "");
                return res;
        }

        public void ViewDraft()
        {
            MoveToElement(HISTORY_VALID_DRAFT1);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath(""));
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on View Draft");
        }

        public void ViewDraft1()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToElement(HISTORT_VALID_DRAFT2);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath("(//i[@mattooltip='Create Draft'])[1]"));
            System.Threading.Thread.Sleep(30000);
            Info(test,"Clicked on Updated View Draft");
        }

        public String CreateDraftFromSnapshot()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToElement(HISTORT_VALID_DRAFT2);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath("//i[@class='mdi mdi-file mdi-18px']"));
            System.Threading.Thread.Sleep(7000);
            String str = "DraftSnapshot " + GenerateRandomNumbers(2);
            EnterValue(ViewDraft_DraftName, str);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("(//button[@class='mat-raised-button mat-primary ng-star-inserted']/span)[contains(text(),'Create Draft')]"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"Created Draft from DraftSnapShot");
            return str;
        }
        public String GetViewDraft()
        {
        String str =  GetText(By.XPath("//mat-dialog-content//div[@class='view-draft-wrapper']/div"));
            Info(test,"Getting Text From View Draft");
            return str;
        }
        public void CloseViewDraft()
        {
            Click(By.XPath("//button//i[@class='mdi mdi-close mdi-24px']"));
            Info(test,"Closing View Draft");
        }
        public void UploadInvalidImages()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String Image_Path = GetInvalidImagePath();
                var fileLength = new FileInfo(Image_Path).Length;
                fileLength = fileLength / 1000;
                Console.WriteLine("The random image" + fileLength);
                Console.WriteLine("********" + Image_Path);
                if (fileLength < 100)
                {
                    EnterValue(UPLOAD_BUTTON, Image_Path);
                    System.Threading.Thread.Sleep(7000);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));
                    VerifyText(test,"Only .jpeg/.jpg/.png/.gif format allowed.", str, "Validating error message for type of image is successful", "Validating error message for type of image is Unsuccessful");
                   
                }
                else
                {
                    EnterValue(UPLOAD_BUTTON, Image_Path);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));
                    VerifyText(test, "Max 100KB size allowed", str, "Validating error message image size greater than 100KB is successful", "Validating error message image size greater than 100KB is Unsuccessful");

                }
                System.Threading.Thread.Sleep(17000);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

       
        public void ClickDashboard()
        {
            Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            Info(test,"Clicked on Dashboard");
        }
        public void ClickAcceptDraftToLive()
        {
            Click(CLICK_ACCEPTDRAFTTOLIVE);
            Info(test,"Clicked on Accept Draft to Live button");
        }

        public void SelectDraftFromAcceptDraftToLiveDropDown()
        {
            Click(SELECT_DRAFT_FROM_CLICK_ACCEPTDRAFTTOLIVE);
            Info(test,"Clicked on First Option in DropDown");
        }
        public String GetDropDownValues()
        {
            String str = GetText(ACCEPTDRAFTTOLIVE_DROPDOWN);
            Info(test,"When Clicked on Accept Draft to Live button the drop down consists of  "+ str);
            Click(By.XPath("//div[@class='cdk-overlay-backdrop cdk-overlay-transparent-backdrop cdk-overlay-backdrop-showing']"));
            return str;
        }
    }
}
