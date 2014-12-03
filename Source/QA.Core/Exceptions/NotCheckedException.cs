namespace QA.Core.Exceptions
{
    using System;
    using System.Text;
    using OpenQA.Selenium;

    public class NotCheckedException : ApplicationException
    {
        public NotCheckedException()
        {
        }

        public NotCheckedException(By by, BaseWebDriverTest ext, Exception ex)
        {
            string message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public NotCheckedException(By by, BaseWebDriverTest ext)
        {
            string message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildNotCheckedExceptionText(By by, BaseWebDriverTest ext)
        {
            var stringBuilder = new StringBuilder();

            string customLoggingMessage =
                string.Format("#### The element with the location strategy:  {0} ####\n ####WAS NOT CHECKED!####", by.ToString());
            stringBuilder.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = string.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            stringBuilder.AppendLine(cuurentUrlMessage);

            return stringBuilder.ToString();
        }
    }
}