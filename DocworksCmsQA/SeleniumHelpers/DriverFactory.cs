using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using DocWorksQA.Utilities;
using OpenQA.Selenium.Safari;

namespace DocWorksQA.SeleniumHelpers
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Safari,
        Firefox,
        Phantomjs
    }

    public class DriverFactory
    {



        public IWebDriver Create()
        {
            IWebDriver driver;
            var driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");
            var browserStackIndicator = ConfigurationHelper.Get<bool>("UseBrowserStack");
            var url = ConfigurationHelper.Get<String>("TargetUrl");
            int timeout = ConfigurationHelper.Get<int>("ImplicitlyWait");


            switch (driverToUse)
                {
                    case DriverToUse.InternetExplorer:
                    Console.WriteLine("Starting Internet Explorer Driver.");
                        driver = new InternetExplorerDriver();
                        break;
                    case DriverToUse.Firefox:
                    Console.WriteLine("Starting Firefox Driver.");
                    FirefoxOptions options = new FirefoxOptions();
                    options.SetPreference("browser.tabs.remote.autostart", false);
                    options.SetPreference("browser.tabs.remote.autostart.1", false);
                    options.SetPreference("browser.tabs.remote.autostart.2", false);
                    options.SetPreference("browser.tabs.remote.force-enable", false);
                   // options.AddArguments("--headless");
                    options.AddAdditionalCapability("moz:webdriverClick", true, true);
                    options.AddArgument("--no-sandbox");
                  //  driver = new FirefoxDriver(options);
                        
                        var driverService = FirefoxDriverService.CreateDefaultService();
                    driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    driverService.HideCommandPromptWindow = true;
                    driverService.SuppressInitialDiagnosticInformation = true;
                    driver = new FirefoxDriver(driverService, options, TimeSpan.FromSeconds(timeout));
                        break;
                    case DriverToUse.Chrome:
                    Console.WriteLine("Starting Chrome Driver.");
                        ChromeOptions option = new ChromeOptions();
                    //option.AddArgument("--headless");
                    option.AddArguments("window-size=1200,1100");
                    option.Proxy = null;
                    option.AddArguments("disable-infobars");
                    option.AddArgument("--no-sandbox");
                    option.AddArguments("--incognito");
                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), option, TimeSpan.FromSeconds(timeout));
                        break;
                    case DriverToUse.Safari:
                    Console.WriteLine("Starting Safari Driver.");
                        driver = new SafariDriver();
                        break;
                    //case DriverToUse.Phantomjs:
                    //    driver = new PhantomJSDriver();
                    //    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

            driver.Manage().Window.Maximize();
            Console.WriteLine("Navigating to URL : "+url);
            driver.Navigate().GoToUrl(url);

            return driver;
        }

      
        
    }
}
