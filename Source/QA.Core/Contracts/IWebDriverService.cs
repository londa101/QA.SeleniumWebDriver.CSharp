namespace QA.Core.Contracts
{
    using OpenQA.Selenium;

    /// <summary>
    /// The WebDriverService interface.
    /// </summary>
    public interface IWebDriverService
    {
        /// <summary>
        /// The get browser.
        /// </summary>
        /// <param name="browserType">
        /// The browser type.
        /// </param>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver GetBrowser(BrowserType browserType);
    }
}