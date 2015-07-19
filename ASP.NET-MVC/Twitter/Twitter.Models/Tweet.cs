namespace Twitter.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        private ICollection<User> favoritedByUser;

        public Tweet()
        {
            this.favoritedByUser = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> FavoritedByUsers
        {
            get
            {
                return this.favoritedByUser;
            }

            set
            {
                this.favoritedByUser = value;
            }
        }
    }
}
