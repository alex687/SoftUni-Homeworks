namespace SportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team : IEntity
    {
        private ICollection<Player> players;
        private ICollection<Vote> votes;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;

        public Team()
        {
            this.homeMatches = new HashSet<Match>();
            this.awayMatches = new HashSet<Match>();
            this.votes = new HashSet<Vote>();
            this.players = new HashSet<Player>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        public DateTime DateFounded { get; set; }

        public virtual ICollection<Match> HomeMatches
        {
            get
            {
                return this.homeMatches;
            }

            set
            {
                this.homeMatches = value;
            }
        }

        public virtual ICollection<Match> AwayMatches
        {
            get
            {
                return this.awayMatches;
            }

            set
            {
                this.awayMatches = value;
            }
        }

        public virtual ICollection<Player> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.players = value;
            }
        }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }
    }
}
