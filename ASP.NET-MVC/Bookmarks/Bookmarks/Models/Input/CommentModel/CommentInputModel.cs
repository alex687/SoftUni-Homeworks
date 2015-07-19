namespace Bookmarks.Models.Input.CommentModel
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        [MinLength(3)]
        public string Text { get; set; }
    }
}