namespace ForumSystem.Web.Controllers
{
    using System.Web.Http;

    using ForumSystem.Data;

    public abstract class BaseController : ApiController
    {
        protected const int NumberArticlesPerPage = 15;

        protected BaseController()
            : this(new ApplicationDbContext())
        {
        }

        protected BaseController(ApplicationDbContext data)
        {
            this.Data = data;
        }

        protected ApplicationDbContext Data { get; set; }
    }
}