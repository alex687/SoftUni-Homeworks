namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Text { get; set; }
        
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        public int BookmarkId { get; set; }

        public Bookmark Bookmark { get; set; }
    }
}
