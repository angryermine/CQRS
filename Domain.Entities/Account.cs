using Domain.Common;

namespace Domain.Entities
{
    public class Account : Entity
    {
        public Account(string email, string password)
        {
            ChangeEmail(email);
            ChangePassword(password);
        }

        public virtual string Email { get; protected set; }
        public virtual Password Password { get; protected set; }

        public virtual void ChangeEmail(string email)
        {
            Email = email;
        }

        public virtual void ChangePassword(string password)
        {
            Password = new Password(password);
        }
    }
}