namespace SportSystem.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class CommentInputModel : IMapTo<Comment>
    {
        [Required]
        [MinLength(3, ErrorMessage = "The minimum lenght is {0}")]
        public string Content { get; set; }
    }
}