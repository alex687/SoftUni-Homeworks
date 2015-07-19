namespace News.Web.Models.NewsItems
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using News.Models;

    public class NewsItemOutputModel
    {
        public static Func<NewsItem, NewsItemOutputModel> Project
        {
            get
            {
                return
                    n => new NewsItemOutputModel
                    {
                        Content = n.Content,
                        Id = n.Id,
                        PublishDate = n.PublishDate,
                        Title = n.Title,
                        UserId = n.UserId,
                        UserName = n.User.UserName
                    };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}