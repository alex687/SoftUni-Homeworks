namespace Bookmarks.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Infrastructure.CacheService;
    using Bookmarks.Models.View;

    using Ninject.Infrastructure.Language;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data, ICacheService cache)
            : base(data)
        {
            this.Cache = cache;
        }

        private ICacheService Cache { get; set; }

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel() { Bookmarks = this.Cache.TopBookmarks };
            
            return this.View(homeViewModel);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

    }
}