using System;
using System.Text;

namespace QA.Core.Exceptions
{
    public class TextNotFoundException : ApplicationException
    {
        public TextNotFoundException()
        {
        }

        public TextNotFoundException(string textToFind, BaseWebDriverTest ext, Exception ex)
        {
            string message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message, ex);
        }

        public TextNotFoundException(string textToFind, BaseWebDriverTest ext)
        {
            string message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message);
        }

        private string BuildTextNotFoundExceptionText(string textToFind, BaseWebDriverTest ext)
        {
            var stringBuilder = new StringBuilder();

            string customLoggingMessage = String.Format("#### The text:  {0} ####\n ####WAS NOT FOUND!####", textToFind);
            stringBuilder.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = String.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            stringBuilder.AppendLine(cuurentUrlMessage);

            return stringBuilder.ToString();
        }
    }
}