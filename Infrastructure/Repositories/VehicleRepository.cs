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


    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Vehicle AddNewVehicleByVehicleModel(VehicleModel model);
        List<VehicleModel> GetAllVehicleList();
        int TotalVehicleCount();
    }

    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Vehicle AddNewVehicleByVehicleModel(VehicleModel model)
        {
            try
            {
                var add = new Vehicle
                {
                    IsDeleted = false,
                    CreatedDate = model.CreatedDate,
                    CreatedById = model.CreatedById,
                    Description = model.Description,
                    Model = model.Model,
                    VehicleName = model.VehicleName,
                    VehiclePlate = model.VehiclePlate,
                    Enterprice = model.Enterprice,
                    VehicleTypeId = model.VehicleType,
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

        public List<VehicleModel> GetAllVehicleList()
        {
            var model = (from vehicle in DataContext.Vehicle
                where vehicle.IsDeleted == false
                select new VehicleModel
                {
                    VehiclePlate = vehicle.VehiclePlate,
                    Model = vehicle.Model,
                    VehicleName = vehicle.VehicleName,
                    Description = vehicle.Description,
                    Enterprice = vehicle.Enterprice ?? false,
                    CreatedById = vehicle.CreatedById,
                    CreatedDate = vehicle.CreatedDate,
                    VehicleId = vehicle.VehicleId,
                    VehicleType = vehicle.VehicleTypeId??1,

                }
                ).ToList();
            return model;
        }

        public int TotalVehicleCount()
        {
            return (from vehicle in DataContext.Vehicle where vehicle.IsDeleted == false select vehicle).Count();
        }
    }
}
