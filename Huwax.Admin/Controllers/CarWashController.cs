using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Huwax.Admin.Controllers
{
    public class CarWashController : Controller
    {
        // GET: CarWash
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult CarWashList()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult AddCarWash()
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");

                return View();

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}