using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class Bf1Controller : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "BattleField 1";
            return View();
        }

        [HttpGet]
        public ActionResult BF1Search() {

            return View();
        }
    }
}