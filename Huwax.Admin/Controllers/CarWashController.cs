using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Huwax.Admin.Controllers
{
    public class CarWashController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICarWashRepository _carWashRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public CarWashController(IUnitOfWork unitOfWork, 
            IVehicleRepository vehicleRepository,
            ICarWashRepository carWashRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _carWashRepository = carWashRepository;
            _vehicleRepository = vehicleRepository;
        }
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
                var model = _carWashRepository.GetAllCarWashModelList();
                return View(model);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        [HttpPost]
        public ActionResult AddCarWash(CarWashModel carWashModel)
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");
                var vehicle = _vehicleRepository.GetVehicleByVehiclePlate(carWashModel.VehiclePlate);
                if (vehicle!=null)
                {
                    var user = (UserModel) Session["User"];
                    var model = new CarWashModel
                    {
                        VehiclePlate = carWashModel.VehiclePlate,
                        CreatedById = user.UserId,
                        CreatedDate = DateTime.Now,
                        Date = DateTime.Now,
                        Description = carWashModel.Description,
                        IsDeleted = false,
                        Total = carWashModel.Total,
                       VehicleId = vehicle.VehicleId,
                       
                    };
                    var add = _carWashRepository.AddNewCarWashByCarWashModel(model);
                    if (add!=null)
                    {
                        return RedirectToAction("CarWashList", "CarWash");
                    }
                }
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}