using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
   public class CariModel
    {
        public int CariId { get; set; }
        public string TCNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
