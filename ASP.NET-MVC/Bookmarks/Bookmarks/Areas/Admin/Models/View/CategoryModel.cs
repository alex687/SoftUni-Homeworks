namespace Bookmarks.Areas.Admin.Models.View
{
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class CategoryModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}