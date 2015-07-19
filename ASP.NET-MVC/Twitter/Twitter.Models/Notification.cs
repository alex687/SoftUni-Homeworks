namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        public DateTime ViewedOn { get; set; }
    }
}
