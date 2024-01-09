using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class BfVController : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "BattleField V";
            return View();
        }
    }
}