namespace Bookmarks.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using Bookmarks.Controllers;
    using Bookmarks.Data;

    [Authorize(Roles = "Admin")]
    public abstract class BaseAdminController : BaseController
    {
        protected BaseAdminController(IBookmarksData data)
            : base(data)
        {
        }
    }
}