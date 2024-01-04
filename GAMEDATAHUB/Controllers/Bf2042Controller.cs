using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMEDATAHUB.Repository;
using GAMEDATAHUB.Models.BF2042Model;
using System.Threading.Tasks;

namespace GAMEDATAHUB.Controllers
{
    public class Bf2042Controller : Controller
    {
        Repository.Repository Resp = new Repository.Repository();

        [HttpGet]
        public ActionResult Overview()
        {

            return View("~/Views/Bf2042/Overview.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Overview(string HeroName, string Platform)
        {
            ViewBag.ShowLoading = true; 

            if (!string.IsNullOrEmpty(Platform))
            {
                if (Platform.Contains("PlayStation"))
                {
                    Platform = "ps4";
                }
                else if (Platform.Contains("Xboxone"))
                {
                    Platform = "xboxone";
                }
                else if (Platform.Contains("Origin"))
                {
                    Platform = "pc";
                }
            }
            else {
                Platform = "pc";
            }
            OverviewModel Overview = await Resp.HeroInfoGet(HeroName, Platform);

            ViewBag.ShowLoading = false;
            return View(Overview);
        }
        [HttpGet]
        public ActionResult Bf2042()
        {
            ViewBag.ShowLoading = false;
            return View();
        }

        [HttpGet]
        public ActionResult AnimationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnimationPage(string HeroName, string Platform, string Target)
        {
            Animation animation = new Animation();
            animation.HeroName = HeroName;
            animation.Platform = Platform;
            animation.TargetPage = Target;
            return View(animation);
        }

        [HttpGet]
        public ActionResult Maps()
        {

            return View();
        }
    }
}
