using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
   public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Gear { get; set; }
        public string Fuel { get; set; }
        public string Km { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
    }
}
