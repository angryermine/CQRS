using Domain.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Persistence.NHibernate.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("Accounts");
            Id(x => x.Id);
            Map(x => x.Email);
            Component(x => x.Password);
        }
    }
}