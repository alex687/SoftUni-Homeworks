namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<User> followers;

        private ICollection<Tweet> tweets;

        private ICollection<Tweet> favoriteTweets;

        private ICollection<Message> receivedMessages;

        private ICollection<Message> sentMessages;

        private ICollection<Notification> notifications;

        private ICollection<User> following;

        public User()
        {
            this.sentMessages = new HashSet<Message>();
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.tweets = new HashSet<Tweet>();
            this.favoriteTweets = new HashSet<Tweet>();
            this.receivedMessages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get
            {
                return this.receivedMessages;
            }

            set
            {
                this.receivedMessages = value;
            }
        }


        public virtual ICollection<Message> SentMessages
        {
            get
            {
                return this.sentMessages;
            }

            set
            {
                this.sentMessages = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<User> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }


        public virtual ICollection<Tweet> Tweets
        {
            get
            {
                return this.tweets;
            }

            set
            {
                this.tweets = value;
            }
        }

        public virtual ICollection<Tweet> FavoriteTweets
        {
            get
            {
                return this.favoriteTweets;
            }

            set
            {
                this.favoriteTweets = value;
            }
        }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
