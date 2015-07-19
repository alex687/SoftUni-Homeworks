namespace Twitter.Web.Models.TweetModels
{
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.Models.UserModels;

    public class TweetViewModel : IMapFrom<Tweet>
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual UserViewModel User { get; set; }

        public bool IsFavorited { get; set; }
    }
}