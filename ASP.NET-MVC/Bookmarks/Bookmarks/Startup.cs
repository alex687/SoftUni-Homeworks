using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookmarks.Startup))]
namespace Bookmarks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
