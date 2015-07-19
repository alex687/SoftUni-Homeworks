using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BugTracker.RestServices.Startup))]

namespace BugTracker.RestServices
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;

    using BugTracker.Data;
    using BugTracker.Data.Migrations;
    using BugTracker.RestServices.Infrastructure.Mapping;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugTrackerDbContext, BugTrackerDbMigrationConfiguration>());

            this.ConfigureAuth(app);
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute();

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IBugTrackerData>()
                .To<BugTrackerData>()
                .WithConstructorArgument("context", new BugTrackerDbContext());
        }
    }
}
