using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
   public class CariOperationModel
    {
        public int CariOperationId { get; set; }
        public Nullable<int> CariId { get; set; }
        public Nullable<int> Total { get; set; }
        public string Description { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
    }
}
