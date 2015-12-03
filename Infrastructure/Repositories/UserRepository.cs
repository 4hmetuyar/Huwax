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
    public interface IUserRepository : IGenericRepository<User>
    {
        User AddNewUserByUserModel(UserModel model);
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public User AddNewUserByUserModel(UserModel model)
        {
            try
            {
                var add = new User
                {
                    CreatedDate = model.CretedDate,
                    IsDeleted = false,
                    CreatedById = model.CreatedById,
                    Avatar = model.Avatar,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    Password = model.Password,
                    Phone = model.Phone,
                    UserName = model.UserName,
                    
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
