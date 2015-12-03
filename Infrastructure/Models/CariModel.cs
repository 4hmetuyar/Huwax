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
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Firma { get; set; }
        public string Unvan { get; set; }
        public string İl { get; set; }
        public string İlce { get; set; }
        public string Adres { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
