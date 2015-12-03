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
                    Adres = model.Adres,
                    CreatedById = model.CreatedById,
                    CreatedDate = model.CreatedDate,
                    Fax = model.Fax,
                    Firma = model.Firma,
                    TCNo = model.TCNo,
                    Tel = model.Tel,
                    Unvan = model.Unvan,
                    VergiDairesi = model.VergiDairesi,
                    VergiNo = model.VergiNo,
                    İl = model.İl,
                    İlce = model.İlce
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
    }
}
