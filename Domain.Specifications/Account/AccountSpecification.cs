namespace Domain.Specifications.Account
{
    public class AccountSpecification : FluentSpecification<Entities.Account>
    {
        public AccountSpecification WithEmail(string email)
        {
            IncludeSpecification(new EmailEqualsSpecification(email));
            return this;
        }

        public AccountSpecification WithPassword(string password)
        {
            IncludeSpecification(new PasswordEqualsSpecification(password));
            return this;
        }
    }
}
