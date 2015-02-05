using System;

namespace Domain.Specifications.Account
{
    public class AccountSpecification : FluentSpecification<Entities.Account>
    {
        public AccountSpecification WithId(int id)
        {
            IncludeSpecification(new IdEqualsSpecification(id));
            return this;
        }

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

        public AccountSpecification WithRegistrationDate(DateTime from, DateTime to)
        {
            IncludeSpecification(new RegistrationDateRange(from, to));
            return this;
        }
    }
}
