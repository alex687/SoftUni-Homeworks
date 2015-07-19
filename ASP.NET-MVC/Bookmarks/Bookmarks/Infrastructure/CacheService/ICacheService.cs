namespace Bookmarks.Infrastructure.CacheService
{
    using System.Collections.Generic;

    using Bookmarks.Models.View.BookmarkModels;

    public interface ICacheService
    {
        IList<BookmarkViewModel> TopBookmarks { get; }
    }
}
