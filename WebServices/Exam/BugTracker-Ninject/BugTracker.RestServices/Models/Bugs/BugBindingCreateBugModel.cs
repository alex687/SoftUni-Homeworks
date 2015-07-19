namespace BugTracker.RestServices.Models.Bugs
{
    using System.ComponentModel.DataAnnotations;

    public class BugBindingCreateBugModel
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }


    }
}