using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMEDATAHUB.Controllers
{
    public class Bf2042Controller : Controller
    {
        [HttpGet]
        public ActionResult Overview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Overview(string name)
        {
            string temp = name;
            return View();
        }
        [HttpGet]
        public ActionResult Bf2042()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bf2042(string HeroName)
        {
            string temp = HeroName;
            return View();
        }
    }
}
