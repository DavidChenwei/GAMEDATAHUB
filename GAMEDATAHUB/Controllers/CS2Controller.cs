using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class CS2Controller : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "Counter-Strike 2";
            return View();
        }
    }
}