using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA.Core.Contracts;
using QA.Core.Exceptions;
using System;
using System.Text;
using System.Threading;
using NoSuchElementException = QA.Core.Exceptions.NoSuchElementException;

namespace QA.Core
{
    public class BaseWebDriverTest
    {
        private IWebDriverService _webDriverService;
        private IWebDriverFactory _webDriverFactory;

        public void TestInit(BrowserType browserType, int timeOut)
        {
            this._webDriverFactory = new WebWebDriverFactory();
            this._webDriverService = new WebDriverService(_webDriverFactory);
            this.Browser = _webDriverService.GetBrowser(browserType);
            this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(timeOut));
            this.TimeOut = timeOut;
            this.Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected log4net.ILog Log { get; set; }

        public IWebDriver Browser { get; set; }

        public StringBuilder VerificationErrors { get; set; }

        public string BaseUrl { get; set; }

        public WebDriverWait Wait { get; set; }

        public IWebElement CurrentElement { get; set; }

        public int TimeOut { get; set; }

        public IWebElement GetElement(By by)
        {
            IWebElement result = null;
            try
            {
                result = this.Wait.Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                Log.Error(ex.Message);
                throw new NoSuchElementException(by, this, ex);
            }

            return result;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                this.Browser.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        public void WaitForElementNotPresent(By by)
        {
            try
            {
                this.GetElement(by);
                throw new ElementStillVisibleException(by, this);
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex.Message);
                return;
            }
        }

        public void WaitForChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Log.ErrorFormat("The element with find expression {0} was not checked.", by.ToString());
                throw new NotCheckedException(by, this);
            }
        }

        public void WaitForNotChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Log.ErrorFormat("The element with find expression {0} was checked.", by.ToString());
                throw new StillCheckedException(by, this);
            }
        }

        public void WaitForTextPresent(string textToFind, bool shouldWait = true)
        {
            for (int second = 0;; second++)
            {
                if (second >= this.TimeOut)
                {
                    Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
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
                    Log.Error(ex.Message);
                }
                Thread.Sleep(1000);
            }
        }

        public void WaitForText(By by, string textToFind)
        {
            IWebElement currentElement = this.GetElement(by);
            string elementText = currentElement.Text;

            if (!textToFind.Equals(elementText))
            {
                Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                throw new TextNotFoundException(textToFind, this);
            }
        }

        public void WaitForTextNotPresent(string textToFind)
        {
            this.WaitForTextPresent(textToFind, false);
        }
    }
}

