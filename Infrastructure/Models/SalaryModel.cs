﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
 public   class SalaryModel
    {
        public int SalaryId { get; set; }
        public Nullable<int> PersonnelId { get; set; }
        public Nullable<int> Total { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
