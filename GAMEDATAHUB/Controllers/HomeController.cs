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
        public async Task<ActionResult> Index()
        {
            string name = "MarineChen";
            string platform = "PC";
            //Resp.dbtest();
            await Resp.HeroInfoGet(name, platform);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}