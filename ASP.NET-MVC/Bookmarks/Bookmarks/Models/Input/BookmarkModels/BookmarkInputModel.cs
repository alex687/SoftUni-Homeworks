namespace Bookmarks.Models.Input.BookmarkModels
{
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Common.Mappings;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Title should be between {0} and {1}")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Url should be between {0} and {1}")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "Description should be between {0} and {1}")]
        public string Description { get; set; }
    }
}