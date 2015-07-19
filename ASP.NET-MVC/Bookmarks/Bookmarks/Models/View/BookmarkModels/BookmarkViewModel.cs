namespace Bookmarks.Models.View.BookmarkModels
{
    using AutoMapper;

    using Bookmarks.Common.Mappings;

    public class BookmarkViewModel : IMapFrom<Bookmark> 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}