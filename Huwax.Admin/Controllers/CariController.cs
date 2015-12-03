using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Huwax.Admin.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult CariAdd()
        {
            return View();
        }

        public ActionResult CariList()
        {
            return View();
        }
    }
}