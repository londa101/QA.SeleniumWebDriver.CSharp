using OpenQA.Selenium;
using QA.Core.Contracts;

namespace QA.Core
{
    public class WebDriverService : IWebDriverService
    {
        private readonly IWebDriverFactory _webDriverFactory;

        public WebDriverService(IWebDriverFactory webDriverFactory)
        {
            this._webDriverFactory = webDriverFactory;
        }

        public IWebDriver GetBrowser(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = this._webDriverFactory.GetChrome();
                    break;

                case BrowserType.Firefox:
                    driver = this._webDriverFactory.GetFirefox();
                    break;

                case BrowserType.InternetExporer:
                    driver = this._webDriverFactory.GetInternetExplorer();
                    break;
            }

            return driver;
        }
    }
}
