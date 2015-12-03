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


    public interface ICariOperationRepository : IGenericRepository<CariOperation>
    {

     }

    public class CariOperationRepository : GenericRepository<CariOperation>, ICariOperationRepository
    {
        public CariOperationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
