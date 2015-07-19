namespace Bookmarks.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Bookmarks.Models;

    using Microsoft.AspNet.Identity;

    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<BookmarksDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookmarksDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var adminRole = new IdentityRole { Name = "Admin" };
                roleManager.Create(adminRole);

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var admin = new User { UserName = "admin", Email = "admin@website.com" };
                userManager.Create(admin, "admin");
                userManager.AddToRole(admin.Id, "Admin");
            }
        }
    }
}
