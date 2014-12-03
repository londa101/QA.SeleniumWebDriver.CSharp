namespace QA.Core
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class BaseValidator
    {
        public void ValidateTitle(string expected, string actual)
        {
            Assert.AreEqual(expected,actual);
        }
    }
}
