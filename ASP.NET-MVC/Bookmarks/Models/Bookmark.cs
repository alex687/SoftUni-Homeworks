namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bookmark : IEntity
    {
        public Bookmark()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            this.Votes = new HashSet<Vote>();
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Title should be between {0} and {1}")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Url should be between {0} and {1}")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Description should be between {0} and {1}")]
        public string Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int VotesResult { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
