using System;
using OpenQA.Selenium;
using QA.Core.Contracts;

namespace QA.Core
{
    public abstract class BasePage : IPage
    {
        private const string ThePageUrlCannotBeEmpty = "The URL of the page cannot be empty.";
        private const string TheTitleCannotBeEmpty = "The title of the page cannot be empty.";
        private const string BaseUrl = "http://www.facebook.com";

        protected readonly IWebDriver driver;
        private string url;
        private string title;

        protected BasePage(IWebDriver driver, string url, string title)
        {
            this.driver = driver;
            this.Url = url;
            this.Title = title;
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException(ThePageUrlCannotBeEmpty);
                }

                this.url = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(TheTitleCannotBeEmpty);
                }

                this.title = value;
            }
        }

        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(this.Url);
        }
    }
}
