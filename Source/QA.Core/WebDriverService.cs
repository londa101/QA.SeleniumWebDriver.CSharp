namespace QA.Core
{
    using Contracts;
    using OpenQA.Selenium;

    public class WebDriverService : IWebDriverService
    {
        private readonly IWebDriverFactory webDriverFactory;

        public WebDriverService(IWebDriverFactory webDriverFactory)
        {
            this.webDriverFactory = webDriverFactory;
        }

        public IWebDriver GetBrowser(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = this.webDriverFactory.GetChrome();
                    break;

                case BrowserType.Firefox:
                    driver = this.webDriverFactory.GetFirefox();
                    break;

                case BrowserType.InternetExporer:
                    driver = this.webDriverFactory.GetInternetExplorer();
                    break;
            }

            return driver;
        }
    }
}
