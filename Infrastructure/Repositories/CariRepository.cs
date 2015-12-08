using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;
using Infrastructure.Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{


    public interface ICariRepository : IGenericRepository<Cari>
    {
        Cari AddNewCariByCariModel(CariModel model);
        List<CariModel> GetAllCariList();
    }

    public class CariRepository : GenericRepository<Cari>, ICariRepository
    {
        public CariRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Cari AddNewCariByCariModel(CariModel model)
        {
            try
            {
                var add = new Cari
                {
                    IsDeleted = false,
                    Address = model.Address,
                    CreatedById = model.CreatedById,
                    CreatedDate = model.CreatedDate,
                    Email = model.Email,
                    Company = model.Company,
                    TCNo = model.TCNo,
                    Phone = model.Phone,
                    Title = model.Title,
                    TaxOffice = model.TaxOffice,
                    TaxNumber = model.TaxNumber,
                    Province = model.Province,
                    District = model.District
                };
                Add(add);
                Commit();
                return add;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CariModel> GetAllCariList()
        {
            var model = (from cari in DataContext.Cari
                         select new CariModel
                         {
                             CreatedDate = cari.CreatedDate,
                            Address = cari.Address,
                            Company = cari.Company,
                            District = cari.District,
                            Email = cari.Email,
                            Phone = cari.Phone,
                            Province = cari.Province,
                            TCNo = cari.TCNo,
                            TaxNumber = cari.TaxNumber,
                            TaxOffice = cari.TaxOffice,
                            Title = cari.Title,
                            CreatedById = cari.CreatedById,
                            CariId = cari.CariId
                            
                         }).ToList();
            return model;
        }
    }
}
