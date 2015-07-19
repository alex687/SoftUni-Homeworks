namespace Bookmarks.Models.View
{
    using System.Collections.Generic;

    using Bookmarks.Models.View.BookmarkModels;

    public class HomeViewModel
    {
        public IList<BookmarkViewModel> Bookmarks { get; set; }
    }
}