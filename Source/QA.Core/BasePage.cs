using OpenQA.Selenium;
using QA.Core.Contracts;
using System;

namespace QA.Core
{
    public abstract class BasePage : IPage
    {
        private const string ThePageUrlCannotBeEmpty = "The URL of the page cannot be empty.";
        private const string TheTitleCannotBeEmpty = "The title of the page cannot be empty.";
        private const string BaseUrl = "http://www.facebook.com";

        protected readonly IWebDriver Driver;
        private string url;
        private string title;

        protected BasePage(IWebDriver driver, string url, string title)
        {
            this.Driver = driver;
            this.Url = url;
            this.Title = title;
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            private set
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

            private set
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
            this.Driver.Navigate().GoToUrl(this.Url);
        }
    }
}
