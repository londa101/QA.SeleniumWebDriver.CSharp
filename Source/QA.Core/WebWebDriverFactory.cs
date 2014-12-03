using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using QA.Core.Contracts;

namespace QA.Core
{
    public class WebWebDriverFactory : IWebDriverFactory
    {
        private const string PathToDrivers = @"D:\PROJECTS\~MINE\WebDriverSeed\Source\QA.Core\";

        public IWebDriver GetFirefox()
        {
            return new FirefoxDriver();
        }

        public IWebDriver GetChrome()
        {
            return new ChromeDriver(PathToDrivers);
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
