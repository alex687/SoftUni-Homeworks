namespace Twitter.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Twitter.Data;
    using Twitter.Models;
    using Twitter.Web.Models.TweetModels;

    [Authorize]
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        // GET: Tweets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Favorite(int id)
        {
            var tweet = this.Data.Tweets.All().FirstOrDefault(t => t.Id == id);
            if (tweet == null)
            {
                return this.HttpNotFound();
            }

            this.UserProfille.FavoriteTweets.Add(tweet);
            this.Data.SaveChanges();

            // this.RedirectToAction("")
            return this.HttpNotFound();
        }

        public ActionResult View(int id)
        {
            var tweet = this.Data.Tweets.All().Where(t => t.Id == id).Include(t => t.User).Project().To<TweetViewModel>().FirstOrDefault();

            if (tweet == null)
            {
                return this.HttpNotFound();
            }

            return this.View(tweet);
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(TweetInputModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var tweet = new Tweet { Text = model.Text, UserId = this.UserProfille.Id };
            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            return this.RedirectToAction("View", new { id = tweet.Id});
        }
    }
}