using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using QA.Core;
using QA.Pages.FacebookMain;

namespace QA.Tests
{
    [TestClass]
    public class Tests : BaseWebDriverTest
    {
        [TestInitialize]
        public void SetupTest()
        {
            this.TestInit(new FirefoxDriver(), @"http://www.telerik.com/", 10);
        }

        [TestCleanup]
        public void TeardownTest()
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

        [TestMethod]
        [Priority(5)]
        public void VerifyTitle()
        {
            var page = new FacebookMainPage(this.Browser);
            page.NavigateTo();

            Assert.AreEqual("Welcome to Facebook - Log In, Sign Up or Learn More", this.Browser.Title);
        }

        [TestMethod]
        [Priority(5)]
        public void VerifyUrl()
        {
            var page = new FacebookMainPage(this.Browser);
            page.NavigateTo();

            Assert.AreEqual(page.Url, this.Browser.Url);
        }

        [TestMethod]
        [Priority(3)]
        public void LoginValidUser()
        {
            var page = new FacebookMainPage(this.Browser);
            page.NavigateTo();
            page.LoginUser();
            
        }
    }
}
