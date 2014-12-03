using OpenQA.Selenium;

namespace QA.Core
{
    public interface IWebDriverService
    {
        IWebDriver GetBrowser(BrowserType browserType);
    }
}