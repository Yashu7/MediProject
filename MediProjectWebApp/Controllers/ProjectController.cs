using MediProjectWebApp.Models;
using MediProjectWebApp.Services;
using MediProjectWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediProjectWebApp.Controllers
{
    public class ProjectController : Controller
    {
        IProjectDaoService userDaoService;
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            userDaoService = new ProjectDaoService();
            return View(userDaoService.ReadAllProjects());
        }
        [HttpPost]
        public JsonResult AddProject(Project project)
        {
            if (ModelState.IsValid)
            {
                userDaoService = new ProjectDaoService();
                var queryStatus = userDaoService.CreateProject(project);

                return Json(project);
            }
            return Json(new { success = false, message = "Unable to save project." });
        }
    }
}