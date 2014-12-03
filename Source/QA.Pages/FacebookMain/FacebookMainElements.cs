using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace QA.Pages.FacebookMain
{
    public class FacebookMainElements
    {

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement InputTextLoginEmail { get; set; }

        [FindsBy(How = How.Id, Using = "pass")]
        public IWebElement InputPasswordLoginPasword { get; set; }

        [FindsBy(How = How.Id, Using = "u_0_n")]
        public IWebElement InputSubmitLoginPasword { get; set; }
    }
}