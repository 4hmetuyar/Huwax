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
  
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
        Salary AddNewSalaryBySalaryModel(SalaryModel model);
    }

    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Salary AddNewSalaryBySalaryModel(SalaryModel model)
        {
            try
            {
                var add = new Salary
                {
                    IsDeleted = false,
                    CreatedDate = model.CreatedDate,
                    CreatedById = model.CreatedById,
                    Total = model.Total,
                    Description = model.Description,
                    PersonnelId = model.PersonnelId,
                    
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
