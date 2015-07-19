namespace MountainsCodeFirst.Data
{
    using System.Data.Entity;

    using MountainsCodeFirst.Migrations;
    using MountainsCodeFirst.Models;

    public class MountainsContext : DbContext
    {
        public MountainsContext()
            : base("MountainsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
        }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Mountain> Mountains { get; set; }
        
        public virtual IDbSet<Peak> Peaks { get; set; }
    }
}
