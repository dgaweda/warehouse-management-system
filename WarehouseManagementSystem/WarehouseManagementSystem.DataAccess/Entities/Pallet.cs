using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Pallet : EntityBase
    {
        public int Barcode { get; set; }
        public int OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? DeliveryId { get; set; }
        public int? EmployeeId { get; set; }

        public Departure Departure { get; set; }
        public Delivery Delivery { get; set; }
        public List<DeliveryProduct> DeliveryProducts { get; set; }

    }
}
