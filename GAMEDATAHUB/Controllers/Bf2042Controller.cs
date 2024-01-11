﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMEDATAHUB.Repository;
using GAMEDATAHUB.Models.BF2042Model;
using GAMEDATAHUB.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GAMEDATAHUB.Controllers
{
    public class Bf2042Controller : Controller
    {
        Repository.Repository Resp = new Repository.Repository();

        [HttpGet]
        public ActionResult Overview(string HeroName, string Platform)
        {

            OverviewModel overviewModel = Resp.OverviewInfoGet(HeroName, Platform);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = Platform;
            ViewData["Avatar"] = overviewModel.Avatar;
            ViewData["Page"] = "Overview";
            return View(overviewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Overview(string HeroName, string Platform, string login)
        {

            if (!string.IsNullOrEmpty(Platform))
            {
                if (Platform.Contains("PlayStation"))
                {
                    Platform = "ps4";
                }
                else if (Platform.Contains("Xbox"))
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
            Overview.isValid = true;
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = Platform;
            ViewData["Avatar"] = Overview.Avatar;
            ViewBag.ShowLoading = false;
            ViewData["Page"] = "Overview";
            if (Overview.isValid)
            {
                //Resp.StoreDataAsync(HeroName);
                return View(Overview);
            }
            else {
                return RedirectToAction("AnimationPage", new { isValid = Overview.isValid, name = HeroName, plat = Platform });;
            }

        }

        [HttpGet]
        public ActionResult Bf2042()
        {
            ViewBag.ShowLoading = false;
            return View();
        }

        [HttpGet]
        public ActionResult AnimationPage(bool isValid, string name, string plat)
        {
            Animation animation = new Animation();
            animation.isValid = isValid;
            animation.HeroName = name;
            animation.Platform = plat;
            return View(animation);
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
        public ActionResult Maps(string HeroName, string PlatForm)
        {
            MapModeView mapModeView = Resp.MapsInfoGet(HeroName, PlatForm);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = mapModeView.Avatar;
            ViewData["Page"] = "Maps";
            return View(mapModeView);
        }

        [HttpPost]
        public JsonResult MapsUpdate(ModeJson modeJson)
        {
            MapModeView mapModeView = Resp.MapsInfoUpdate(modeJson.SortMethod, modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(mapModeView);
            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public ActionResult Modes(string HeroName, string PlatForm)
        {

            GameModeView GameModes = Resp.GameModeInfoGet(Utils.DescMethods, Utils.HeaderWin, HeroName, PlatForm);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = GameModes.Avatar;
            ViewData["Page"] = "Modes";
            return View(GameModes);
        }

        [HttpPost]
        public JsonResult ModesUpdate(ModeJson modeJson) {


            GameModeView GameModes = Resp.GameModeInfoUpdate(modeJson.SortMethod,modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(GameModes);

            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Specialists(string HeroName, string PlatForm)
        {
            SpecialistModelView specialistModelView = Resp.SpecialistInfoGet(HeroName, PlatForm, Utils.DescMethods, Utils.HeaderKill);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = specialistModelView.Avatar;
            ViewData["Page"] = "Specialists";
            return View(specialistModelView);
        }

        [HttpPost]
        public JsonResult SpecialistsUpdate(ModeJson modeJson)
        {
            SpecialistModelView specialistModelView = Resp.SpecialistInfoUpdate(modeJson.SortMethod, modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(specialistModelView);
            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Vehicles(string HeroName, string PlatForm)
        {

            VehicleModelView vehicleModelView = Resp.VehiclesInfoGet(HeroName, PlatForm);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = vehicleModelView.Avatar;
            ViewData["Page"] = "Vehicles";
            return View(vehicleModelView);
        }

        [HttpPost]
        public JsonResult VehiclesUpdate(ModeJson modeJson)
        {
            VehicleModelView vehicleModelView = Resp.VehiclesInfoUpdate(modeJson.SortMethod, modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(vehicleModelView);
            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Weapons(string HeroName, string PlatForm)
        {

            string SortMethod = "DESC";
            string HeaderIndex = "header1";
            WeaponModelView weaponModelView = Resp.WeaponInfoGet(HeroName, PlatForm, SortMethod, HeaderIndex);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = weaponModelView.Avatar;
            ViewData["Page"] = "Weapons";
            return View(weaponModelView);
        }

        [HttpPost]
        public JsonResult WeaponsUpdate(ModeJson modeJson)
        {
            WeaponModelView weaponModelView = Resp.WeaponInfoUpdate(modeJson.SortMethod, modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(weaponModelView);
            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Gadgets(string HeroName, string PlatForm)
        {

            GadgetModelView gadgetModelView = Resp.GadgetInfoGet(HeroName, PlatForm);
            ViewData["HeroName"] = HeroName;
            ViewData["PlatForm"] = PlatForm;
            ViewData["Avatar"] = gadgetModelView.Avatar;
            ViewData["Page"] = "Gadgets";
            return View(gadgetModelView);
        }

        [HttpPost]
        public JsonResult GadgetsUpdate(ModeJson modeJson)
        {
            GadgetModelView gadgetModelView = Resp.GadgetInfoUpdate(modeJson.SortMethod, modeJson.HeaderName, modeJson.HeroName, modeJson.PlatForm);
            var JsonPayLoad = JsonConvert.SerializeObject(gadgetModelView);
            return Json(JsonPayLoad, JsonRequestBehavior.AllowGet);
        }

    }
}
