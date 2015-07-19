namespace SportSystem.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using SportSystem.Data;
    using SportSystem.Data.Migrations;
    using SportSystem.Web.Infrastructure.Mappings;
    using SportSystem.Web.Infrastructure.ModelBinders;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewConfig.RegisterViews(ViewEngines.Engines);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportSystemDbContext, Configuration>());

            var autoMapper = new AutoMapperConfig(new[] { Assembly.GetExecutingAssembly() });
            autoMapper.Execute();

            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());
        }
    }
}
