using Domain.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Persistence.NHibernate.Mappings
{
    public class PasswordMap : ComponentMap<Password>
    {
        public PasswordMap()
        {
            Map(x => x.Hash);
        }
    }
}