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
        List<CarWashModel> GetAllCarWashModelList();
        int TotalCarWashCount();
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

        public List<CarWashModel> GetAllCarWashModelList()
        {
            try
            {
                return (from car in DataContext.Vehicle
                    join carWash in DataContext.CarWash on car.VehicleId equals carWash.VehicleId
                        where carWash.IsDeleted==false && car.IsDeleted==false
                    select new CarWashModel
                    {
                        VehiclePlate = car.VehiclePlate,
                        Date = carWash.Date,
                        Description = carWash.Description,
                        Total = carWash.Total,
                        VehicleId = carWash.VehicleId,
                        CarWashId = carWash.CarWashId,
                        VehicleName = car.VehicleName,
                        
                    }
                    ).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int TotalCarWashCount()
        {
            return (from carWash in DataContext.CarWash where carWash.IsDeleted == false select carWash).Count();
        }
    }
}
