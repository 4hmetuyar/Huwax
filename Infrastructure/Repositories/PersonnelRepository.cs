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
 

    public interface IPersonnelRepository : IGenericRepository<Personnel>
    {
        Personnel AddNewPersonnelByPersonnelModel(PersonnelModel model);
    }

    public class PersonnelRepository : GenericRepository<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Personnel AddNewPersonnelByPersonnelModel(PersonnelModel model)
        {
            try
            {
                var add = new Personnel
                {
                    IsDeleted = false,
                    CreatedDate = model.CreatedDate,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    Phone = model.Phone,
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
