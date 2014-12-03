namespace QA.Core.Exceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class ElementStillVisibleException : ApplicationException
    {
        public ElementStillVisibleException()
        {
        }

        public ElementStillVisibleException(By by, BaseWebDriverTest ext, Exception ex)
        {
            string message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public ElementStillVisibleException(By by, BaseWebDriverTest ext)
        {
            string message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildElementStillVisibleExceptionText(By by, BaseWebDriverTest ext)
        {
            var sb = new StringBuilder();

            string customLoggingMessage = string.Format("#### The element with the location strategy:  {0} ####\n ####IS STILL VISIBLE!####", by.ToString());
            sb.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = string.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}