namespace QA.Pages.FacebookMain
{
    using Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class FacebookMainPage : BasePage
    {
        private const string PageUrl = @"https://www.facebook.com/";
        private const string PageTitle = @"Welcome to Facebook - Log In, Sign Up or Learn More";

        public FacebookMainPage(IWebDriver driver)
            : base(driver, PageUrl, PageTitle)
        {
            this.Elements = new FacebookMainElements();
            PageFactory.InitElements(this.Driver, this.Elements);
        }

        public FacebookMainElements Elements { get; set; }

        public void LoginUser()
        {
            this.Elements.InputTextLoginEmail.SendKeys("Jane");
            this.Elements.InputPasswordLoginPassword.SendKeys("Doe");

            this.Elements.InputSubmitLoginPassword.Click();
        }
    }
}
