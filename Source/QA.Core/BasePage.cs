namespace QA.Core
{
    using System;

    using Contracts;
    using OpenQA.Selenium;

    /// <summary>
    /// The base page.
    /// </summary>
    public abstract class BasePage : IPage
    {
        private const string ThePageUrlCannotBeEmpty = "The URL of the page cannot be empty.";
        private const string TheTitleCannotBeEmpty = "The title of the page cannot be empty.";
        private const string TheDriverCannotBeNull = "The driver cannot be null.";

        private IWebDriver driver;
        private string url;
        private string title;

        protected BasePage(IWebDriver driver, string url, string title)
        {
            this.Driver = driver;
            this.Url = url;
            this.Title = title;
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(TheDriverCannotBeNull);
                }

                this.driver = value;
            }
        }
        
        /// <summary>
        /// Gets the url.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an ArgumentNullException if the value is empty or null.
        /// </exception>
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

        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws an ArgumentNullException if the value for the title is empty or null.
        /// </exception>
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

        /// <summary>
        /// Navigates to the page.
        /// </summary>
        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(this.Url);
        }
    }
}
