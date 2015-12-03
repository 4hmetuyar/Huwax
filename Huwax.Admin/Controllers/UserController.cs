using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Huwax.Common;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Huwax.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserController(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult AddUser()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult UserList()
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");

                var user = _userRepository.GetAllUserList();
                return View(user);

            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public ActionResult UserProfile()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserModel usersModel, HttpPostedFileBase files)
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");
                var sessionUser = (UserModel)Session["User"];
                if (usersModel != null)
                {
                    if (_userRepository.CheckTheUserNameByUserName(usersModel.UserName))
                    {
                        ModelState.AddModelError("", "Kullanıcı adı kullanılıyor!");
                        return View("AddUser", usersModel);
                    }

                    if (usersModel.Password != usersModel.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Sifreler Aynı Değil!");
                        return View("AddUser", usersModel);
                    }

                    var model = new UserModel
                    {
                        UserName = usersModel.UserName,
                        Password = usersModel.Password,
                        Name = usersModel.Name,
                        LastName = usersModel.LastName,
                        Email = usersModel.Email,
                        IsDeleted = false,
                        Phone = usersModel.Phone,
                        CreatedById = sessionUser.UserId
                    };
                    var user = _userRepository.AddNewUserByUserModel(model);
                    if ((files != null) && (files.ContentLength > 0) && !string.IsNullOrEmpty(files.FileName) &&
                        (files.ContentType == "image/jpeg" || files.ContentType == "image/png"))
                    {
                        using (System.Drawing.Image img = System.Drawing.Image.FromStream(files.InputStream))
                        {
                            byte[] file = new byte[files.InputStream.Length];
                            var reader = new BinaryReader(files.InputStream);
                            files.InputStream.Seek(0, SeekOrigin.Begin);
                            file = reader.ReadBytes((int)files.InputStream.Length);
                            if (user != null)
                            {
                                var updateUser = _userRepository.GetById(user.UserId);
                                updateUser.Avatar = file;
                                _userRepository.Update(updateUser);
                                _userRepository.Commit();
                            }
                        }
                    }
                }
                return RedirectToAction("UserList", "User");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult UserProfileEdit(int userId)
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            try
            {
                var user = _userRepository.GetById(userId);
                if (user != null)
                {
                    var model = new UserModel
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        LastName = user.LastName,
                        Name = user.Name,
                        Avatar = user.Avatar,
                        Phone = user.Phone,
                        CreatedById = user.CreatedById,

                    };
                    return View(model);

                }
                return RedirectToAction("UserList", "User");

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}