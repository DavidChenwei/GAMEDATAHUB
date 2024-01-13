using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GAMEDATAHUB.Repository;
using GAMEDATAHUB.Models;

namespace GAMEDATAHUB.Controllers
{
    public class HomeController : Controller
    {
        Repository.Repository Resp = new Repository.Repository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ModelState.AddModelError("", "error");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string Email)
        {
            string salt;
            string hashedPassword = EncryptionService.Encrypt(Password, out salt);
            //bool isPasswordValid = EncryptionService.Decrypt(Password,salt,hashedPassword);
            ResponseModel response = Resp.Register(UserName, Email, hashedPassword, salt);
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