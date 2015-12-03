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
  
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
    }

    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
