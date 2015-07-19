namespace Bookmarks.Models.View.BookmarkModels
{
    using System.Collections.Generic;

    using AutoMapper;

    using Bookmarks.Common.Mappings;
    using Bookmarks.Models.View.CommentModels;

    public class BookmarkDetailsViewModel : IMapFrom<Bookmark>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public string Category { get; set; }

        public int VotesResult { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Bookmark, BookmarkDetailsViewModel>()
                .ForMember(bvm => bvm.Category, opt => opt.MapFrom(b => b.Category.Name));
        }
    }
}