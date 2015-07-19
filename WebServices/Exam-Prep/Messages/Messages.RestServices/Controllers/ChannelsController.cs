using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessagesRestService.Controllers
{
    public class ChannelsController : Controller
    {
        // GET: Channels
        public ActionResult Index()
        {
            return View();
        }
    }
}