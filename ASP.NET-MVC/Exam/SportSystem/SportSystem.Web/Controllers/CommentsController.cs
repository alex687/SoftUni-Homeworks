namespace SportSystem.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper;

    using SportSystem.Data;
    using SportSystem.Models;
    using SportSystem.Web.InputModels;

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ISportSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Add(SportSystem.Models.Match match, CommentInputModel commentInput)
        {
            var comment = Mapper.Map<Comment>(commentInput);
            comment.AuthorId = this.UserProfille.Id;
            comment.MatchId = match.Id;
            comment.CreatedOn = DateTime.Now;

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            return this.RedirectToAction("Details", "Matches", new { id = match.Id });
        }
    }
}