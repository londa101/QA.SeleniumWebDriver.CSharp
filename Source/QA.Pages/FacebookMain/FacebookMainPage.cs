using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QA.Core;

namespace QA.Pages.FacebookMain
{
    public class FacebookMainPage : BasePage
    {
        private const string url = @"https://www.facebook.com/";
        private const string title = @"Welcome to Facebook - Log In, Sign Up or Learn More";

        public FacebookMainPage(IWebDriver driver)
            : base(driver, url, title)
        {
            this.Elements = new FacebookMainElements();
            PageFactory.InitElements(this.driver, this.Elements);
        }

        public FacebookMainElements Elements { get; set; }

        public void LoginUser()
        {
           
            this.Elements.InputTextLoginEmail.SendKeys("Jane");
            this.Elements.InputPasswordLoginPasword.SendKeys("Doe");

            this.Elements.InputSubmitLoginPasword.Click();
          
        }
    }
}
