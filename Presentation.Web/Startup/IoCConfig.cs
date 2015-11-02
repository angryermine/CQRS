using System.Linq;
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

namespace Presentation.Web.Startup
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var database = MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("Main"));
            var config = Fluently.Configure().Database(database)
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.Load("Infrastructure.Persistence.NHibernate")))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            var container = new Container();
            container.Register(config.BuildSessionFactory, new WebRequestLifestyle());
            container.Register(() => container.GetInstance<ISessionFactory>().OpenSession(), new WebRequestLifestyle());
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.Register<IRepository, Repository>();

            container.RegisterCollection(typeof(IQuery<>), Assembly.Load("Application.Queries"));
            container.Register(typeof(IQueryHandler<,>), new[] { Assembly.Load("Application.Queries") });
            container.Register<IQueryDispatcher>(() => new QueryDispatcher(container.GetInstance));

            container.Register(typeof(ICommandHandler<>), new[] { Assembly.Load("Application.Commands") });
            container.Register<ICommandDispatcher>(() => new CommandDispatcher(container.GetInstance));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}