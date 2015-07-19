namespace SportSystem.Web.ViewModels
{
    using System;

    using SportSystem.Models;
    using SportSystem.Web.Infrastructure.Mappings;

    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }
    }
}