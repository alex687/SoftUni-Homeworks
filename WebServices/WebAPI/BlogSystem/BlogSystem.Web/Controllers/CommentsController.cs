namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;

    using BlogSystem.Data;
    using BlogSystem.Models;
    using BlogSystem.Web.Models.Comments;

    using Microsoft.AspNet.Identity;

    public class CommentsController : ApiController
    {
        private IBlogSystemData data;

        public CommentsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [AllowAnonymous]
        public IHttpActionResult GetCommentsForPost(int postId)
        {
            var comments = this.data.Posts.All().Where(p => p.Id == postId).Select(p => p.Comments);

            return this.Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult Add(int postId, CommentsModel commentUpload)
        {
            if (commentUpload == null)
            {
                this.ModelState.AddModelError("comment", "There is no comment");
            }

            if (this.data.Users.All().Count(u => u.Id == commentUpload.UserId) == 0)
            {
                this.ModelState.AddModelError("user", "Invalid User");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var comment = Mapper.Map<Comment>(commentUpload);
            comment.PostId = postId;
            comment.UserId = this.User.Identity.GetUserId();
            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            return this.Ok(comment);
        }
    }
}