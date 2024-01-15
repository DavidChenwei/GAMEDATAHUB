using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GAMEDATAHUB.Repository;
using GAMEDATAHUB.Models;
using System.Runtime.Caching;

namespace GAMEDATAHUB.Controllers
{
    public class HomeController : Controller
    {
        Repository.Repository Resp = new Repository.Repository();
        private MemoryCache cache = MemoryCache.Default;
        [HttpGet]
        public ActionResult Index()
        {
            UserModel userModel = new UserModel();
            if (cache.Contains("Login"))
            {
                userModel = (UserModel)cache.Get("Login");
                ViewBag.AccountName = userModel.UserName;
            }
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            UserModel userModel = new UserModel();
            if (cache.Contains("Login"))
            {
                userModel = (UserModel)cache.Get("Login");
                
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            ViewBag.ReturnUrl = userModel.Redirection;

            ResponseModel response = new ResponseModel();
            if (ModelState.IsValid) {
                ModelState.Clear();
                if (!userModel.IsLogin)
                {
                    string salt;
                    string hashedPassword = EncryptionService.Encrypt(userModel.UserPassword, out salt);
                    //bool isPasswordValid = EncryptionService.Decrypt(Password,salt,hashedPassword);
                    response = Resp.Register(userModel.UserName, userModel.UserEmail, hashedPassword, salt);
                    userModel.ErrorMessage = response.ReturnText;
                    if (response.IsValid)
                    {
                        cache.Add("Login", userModel, DateTimeOffset.UtcNow.AddMinutes(360));
                        string controllerName;
                        string actionName;
                        string heroName;
                        string platForm;

                        string res = Resp.UrlParse(userModel.Redirection, out controllerName, out actionName, out heroName, out platForm);
                        ViewBag.AccountName = heroName;
                        RedirectToAction(actionName, controllerName, new { HeroName = heroName, PlatForm = platForm });
                    }
                    else
                    {
                        userModel.ErrorMessage = response.ReturnText;
                    }
                }

                if (userModel.IsLogin) {
                    userModel = Resp.Login(userModel.UserEmail, userModel.UserPassword);
                    bool isPasswordValid = EncryptionService.Decrypt(userModel.UserPassword, userModel.UserSalt, userModel.HashedPassword);
                    if (isPasswordValid)
                    {
                        string controllerName;
                        string actionName;
                        string heroName;
                        string platForm;
                        ViewBag.AccountName = userModel.UserName;
                        cache.Add("Login", userModel, DateTimeOffset.UtcNow.AddMinutes(360));
                        if (ViewBag.ReturnUrl == "/") {
                            return RedirectToAction("Index", "Home");
                        }
                        else {
                            string res = Resp.UrlParse(ViewBag.ReturnUrl, out controllerName, out actionName, out heroName, out platForm);
                            return RedirectToAction(actionName, controllerName, new { HeroName = heroName, PlatForm = platForm, AccountName = userModel.UserName });
                        }

                    }
                    else {
                        userModel.ErrorMessage = "Password is invalid";
                    }
                }

            }

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