﻿namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int VoteValue { get; set; }
    }
}
