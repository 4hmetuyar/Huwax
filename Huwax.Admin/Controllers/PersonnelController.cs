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
    public class PersonnelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly ISalaryRepository _salaryRepository;

        public PersonnelController(IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IPersonnelRepository personnelRepository,
            ISalaryRepository salaryRepository)
        {
            _unitOfWork = unitOfWork;
            _personnelRepository = personnelRepository;
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
        }
        // GET: Personnel
        public ActionResult Index()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult AddPersonnel()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            return View();
        }
        [HttpPost]
        public ActionResult AddPersonnel(PersonnelModel model)
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");
                var user = (UserModel) Session["User"];
                if (model!=null)
                {
                    var add = new PersonnelModel
                    {
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                        CreatedById = user.UserId,
                        Email = model.Email,
                        LastName = model.LastName,
                        Name = model.Name,
                        Phone = model.Phone,
                        
                    };
                    var personnel = _personnelRepository.AddNewPersonnelByPersonnelModel(model);
                    if (personnel!=null)
                    {
                        var salary = new SalaryModel
                        {
                            IsDeleted = false,
                            CreatedDate = DateTime.Now,
                            CreatedById = user.UserId,
                            Description = model.Description,
                            Total = model.Total,
                            PersonnelId = personnel.PersonnelId,
                            
                        };
                        var salaryAdd = _salaryRepository.AddNewSalaryBySalaryModel(salary);
                    }
                }


                return RedirectToAction("PersonnelList","Personnel");
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public ActionResult PersonnelList()
        {
            try
            {
                if (Session["User"] == null) return RedirectToAction("Login", "Account");
                var personnel = _personnelRepository.GetAllPersonnel();

                return View(personnel);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
}