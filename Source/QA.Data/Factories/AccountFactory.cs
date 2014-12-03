namespace QA.Data.Factories
{
    using Models;

    public class AccountFactory
    {
        public Account GetInvalidAccount()
        {
            return new Account("login", "password");
        }
    }
}
