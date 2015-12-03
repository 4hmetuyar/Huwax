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
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public AccountController(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Login(UserModel usersModel)
        {
            try
            {
                if (usersModel != null)
                {
                    var user = _userRepository.GetUsersModelByUserNameAndPassword(usersModel.UserName,
                        usersModel.Password);
                    if (user != null)
                    {
                        Session["User"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı yada sifre yanlış!");
                        return View();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}