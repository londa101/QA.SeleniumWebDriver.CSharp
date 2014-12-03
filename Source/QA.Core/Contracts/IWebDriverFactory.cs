namespace QA.Core.Contracts
{
    using OpenQA.Selenium;

    /// <summary>
    /// The WebDriverFactory interface.
    /// </summary>
    public interface IWebDriverFactory
    {
        /// <summary>
        /// The get firefox.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver GetFirefox();

        /// <summary>
        /// The get chrome.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver GetChrome();

        /// <summary>
        /// The get internet explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver GetInternetExplorer();

        /// <summary>
        /// Gets Safari Browser.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        IWebDriver GetSafari();
    }
}