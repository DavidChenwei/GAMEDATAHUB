using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class LOLController : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            ViewData["GameName"] = "Leage Of Lengend";
            return View();
        }
    }
}