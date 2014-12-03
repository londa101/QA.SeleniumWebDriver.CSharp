using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Core;
using QA.Pages.FacebookMain;

namespace QA.Tests
{
    [TestClass]
    public class Tests : BaseWebDriverTest
    {
        private FacebookMainPage page;

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
            page.NavigateTo();
       
            Assert.AreEqual(page.Title, this.Browser.Title);
        }

        [TestMethod]
        [Priority(5)]
        public  void VerifyUrl()
        {
            this.page.NavigateTo();

            Assert.AreEqual(page.Url, this.Browser.Url);
        }

        [TestMethod]
        [Priority(3)]
        public void LoginValidUser()
        {
            this.page.NavigateTo();
            this.page.LoginUser();
        }
    }
}
