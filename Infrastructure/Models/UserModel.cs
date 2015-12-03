using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Avatar { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public Nullable<System.Guid> ActivationGuid { get; set; }
        public Nullable<int> BayiId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CretedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
