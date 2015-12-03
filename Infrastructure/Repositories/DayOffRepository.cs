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
 

    public interface IDayOffRepository : IGenericRepository<DayOff>
    {
    }

    public class DayOffRepository : GenericRepository<DayOff>, IDayOffRepository
    {
        public DayOffRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
