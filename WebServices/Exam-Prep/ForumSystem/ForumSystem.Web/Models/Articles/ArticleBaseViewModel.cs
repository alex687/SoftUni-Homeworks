namespace ForumSystem.Web.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ForumSystem.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class ArticleBaseViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public virtual ICollection<string> Tags { get; set; }
    }
}