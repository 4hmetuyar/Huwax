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
                    Enterprice = model.Enterprice


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
