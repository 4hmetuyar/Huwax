using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Huwax.Admin.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult AddVehicle()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }
          [HttpPost]
        public ActionResult AddVehicle(VehicleModel vehicleModel)
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

        public ActionResult VehicleList()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }
    }
}