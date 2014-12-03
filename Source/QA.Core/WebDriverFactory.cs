namespace QA.Core
{
    using System;

    using Contracts;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Safari;

    public class WebDriverFactory : IWebDriverFactory
    {
        private readonly string pathToDrivers = Environment.CurrentDirectory;

        public IWebDriver GetFirefox()
        {
            return new FirefoxDriver();
        }

        public IWebDriver GetChrome()
        {
            return new ChromeDriver(this.pathToDrivers);
        }

        public IWebDriver GetInternetExplorer()
        {
            return new InternetExplorerDriver();
        }

        public IWebDriver GetSafari()
        {
            return new SafariDriver();
        }
    }
}