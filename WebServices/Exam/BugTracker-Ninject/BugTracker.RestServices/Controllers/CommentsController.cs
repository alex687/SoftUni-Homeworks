namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using BugTracker.Data;
    using BugTracker.Data.Models;
    using BugTracker.RestServices.Models.Comments;

    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        /*public CommentsController()
            : base()
        {
        }
        */
        public CommentsController(IBugTrackerData data)
            : base(data)
        {
        }


        [HttpGet]
        public IHttpActionResult GetComments()
        {
            var comments = this.Data.Comments.All().OrderByDescending(c => c.DateCreated).Project().To<CommentsAllOutputModel>();

            return this.Ok(comments);
        }

        [HttpGet]
        public IHttpActionResult GetCommentsForBug(int id)
        {
            if (!this.Data.Bugs.All().Any(b => b.Id == id))
            {
                return this.NotFound();
            }

            var comments = this.Data.Comments.All().Where(c => c.BugId == id).OrderByDescending(c => c.DateCreated).Project().To<CommentsOutputModel>();

            return this.Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult PostAddComment(int id, CommentBindingModel commentData)
        {
            if (!this.Data.Bugs.All().Any(b => b.Id == id))
            {
                return this.NotFound();
            }

            if (commentData == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var comment = new Comment() { Text = commentData.Text, BugId = id, DateCreated = DateTime.Now };
            if (this.User.Identity.IsAuthenticated)
            {
                comment.AuthorId = this.User.Identity.GetUserId();
            }

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            if (this.User.Identity.IsAuthenticated)
            {
                return this.Ok(new { Id = comment.Id, Author = this.User.Identity.GetUserName(), Message = "User comment added for bug #" + id });
            }

            return this.Ok(new { Id = comment.Id, Message = "Added anonymous comment for bug #" + id });
        }
    }
}