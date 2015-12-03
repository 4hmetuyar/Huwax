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


    public interface ICariOperationRepository : IGenericRepository<CariOperation>
    {
        CariOperation AddNewCariOperationByCariOperationModel(CariOperationModel model);
    }

    public class CariOperationRepository : GenericRepository<CariOperation>, ICariOperationRepository
    {
        public CariOperationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public CariOperation AddNewCariOperationByCariOperationModel(CariOperationModel model)
        {
            try
            {
                var add = new CariOperation
                {
                    CariId = model.CariId,
                    CreatedById = model.CreatedById,
                    CreatedDate = model.CreatedDate,
                    Date = model.Date,
                    Description = model.Description,
                    IsDeleted = false,
                    Status = model.Status,
                    Total = model.Total

                };
                return add;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
