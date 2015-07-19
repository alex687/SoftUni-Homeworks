using Microsoft.Owin;

[assembly: OwinStartup(typeof(SportSystem.Web.Startup))]

namespace SportSystem.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
