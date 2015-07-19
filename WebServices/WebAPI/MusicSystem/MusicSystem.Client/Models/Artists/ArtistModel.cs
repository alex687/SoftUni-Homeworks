namespace MusicSystem.Client.Models.Artists
{
    using System;

    public class ArtistModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}