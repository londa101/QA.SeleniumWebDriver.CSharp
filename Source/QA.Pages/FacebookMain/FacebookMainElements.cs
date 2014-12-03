namespace QA.Pages.FacebookMain
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// The facebook main elements.
    /// </summary>
    public class FacebookMainElements
    {
        /// <summary>
        /// Gets or sets the field for login email.
        /// </summary>
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement InputTextLoginEmail { get; set; }

        /// <summary>
        /// Gets or sets the input passport field for the password.
        /// </summary>
        [FindsBy(How = How.Id, Using = "pass")]
        public IWebElement InputPasswordLoginPassword { get; set; }

        /// <summary>
        /// Gets or sets the input type submit for the login button.
        /// </summary>
        [FindsBy(How = How.Id, Using = "u_0_n")]
        public IWebElement InputSubmitLoginPassword { get; set; }
    }
}