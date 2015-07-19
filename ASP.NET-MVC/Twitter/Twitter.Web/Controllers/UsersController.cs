namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;


    using PagedList;

    using Twitter.Data;
    using Twitter.Web.Models.TweetModels;

    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {

            return this.View();
        }

        [AllowAnonymous]
        public ActionResult ProfilleView(string username, int page = 1)
        {
            var visitUser = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
            if (visitUser == null)
            {
                return this.HttpNotFound();
            }

            var tweets = visitUser.Tweets
              .AsQueryable()
              .OrderByDescending(t => t.Id)
              .Project()
              .To<TweetViewModel>();

            PagedList<TweetViewModel> model = new PagedList<TweetViewModel>(tweets, page, 10);

            return this.Content("Username ahahaaha");
        }

        public ActionResult Follow(string username)
        {
            var followUser = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
            if (followUser == null)
            {
                return this.HttpNotFound();
            }

            if (followUser.Id == this.UserProfille.Id)
            {
                return this.RedirectToAction("Index");
            }

            this.UserProfille.Following.Add(followUser);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}