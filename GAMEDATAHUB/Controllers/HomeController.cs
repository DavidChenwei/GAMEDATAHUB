using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GAMEDATAHUB.Repository;

namespace GAMEDATAHUB.Controllers
{
    public class HomeController : Controller
    {
        Repository.Repository Resp = new Repository.Repository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewData["GameName"] = "Mobile App";

            return View();
        }
    }
}