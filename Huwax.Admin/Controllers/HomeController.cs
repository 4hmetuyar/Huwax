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

        public HomeController(IUnitOfWork unitOfWork, 
            IVehicleRepository vehicleRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
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
    }
}