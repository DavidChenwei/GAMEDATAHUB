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
        public ActionResult Index()
        {
            UserModel userModel = new UserModel();
            if (cache.Contains("Login"))
            {
                userModel = (UserModel)cache.Get("Login");
            }
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";
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
            if (ModelState.IsValid) {
                ModelState.Clear();
                if (!userModel.IsLogin)
                {
                    string salt;
                    string hashedPassword = EncryptionService.Encrypt(userModel.UserPassword, out salt);
                    //bool isPasswordValid = EncryptionService.Decrypt(Password,salt,hashedPassword);
                    ResponseModel response = Resp.Register(userModel.UserName, userModel.UserEmail, hashedPassword, salt);

                    if (response.IsValid)
                    {
                        cache.Add("Login", userModel, DateTimeOffset.UtcNow.AddMinutes(360));
                        return RedirectToAction("Index", new { UserModel = userModel });
                    }
                }
                else { 
                    
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