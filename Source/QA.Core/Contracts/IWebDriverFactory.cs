using OpenQA.Selenium;

namespace QA.Core.Contracts
{
    public interface IWebDriverFactory
    {
        IWebDriver GetFirefox();

        IWebDriver GetChrome();

        IWebDriver GetInternetExplorer();

        IWebDriver GetSafary();
    }
}