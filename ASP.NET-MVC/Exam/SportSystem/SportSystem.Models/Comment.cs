namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        [Required]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
