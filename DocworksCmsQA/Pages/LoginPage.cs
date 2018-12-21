using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Utilities;

namespace DocWorksQA.Pages
{
    public class LoginPage : PageControl
    {

        By USERNAME_FIELD = By.XPath("//input[@placeholder='User Name']");
        By PASSWORD_FIELD = By.XPath("//input[@placeholder='Password']");
        By LOGIN_BUTTON = By.XPath("//app-login//button");
        By USERNAME_ERROR = By.XPath("//input[@id='userName']/following-sibling::div//small");
        By PASSWORD_ERROR = By.XPath("//input[@id='passWord']/following-sibling::div//small");
        By CAPTCHA_CHECKBOX = By.XPath("//span[@role='checkbox']//div[@class='recaptcha-checkbox-checkmark']");

        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }
        

        public void EnterUserName(String username) {
            EnterValue(USERNAME_FIELD, username);
            //info("Entered Username : "+username);
        }

        public void EnterPassword(String password) {
            EnterValue(PASSWORD_FIELD, password);
           // info("Entered Password : " + password);
            
        }

        public void CheckCaptchaBox() {
            Click(CAPTCHA_CHECKBOX);
          //  info("Clicking on Captcha Checkbox.");
          }

        public void SuccessScreenshot(String path, String message)
        {
           // info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }

        public void ClickLogin() {
            Click(LOGIN_BUTTON);
          //  info("Clicked on Login Button.");
        }

        public String GetUserNameError() {
            String tmp = GetText(USERNAME_ERROR);
         //   info("Getting error message from username field. = "+tmp);
            return tmp;
        }

        public void Login(){
            EnterUserName(uid);
            EnterPassword(pwd);
            ClickLogin();
        }

    }
}
