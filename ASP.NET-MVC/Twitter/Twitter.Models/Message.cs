namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        
        [InverseProperty("ReceivedMessages")]
        public virtual User Receiver { get; set; }

        [Required]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [InverseProperty("SentMessages")]
        public virtual User Sender { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }
    }
}
