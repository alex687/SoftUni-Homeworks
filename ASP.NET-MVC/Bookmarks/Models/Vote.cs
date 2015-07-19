namespace Bookmarks.Models
{
    public class Vote : IEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int BookmarkId { get; set; }

        public Bookmark Bookmark { get; set; }

        public int UserVote { get; set; }
    }
}
