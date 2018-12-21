using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocworksCmsQA.SeleniumHelpers
{
    public class DriverFactory
    {

        private DriverFactory()
        {
            //Do-nothing..Do not allow to initialize this class from outside
        }
        private static DriverFactory instance = new DriverFactory();

        public static DriverFactory getInstance()
        {
            return instance;
        }

        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>() // thread local driver object for IWebDriver
   {
      @Override
      protected IWebDriver initialValue()
        {
            return new FirefoxDriver(); // can be replaced with other browser drivers
        }
    };

    public IWebDriver getDriver() // call this method to get the driver object and launch the browser
    {
        return driver.get();
    }

    public void removeDriver() // Quits the driver and closes the browser
    {
        driver.get().quit();
        driver.remove();
    }
}

}

