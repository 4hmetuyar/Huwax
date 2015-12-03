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


    public interface ICariRepository : IGenericRepository<Cari>
    {
    }

    public class CariRepository : GenericRepository<Cari>, ICariRepository
    {
        public CariRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
