using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DocWorksQA.SeleniumHelpers
{
    public class PageControl : Utilities.CommonMethods
    {
       IWebDriver driver;

        public IWebElement R1 { get; private set; }

        public PageControl(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void Click(By by)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Clicking on " + by.ToString());
            try
            {
                WaitForElement(by).Click();
                /*
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", WaitForElement(by));
                */

                System.Threading.Thread.Sleep(5000);
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Click Operation");
                WaitForElement(by).Click();

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Click Operation");
                WaitForElement(by).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        

        public void EnterValue(By by, string value)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Entering value into " + by.ToString());
            try
            {

                Type(by, value);

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void Clear(By by)
        {
            try
            {
                WaitForElement(by).Clear();
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Clear Operation");
                WaitForElement(by).Clear();

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Clear Operation");
                WaitForElement(by).Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetText(By by)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Getting text for " + by.ToString());

            try
            {
                String text = WaitForElement(by).Text;
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Returned text is " + text);
                return text;
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Get Text Operation");
                String text = WaitForElement(by).Text;
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Returned text is " + text);
                return text;

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Get Text Operation");
                String text = WaitForElement(by).Text;
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Returned text is " + text);
                return text;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String GetAttribute(By by)
        {
            try
            {
                return WaitForElement(by).GetAttribute("text");
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Get Attribute Operation");
                return WaitForElement(by).GetAttribute("text");

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Get Attribute Operation");
                return WaitForElement(by).GetAttribute("text");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetSize(By by)
        {
            IWebElement element = WaitForElement(by);

            ElementHighlight(element);
            return element.Size.ToString();
        }

        public String GetSizeOfElements(By by)
        {
            String str = GetElementList(by).Count.ToString();
            return str;
        }

        public IList<IWebElement> GetElementList(By by)
        {
            return driver.FindElements(by);
        }

        public Boolean IsEnabled(By by)
        {
            try
            {
                return WaitForElement(by).Enabled;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Boolean IsDisplayed(By by)
        {
            try
            {
                return WaitForElement(by).Displayed;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetTitle()
        {
            System.Threading.Thread.Sleep(4000);
            string tmp = driver.Title;
            Console.WriteLine("The page title is " + tmp);
            return tmp;
        }

        public string GetCurrentUrl()
        {
            System.Threading.Thread.Sleep(4000);
            String tmp1 = driver.Url;
            Console.WriteLine("The current url is " + tmp1);
            return tmp1;

        }


        public void Type(By by, String Value)
        {
            try
            {
                WaitForElement(by).SendKeys(Value);
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Type Operation");
                WaitForElement(by).SendKeys(Value);

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Type Operation");
                WaitForElement(by).SendKeys(Value);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string GetTextOfHiddenElement(By by)
        {
            IWebElement element = WaitForElement(by);
            String script = "return arguments[0].innerHTML";
            String n = (String)((IJavaScriptExecutor)driver).ExecuteScript(script, element);

            return n;
        }

        public void ClickByJavaScriptExecutor(By by)
        {
            IWebElement ele = WaitForElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
             executor.ExecuteScript("arguments[0].click();", ele);
           
        }
        

        public void ClearByJavaScriptExecutor(By by)
        {
            IWebElement ele = WaitForElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].clear();", ele);
        }

        public void SendKeysByJavaScriptExecutor(By by,String name)
        {
            IWebElement ele = WaitForElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].value = '"+name+"';", ele);
        }

        public void MoveToElement(By by)
        {


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            const string script =
               "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            js.ExecuteScript(script);

            IWebElement ele = WaitForElement(by);
            Actions act = new Actions(driver);
            act.MoveToElement(ele);
            act.Perform();
        }



        public void MoveToElement(IWebElement element)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            const string script =
               "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            js.ExecuteScript(script);

            Actions act = new Actions(driver);
            act.MoveToElement(element);
            act.Perform();
        }
        public void ContextClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
            builder.ContextClick(ele).Build().Perform();
        }

        public void MoveToelementAndClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
            builder.MoveToElement(ele).Click().Build().Perform();
        }

        public void RightClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
            builder.MoveToElement(ele).ContextClick(ele).Build().Perform();
        }
        public void ScrollToElementAndClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(ele).Click().Build().Perform();
        }



        public void MoveToelementAndType(By by, String Name)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
            builder.MoveToElement(ele).SendKeys(Name).Build().Perform();
        }
        public void MoveToelementAndRightClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
            builder.MoveToElement(ele).ContextClick(ele).Build().Perform();


        }


        public void SelectDropdown(By by, String value)
        {
            SelectElement select = null;

            try
            {
                select = new SelectElement(WaitForElement(by));

                Console.WriteLine("Selecting by Text " + value);
                select.SelectByText(value);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine("Selecting by value " + value);

                select.SelectByText(value);
            }
        }

      

        public IWebElement WaitForElement(By by)
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                element = wait.Until<IWebElement>((d) =>
                {
                    Highlight(d.FindElement(by));
                    return d.FindElement(by);
                });
            }
            catch (Exception e) {
                throw e;
            }

            RemoveHighlight(element);
            return element;
        }
         public void ElementHighlight(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                    element, "color: red; border: 5px solid red;");


        }

        public String TakeScreenshot()
        {

            String path = GetCurrentProjectPath() + "/bin/Release/Reports/Screenshot";

            CreateDirectory(path);

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            TimeAndDate.Replace(" ", "_");
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(path + "/screenshot-" + TimeAndDate + ".jpg", ScreenshotImageFormat.Jpeg);
            return "./Screenshot/screenshot-" + TimeAndDate + ".jpg";

        }

        public String TakeElementScreenshot(By by)
        {
            IWebElement element = WaitForElement(by);
            Highlight( element);
            String path = GetCurrentProjectPath() + "/bin/Release/Reports/Screenshot";

            CreateDirectory(path);

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            TimeAndDate.Replace(" ", "_");

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(path + "/screenshot-" + TimeAndDate + ".jpg", ScreenshotImageFormat.Jpeg);
            RemoveHighlight(element);
            return "./Screenshot/screenshot-" + TimeAndDate + ".jpg";

        }

        public void Highlight(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, " border: 3px solid red;");
        }


        public void RemoveHighlight(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");

        }

    }
}
