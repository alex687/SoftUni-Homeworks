namespace ForumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")] 
        public virtual ApplicationUser User { get; set; }

        public virtual Article Article { get; set; }

    }
}
