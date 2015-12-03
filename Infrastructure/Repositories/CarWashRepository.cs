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
 

    public interface ICarWashRepository : IGenericRepository<CarWash>
    {
    }

    public class CarWashRepository : GenericRepository<CarWash>, ICarWashRepository
    {
        public CarWashRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
