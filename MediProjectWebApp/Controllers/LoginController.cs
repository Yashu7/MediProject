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
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                IUserDaoService userDaoService = new UserDAOService();
                var queryStatus = userDaoService.LoginUser(model);
                if (queryStatus == QueryStatus.Success)
                {
                    Session["User"] = model.Username;
                    return Json(new { success = true, message = "OK" });
                }
            }

            return Json(new { success = false, message = "Please enter valid login credentials." });
        }
    }
}