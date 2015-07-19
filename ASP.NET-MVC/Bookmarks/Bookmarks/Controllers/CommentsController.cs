namespace Bookmarks.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Bookmarks.Data;
    using Bookmarks.Models;
    using Bookmarks.Models.Input.CommentModel;
    using Bookmarks.Models.View.CommentModels;

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(IBookmarksData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Add(CommentInputModel commentInput, Bookmark bookmark)
        {
            if (bookmark == null)
            {
                this.HttpNotFound();
            }

            var comment = new Comment { Text = commentInput.Text, AuthorId = this.UserProfille.Id, BookmarkId = bookmark.Id };
            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var commentView = Mapper.Map<CommentViewModel>(comment);
            return this.PartialView("DisplayTemplates/CommentViewModel", commentView);
        }
    }
}