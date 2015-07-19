namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Twitter.Data;
    using Twitter.Models;

    public class BaseController : Controller
    {
        private User user; 

        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        protected ITwitterData Data { get; set; }

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