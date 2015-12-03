using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;
using Infrastructure.Infrastructure;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
 

    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
    }

    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
