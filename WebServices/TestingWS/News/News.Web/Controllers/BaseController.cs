using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace News.Web.Controllers
{
    using System.Web.Http;

    using News.Data;

    public abstract class BaseController : ApiController
    {
        protected BaseController()
            : this(new NewsData(new NewsDbContext()))
        {
        }

        protected BaseController(INewsData newsData)
        {
            this.NewsData = newsData;
        }

        public INewsData NewsData { get; set; }
    }
}
