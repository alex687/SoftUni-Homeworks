namespace Bookmarks
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Bookmarks.Common.Mappings;
    using Bookmarks.Data;
    using Bookmarks.Data.Migrations;
    using Bookmarks.Infrastructure.ModelBinders;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);

            var autoMapper = new AutoMapperConfig(new[] { Assembly.GetExecutingAssembly() });
            autoMapper.Execute();

            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, Configuration>());
        }
    }
}
