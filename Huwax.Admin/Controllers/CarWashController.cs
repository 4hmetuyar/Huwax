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

        public CarWashController(IUnitOfWork unitOfWork, 
            ICarWashRepository carWashRepository,
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _carWashRepository = carWashRepository;
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

                return View();

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
                var vehicle=
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}