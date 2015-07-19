namespace Twitter.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PagedList;

    using Twitter.Data;
    using Twitter.Web.Models.TweetModels;

    using WebGrease.Css.Extensions;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1)
        {
            var tweets = this.Data.Tweets.All()
                .Include(x => x.User)
                .OrderByDescending(t => t.Id)
                .Project()
                .To<TweetViewModel>();

            PagedList<TweetViewModel> model = new PagedList<TweetViewModel>(tweets, page, 10);

            return this.View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}