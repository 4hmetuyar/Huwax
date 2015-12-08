using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Huwax.Common;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Huwax.Admin.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IUnitOfWork unitOfWork, 
            IVehicleRepository vehicleRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
        }
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
                if (vehicleModel != null)
                {
                    var user = (UserModel)Session["User"];
                     var enterprice = vehicleModel.CustumerType != (int)Enums.Enterprice.Bireysel;
                    var model = new VehicleModel
                    {
                        CreatedById = user.UserId,
                        CreatedDate = DateTime.Now,
                        Enterprice = enterprice,
                        Description = vehicleModel.Description,
                        IsDeleted = false,
                        Model = vehicleModel.Model,
                        VehicleName = vehicleModel.VehicleName,
                        VehiclePlate = vehicleModel.VehiclePlate
            
                    };
                    var add = _vehicleRepository.AddNewVehicleByVehicleModel(model);
                    if (add!=null)
                    {
                        return RedirectToAction("VehicleList", "Vehicle");
                    }
                }
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