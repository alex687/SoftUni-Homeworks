namespace Bookmarks.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Models;
    using Bookmarks.Models.Input.BookmarkModels;
    using Bookmarks.Models.View.BookmarkModels;

    using PagedList;

    [Authorize]
    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var bookmarks = this.Data.Bookmarks.All().OrderByDescending(b => b.Id)
                .Project()
                .To<BookmarkViewModel>();

            PagedList<BookmarkViewModel> model = new PagedList<BookmarkViewModel>(bookmarks, page, 10);


            return this.View(model);
        }

        public ActionResult View(Bookmark bookmark)
        {
            if (bookmark == null)
            {
                return this.HttpNotFound();
            }

            var bookmarkView = Mapper.Map<BookmarkDetailsViewModel>(bookmark);

            return this.View(bookmarkView);
        }

        public ActionResult VoteForBookmark(Bookmark bookmark)
        {
            if (bookmark == null)
            {
                return this.HttpNotFound();
            }

            var vote = new Vote { BookmarkId = bookmark.Id, UserId = this.UserProfille.Id, UserVote = 1 };
            this.Data.Votes.Add(vote);
            bookmark.VotesResult = bookmark.VotesResult + 1;
            this.Data.SaveChanges();

            return this.Content(bookmark.VotesResult.ToString());
        }

        public ActionResult Create()
        {
            this.LoadCategories();
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(BookmarkInputModel bookmarkInput)
        {
            if (bookmarkInput != null && this.ModelState.IsValid)
            {
                var bookmark = Mapper.Map<Bookmark>(bookmarkInput);
                bookmark.OwnerId = this.UserProfille.Id;
                this.Data.Bookmarks.Add(bookmark);
                this.Data.SaveChanges();

                return this.RedirectToAction("View", new { id = bookmark.Id });
            }

            return this.View(bookmarkInput);
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = this.Data.Categories
                .All()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
        }
    }
}