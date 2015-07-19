namespace BugTracker.RestServices.Controllers
{
    using System.Web.Http;

    using BugTracker.Data;

    public abstract class BaseController : ApiController
    {
        protected BaseController()
            : this(new BugTrackerData(new BugTrackerDbContext()))
        {
        } 

        protected BaseController(IBugTrackerData data)
        {
            this.Data = data;
        }

        public IBugTrackerData Data { get; set; }
    }
}