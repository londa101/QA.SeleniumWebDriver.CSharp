namespace QA.Data.Models
{
    public class Account
    {
        private string password;
        private string email;

        public Account(string email, string password)
        {
            this.Password = password;
            this.Email = email;
        }

        public string Email
        {
            get { return this.email; }
            private set { this.email = value; }
        }

        public string Password
        {
            get { return this.password; }
            private set { this.password = value; }
        }
    }
}