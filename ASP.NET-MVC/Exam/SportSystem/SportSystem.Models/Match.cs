namespace SportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match : IEntity
    {
        private ICollection<Comment> comments;
        private ICollection<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Bet> Bets
        {
            get
            {
                return this.bets;
            }

            set
            {
                this.bets = value;
            }
        }
    }
}
