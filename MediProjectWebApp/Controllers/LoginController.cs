using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models.Accounts;
using MediProjectWebApp.Services;
using MediProjectWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MediProjectWebApp.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = BlowfishHelper.EncryptBlowfish(model.Password, "12345678abcdefgmypassword");
                IUserDaoService userDaoService = new UserDAOService();
                var queryStatus = userDaoService.LoginUser(model);
                if (queryStatus == QueryStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Login");
                }
            }

            return Json(new { success = false, message = "Please enter valid login credentials." });
        }
    }
}