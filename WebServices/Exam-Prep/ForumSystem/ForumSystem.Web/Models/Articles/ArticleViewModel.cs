namespace ForumSystem.Web.Models.Articles
{
    using System.Collections.Generic;

    using ForumSystem.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ForumSystem.Web.Models.Comments;

    public class ArticleViewModel : ArticleBaseViewModel, IMapFrom<Article>
    {
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}