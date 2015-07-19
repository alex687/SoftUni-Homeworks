namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Category name should be between {0} and {1}")]
        public string Name { get; set; }
    }
}
