namespace Bookmarks.Infrastructure.CacheService
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Models.View;
    using Bookmarks.Models.View.BookmarkModels;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IBookmarksData data;

        public MemoryCacheService(IBookmarksData data)
        {
            this.data = data;
        }

        public IList<BookmarkViewModel> TopBookmarks
        {
            get
            {
                return this.Get<IList<BookmarkViewModel>>(
                    "Bookmarks",
                    () => this.data.Bookmarks.All()
                     .OrderBy(b => b.VotesResult)
                    .Take(6)
                    .Project()
                    .To<BookmarkViewModel>()
                    .ToList());
            }
        }
    }
}