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
        [HttpPost]
        public ActionResult CariAdd(CariModel cariModel)
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");
                if (cariModel!=null)
                {
                    var user = (UserModel) Session["User"];
                    var model = new CariModel
                    {
                        Email = cariModel.Email,
                        CreatedDate = DateTime.Now,
                        CreatedById = user.UserId,
                        IsDeleted = false,
                        Address = cariModel.Address,
                        Company = cariModel.Company,
                        District = cariModel.District,
                        Phone = cariModel.Phone,
                        Province = cariModel.Province,
                        TCNo = cariModel.TCNo,
                        TaxNumber = cariModel.TaxNumber,
                        TaxOffice = cariModel.TaxOffice,
                        Title = cariModel.Title,

                    };

                    var add = _cariRepository.AddNewCariByCariModel(model);
                    if (add!=null)
                    {
                        return RedirectToAction("CariList", "Cari");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
            
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