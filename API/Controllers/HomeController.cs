using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/docs")]
        [Route("/swagger")]
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}

