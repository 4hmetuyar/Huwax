using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Huwax.Admin.Controllers
{
    public class CariController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICariRepository _cariRepository;

        public CariController(IUnitOfWork unitOfWork, 
            IUserRepository userRepository,
            ICariRepository cariRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _cariRepository = cariRepository;
        }
        // GET: Cari
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult CariAdd()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult CariList()
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");

                var cariList = _cariRepository.GetAllCariList();
                return View(cariList);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}