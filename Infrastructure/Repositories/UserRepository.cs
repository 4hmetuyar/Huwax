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
        UserModel GetUsersModelByUserNameAndPassword(string userName, string password);
        bool CheckTheUserNameByUserName(string userName);

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

        public UserModel GetUsersModelByUserNameAndPassword(string userName, string password)
        {
            var model = (from user in DataContext.User
                         where user.UserName == userName && user.Password == password && user.IsDeleted == false
                         select new UserModel
                         {
                             Avatar = user.Avatar,
                              CreatedById = user.CreatedById,
                              Email = user.Email,
                             IsDeleted = user.IsDeleted,
                             LastName = user.LastName,
                             ModifiedById = user.ModifiedById,
                             ModifiedDate = user.ModifiedDate,
                             Name = user.Name,
                             Password = user.Password,
                             Phone = user.Phone,
                              UserId = user.UserId,
                             UserName = user.UserName,
                          }).FirstOrDefault();
            return model;
        }

        public bool CheckTheUserNameByUserName(string userName)
        {
            try
            {
                var model = (from u in DataContext.User
                             where u.UserName == userName && u.IsDeleted == false
                             select u).FirstOrDefault();
                if (model != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
