namespace BugTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [Column(TypeName = "text")]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public virtual Bug Bug { get; set; }
    }
}
