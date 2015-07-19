namespace MusicSystem.Data
{
    using System.Data.Entity;

    using MusicSystem.Models;

    public interface IMusicSystemDbContext
    {
        IDbSet<Artist> Artists { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        int SaveChanges();
    }
}
