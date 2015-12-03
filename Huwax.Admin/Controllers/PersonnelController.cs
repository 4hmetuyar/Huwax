using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Models;

namespace Huwax.Admin.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult AddPersonnel()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }
        [HttpPost]
        public ActionResult AddPersonnel(PersonnelModel model)
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult PersonnelList()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }
    }
}