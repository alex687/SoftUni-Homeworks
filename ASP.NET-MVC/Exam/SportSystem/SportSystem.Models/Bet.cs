namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bet : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public double Ammount { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
