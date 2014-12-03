namespace QA.Core
{
    using System;
    using System.Text;
    using System.Threading;

    using Contracts;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using NoSuchElementException = Exceptions.NoSuchElementException;

    /// <summary>
    /// The base web driver test.
    /// </summary>
    public class BaseWebDriverTest
    {
        /// <summary>
        /// The web driver service.
        /// </summary>
        private readonly IWebDriverService webDriverService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWebDriverTest"/> class.
        /// </summary>
        public BaseWebDriverTest()
        {
            IWebDriverFactory webDriverFactory = new WebDriverFactory();
            this.webDriverService = new WebDriverService(webDriverFactory);
        }

        public IWebDriver Browser { get; set; }

        public StringBuilder VerificationErrors { get; set; }

        public string BaseUrl { get; set; }

        public WebDriverWait Wait { get; set; }

        public IWebElement CurrentElement { get; set; }

        public int TimeOut { get; set; }

        protected log4net.ILog Log { get; set; }

        protected void OpenBrowser(BrowserType browserType, int timeOut)
        {
            this.Browser = this.webDriverService.GetBrowser(browserType);
            this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(timeOut));
            this.TimeOut = timeOut;
            this.Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected void CloseBrowser()
        {
            try
            {
                this.Browser.Quit();
            }
            catch (Exception ex)
            {
                this.Log.Error(ex.Message);
            }
        }

        protected IWebElement GetElement(By by)
        {
            IWebElement result = null;
            try
            {
                result = this.Wait.Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                this.Log.Error(ex.Message);
                throw new NoSuchElementException(by, this, ex);
            }

            return result;
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                this.Browser.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                this.Log.Error(ex.Message);
                return false;
            }
        }

        protected void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        protected void WaitForElementNotPresent(By by)
        {
            try
            {
                this.GetElement(by);
                throw new ElementStillVisibleException(by, this);
            }
            catch (NoSuchElementException ex)
            {
                this.Log.Error(ex.Message);
                return;
            }
        }

        protected void WaitForChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                this.Log.ErrorFormat("The element with find expression {0} was not checked.", by.ToString());
                throw new NotCheckedException(by, this);
            }
        }

        protected void WaitForNotChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                this.Log.ErrorFormat("The element with find expression {0} was checked.", by.ToString());
                throw new StillCheckedException(by, this);
            }
        }

        protected void WaitForTextPresent(string textToFind, bool shouldWait = true)
        {
            for (int second = 0; second < this.TimeOut; second++)
            {
                if (second >= this.TimeOut)
                {
                    this.Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                    throw new TextNotFoundException(textToFind, this);
                }

                try
                {
                    string bodyInnerHtml = this.Browser.FindElement(By.TagName("body")).Text;
                    bool isContainingText = bodyInnerHtml.Contains(textToFind);
                    Assert.AreEqual(shouldWait, isContainingText);

                    break;
                }
                catch (Exception ex)
                {
                    this.Log.Error(ex.Message);
                }

                Thread.Sleep(1000);
            }
        }

        protected void WaitForText(By by, string textToFind)
        {
            IWebElement currentElement = this.GetElement(by);
            string elementText = currentElement.Text;

            if (!textToFind.Equals(elementText))
            {
                this.Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                throw new TextNotFoundException(textToFind, this);
            }
        }

        protected void WaitForTextNotPresent(string textToFind)
        {
            this.WaitForTextPresent(textToFind, false);
        }
    }
}