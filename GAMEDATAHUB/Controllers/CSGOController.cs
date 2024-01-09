using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class CSGOController : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "CS:G0";
            return View();
        }
    }
}