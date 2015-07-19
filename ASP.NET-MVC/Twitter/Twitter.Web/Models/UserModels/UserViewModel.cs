namespace Twitter.Web.Models.UserModels
{
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public bool IsFolowed { get; set; }
    }
}