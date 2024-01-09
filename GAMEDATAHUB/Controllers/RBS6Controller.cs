using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class RBS6Controller : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "Rainbow Six";
            return View();
        }
    }
}