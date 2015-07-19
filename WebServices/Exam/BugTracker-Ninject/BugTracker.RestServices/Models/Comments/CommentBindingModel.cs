namespace BugTracker.RestServices.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; }
    }
}