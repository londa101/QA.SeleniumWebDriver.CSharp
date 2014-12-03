using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using QA.Core.Contracts;
using System;

namespace QA.Core
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private readonly string pathToDrivers = Environment.CurrentDirectory;

        public IWebDriver GetFirefox()
        {
            return new FirefoxDriver();
        }

        public IWebDriver GetChrome()
        {
            return new ChromeDriver(pathToDrivers);
        }

        public IWebDriver GetInternetExplorer()
        {
            return new InternetExplorerDriver();
        }

        public IWebDriver GetSafary()
        {
            return new SafariDriver();
        }
    }
}