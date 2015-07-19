namespace SportSystem.Web.ViewModels
{
    using System;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}