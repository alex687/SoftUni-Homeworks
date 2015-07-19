namespace Twitter.Web.Models.TweetModels
{
    using System.ComponentModel.DataAnnotations;

    public class TweetInputModel
    {
        [Required]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "{0} lenght is between {2} and {1}")]
        public string Text { get; set; }
    }
}