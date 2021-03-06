﻿namespace Bookmarks.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class BookmarksDbContext : IdentityDbContext<User>, IDbContext
    {
        public BookmarksDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Bookmark> Bookmarks { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }
    }
}
