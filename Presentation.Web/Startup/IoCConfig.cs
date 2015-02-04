using System.Reflection;
using System.Web.Mvc;
using Application.Common.Commands;
using Application.Common.Queries;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.NHibernate;
using Infrastructure.Persistence.NHibernate.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Presentation.Web
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var database = MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("Main"));
            var config = Fluently.Configure().Database(database)
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AccountMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            var container = new Container();
            container.Register(config.BuildSessionFactory, new WebRequestLifestyle());
            container.Register(() => container.GetInstance<ISessionFactory>().OpenSession(), new WebRequestLifestyle());
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.RegisterOpenGeneric(typeof(IRepository<>), typeof(Repository<>));

            container.RegisterManyForOpenGeneric(typeof(IQuery<>), Assembly.Load("Application.Queries"));
            container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), Assembly.Load("Application.Queries"));
            container.Register<IQueryDispatcher>(() => new QueryDispatcher(container.GetInstance));

            container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), Assembly.Load("Application.Commands"));
            container.Register<ICommandDispatcher>(() => new CommandDispatcher(container.GetInstance));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}