using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicSystem.Web.Controllers
{
    using System.Web.Http;

    using MusicSystem.Data;

    public abstract class BaseController : ApiController
    {
        protected readonly IMusicSystemDbContext Data;

        protected BaseController()
            : this(new ApplicationDbContext())
        {
        }

        protected BaseController(IMusicSystemDbContext data)
        {
            this.Data = data;
        }
    }
}