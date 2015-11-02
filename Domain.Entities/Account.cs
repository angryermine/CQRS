using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Account : Entity
    {
        protected Account()
        {
            RegistrationDate = DateTime.Now;
        }

        public Account(string name, string email, string password)
            : this()
        {
            ChangeName(name);
            ChangeEmail(email);
            ChangePassword(password);
        }

        public virtual string Name { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual Password Password { get; protected set; }
        public virtual DateTime RegistrationDate { get; protected set; }

        public virtual void ChangeName(string name)
        {
            Name = name;
        }

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