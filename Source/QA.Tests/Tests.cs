namespace QA.Tests
{
    using Core;
    using Data.Factories;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pages.FacebookMain;

    [TestClass]
    public class Tests : BaseWebDriverTest
    {
        private FacebookMainPage page;
        private AccountFactory accountFactory = new AccountFactory();

        [TestInitialize]
        public void SetupTest()
        {
            this.OpenBrowser(BrowserType.Chrome, 10);
            this.page = new FacebookMainPage(this.Browser);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.CloseBrowser();
        }

        [TestMethod]
        [Priority(5)]
        public void VerifyTitle()
        {
            this.page.NavigateTo();

            Assert.AreEqual(this.page.Title, this.Browser.Title);
        }

        [TestMethod]
        [Priority(5)]
        public void VerifyUrl()
        {
            this.page.NavigateTo();

            Assert.AreEqual(this.page.Url, this.Browser.Url);
        }

        [TestMethod]
        [Priority(3)]
        public void LoginInvalidUser()
        {
            this.page.NavigateTo();
            Account account = this.accountFactory.GetInvalidAccount();
            this.page.LoginUser(account);
        }
    }
}
