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
 

    public interface ICarWashRepository : IGenericRepository<CarWash>
    {
        CarWash AddNewCarWashByCarWashModel(CarWashModel model);
    }

    public class CarWashRepository : GenericRepository<CarWash>, ICarWashRepository
    {
        public CarWashRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public CarWash AddNewCarWashByCarWashModel(CarWashModel model)
        {
            try
            {
                var add = new CarWash
                {
                    IsDeleted = false,
                    CreatedById = model.CreatedById,
                    Total = model.Total,
                    CreatedDate = model.CreatedDate,
                    Date = model.Date,
                    Description = model.Description,
                    VehicleId = model.VehicleId,


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
