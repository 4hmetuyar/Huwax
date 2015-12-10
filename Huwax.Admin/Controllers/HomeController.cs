using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Huwax.Admin.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICarWashRepository _carWashRepository;

        public HomeController(IUnitOfWork unitOfWork, 
            IVehicleRepository vehicleRepository,
            ICarWashRepository carWashRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _carWashRepository = carWashRepository;
            _vehicleRepository = vehicleRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult _TotalVehicle()
        {
            try
            {
                var model =new ReportModel
                {
                    TotolVehicle = _vehicleRepository.TotalVehicleCount(),
                };
                return PartialView(model);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult _TotalCarWash()
        {
            try
            {
                var model = new ReportModel
                {
                    TotalCarWash = _carWashRepository.TotalCarWashCount(),
                };
                return PartialView(model);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}