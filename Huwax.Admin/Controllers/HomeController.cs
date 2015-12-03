using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Huwax.Admin.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public HomeController(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");
            return View();
        }
    }
}