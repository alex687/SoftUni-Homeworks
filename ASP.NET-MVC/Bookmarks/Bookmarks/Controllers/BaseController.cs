namespace Bookmarks.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Bookmarks.Data;
    using Bookmarks.Models;

    public abstract class BaseController : Controller
    {
        private User user; 

        protected BaseController(IBookmarksData data)
        {
            this.Data = data;
        }

        protected IBookmarksData Data { get; set; }

        protected User UserProfille
        {
            get
            {
                if (this.user == null)
                {
                    if (this.HttpContext.User.Identity.IsAuthenticated)
                    {
                        var username = this.HttpContext.User.Identity.Name;
                        this.user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                    }
                }

                return this.user;
            }
        }
    }
}