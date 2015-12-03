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
 

    public interface IPersonnelRepository : IGenericRepository<Personnel>
    {
    }

    public class PersonnelRepository : GenericRepository<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
