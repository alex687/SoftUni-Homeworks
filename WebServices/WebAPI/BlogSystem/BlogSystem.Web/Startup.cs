using BlogSystem.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace BlogSystem.Web
{
    using System.Reflection;
    using System.Web.Http;

    using BlogSystem.Data;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
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
            kernel.Bind<IBlogSystemData>()
                .To<BlogSystemData>()
                .WithConstructorArgument("context", new BlogSystemContext());
        }
    }
}
