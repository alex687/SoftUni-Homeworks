namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using SportSystem.Data;
    using SportSystem.Models;

    public abstract class BaseController : Controller
    {
        private User user;

        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected ISportSystemData Data { get; set; }

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